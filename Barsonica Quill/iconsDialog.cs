using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Barsonica_Quill
{
    public partial class iconsDialog : Form
    {
        string folder = "";
        string[] icons;
        string[] iconSets;
        public Image[] iconFiles = new Image[18];
        char sepChar;

        public iconsDialog()
        {
            InitializeComponent();

            sepChar = Path.DirectorySeparatorChar;

            icons = new string[18];
            icons[0] = "arrangmentBlock.png";
            icons[1] = "arrangmentCenter.png";
            icons[2] = "arrangmentLeft.png";
            icons[3] = "arrangmentRight.png";
            icons[4] = "backColor.png";
            icons[5] = "bold.png";
            icons[6] = "close.png";
            icons[7] = "find.png";
            icons[8] = "findAndReplace.png";
            icons[9] = "fontColor.png";
            icons[10] = "italic.png";
            icons[11] = "maximize.png";
            icons[12] = "minimize.png";
            icons[13] = "new.png";
            icons[14] = "open.png";
            icons[15] = "print.png";
            icons[16] = "save.png";
            icons[17] = "underline.png";

        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //validate the selection
            try {
                for (int i = 0; i < 18; i++)
                {
                    iconFiles[i] = new Bitmap(folder + sepChar + comboBox.Items[comboBox.SelectedIndex].ToString() + sepChar + icons[i]);s
                }
                checkBox.Checked = true;
            }
            catch
            {
                checkBox.Checked = false;
            }
                
            

        }

        private void button_Click(object sender, EventArgs e)
        {
            //submit the result
            if (checkBox.Checked)
            {
                this.Hide();
                this.DialogResult = DialogResult.OK;

            }
        }

        private void comboBox_Click(object sender, EventArgs e)
        {
            comboBox.Items.Clear();

            //load the folders
            folder = Path.GetDirectoryName(Application.ExecutablePath) + sepChar  + "Icons";
            iconSets = Directory.GetDirectories(folder);
            for(int i = 0;i< iconSets.Length;i++)
            {
                comboBox.Items.Add(iconSets[i].Split(sepChar)[iconSets[i].Split(sepChar).Length-1]);
            }
            

        }


    }
}
