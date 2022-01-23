using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace CrabSS
{
    /// <summary>
    /// console.xaml 的交互逻辑
    /// </summary>
    public partial class EmbConsole : MetroWindow
    {
        public string time = DateTime.Now.ToLocalTime().ToString();
        Process p = new Process();
        public EmbConsole()
        {
            for (bool a = true; a == true; a = true)
            {
                this.time = DateTime.Now.ToLocalTime().ToString();
            }
            InitializeComponent();
            TextRange tr = new(cons.Document.ContentEnd, cons.Document.ContentEnd);
            MainWindow mw = new();
            mw.start.Content = "服务器已启动";
            mw.start.IsEnabled = false;
            tr.Text = "\r[" + time + "]" + mw.min.Value + mw.max.Value + "\r";
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mw = new();
            mw.start.Content = "自然选择，前进四！";
            mw.start.IsEnabled = true;
        }
        private async void ProcessOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            try
            {
                Action methodDelegate = delegate ()
                {
                    if (!String.IsNullOrEmpty(outLine.Data))
                    {
                        TextRange tr = new(cons.Document.ContentEnd, cons.Document.ContentEnd);
                        tr.Text = "\r[" + time + "] " + outLine.Data + "\r";
                        Brush brush = Brushes.Black;//彩色回显？
                        if (outLine.Data.IndexOf("INFO") != -1)
                            brush = System.Windows.Media.Brushes.Gray;
                        else if (outLine.Data.IndexOf("WARN") != -1)
                        {
                            System.Drawing.Color drawColor = System.Drawing.Color.FromArgb(255, 185, 0, 0);
                            brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(drawColor.A, drawColor.R, drawColor.G, drawColor.B));
                        }
                        else if (outLine.Data.IndexOf("ERROR") != -1)
                        {
                            System.Drawing.Color drawColor = System.Drawing.Color.FromArgb(255, 214, 0, 21);
                            brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(drawColor.A, drawColor.R, drawColor.G, drawColor.B));
                        }
                        else
                            brush = Brushes.Black;
                        tr.ApplyPropertyValue(TextElement.ForegroundProperty, brush);
                        cons.ScrollToEnd();

                    }

                };
                this.Dispatcher.BeginInvoke(methodDelegate);

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync(":(", ex.ToString(), MessageDialogStyle.AffirmativeAndNegative);
            }
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                p.StandardInput.WriteLine(command.Text);
                p.StandardInput.AutoFlush = true;
            }
            catch (Exception ex)
            {
                TextRange tr = new(cons.Document.ContentEnd, cons.Document.ContentEnd);
                tr.Text = "\r[" + time + "]执行时发生错误：" + ex.ToString() + "\r";
            }
        }
        private void stop_Click(object sender, RoutedEventArgs e)
        {
            TextRange tr = new(cons.Document.ContentEnd, cons.Document.ContentEnd);
            try
            {
                tr.Text = "\r[" + time + "]正在硬关闭服务器\r";
                Process.Start(@"C:\Windows\system32\taskkill.exe", "-f -im java.exe");
                p.CancelOutputRead();
                tr.Text = "\r[" + time + "]关闭完了捏\r";
            }
            catch (Exception ex)
            {
                tr.Text = "\r[" + time + "]关闭时发生错误：" + ex.ToString() + "\r";
            }
        }
        private void restart_Click(object sender, RoutedEventArgs e)
        {
            TextRange tr = new(cons.Document.ContentEnd, cons.Document.ContentEnd);
            try
            {
                tr.Text = "\r[" + time + "]正在硬关闭服务器\r";
                Process.Start(@"C:\Windows\system32\taskkill.exe", "-f -im java.exe");
                p.CancelOutputRead();
                tr.Text = "\r[" + time + "]关闭完成。\r";
                try
                {
                    tr.Text = "\r[" + time + "]服务器正在启动\r";
                    p.StartInfo.FileName = "start.cmd";
                    p.StartInfo.Arguments = "start.cmd";
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardInput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.Start();
                    p.OutputDataReceived += new DataReceivedEventHandler(ProcessOutputHandler);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("你想啥呢你", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    tr.Text = "\r[" + time + "]重新启动时发生错误：" + ex.ToString() + "\r";
                }
            }
            catch (Exception ex)
            {
                tr.Text = "\r[" + time + "]关闭时发生错误：" + ex.ToString() + "\r";
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            var path = Environment.SystemDirectory;
            TextRange tr = new(cons.Document.ContentEnd, cons.Document.ContentEnd);
            tr.Text = "\r[" + time + "]服务器正在启动\r";
            p.StartInfo.FileName = "start.cmd";
            p.StartInfo.Arguments = "start.cmd";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            p.BeginOutputReadLine();
            p.OutputDataReceived += new DataReceivedEventHandler(ProcessOutputHandler);
            start.Visibility = Visibility.Hidden;
        }
    }
}
