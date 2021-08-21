/*
 * 许可协议：GNU General Public License 3.0
* 文件名称: Form3.cs
* 创建者: @是螃蟹aaaaa
* 创建日期: 2021 / 08 /13
* 最后编辑日期: 2021 / 08 /15
* 编译环境: .NET FrameWork 4.5(Visual Studio 2022)、Windows 11 （10.0.22000.120）
* 注:禁止商业用途
*/
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrabMCSM
{
    public partial class Form3 : MaterialForm
    {
        public Form3()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(Primary.Indigo400, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Blue400, TextShade.WHITE);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Visible = true;
                textBox1.Text = string.Empty;
                StreamReader sr = new StreamReader("server.properties");
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("未找到配置文件，确认开启过服务器？", "关键错误", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
            }              
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("server.properties");
            sw.WriteLine(textBox1.Text);
            sw.Close();
            MessageBox.Show("文件已保存", "配置文件编辑器", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            StreamReader sr = new StreamReader("server.properties");
            textBox1.Text = sr.ReadToEnd();
            sr.Close();
        }
    }
}
