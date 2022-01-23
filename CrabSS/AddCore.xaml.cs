using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// AddCore.xaml 的交互逻辑
    /// </summary>
    public class settinginfos //chums
    {
        public string Version { get; set; }
        public string WindowTitle { get; set; }
        public string ColorTheme { get; set; }
        public int minRamSize { get; set; }
        public int maxRamSize { get; set; }
        public string CustomJavaPath { get; set; }
    }
    public partial class AddCore : MetroWindow
    {
        private int  minRamSize;
        private int maxRamSize;

        public AddCore()
        {
            InitializeComponent();
            settinginfos readed = new();
            using (StreamReader readFile = File.OpenText("settings.json"))
            {
                using (JsonTextReader reader = new JsonTextReader(readFile)) //using Newtonsoft.Json
                {
                    JObject oJson = (JObject)JToken.ReadFrom(reader);
                    string ver = readed.Version = oJson["Version"].ToString();
                    string title = readed.WindowTitle = oJson["WindowTitle"].ToString();
                    string CustomJavaPath = readed.CustomJavaPath = oJson["CustomJavaPath"].ToString();
                    int minRamSize = readed.minRamSize = (int)oJson["minRamSize"];
                    int maxRamSize = readed.maxRamSize = (int)oJson["maxRamSize"];
                    this.minRamSize = minRamSize;
                    this.maxRamSize = maxRamSize;
                    string V = ver;
                }
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mw = new();
            mw.data.Content = "内核未导入:(";
        }

        private async void choosejvav_Click(object sender, RoutedEventArgs e)
        {
            var of = new OpenFileDialog();
            of.Filter = "jar file|*.jar";
            if (of.ShowDialog() == true)
            {
                try
                {
                    string corePath = System.IO.Path.GetFullPath(of.FileName);
                    string coreName = of.SafeFileName;
                    File.Copy(corePath, Environment.CurrentDirectory + "\\start.jar");
                    jvav.Text = coreName;
                }
                catch (Exception ex)
                {
                    await this.ShowMessageAsync(":(", ex.ToString(), MessageDialogStyle.AffirmativeAndNegative);
                }            
            }
        }

        private async void verify_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("start.jar"))
            {
                if (!File.Exists("eula.txt"))
                {
                    FileStream ff = File.Create("eula.txt");// 创建eula
                    string eula = "eula=true";
                    byte[] eulaB = System.Text.Encoding.Default.GetBytes(eula);
                    ff.Write(eulaB, 0, eulaB.Length);
                    ff.Close();
                }
                kaifu mw = new();
                string cmd = "start.cmd";
                FileStream fs = File.Create(cmd);
                if (mw.jvav.Text == "")
                {
                    if (mw.customcode.Text == "")
                    {
                        string eula = "java -Xms" + minRamSize + "m -Xmx" + maxRamSize + "m -jar start.jar -nogui \npause";
                        byte[] eulaB = System.Text.Encoding.Default.GetBytes(eula);
                        fs.Write(eulaB, 0, eulaB.Length);
                        fs.Close();
                        console c = new();
                        Close();
                        c.ShowDialog();
                    }
                    else
                    {
                        string eula = "java -Xms" + minRamSize + "m -Xmx" + maxRamSize + "m -jar start.jar " + mw.customcode.Text + "\npause";
                        byte[] eulaB = System.Text.Encoding.Default.GetBytes(eula);
                        fs.Write(eulaB, 0, eulaB.Length);
                        fs.Close();
                        console c = new();
                        Close();
                        c.ShowDialog();
                    }
                }
                else
                {
                    if (mw.customcode.Text == "")
                    {
                        string eula = '"' + mw.jvav.Text + '"' + " -Xms" + minRamSize + "m -Xmx" + maxRamSize + "m -jar start.jar -nogui \npause";
                        byte[] eulaB = System.Text.Encoding.Default.GetBytes(eula);
                        fs.Write(eulaB, 0, eulaB.Length);
                        fs.Close();
                        console c = new();
                        Close();
                        c.ShowDialog();
                    }
                    else
                    {
                        string eula = '"' + mw.jvav.Text + '"' + " -Xms" + minRamSize + "m -Xmx" + maxRamSize + "m -jar start.jar " + mw.customcode.Text + "\npause";
                        byte[] eulaB = System.Text.Encoding.Default.GetBytes(eula);
                        fs.Write(eulaB, 0, eulaB.Length);
                        fs.Close();
                        console c = new();
                        Close();
                        c.ShowDialog();
                    }
                }
            }
            else
            {
                await this.ShowMessageAsync(":(", "您的内核没了捏（", MessageDialogStyle.AffirmativeAndNegative);
            }
        }

        public static string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }
    }
}
