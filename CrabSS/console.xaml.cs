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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace CrabSS
{
    /// <summary>
    /// console.xaml 的交互逻辑
    /// </summary>
    public partial class console : MetroWindow
    {
        public Process p = new Process();
        DispatcherTimer timer = new DispatcherTimer();
        string nowtime = DateTime.Now.ToLocalTime().ToString();
        public console()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            nowtime = DateTime.Now.ToLocalTime().ToString();
            Action methodDelegate = delegate ()
            {
                this.time.Content = "当前时间  " + nowtime;
            };
            this.Dispatcher.BeginInvoke(methodDelegate);
        }
        private async void start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var path = Environment.SystemDirectory;
                const string cmd = "start.cmd";
                p.StartInfo.FileName = cmd;
                p.StartInfo.Arguments = cmd;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardError = true;
                p.Start();
                p.BeginOutputReadLine();
                p.OutputDataReceived += new DataReceivedEventHandler(ProcessOutputHandler);
                start.IsEnabled = false;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync(":( Oops", ex.ToString(), MessageDialogStyle.AffirmativeAndNegative);
                start.IsEnabled = true;
            }
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
                        tr.Text = "\r" + outLine.Data + "\r";
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
                        else if (outLine.Data.IndexOf("FATAL") != -1)
                        {
                            System.Drawing.Color drawColor = System.Drawing.Color.FromArgb(255,195, 0, 82);
                            brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(drawColor.A, drawColor.R, drawColor.G, drawColor.B));
                        }
                        else
                        brush = Brushes.Black;
                        tr.ApplyPropertyValue(TextElement.ForegroundProperty, brush);
                        cons.ScrollToEnd();
                    }
                };
                Dispatcher.BeginInvoke(methodDelegate);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync(":( Oops", ex.ToString(), MessageDialogStyle.AffirmativeAndNegative);
            }
        }
        private async void ExecuteTclCommand(string tclCommand)
        {
            try
            {
                p.StandardInput.WriteLine(tclCommand);
                p.StandardInput.AutoFlush = true;
                cmd.Text = "";
            }
            catch(Exception ex)
            {
                await this.ShowMessageAsync(":( Oops", ex.ToString(), MessageDialogStyle.AffirmativeAndNegative);
            }
        }
        private void op_Click(object sender, RoutedEventArgs e)
        {
            cmd.Text = "op ";
        }

        private void ban_Click(object sender, RoutedEventArgs e)
        {
            cmd.Text = "ban ";
        }

        private void gm_Click(object sender, RoutedEventArgs e)
        {
            cmd.Text = "gamemode 1";
        }

        private void list_Click(object sender, RoutedEventArgs e)
        {
            ExecuteTclCommand("list");
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            ExecuteTclCommand(cmd.Text);
        }

        private void shutdown_Click(object sender, RoutedEventArgs e)
        {
            ExecuteTclCommand("stop");
            start.IsEnabled = true;
        }
    }
}
