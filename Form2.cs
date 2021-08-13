/*
 * 许可协议：GNU General Public License 3.0
* 文件名称: Form2.cs
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            String path = @"plugins";
            string[] files = Directory.GetFiles(path, "*.jar" );
            foreach (string file in files)
                {
                listBox1.Items.Add(file);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            of.ShowDialog();
        }
        private void of_fileOK(object sender,EventArgs e)
        {
            string pluginPath = System.IO.Path.GetFullPath(of.FileName);
            string pluginName = of.SafeFileName;
            File.Copy(pluginPath, "plugins\\" + pluginName);
            MessageBox.Show("插件已复制到plugins目录，可以去看看啦", "插件...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void of_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
