using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NHunspell;

namespace LightFarsiDictionary
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			WarmUpTheDatabase();
			InitializeComponent();
			_spellFa = new Hunspell();
			_spellEn = new Hunspell();

		}

		const string ConnectionStringEnFa = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dicenfa.db;Persist Security Info=True;Mode=Read";

		#region variables

		private SpeechSynthesizer _speech;
		private Prompt _speechPrompt;
		private Hunspell _spellFa;
		private Hunspell _spellEn;
		private bool _spellCheckLoaded = false;
		private bool _changingDirection = false;
		#endregion

		#region private methods
		/// <summary>
		/// 
		/// </summary>
		static void WarmUpTheDatabase()
		{
			Thread warmUp;
			warmUp = new Thread(() =>
			{
				try
				{
					using (var conn = new OleDbConnection(ConnectionStringEnFa))
					{
						conn.Open();
					}
				}
				catch { }
			});
			warmUp.IsBackground = true;
			warmUp.Name = "WarmUp-OleDb";
			warmUp.Start();
		}

		/// <summary>
		/// 
		/// </summary>
		void InitSpellCheck()
		{
			Thread warmUp;
			warmUp = new Thread(() =>
			{
				try
				{
					_spellFa.Load("spelldic\\fa.aff", "spelldic\\fa.dic");
					_spellEn.Load("spelldic\\en_US.aff", "spelldic\\en_US.dic");
					_spellCheckLoaded = true;
				}
				catch { }
			});
			warmUp.IsBackground = true;
			warmUp.Name = "WarmUp-SpellCheck";
			warmUp.Start();
		}

		/// <summary>
		/// 
		/// </summary>
		void LoadTextFromClipboard()
		{
			if (Clipboard.ContainsText())
			{
				var text = Clipboard.GetText();
				var spaceIndex = text.IndexOf(" ");
				if (spaceIndex != -1)
				{
					text = text.Substring(0, spaceIndex);
				}
				if (text.Length <= 15)
				{
					txtWord.Text = text;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void ChangeTextBoxRtl(RightToLeft rtl)
		{
			if (txtWord.RightToLeft != rtl)
			{
				_changingDirection = true;
				try
				{
					txtWord.RightToLeft = rtl;
					txtWord.HideSuggestions();
				}
				finally
				{
					_changingDirection = false;
				}
			}
		}
		#endregion

		#region dictionary methods

		/// <summary>
		/// English -> Farsi
		/// </summary>
		string GetEnglishMeaning(OleDbConnection conn, string eng)
		{
			using (var cmd = new OleDbCommand())
			{
				string command = "SELECT  Farsi FROM EnglishToFarsi  WHERE  English = '" + eng + "'";
				cmd.Connection = conn;
				cmd.CommandText = command;

				object result = cmd.ExecuteScalar();
				if (result == null)
				{
					return string.Empty;
				}
				return result.ToString();
			}
		}

		/// <summary>
		/// Farsi -> English
		/// </summary>
		string GetFarsiMeaning(OleDbConnection conn, string fa)
		{
			using (var cmd = new OleDbCommand())
			{
				string command = "SELECT  English FROM FarsiToEnglish  WHERE  Farsi = '" + fa + "'";
				cmd.Connection = conn;
				cmd.CommandText = command;

				object result = cmd.ExecuteScalar();
				if (result == null)
				{
					return string.Empty;
				}
				return result.ToString();
			}
		}



		/// <summary>
		/// Display in the form
		/// </summary>
		private void ShowTheMeaning(string theWord, string theMeaning)
		{
			lblExactWord.Text = theWord;
			txtMeaning.Text = theMeaning;
		}

		/// <summary>
		/// 
		/// </summary>
		private void EnglishToFarsiMeaningRecrusive(string english)
		{
			if (_spellCheckLoaded)
			{
				var suggestList = _spellEn.Suggest(english);
				if (suggestList != null && suggestList.Count > 0)
				{
					txtWord.Items.Clear();
					txtWord.Items.AddRange(suggestList.ToArray());
					txtWord.ShowSuggestions();
				}
				else
				{
					txtWord.HideSuggestions();
					txtWord.Items.Clear();
				}
			}

			using (var conn = new OleDbConnection(ConnectionStringEnFa))
			{
				conn.Open();
				var engMeaning = GetEnglishMeaning(conn, english);
				if (!string.IsNullOrEmpty(engMeaning))
				{
					ShowTheMeaning(english, engMeaning);
				}
				else
				{
					// only if it is long enough
					if (english.Length <= 1)
						return;



					var word = english;
					int decreasePoint = 2;
					do
					{
						engMeaning = GetEnglishMeaningLikeEnd(conn, word, out word);
						if (!string.IsNullOrEmpty(engMeaning))
						{
							ShowTheMeaning(word, engMeaning);
							return;
						}
						if (word.Length > 2)
						{
							word = word.Remove(word.Length - 1, 1);
							decreasePoint--;
						}
						else
						{
							decreasePoint = -1;
						}

					} while (decreasePoint >= 0);


					word = english;
					decreasePoint = 2;
					do
					{
						engMeaning = GetEnglishMeaningLikeBegin(conn, word, out word);
						if (!string.IsNullOrEmpty(engMeaning))
						{
							ShowTheMeaning(word, engMeaning);
							return;
						}
						if (word.Length > 2)
						{
							word = word.Remove(0, 1);
							decreasePoint--;
						}
						else
						{
							decreasePoint = -1;
						}

					} while (decreasePoint >= 0);

				}
			}

		}

		/// <summary>
		/// 
		/// </summary>
		string GetEnglishMeaningLikeBegin(OleDbConnection conn, string eng, out string foundEnglishWord)
		{
			foundEnglishWord = eng;
			using (var cmd = new OleDbCommand())
			{
				string command = "SELECT  English,Farsi FROM EnglishToFarsi  WHERE  English LIKE '%" + eng + "'";
				cmd.Connection = conn;
				cmd.CommandText = command;

				using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
				{
					if (reader.Read())
					{
						foundEnglishWord = reader[0].ToString();
						return reader[1].ToString();
					}
					else
					{
						return string.Empty;
					}
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		string GetEnglishMeaningLikeEnd(OleDbConnection conn, string eng, out string foundEnglishWord)
		{
			foundEnglishWord = eng;
			using (var cmd = new OleDbCommand())
			{
				string command = "SELECT English,Farsi FROM EnglishToFarsi  WHERE  English LIKE '" + eng + "%'";
				cmd.Connection = conn;
				cmd.CommandText = command;

				using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
				{
					if (reader.Read())
					{
						foundEnglishWord = reader[0].ToString();
						return reader[1].ToString();
					}
					else
					{
						return string.Empty;
					}
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		void FarsiToEnglishMeaningRecrusive(string farsi)
		{
			if (_spellCheckLoaded)
			{
				var suggestList = _spellFa.Suggest(farsi);
				if (suggestList != null && suggestList.Count > 0)
				{
					txtWord.Items.Clear();
					txtWord.Items.AddRange(suggestList.ToArray());
					txtWord.ShowSuggestions();
				}
				else
				{
					txtWord.HideSuggestions();
					txtWord.Items.Clear();
				}
			}

			using (var conn = new OleDbConnection(ConnectionStringEnFa))
			{
				conn.Open();
				var english = GetFarsiMeaning(conn, farsi);
				if (!string.IsNullOrEmpty(english))
				{
					ShowTheMeaning(farsi, english);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		void SayWord()
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(txtWord.Text))
				{
					if (_speech == null)
						_speech = new SpeechSynthesizer();
					if (_speechPrompt != null)
					{
						_speech.SpeakAsyncCancel(_speechPrompt);
					}
					_speechPrompt = new Prompt(txtWord.Text);
					_speech.SpeakAsync(_speechPrompt);
				}
			}
			catch
			{
				MessageBox.Show("Failed to call Text to Speech engine.", "Text to Speech", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		bool HasPersianChar(string str)
		{
			foreach (char c in str)
			{
				int ic = (int)c;
				if (ic >= 1548 && ic <= 1648)
					return true;
			}
			return false;
		}


		/// <summary>
		/// Convert to persian chars
		/// </summary>
		string ConvertToPersianChars(string str)
		{
			if (string.IsNullOrEmpty(str)) return str;
			str = ReplaceStrEx(str, "ي", "ی", StringComparison.InvariantCulture);
			str = ReplaceStrEx(str, "ك", "ک", StringComparison.InvariantCulture);
			return str;
		}

		/// <summary>
		/// Convert to persian chars
		/// </summary>
		string ConvertToPartialArabicChars(string str)
		{
			if (string.IsNullOrEmpty(str)) return str;
			str = ReplaceStrEx(str, "ی", "ي", StringComparison.InvariantCulture);
			//str = ReplaceStrEx(str, "ک", "ك", StringComparison.InvariantCulture);
			return str;
		}

		/// <summary>
		/// Implements fast string replacing algorithm for CS
		/// </summary>
		string ReplaceStrEx(string original, string pattern, string replacement, StringComparison comparisonType)
		{
			if (original == null)
			{
				return null;
			}

			if (String.IsNullOrEmpty(pattern))
			{
				return original;
			}

			int lenPattern = pattern.Length;
			int idxPattern = -1;
			int idxLast = 0;

			var result = new StringBuilder();
			try
			{
				while (true)
				{
					idxPattern = original.IndexOf(pattern, idxPattern + 1, comparisonType);

					if (idxPattern < 0)
					{
						result.Append(original, idxLast, original.Length - idxLast);

						break;
					}

					result.Append(original, idxLast, idxPattern - idxLast);
					result.Append(replacement);

					idxLast = idxPattern + lenPattern;
				}

				return result.ToString();
			}
			finally
			{
				result.Length = 0;
			}
		}
		#endregion

		#region form events

		private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_speech != null)
			{
				_speech.Dispose();
				_speech = null;
			}
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			InitSpellCheck();
			LoadTextFromClipboard();
		}

		private void frmMain_Shown(object sender, EventArgs e)
		{

		}

		private void frmMain_Activated(object sender, EventArgs e)
		{
			if (!_changingDirection)
			{
				if (txtWord.Text.Length > 0)
				{
					txtWord.TextBox.SelectionStart = 0;
					txtWord.TextBox.SelectionLength = txtWord.Text.Length;
				}
				txtWord.TextBox.Focus();
			}
		}

		private void frmMain_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F12)
			{
				SayWord();
			}
		}

		private void btnSay_Click(object sender, EventArgs e)
		{
			SayWord();
		}

		private void txtWord_TextChanged(object sender, EventArgs e)
		{
			var text = ReplaceStrEx(txtWord.Text, "'", "", StringComparison.Ordinal);
			ShowTheMeaning(text, "(یافت نشد)");

			if (!string.IsNullOrWhiteSpace(text))
			{
				text = ConvertToPartialArabicChars(text);
				if (HasPersianChar(text))
				{
					FarsiToEnglishMeaningRecrusive(text);
					ChangeTextBoxRtl(RightToLeft.Yes);
				}
				else
				{
					EnglishToFarsiMeaningRecrusive(text);
					ChangeTextBoxRtl(RightToLeft.No);
				}
			}
			else
			{
				txtWord.HideSuggestions();
			}

		}

		private void lblSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start(new ProcessStartInfo("http://www.salarcode.com/")
								{
									UseShellExecute = true
								})
					.Start();
			}
			catch (Exception)
			{

			}
		}

		#endregion
	}
}