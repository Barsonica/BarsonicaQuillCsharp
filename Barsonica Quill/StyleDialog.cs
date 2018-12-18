using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Barsonica_Quill
{
    public partial class StyleDialog : Form
    {
        public Style style = new Style();
        FontFamily[] font;

        public StyleDialog(string DefName)
        {
            InitializeComponent();
            NameTextBox.Text = DefName;

            //get installed fonts
            using (InstalledFontCollection fontsCollection = new InstalledFontCollection())
            {
                Text_FontBox.Items.Clear();
                font = fontsCollection.Families;
                foreach (FontFamily fon in font)
                {
                    Text_FontBox.Items.Add(fon.Name);
                }

            }
            Text_FontBox.SelectedIndex = 1;
            
        }

        private void ArrangmentChanged(object sender, EventArgs e)
        {
            Alignment_Block.Checked = false;
            Alignment_Left.Checked = false;
            Alignment_Right.Checked = false;
            Alignment_Center.Checked = false;
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            if (Alignment_Left.Checked)
                style.Align = HorizontalAlignment.Left;
            else if (Alignment_Block.Checked)
                style.Align = HorizontalAlignment.Center;
            else if (Alignment_Center.Checked)
                style.Align = HorizontalAlignment.Center;
            else if (Alignment_Right.Checked)
                style.Align = HorizontalAlignment.Right;

            style.font = new Font(font[Text_FontBox.SelectedIndex], (int)Text_FontSize.Value);

            style.Name = NameTextBox.Text;

            style.fontStyle = FontStyle.Regular;
            if (Text_UnderlineCheck.Checked)
                style.fontStyle |= FontStyle.Underline;
            if (Text_BoldCheck.Checked)
                style.fontStyle |= FontStyle.Bold;
            if (Text_ItalicCheck.Checked)
                style.fontStyle |= FontStyle.Italic;

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void Text_BackColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                style.BackColor = colorDialog.Color;
                Text_BackColorBox.BackColor = colorDialog.Color;
            }
        }

        private void Text_ColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                style.FontColor = colorDialog.Color;
                Text_ColorBox.BackColor = colorDialog.Color;
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        
    }
}
