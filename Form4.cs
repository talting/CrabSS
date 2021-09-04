using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrabMCSM
{
    public partial class Form4 : MaterialForm
    {
        public Form4()
        {
            InitializeComponent();
            MaterialSkinManager skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(Primary.Indigo400, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Blue400, TextShade.WHITE);
            skinManager.ROBOTO_MEDIUM_10 = new Font("Microsoft YaHei", 10);
            skinManager.ROBOTO_MEDIUM_11 = new Font("Microsoft YaHei", 11);
            skinManager.ROBOTO_MEDIUM_12 = new Font("Microsoft YaHei", 12);
            skinManager.ROBOTO_REGULAR_11 = new Font("Microsoft YaHei", 11);
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
                string moss = System.IO.Directory.GetCurrentDirectory();
            string exeLocation = "\\frpService\\MossFrpClient.exe";
            string main = moss + exeLocation;
            Process.Start(@main);
        }
    }
}
