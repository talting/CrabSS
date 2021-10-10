using Catel.Services;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThirdParty.Json.LitJson;
using System.Management;
using System.Diagnostics;

namespace CrabSSWPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string V = "";
        private string version;

        public class settinginfo//配置文件模块，用来读取用户个性化设置
        {
            public string Version { get; set; }
            public string WindowTitle { get; set; }
            public string ColorTheme { get; set; }
            public string minRamSize { get; set; }
            public string maxRamSize { get; set; }
            public string IsCustomJavaSeted { get; set; }
            public string CustomJavaPath { get; set; }
        }
        private static string GetPhisicalMemory()
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                st = mo["TotalPhysicalMemory"].ToString();
            }
            return st;
        }

        public static long GetAvailablePhysicalMemory()
        {
            long capacity = 0;
            try
            {
                foreach (ManagementObject mo1 in new ManagementClass("Win32_PerfFormattedData_PerfOS_Memory").GetInstances())
                    capacity += long.Parse(mo1.Properties["AvailableBytes"].Value.ToString());
            }
            catch (Exception ex)
            {
                capacity = -1;
            }
            return capacity;
        }
        public MainWindow()
        {
            if (!File.Exists("settings.json"))
            {//初始化Json部分
                try
                {
                    settinginfo settings = new settinginfo();
                    string json = JsonMapper.ToJson(settings); //using LitJson
                    StreamWriter sw = new StreamWriter(System.Environment.CurrentDirectory + "\\settings.json");
                    sw.Write(json);
                    sw.Close();
                    string strJson = File.ReadAllText("settings.json", Encoding.UTF8);
                    JObject oJson = JObject.Parse(strJson); //using Newtonsoft.Json.Linq
                    oJson["Version"] = "0.14";
                    oJson["WindowTitle"] = "CrabSS | Crab MCServer Starter";
                    oJson["minRamSize"] = "512";
                    oJson["maxRamSize"] = "2048";
                    oJson["IsCustomJavaSeted"] = "false";
                    oJson["CustomJavaPath"] = "";
                    string strConvert = Convert.ToString(oJson); //将json装换为string
                    File.WriteAllText("settings.json", strConvert); //将内容写进json文件中
                    sw.Dispose();
                }
                catch (UnauthorizedAccessException)
                {
                    System.Windows.MessageBox.Show("无法生成配置文件\nUnauthorizedAccessException:对路径" + System.Environment.CurrentDirectory + " 的访问被拒绝。\n程序即将退出。", "关键错误", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Hand, (MessageBoxResult)MessageBoxDefaultButton.Button2);
                    System.Windows.Application app = new System.Windows.Application();
                    this.Close();
                }
            }
            else
            {
                settinginfo readed = new settinginfo();
                using (StreamReader readFile = File.OpenText("settings.json"))
                {
                    using (JsonTextReader reader = new JsonTextReader(readFile)) //using Newtonsoft.Json
                    {
                        JObject oJson = (JObject)JToken.ReadFrom(reader);
                        string version = readed.Version = oJson["Version"].ToString();
                        string title = readed.WindowTitle = oJson["WindowTitle"].ToString();
                        string minRamSize = readed.minRamSize = oJson["minRamSize"].ToString();
                        string maxRamSize = readed.maxRamSize = oJson["maxRamSize"].ToString();
                        string IsCustomJavaSeted = readed.IsCustomJavaSeted = oJson["IsCustomJavaSeted"].ToString();
                        string CustomJavaPath = readed.CustomJavaPath = oJson["CustomJavaPath"].ToString();
                        string V = version;
                        reader.Close();
                    }
                    string F = V;
                }
            }
            InitializeComponent();
            broadcast.Content = httpGet("https://www.crabapi.cn/api/v5/crabss/data/getData");
        }
        public static string HttpDownloadFile(string url, string path)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            //创建本地文件写入流
            Stream stream = new FileStream(path, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            return path;
        }
        static string httpGet(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
        private void SmartAllot_Checked(object sender, RoutedEventArgs e)
        {
            maxram.IsEnabled = false;
            minram.IsEnabled = false;
        }

        private void Customize_Checked(object sender, RoutedEventArgs e)
        {
            maxram.IsEnabled = true;
            minram.IsEnabled = true;
        }

        private void DJava_Checked(object sender, RoutedEventArgs e)
        {
            JRoute.IsEnabled = false;
        }

        private void maxram_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void minram_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CJava_Checked(object sender, RoutedEventArgs e)
        {
            JRoute.IsEnabled = true;
            ChooseJava.IsEnabled = true;
        }

        private void JRoute_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void enabled_custom_start_code_Checked(object sender, RoutedEventArgs e)
        {
            csc.IsEnabled = true;

        }

        private void enabled_start_jar_name_Checked(object sender, RoutedEventArgs e)
        {
            csn.IsEnabled = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ChooseJava_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Filter = "可执行程序文件 (*.exe)|*.exe";
            if (fileDialog.ShowDialog() == true)
            {
                JRoute.Text = fileDialog.FileName;
            }
        }

        private void pro_Click(object sender, RoutedEventArgs e)
        {
            ProperitesUpdater pr = new ProperitesUpdater();
            pr.ShowDialog();
        }

        private void plugin_Click(object sender, RoutedEventArgs e)
        {
            Plugins plugin = new Plugins();
            plugin.ShowDialog();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        /**
         * string[] lines =
    {
        "First line", "Second line", "Third line" 
    };

    await File.WriteAllLinesAsync("WriteLines.txt", lines);
         * **/
        {
            if (DJava.IsChecked == true)
            {
                if (SmartAllot.IsChecked == true)
                {
                    float ram = GetAvailablePhysicalMemory();
                    if (enabled_start_jar_name.IsChecked == true)
                    {
                        if (csc.Text != "")
                        {
                            if (enabled_custom_start_code.IsChecked == true)
                            {
                                if (csn.Text != "")
                                {
                                    string[] lines =
                                    {
                                        "java -Xms"+ram / 5+"M -Xmx"+ram+"M -jar "+csc.Text + " " + csn.Text
                                    };
                                    File.WriteAllLinesAsync("start.cmd", lines);
                                    Console cons = new Console();
                                    cons.Show();
                                }
                                else
                                {
                                    System.Windows.MessageBox.Show("？宁的自定义值是空的", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                                }
                            }
                            else
                            {
                                string[] lines =
                                    {
                                        "java -Xms"+ram / 5+"M -Xmx"+ram+"M -jar start.jar"+ " " + csn.Text
                                    };
                                File.WriteAllLinesAsync("start.cmd", lines);
                                Console cons = new Console();
                                cons.Show();
                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("？宁的自定义参数是空气", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        if (enabled_custom_start_code.IsChecked == true)
                        {
                            if (csn.Text != "")
                            {
                                string[] lines =
                                {
                                        "java -Xms"+ram / 5+"M -Xmx"+ram+"M -jar "+csc.Text
                                    };
                                File.WriteAllLinesAsync("start.cmd", lines);
                                Console cons = new Console();
                                cons.Show();
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("？宁的自定义值是空的", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                            }
                        }
                        else
                        {
                            string[] lines =
                                {
                                        "java -Xms"+ram / 5+"M -Xmx"+ram+"M -jar start.jar"
                                    };
                            File.WriteAllLinesAsync("start.cmd", lines);
                            Console cons = new Console();
                            cons.Show();
                        }
                    }
                }
                else
                {
                    if (enabled_custom_start_code.IsChecked == true)
                    {
                        if (csn.Text != "")
                        {
                            if (enabled_start_jar_name.IsChecked == true)
                            {
                                if (csc.Text != "")
                                {
                                    if (enabled_custom_start_code.IsChecked == true)
                                    {
                                        if (csn.Text != "")
                                        {
                                            string[] lines =
                                            {
                                        "java -Xms"+minram.Text+"M -Xmx"+maxram.Text+"M -jar "+csc.Text + " " + csn.Text
                                    };
                                            File.WriteAllLinesAsync("start.cmd", lines);
                                            Console cons = new Console();
                                            cons.Show();
                                        }
                                        else
                                        {
                                            System.Windows.MessageBox.Show("？宁的自定义值是空的", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                                        }
                                    }
                                    else
                                    {
                                        string[] lines =
                                            {
                                        "java -Xms"+minram.Text+"M -Xmx"+maxram.Text+"M -jar start.jar"+ " " + csn.Text
                                    };
                                        File.WriteAllLinesAsync("start.cmd", lines);
                                        Console cons = new Console();
                                        cons.Show();
                                    }
                                }
                                else
                                {
                                    System.Windows.MessageBox.Show("？宁的自定义参数是空气", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                                }
                            }
                            else
                            {
                                if (enabled_custom_start_code.IsChecked == true)
                                {
                                    if (csn.Text != "")
                                    {
                                        string[] lines =
                                        {
                                        "java -Xms"+minram.Text+"M -Xmx"+maxram.Text+"M -jar "+csc.Text
                                    };
                                        File.WriteAllLinesAsync("start.cmd", lines);
                                        Console cons = new Console();
                                        cons.Show();
                                    }
                                    else
                                    {
                                        System.Windows.MessageBox.Show("？宁的自定义值是空的", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                                    }
                                }
                                else
                                {
                                    string[] lines =
                                        {
                                        "java -Xms"+minram.Text+"M -Xmx"+maxram.Text+"M -jar start.jar"
                                    };
                                    File.WriteAllLinesAsync("start.cmd", lines);
                                    Console cons = new Console();
                                    cons.Show();
                                }
                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("？宁的自定义值是空的", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        string[] lines =
                                        {
                                        "java -Xms"+minram.Text+"M -Xmx"+maxram.Text+"M -jar start.jar"
                                    };
                        File.WriteAllLinesAsync("start.cmd", lines);
                        Console cons = new Console();
                        cons.Show();
                    }
                }
            }
            else if (CJava.IsChecked == true)
            {
                if (enabled_start_jar_name.IsChecked == true)
                {
                    if (csc.Text != "")
                    {
                        if (SmartAllot.IsChecked == true)
                        {
                            float ram = GetAvailablePhysicalMemory();
                            if (enabled_start_jar_name.IsChecked == true)
                            {
                                if (csc.Text != "")
                                {
                                    if (enabled_custom_start_code.IsChecked == true)
                                    {
                                        if (csn.Text != "")
                                        {
                                            string[] lines =
                                            {
                                        "java -Xms"+ram / 5+"M -Xmx"+ram+"M -jar "+csc.Text + " " + csn.Text
                                    };
                                            File.WriteAllLinesAsync("start.cmd", lines);
                                            Console cons = new Console();
                                            cons.Show();
                                        }
                                        else
                                        {
                                            System.Windows.MessageBox.Show("？宁的自定义值是空的", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                                        }
                                    }
                                    else
                                    {
                                        string[] lines =
                                            {
                                        "java -Xms"+ram / 5+"M -Xmx"+ram+"M -jar start.jar"+ " " + csn.Text
                                    };
                                        File.WriteAllLinesAsync("start.cmd", lines);
                                        Console cons = new Console();
                                        cons.Show();
                                    }
                                }
                                else
                                {
                                    System.Windows.MessageBox.Show("？宁的自定义参数是空气", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                                }
                            }
                            else
                            {
                                if (enabled_custom_start_code.IsChecked == true)
                                {
                                    if (csn.Text != "")
                                    {
                                        string[] lines =
                                        {
                                        "java -Xms"+ram / 5+"M -Xmx"+ram+"M -jar "+csc.Text
                                    };
                                        File.WriteAllLinesAsync("start.cmd", lines);
                                        Console cons = new Console();
                                        cons.Show();
                                    }
                                    else
                                    {
                                        System.Windows.MessageBox.Show("？宁的自定义值是空的", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                                    }
                                }
                                else
                                {
                                    string[] lines =
                                        {
                                        "java -Xms"+ram / 5+"M -Xmx"+ram+"M -jar start.jar"
                                    };
                                    File.WriteAllLinesAsync("start.cmd", lines);
                                    Console cons = new Console();
                                    cons.Show();
                                }
                            }
                        }
                        else
                        {
                            if (enabled_custom_start_code.IsChecked == true)
                            {
                                if (csn.Text != "")
                                {
                                    if (enabled_start_jar_name.IsChecked == true)
                                    {
                                        if (csc.Text != "")
                                        {
                                            if (enabled_custom_start_code.IsChecked == true)
                                            {
                                                if (csn.Text != "")
                                                {
                                                    string[] lines =
                                                    {
                                        "java -Xms"+minram.Text+"M -Xmx"+maxram.Text+"M -jar "+csn.Text + " " + csc.Text
                                    };
                                                    File.WriteAllLinesAsync("start.cmd", lines);
                                                    Console cons = new Console();
                                                    cons.Show();
                                                }
                                                else
                                                {
                                                    System.Windows.MessageBox.Show("？宁的自定义值是空的", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                                                }
                                            }
                                            else
                                            {
                                                string[] lines =
                                                    {
                                        "java -Xms"+minram.Text+"M -Xmx"+maxram.Text+"M -jar start.jar"+ " " + csn.Text
                                    };
                                                File.WriteAllLinesAsync("start.cmd", lines);
                                                Console cons = new Console();
                                                cons.Show();
                                            }
                                        }
                                        else
                                        {
                                            System.Windows.MessageBox.Show("？宁的自定义参数是空气", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                                        }
                                    }
                                    else
                                    {
                                        if (enabled_custom_start_code.IsChecked == true)
                                        {
                                            if (csn.Text != "")
                                            {
                                                string[] lines =
                                                {
                                        "java -Xms"+minram.Text+"M -Xmx"+maxram.Text+"M -jar "+csc.Text
                                    };
                                                File.WriteAllLinesAsync("start.cmd", lines);
                                                Console cons = new Console();
                                                cons.Show();
                                            }
                                            else
                                            {
                                                System.Windows.MessageBox.Show("？宁的自定义值是空的", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                                            }
                                        }
                                        else
                                        {
                                            string[] lines =
                                                {
                                        "java -Xms"+minram.Text+"M -Xmx"+maxram.Text+"M -jar start.jar"
                                    };
                                            File.WriteAllLinesAsync("start.cmd", lines);
                                            Console cons = new Console();
                                            cons.Show();
                                        }
                                    }
                                }
                                else
                                {
                                    System.Windows.MessageBox.Show("？宁的自定义值是空的", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                                }
                            }
                            else
                            {
                                string[] lines =
                                                {
                                        "java -Xms"+minram.Text+"M -Xmx"+maxram.Text+"M -jar start.jar"
                                    };
                                File.WriteAllLinesAsync("start.cmd", lines);
                                Console cons = new Console();
                                cons.Show();
                            }
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("？宁的自定义参数是空气", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("？宁的Jvav好像没了捏", "出错了，但不是程序的错（", (MessageBoxButton)MessageBoxDefaultButton.Button1, MessageBoxImage.Warning);
            }
        }
    }
}
        //https://login2.nide8.com:233/index/jar