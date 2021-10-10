using System;
using System.Collections.Generic;
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
    /// ProperitesUpdater.xaml 的交互逻辑
    /// </summary>
    public partial class ProperitesUpdater : Window
    {
        public ProperitesUpdater()
        {
            InitializeComponent();
            try
            {
                pro.Text = string.Empty;
                StreamReader sr = new StreamReader("server.properties");
                pro.Text = sr.ReadToEnd();
                sr.Close();
            }
            catch (System.IO.FileNotFoundException)
            {
                System.Windows.Forms.MessageBox.Show("未找到配置文件，确认开启过服务器？", "关键错误",MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("server.properties");
            sw.WriteLine(pro.Text);
            sw.Close();
            System.Windows.Forms.MessageBox.Show("文件已保存", "配置文件编辑器", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }

        private void reload_Click(object sender, RoutedEventArgs e)
        {
            pro.Text = string.Empty;
            StreamReader sr = new StreamReader("server.properties");
            pro.Text = sr.ReadToEnd();
            sr.Close();
        }
    }
}
