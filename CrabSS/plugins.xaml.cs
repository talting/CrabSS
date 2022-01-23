using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CrabSS
{
    /// <summary>
    /// plugins.xaml 的交互逻辑
    /// </summary>
    public partial class plugins : MetroWindow
    {
        public plugins()
        {
            InitializeComponent();
            try
            {
                String path = @"plugins";
                string[] files = Directory.GetFiles(path, "*.jar");
                foreach (string file in files)
                {
                    pluginlist.Items.Add(file);
                }
                counts.Content = "插件总数 " + pluginlist.Items.Count;
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync(":( 发生错误，但不是程序的错", ex.ToString());
                counts.Content = "插件总数 " + pluginlist.Items.Count;
            }
        }

        private void addplugins_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var of = new Microsoft.Win32.OpenFileDialog();
                of.Filter = "插件文件 (*.jar)|*.jar";
                if (of.ShowDialog() == true)
                {
                    pluginlist.Items.Clear();
                    string pluginPath = System.IO.Path.GetFullPath(of.FileName);
                    string pluginName = of.SafeFileName;
                    File.Copy(pluginPath, "plugins\\" + pluginName);
                    String path = @"plugins";
                    string[] files = Directory.GetFiles(path, "*.jar");
                    foreach (string file in files)
                    {
                        pluginlist.Items.Add(file);
                    }
                    counts.Content = "插件总数 " + pluginlist.Items.Count;
                    this.ShowMessageAsync("成功", "插件已复制到plugins目录");
                }
                try
                {
                    String path = @"plugins";
                    string[] files = Directory.GetFiles(path, "*.jar");
                    int i = 0;
                    foreach (string file in files)
                    {
                        i++;
                    }
                    Main m = new();
                    m.plugins.Title = "插件管理 | 总数" + i;
                }
                catch (Exception ex)
                {
                    this.ShowMessageAsync(":( 发生错误，但不是程序的错", ex.ToString());
                    counts.Content = "插件总数 " + pluginlist.Items.Count;
                }
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync(":( 出错了，但是是程序的错", ex.ToString());
            }
        }

        private void refresh_MouseDown(object sender, RoutedEventArgs e)
        {
            pluginlist.Items.Clear();
            try
            {
                String path = @"plugins";
                string[] files = Directory.GetFiles(path, "*.jar");
                foreach (string file in files)
                {
                    pluginlist.Items.Add(file);
                }
                counts.Content = "插件总数 " + pluginlist.Items.Count;
                this.ShowMessageAsync("成功", "已刷新插件列表");
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync(":( 发生错误，但不是程序的错", ex.ToString());
                counts.Content = "插件总数 " + pluginlist.Items.Count;
            }
        }
    }
}
