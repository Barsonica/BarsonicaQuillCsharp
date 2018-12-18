using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barsonica_Quill
{
    public partial class ProgramManager
    {
        public StyleDialog SD;
        Form1 MainWindow;
        bool IsNew = true;

        public void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainWindow = new Form1(this);
            SD = new StyleDialog(this);
                
            Application.Run(MainWindow);
            Application.Run(SD);
            SD.Hide();
        }

        public void RequestNewStyle()
        {
            IsNew = true;
            SD.Show();
        }

        public void RequestEditStyle()
        {
            IsNew = false;
            SD.Show();
        }

        public void SubmitStyle()
        {
            if (IsNew)
                MainWindow.AddStyle();
            else
                MainWindow.EditStyle();
            SD.Hide();
        }

    }
}
