/*
 * 许可协议：GNU General Public License 3.0
* 文件名称: Form3.cs
* 创建者: @是螃蟹aaaaa
* 创建日期: 2021 / 08 /13
* 最后编辑日期: 2021 / 08 /13
* 编译环境: .NET FrameWork 4.5(Visual Studio 2017)、Windows 11 （10.0.22000.120）
* 注:禁止商业用途
*/
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
                textBox1.Visible = true;
                textBox1.Text = string.Empty;
                StreamReader sr = new StreamReader("server.properties");
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("server.properties");
            sw.WriteLine(textBox1.Text);
            sw.Close(); 
            MessageBox.Show("文件已保存", "配置文件编辑器", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            StreamReader sr = new StreamReader("server.properties");
            textBox1.Text = sr.ReadToEnd();
            sr.Close();
        }
    }
}
