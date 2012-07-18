using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LightFarsiDic.Database.Entities;
using NHibernate.Linq;
using NHunspell;

namespace LightFarsiDictionary
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
			_spellFa = new Hunspell();
			_spellEn = new Hunspell();
		}
		#region variables

		private SpeechSynthesizer _speech;
		private Prompt _speechPrompt;
		private Hunspell _spellFa;
		private Hunspell _spellEn;
		private bool _spellCheckLoaded = false;
		private bool _changingDirection = false;
		private const string notFoundMessage = "(یافت نشد)";

		#endregion

		#region private methods

		void ChangeUserInputWord(string word, bool ifempty)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new Action<string, bool>(ChangeUserInputWord), word, ifempty);
				return;
			}
			if (ifempty && txtWord.Text.Length == 0)
				txtWord.Text = word;
		}

		/// <summary>
		/// 
		/// </summary>
		void InitSpellCheck()
		{
			var warmUp = new Thread(
				() =>
				{
					try
					{
						_spellFa.Load("spelldic\\fa.aff", "spelldic\\fa.dic");
						_spellEn.Load("spelldic\\en_US.aff", "spelldic\\en_US.dic");
						_spellCheckLoaded = true;
					}
					catch
					{
					}
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
				var text = Clipboard.GetText().Trim();

				var loadText = new Action(
					() =>
					{
						if (Program._warmUp != null)
						{
							Program._warmUp.Join();
						}

						var spaceIndex = text.IndexOf(" ");
						if (spaceIndex != -1)
						{
							text = text.Substring(0, spaceIndex);
						}
						if (text.Length <= 15)
						{
							ChangeUserInputWord(text, true);
						}
					});
				loadText.BeginInvoke(null, null);
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
		void SayWordWarmup()
		{
			if (_speech == null)
			{
				try
				{
					_speech = new SpeechSynthesizer();
					_speechPrompt = new Prompt(txtWord.Text);
					_speech.SpeakAsync("");
				}
				catch (Exception)
				{
				}
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

		void FindMeaningFarsi(string word, out string foundWord, out string meaning)
		{
			foundWord = word;
			meaning = notFoundMessage;
			if (_spellCheckLoaded)
			{
				var suggestList = _spellFa.Suggest(word);
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
			using (var session = dicenfaSession.OpenStatelessSession())
			{
				var farsiMeaning = session.QueryOver<FarsiToEnglish>().Where(x => x.Farsi == word).Take(1).SingleOrDefault();
				if (farsiMeaning != null)
				{
					foundWord = farsiMeaning.Farsi;
					meaning = farsiMeaning.English;
				}
			}
		}
		void FindMeaningEnglish(string word, out string foundWord, out string meaning)
		{
			foundWord = word;
			meaning = notFoundMessage;
			List<string> foundList = null;
			using (var session = dicenfaSession.OpenStatelessSession())
			{
				var farsiMeaning = session.QueryOver<EnglishToFarsi>().Where(x => x.English == word).Take(1).SingleOrDefault();
				if (farsiMeaning != null)
				{
					foundWord = farsiMeaning.English;
					meaning = farsiMeaning.Farsi;
				}
				else
				{
					var corrections = session.Query<EnglishToFarsi>().Where(x => x.English.StartsWith(word)).Take(5).ToList();
					if (corrections.Count > 0)
					{
						foundList = corrections.Select(toFarsi => toFarsi.English).ToList();
					}
					else
					{
						corrections = session.Query<EnglishToFarsi>().Where(x => x.English.EndsWith(word)).Take(5).ToList();
						if (corrections.Count > 0)
						{
							foundList = corrections.Select(toFarsi => toFarsi.English).ToList();
						}
					}
				}
			}

			if (_spellCheckLoaded)
			{
				var suggestList = _spellEn.Suggest(word);
				if (suggestList != null && suggestList.Count > 0)
				{
					txtWord.Items.Clear();
					txtWord.Items.AddRange(suggestList.ToArray());
					if (foundList != null)
						txtWord.Items.AddRange(foundList.ToArray());
					txtWord.ShowSuggestions();
				}
				else
				{
					txtWord.HideSuggestions();
					txtWord.Items.Clear();
				}
			}
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


		private void txtWord_TextChanged(object sender, EventArgs e)
		{
			var word = ReplaceStrEx(txtWord.Text, "'", "", StringComparison.Ordinal).Trim();
			ShowTheMeaning(word, "(یافت نشد)");

			if (!string.IsNullOrWhiteSpace(word))
			{
				word = ConvertToPartialArabicChars(word);
				string foundWord, meaning;

				if (HasPersianChar(word))
				{
					FindMeaningFarsi(word, out foundWord, out meaning);
					ShowTheMeaning(foundWord, meaning);

					ChangeTextBoxRtl(RightToLeft.Yes);
				}
				else
				{
					FindMeaningEnglish(word, out foundWord, out meaning);
					ShowTheMeaning(foundWord, meaning);
					ChangeTextBoxRtl(RightToLeft.No);
				}
			}
			else
			{
				txtWord.HideSuggestions();
			}
		}

		private void btnSay_Click(object sender, EventArgs e)
		{
			SayWord();
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
		private void lnkSources_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start(new ProcessStartInfo("http://lightfarsidictionary.codeplex.com/")
				{
					UseShellExecute = true
				})
					.Start();
			}
			catch (Exception)
			{

			}
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			InitSpellCheck();
		}

		private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_speech != null)
			{
				_speech.Dispose();
				_speech = null;
			}
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

		private void btnSay_MouseEnter(object sender, EventArgs e)
		{
			SayWordWarmup();
		}

		private void frmMain_Shown(object sender, EventArgs e)
		{
			LoadTextFromClipboard();
		}

	}
}
