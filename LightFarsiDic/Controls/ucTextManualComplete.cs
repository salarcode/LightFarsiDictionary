using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LightFarsiDictionary.Controls
{
	public partial class ucTextManualComplete : UserControl
	{
		public ucTextManualComplete()
		{
			InitializeComponent();
			AutoPerformComplete = true;
		}

		private void ParentLostFocus()
		{
			var parentF = this.FindForm();
			if (parentF != null)
			{
				parentF.LostFocus +=
					(s, args) => SetSuggestionVisible(false);
				parentF.Move +=
					(s, args) => SetSuggestionVisible(false);
				parentF.Click +=
					(s, args) => SetSuggestionVisible(false);
			}
		}

		public bool AutoPerformComplete { get; set; }
		[Browsable(true)]
		public new event System.EventHandler TextChanged;

		public new string Text
		{
			get { return this.txtText.Text; }
			set { txtText.Text = value; }
		}

		public TextBox TextBox
		{
			get { return this.txtText; }
		}

		public ListBox SuggestionListBox
		{
			get { return this.lstSuggest; }
		}

		public bool SuggestionVisible
		{
			get { return lstSuggest.Visible; }
			set { lstSuggest.Visible = value; }
		}

		public ListBox.ObjectCollection Items
		{
			get { return this.lstSuggest.Items; }
		}

		public void ShowSuggestions()
		{
			SetSuggestionVisible(true);
		}

		public void HideSuggestions()
		{
			SetSuggestionVisible(false);
		}

		protected void OnTextChanged()
		{
			EventHandler handler = TextChanged;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		private void SetSuggestionVisible(bool v)
		{
			if (v)
			{
				SetControlSuggestionHeight();
			}
			lstSuggest.Visible = v;
		}

		private void SetControlSuggestionHeight()
		{
			const int space = 1;
			var suggestListHeight = 0;
			if (lstSuggest.Items.Count < 8)
			{
				var count = lstSuggest.Items.Count == 0 ? 1 : lstSuggest.Items.Count;
				suggestListHeight = (lstSuggest.ItemHeight + 5) * count;
			}
			else
			{
				suggestListHeight = lstSuggest.ItemHeight * 12;
			}
			if (lstSuggest.Visible == true)
			{
				this.Size = new Size(this.Size.Width, txtText.Height + suggestListHeight + space);
			}
			else
			{
				this.Size = new Size(this.Size.Width, txtText.Height + space);
			}
		}

		private void lstSuggest_VisibleChanged(object sender, EventArgs e)
		{
			SetControlSuggestionHeight();
		}

		private void txtText_KeyDown(object sender, KeyEventArgs e)
		{
			if (!AutoPerformComplete)
				return;
			if (txtText.Focused)
			{
				if (e.KeyCode == Keys.Down)
				{
					lstSuggest.Focus();
					if (lstSuggest.Items.Count > 0 && lstSuggest.SelectedIndex < 0)
					{
						lstSuggest.SelectedIndex = 0;
					}
				}
				else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
				{
					SetSuggestionVisible(false);
				}
			}
		}

		private void lstSuggest_KeyDown(object sender, KeyEventArgs e)
		{
			if (!AutoPerformComplete)
				return;
			if (e.KeyCode == Keys.Enter)
			{
				if (lstSuggest.SelectedIndex >= 0)
				{
					txtText.Text = lstSuggest.Items[lstSuggest.SelectedIndex].ToString();
				}
				SetSuggestionVisible(false);
			}
			else if (e.KeyCode == Keys.Escape)
			{
				SetSuggestionVisible(false);
			}
		}
		private void lstSuggest_DoubleClick(object sender, EventArgs e)
		{
			if (!AutoPerformComplete)
				return;

			if (lstSuggest.SelectedIndex >= 0)
			{
				txtText.Text = lstSuggest.Items[lstSuggest.SelectedIndex].ToString();
			}
			SetSuggestionVisible(false);
		}
		private void lstSuggest_Click(object sender, EventArgs e)
		{
			if (!AutoPerformComplete)
				return;
			if (lstSuggest.SelectedIndex >= 0)
			{
				txtText.Text = lstSuggest.Items[lstSuggest.SelectedIndex].ToString();
				SetSuggestionVisible(false);
			}
		}


		private void lstSuggest_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstSuggest.SelectedIndex >= 0)
			{
				//txtText.Text = lstSuggest.Items[lstSuggest.SelectedIndex].ToString();
				//if(AutoPerformComplete)
				//{
				//    SetSuggestionVisible(false);
				//}
			}
		}

		private void ucTextManualComplete_Leave(object sender, EventArgs e)
		{
			if (!AutoPerformComplete)
				return;
			SetSuggestionVisible(false);
		}

		private void lstSuggest_Leave(object sender, EventArgs e)
		{
			if (!AutoPerformComplete)
				return;
			SetSuggestionVisible(false);
		}

		private void txtText_TextChanged(object sender, EventArgs e)
		{
			OnTextChanged();
		}

		private void ucTextManualComplete_Load(object sender, EventArgs e)
		{
			ParentLostFocus();
			this.txtText.Focus();
		}

		private void txtText_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Escape)
			{
				e.Handled = true;
			}

		}

	}
}
