using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CrabSSWPFTest
{
    /// <summary>
    /// Plugins.xaml 的交互逻辑
    /// </summary>
    public partial class Plugins : Window
    {
        public Plugins()
        {
            InitializeComponent();
            try
            {
                String path = @"plugins";
                string[] files = Directory.GetFiles(path, "*.jar");
                foreach (string file in files)
                {
                    pluginList.Items.Add(file);
                }
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                System.Windows.Forms.MessageBox.Show("花♂Q！", "文件不存在 :D", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            var of = new Microsoft.Win32.OpenFileDialog();
            of.Filter = "插件文件 (*.jar)|*.jar";
            if (of.ShowDialog() == true)
            {
                string pluginPath = System.IO.Path.GetFullPath(of.FileName);
                string pluginName = of.SafeFileName;
                File.Copy(pluginPath, "plugins\\" + pluginName);
                System.Windows.Forms.MessageBox.Show("插件已复制到plugins目录，可以去看看啦", "插件...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
        }
        private void open_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", Environment.CurrentDirectory + "\\plugins");
        }
        private void refresh_Click(object sender,RoutedEventArgs e)
        {
            try
            {
                pluginList.Items.Clear();   
                String path = @"plugins";
                string[] files = Directory.GetFiles(path, "*.jar");
                foreach (string file in files)
                {
                    pluginList.Items.Add(file);
                }
                //运行了，好bug！好bug！
                System.Windows.Forms.MessageBox.Show("数据刷新成功", "插件...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                System.Windows.Forms.MessageBox.Show("花♂Q！", "文件不存在 :D", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }
    }
}
