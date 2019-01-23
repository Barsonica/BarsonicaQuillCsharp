using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using printhelper;

namespace Barsonica_Quill
{
    public partial class Form1 : Form
    {
        static char SepChar = Path.DirectorySeparatorChar;
        public PrintTools pt = new PrintTools();  // instantiate printing manager

        public Form1()
        {
            InitializeComponent();
            ResizeWindow();
            timer.Start();

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

            //styles
            try
            {
                PersistentDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "Quill");
                if (!Directory.Exists(PersistentDataPath))
                    Directory.CreateDirectory(PersistentDataPath);
            }
            catch { }
            LoadStyles();
            RefreshStyles();

            //set supported text formats
            openFileDialog.Filter = "All Files|*.*" + "|Plain text|*.txt" + "|Rich text format|*.rtf" /*+ "|Open Document|*.odt"*/;
            saveFileDialog.Filter = "Plain text|*.txt" + "|Rich text format|*.rtf" /*+ "|Open Document|*.odt"*/;

        }
        
        #region File Operations

        string FileName, FilePath, originalFile;
        string PersistentDataPath;

        private void File_NewButton_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "";
            FileName = "";
            FilePath = "";
            TopLabel.Text = "Barsonica Quill";
            this.Text = "Barsonica Quill";
        }

        private void File_OpenButton_Click(object sender, EventArgs e)
        {
                //show dialog and validate
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            if(!openFileDialog.CheckFileExists)
                return;

            FilePath = openFileDialog.FileName;
            FileName = FilePath.Split(SepChar)[FilePath.Split(SepChar).Length - 1];

                //document type switch
            switch (openFileDialog.FileName.Split('.')[1])
            {
                case "txt":
                    richTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    originalFile = richTextBox.Text;
                    break;
                case "rtf": 
                    LoadRTF(openFileDialog.FileName);
                    break;
                case "odt":
                    LoadODT(openFileDialog.FileName);
                    break;
                default:
                    break;
                
            }
            TopLabel.Text = FileName + " - Barsonica Quill";
            this.Text = FileName + " - Barsonica Quill";
        }
        
        void LoadODT(string filePath)
        {

        }

        void LoadRTF(string filePath)
        {
            richTextBox.LoadFile(filePath);
        }

       //saving
        private void File_SaveButton_Click(object sender, EventArgs e)
        {
            if (!TopLabel.Text.Contains(".") || this.Text.Contains("."))
                saveAsToolStripMenuItem_Click(sender, e);
            else
            {
                switch (FileName.Split('.')[1])
                {
                    case "txt":
                        using (StreamWriter sw = new StreamWriter(FilePath))
                        {
                            sw.Write(richTextBox.Text);
                            sw.Flush();
                        }
                        break;
                    case "odt":
                        SaveODT(FilePath);
                        break;
                    case "rtf":
                        SaveRTF(FilePath);
                        break;
                    default:
                        break;
                }
                TopLabel.Text = FileName + " - Barsonica Quill";
                this.Text = FileName + " - Barsonica Quill";
            }
            
            originalFile = richTextBox.Text;
            SaveStyles();

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show dialog and validate
            if (saveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            FilePath = saveFileDialog.FileName;
            FileName = FilePath.Split(SepChar)[FilePath.Split(SepChar).Length - 1];

            switch (saveFileDialog.FilterIndex)
            {
                case 2: //txt
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        sw.Write(richTextBox.Text);
                        sw.Flush();
                        originalFile = richTextBox.Text;
                    }
                    break;
                case 3: //rtf
                    SaveRTF(FilePath);
                    break;
                case 4: //odt
                    SaveODT(FilePath);
                    break;
            }

            TopLabel.Text = FileName + " - Barsonica Quill";
            this.Text = FileName + " - Barsonica Quill";
            originalFile = richTextBox.Text;
            SaveStyles();
        }

        private void saveCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show dialog and validate
            if (saveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            switch (saveFileDialog.FilterIndex)
            {
                case 1: //txt
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        sw.Write(richTextBox.Text);
                        sw.Flush();
                    }
                    break;
                case 2: //rtf
                    SaveRTF(saveFileDialog.FileName);
                    break;
                case 3: //odt
                    SaveODT(saveFileDialog.FileName);
                    break;
            }
            SaveStyles();
        }

        void SaveODT(string filePath)
        {

        }

        void SaveRTF(string filePath)
        {
            richTextBox.SaveFile(filePath);
        }

        //when text is changed
        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox.Text != originalFile && (!TopLabel.Text.Contains("*")|| !this.Text.Contains("*")))
            {
                TopLabel.Text += "*";
                this.Text += "*";
            }

            if (richTextBox.Text.Contains("NYAN CAT")) //easter egg
                NyanEgg();
        }
        #endregion

        #region Mistakes

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Redo();
        }
        #endregion

        #region Easter Eggs

        void NyanEgg()
        {
            richTextBox.Select(richTextBox.Find("NYAN CAT"), 8);
            richTextBox.SelectedText = "";
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=QH2-TGUlwu4");
        }

        #endregion

        #region Formating

        //when selected, changes font
        bool change = true;
        private void richTextBox_SelectionChanged(object sender, EventArgs e)
        {
            change = false;
            try
            {
                Text_FontSize.Value = (decimal)richTextBox.SelectionFont.Size;
            }
            catch { }

            change = false;
            try
            {
                Text_FontBox.SelectedIndex = Text_FontBox.Items.IndexOf(richTextBox.SelectionFont.Name);
            }
            catch { }

            change = false;
            try
            {
                if (richTextBox.SelectionFont.Style == FontStyle.Bold)
                    Text_BoldCheck.Checked = true;
                else
                    Text_BoldCheck.Checked = false;
            }
            catch { }

            change = false;
            try
            {
                if (richTextBox.SelectionFont.Style == FontStyle.Italic)
                    Text_ItalicCheck.Checked = true;
                else
                    Text_ItalicCheck.Checked = false;
            }
            catch { }

            change = false;
            try
            {
                if (richTextBox.SelectionFont.Style == FontStyle.Underline)
                    Text_UnderlineCheck.Checked = true;
                else
                    Text_UnderlineCheck.Checked = false;
            }
            catch { }

            change = false;
            try
            {
                Text_BackColorBox.BackColor = richTextBox.SelectionBackColor;
            }
            catch { }

            change = false;
            try
            {
                Text_ColorBox.BackColor = richTextBox.SelectionColor;
            }
            catch { }

            change = true;
        }
        
        //text
        FontFamily[] font;

        private void Format_Text_ColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog.ShowDialog();
            Text_ColorBox.BackColor = ColorDialog.Color;
            richTextBox.SelectionColor = ColorDialog.Color;
        }

        private void Format_Text_BackColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog.ShowDialog();
            Text_BackColorBox.BackColor = ColorDialog.Color;
            richTextBox.SelectionBackColor = ColorDialog.Color;
        }
        
        private void Text_FontBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (change)
            {
                richTextBox.SelectionFont = new Font(font[Text_FontBox.SelectedIndex], (int)Text_FontSize.Value);
                change = false;
            }
        }

        private void Text_BoldCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (change)
            {
                if (!Text_BoldCheck.Checked)
                    richTextBox.SelectionFont = new Font(font[Text_FontBox.SelectedIndex], (int)Text_FontSize.Value, FontStyle.Regular);
                else
                    richTextBox.SelectionFont = new Font(font[Text_FontBox.SelectedIndex], (int)Text_FontSize.Value, richTextBox.SelectionFont.Style | FontStyle.Bold);
                change = false;
            }
        }

        private void Text_ItalicCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (change)
            {
                if (!Text_ItalicCheck.Checked)
                    richTextBox.SelectionFont = new Font(font[Text_FontBox.SelectedIndex], (int)Text_FontSize.Value, FontStyle.Regular);
                else
                    richTextBox.SelectionFont = new Font(font[Text_FontBox.SelectedIndex], (int)Text_FontSize.Value, richTextBox.SelectionFont.Style | FontStyle.Italic);
                change = false;
            }
        }

        private void Text_UnderlineCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (change)
            {
                if (!Text_UnderlineCheck.Checked)
                richTextBox.SelectionFont = new Font(font[Text_FontBox.SelectedIndex], (int)Text_FontSize.Value, FontStyle.Regular);
            else
                richTextBox.SelectionFont = new Font(font[Text_FontBox.SelectedIndex], (int)Text_FontSize.Value, richTextBox.SelectionFont.Style | FontStyle.Underline);
                change = false;
            }
        }

        #endregion

        #region Alignment

        private void Alignment_LeftButton_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void Alignment_CenterButton_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void Alignment_RightButton_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void Alignment_BlockButton_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Left;
        }

        #endregion

        #region Styles

        List<Style> styles = new List<Style>();
        
        private void Styles_AddButton_Click(object sender, EventArgs e)
        {
            StyleDialog SD = new StyleDialog("Style");
            
            if (SD.ShowDialog() == DialogResult.OK)
                styles.Add(SD.style);

            RefreshStyles();
        }

        private void Styles_EditButton_Click(object sender, EventArgs e)
        {
            if(styles.ToArray().Length > 0 && Styles_List.SelectedIndex >= 0)
            {
                StyleDialog SD = new StyleDialog(Styles_List.Items[Styles_List.SelectedIndex].ToString());
                if (SD.ShowDialog() == DialogResult.OK)
                    styles[Styles_List.SelectedIndex] = SD.style;
                RefreshStyles();
            }
        }
        
        private void Styles_DelButton_Click(object sender, EventArgs e)
        {
            if (styles.ToArray().Length > 0 && Styles_List.SelectedIndex >= 0)
            {
                styles.RemoveAt(Styles_List.SelectedIndex);
                RefreshStyles();
            }
        }

        void RefreshStyles()
        {
            SaveStyles();
            LoadStyles();

            Styles_List.Items.Clear();
            for(int i = 0; i < styles.ToArray().Length; i++)
            {
                Styles_List.Items.Add(styles.ToArray()[i].Name);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            richTextBox.SelectionBackColor = styles[Styles_List.SelectedIndex].BackColor;
            richTextBox.SelectionColor = styles[Styles_List.SelectedIndex].FontColor;
            richTextBox.SelectionFont = styles[Styles_List.SelectedIndex].font;
            richTextBox.SelectionAlignment = styles[Styles_List.SelectedIndex].Align;

        }
        
        void SaveStyles()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(PersistentDataPath + Path.DirectorySeparatorChar + "styles.csv", FileMode.Create)))
                {
                    sw.WriteLine("Name;Fontname;Fontsize;Fontcolor.R;Fontcolor.G;fontcolor.B;BackColor.R;BackColor.G;BackColor.B;Fontstyle;Alingment");
                    foreach (Style S in styles)
                    {
                        sw.WriteLine(S.ToString());
                    }
                    sw.Flush();
                }
            }
            catch
            {
                MessageBox.Show("Unable to write config file");
            }
        }

        void LoadStyles()
        {
            try
            {
                string[] fileContent;
                using (StreamReader sr = new StreamReader(PersistentDataPath + Path.DirectorySeparatorChar + "styles.csv"))
                {
                    fileContent = sr.ReadToEnd().Split('\n');
                }
                styles.Clear();
                for(int i = 1; i< fileContent.Length-1; i++)
                {
                    Style res = new Style();
                    res.FromString(fileContent[i]);
                    styles.Add(res);
                }
            }
            catch
            {

            }
        }

        #endregion

        #region Find

        private void Find_FindButton_Click(object sender, EventArgs e)
        {
           
            richTextBox.Select(richTextBox.Find(Find_TextBox1.Text),Find_TextBox1.Text.Length);
            richTextBox.Focus();
        }

        private void Find_FindAndReplace_Click(object sender, EventArgs e)
        {
            if (Find_CheckBoxAll.Checked) //find and replace all
            {
                while (richTextBox.Text.Contains(Find_TextBox1.Text))
                {
                    richTextBox.Select(richTextBox.Find(Find_TextBox1.Text), Find_TextBox1.Text.Length);
                    richTextBox.SelectedText = Find_TextBox2.Text;
                }
            }else
            {       //find and replace the first one
                richTextBox.Select(richTextBox.Find(Find_TextBox1.Text), Find_TextBox1.Text.Length);
                richTextBox.SelectedText = Find_TextBox2.Text;
            }

            richTextBox.Focus();
        }

        #endregion

        #region Print

        private void File_PrintButton_Click(object sender, EventArgs e)
        {
            Exception ex = new Exception("An Exception Occurred during printg");
            pt.GeneralPrintForm("Basic Print", richTextBox.Rtf, ref ex);  // Constructor 1 demo
            return;
        }

        #endregion

        #region Window buttons

        bool Maximized = false;
        Point OriginLoc = new Point(0,0);
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TopLabel.Text.Contains("*") || this.Text.Contains("*"))
            {
                DialogResult Result = MessageBox.Show("Do you want to save the file?", "Quit application", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (Result == DialogResult.Cancel)
                    return;
                else if (Result == DialogResult.Yes)
                {
                    File_SaveButton_Click(sender, e);
                }
            }
        }

        private void App_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void App_Maximaze_Click(object sender, EventArgs e)
        {
            if (Maximized)
            {
                this.Size = new System.Drawing.Size(1150, 700);
                this.Location = OriginLoc;
                Maximized = false;
            }
            else
            {
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                OriginLoc = this.Location;
                this.Location = new Point(0, 0);
                Maximized = true;
            }
            ResizeWindow();
        }
        
        private void App_Minimaze_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Resize

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            ResizeWindow();
        }

        void ResizeWindow()
        {
            WindowButtons.Location = new Point(this.Width - 97, 1);

            richTextBox.Size = new Size((int)(6* Scaling.Value), (int)(6 * Scaling.Value * 1.4));
            richTextBox.Location = new Point((int)(TextsPanel.Width-20-richTextBox.Width)/2, 20);
            
            TopLabel.Location = new Point((this.Width-TopLabel.Width)/2, 6);

            Scaling.Location = new Point(0,StylesPanel.Height - 19);
            ScaleLabel.Location = new Point(ScaleLabel.Location.X, Scaling.Location.Y - 15);

            Styles.Size = new Size(StylesPanel.Width - 10, StylesPanel.Height - 42);
            Styles_List.Size = new Size(Styles.Width - 12, Styles.Height - 38);
            Styles_AddButton.Location = new Point(Styles_AddButton.Location.X, Styles.Height-28);
            Styles_EditButton.Location = new Point(Styles_EditButton.Location.X, Styles.Height - 28);
            Styles_DelButton.Location = new Point(Styles_DelButton.Location.X, Styles.Height - 28);
        }

        private void Scaling_ValueChanged(object sender, EventArgs e)
        {
            ScaleLabel.Text = Scaling.Value.ToString() + " %";
            richTextBox.ZoomFactor = (float)((Scaling.Value + 0.0) / 100);
            ResizeWindow();
        }
        
        private void richTextBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if(((Scaling.Value + e.Delta / 120) < Scaling.Maximum) && ((Scaling.Value + e.Delta / 120) > Scaling.Minimum) && Control.ModifierKeys == Keys.Control)
            {
                Scaling.Value += e.Delta / 120;
                Scaling_ValueChanged(sender, e);
            }
        }

        #endregion

        #region Window dragging

        bool Dragging = false;
        Point DraggingStartPoint = new Point(0, 0);

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DraggingStartPoint = new Point(e.X, e.Y);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Dragging)
            {
                Point p = MousePosition;
                Location = new Point(p.X - this.DraggingStartPoint.X, p.Y - this.DraggingStartPoint.Y);
            }
        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hideToolStripMenuItem.Checked)
            {
                hideToolStripMenuItem.Checked = false;
                App_Close.Visible = false;
                App_Maximaze.Visible = false;
                App_Minimaze.Visible = false;
                TopLabel.Visible = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                hideToolStripMenuItem.Checked = true;
                App_Close.Visible = true;
                App_Maximaze.Visible = true;
                App_Minimaze.Visible = true;
                TopLabel.Visible = true;
                this.FormBorderStyle = FormBorderStyle.None;
                Form1_ResizeEnd(sender,e);
            }
        }

        #endregion

        #region External dialogs

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm AF = new AboutForm();
            AF.ShowDialog();
        }
        
        private void iconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iconsDialog iD = new iconsDialog();
            if(DialogResult.OK == iD.ShowDialog())
            {
                Alignment_BlockButton.BackgroundImage = iD.iconFiles[0];
                Alignment_CenterButton.BackgroundImage = iD.iconFiles[1];
                Alignment_LeftButton.BackgroundImage = iD.iconFiles[2];
                Alignment_RightButton.BackgroundImage = iD.iconFiles[3];
                Text_BackColorButton.BackgroundImage = iD.iconFiles[4];
                Text_BoldCheck.BackgroundImage = iD.iconFiles[5];
                App_Close.BackgroundImage = iD.iconFiles[6];
                Find_FindButton.BackgroundImage = iD.iconFiles[7];
                Find_FindAndReplace.BackgroundImage = iD.iconFiles[8];
                Text_ColorButton.BackgroundImage = iD.iconFiles[9];
                Text_ItalicCheck.BackgroundImage = iD.iconFiles[10];
                App_Maximaze.BackgroundImage = iD.iconFiles[11];
                App_Minimaze.BackgroundImage = iD.iconFiles[12];
                File_NewButton.BackgroundImage = iD.iconFiles[13];
                File_OpenButton.BackgroundImage = iD.iconFiles[14];
                File_PrintButton.BackgroundImage = iD.iconFiles[15];
                File_SaveButton.BackgroundImage = iD.iconFiles[16];
                Text_UnderlineCheck.BackgroundImage = iD.iconFiles[17];
                undo.BackgroundImage = iD.iconFiles[18];
                redo.BackgroundImage = iD.iconFiles[19];

            }
            else
            {
                Alignment_BlockButton.BackgroundImage = Properties.Resources.arrangmentBlock;
                Alignment_CenterButton.BackgroundImage = Properties.Resources.arrangmentCenter;
                Alignment_LeftButton.BackgroundImage = Properties.Resources.arrangmentLeft;
                Alignment_RightButton.BackgroundImage = Properties.Resources.arrangmentRight;
                Text_BackColorButton.BackgroundImage = Properties.Resources.backColor;
                Text_BoldCheck.BackgroundImage = Properties.Resources.bold;
                App_Close.BackgroundImage = Properties.Resources.close;
                Find_FindButton.BackgroundImage = Properties.Resources.find;
                Find_FindAndReplace.BackgroundImage = Properties.Resources.findAndReplace;
                Text_ColorButton.BackgroundImage = Properties.Resources.fontColor;
                Text_ItalicCheck.BackgroundImage = Properties.Resources.italic;
                App_Maximaze.BackgroundImage = Properties.Resources.maximize;
                App_Minimaze.BackgroundImage = Properties.Resources.minimize;
                File_NewButton.BackgroundImage = Properties.Resources._new;
                File_OpenButton.BackgroundImage = Properties.Resources.open;
                File_PrintButton.BackgroundImage = Properties.Resources.print;
                File_SaveButton.BackgroundImage = Properties.Resources.save;
                Text_UnderlineCheck.BackgroundImage = Properties.Resources.underline;
                undo.BackgroundImage = Properties.Resources.undo;
                redo.BackgroundImage = Properties.Resources.redo;
            }
        }
        #endregion

    }

    public struct Style
    {
        public Style(string name,Font fnt,Color fontColor,Color backColor,FontStyle fntStyle,HorizontalAlignment align){
            Name = name;
            FontColor = fontColor;
            BackColor = backColor;
            fontStyle = fntStyle;
            Align = align;
            font = new Font(fnt, fntStyle);
        }
        public string Name;
        public Font font;
        public FontStyle fontStyle;
        public Color FontColor, BackColor;
        public HorizontalAlignment Align;

        public override string ToString()
        {
            return Name + ";" + font.Name + ";" + font.Size.ToString() + ";" + FontColor.R.ToString() + ";" + FontColor.G.ToString() + ";" + FontColor.B.ToString() + ";" + BackColor.R.ToString() + ";" + BackColor.G.ToString() + ";" + BackColor.B.ToString() + ";" + fontStyle.ToString() + ";" + Align.ToString();
        }
        public void FromString(string input)
        {
            string[] Splitted = input.Split(';');
            Name = Splitted[0];
            try
            {
                font = new Font(Splitted[1], float.Parse(Splitted[2]));
                FontColor = Color.FromArgb(byte.Parse(Splitted[3]), byte.Parse(Splitted[4]), byte.Parse(Splitted[5]));
                BackColor = Color.FromArgb(byte.Parse(Splitted[6]), byte.Parse(Splitted[7]), byte.Parse(Splitted[8]));
            }
            catch
            {
                MessageBox.Show("error loading styles");
            }

            switch (Splitted[9].ToLower())
            {
                case "regular":
                    fontStyle = FontStyle.Regular;
                    break;
                case "underline":
                    fontStyle = FontStyle.Underline;
                    break;
                case "bold":
                    fontStyle = FontStyle.Bold;
                    break;
                case "italic":
                    fontStyle = FontStyle.Italic;
                    break;
            }

            switch (Splitted[10].ToLower())
            {
                case "left":
                    Align = HorizontalAlignment.Left;
                    break;
                case "right":
                    Align = HorizontalAlignment.Right;
                    break;
                case "center":
                    Align = HorizontalAlignment.Center;
                    break;
            }



        }

    };

}
