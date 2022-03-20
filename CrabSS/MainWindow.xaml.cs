using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ThirdParty.Json.LitJson;

namespace CrabSS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public class settinginfo//配置文件模块，用来读取用户个性化设置
    {
        public string Version { get; set; }
        public string WindowTitle { get; set; }
        public string ColorTheme { get; set; }
        public int minRamSize { get; set; }
        public int maxRamSize { get; set; }
        public string CustomJavaPath { get; set; }
        public bool isFrpOn { get; set; }
        public string background { get; set; }
    }
    public partial class MainWindow : MetroWindow
    {
        private const string V = "";
        private bool isFrpOn;

        /*public static string GetHttpResponse(string url, int Timeout)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = Timeout;

             HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }*/
        public MainWindow()
        {
            InitializeComponent();
            this.AllowsTransparency = true;
            mossfrp.Visibility = Visibility.Hidden;
            gefrp.Visibility = Visibility.Hidden;
            others.Visibility = Visibility.Hidden;
            try
            {
                String path = @"plugins";
                string[] files = Directory.GetFiles(path, "*.jar");
                foreach (string file in files)
                {
                    pluginlist.Items.Add(file);
                }
                counts.Content = pluginlist.Items.Count;
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync(":( 发生错误，但不是程序的错",ex.ToString());
            }
            try
            {
                servers.Text = string.Empty;
                StreamReader sr = new StreamReader("server.properties");
                servers.Text = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync(":( 发生错误，但不是程序的错", ex.ToString());
            }
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
                    oJson["Version"] = "0.15r2";
                    oJson["WindowTitle"] = "CrabSS Beta";
                    oJson["minRamSize"] = 512;
                    oJson["maxRamSize"] = 2048;
                    oJson["CustomJavaPath"] = "";
                    oJson["isFrpOn"] = false;
                    oJson["background"] = "default";
                    string strConvert = Convert.ToString(oJson); //将json装换为string
                    File.WriteAllText("settings.json", strConvert); //将内容写进json文件中
                    sw.Dispose();
                }
                catch (Exception ex)
                {
                    this.ShowMessageAsync(":( 出错了，但是是程序的错", ex.ToString());
                    this.Shutdown();
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
                        string ver = readed.Version = oJson["Version"].ToString();
                        string title = readed.WindowTitle = oJson["WindowTitle"].ToString();
                        string CustomJavaPath = readed.CustomJavaPath = oJson["CustomJavaPath"].ToString();
                        int minRamSize = readed.minRamSize;
                        int maxRamSize = readed.maxRamSize;
                        string background = readed.background;
                        bool isFrpOn = readed.isFrpOn;
                        string V = ver;
                        reader.Close();
                        min.Value = minRamSize;
                        max.Value = maxRamSize;
                        jvav.Text = CustomJavaPath;
                       /** bg.Text = background;
                       if (background != "default"){
                            MainWindow mw = new();
                            mw.Background = Background;
                        }**/
                        this.Title = title;
                        if (isFrpOn == true)
                        {
                            mainer.IsEnabled = true;
                        }
                        else
                        {
                            mainer.IsEnabled = false;
                        }
                    }
                    string F = V;
                }
            }
            /*string version = GetHttpResponse("https://v6.crabapi.cn/api/crabss/version?channel=beta",3200);
            string hikotoko = GetHttpResponse("https://v1.hitokoto.cn/?encode=text",1600);
            hitokoto.Content = hikotoko;
            version_online.Content = "联网版本号["+version+"]";
            content.Content = GetHttpResponse("https://v6.crabapi.cn/api/crabss/broadcast?channel=beta&encode=text",1600);
            min.Value = 128;
            max.Minimum = (double)min.Value;
            loading.Visibility = Visibility.Hidden;*/
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            你被骗了 rickroll = new();
            rickroll.Show();
        }
        private void add_Click(object sender, RoutedEventArgs e)
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
                    counts.Content = pluginlist.Items.Count;
                    this.ShowMessageAsync("成功", "插件已复制到plugins目录");
                }
            }
            catch(Exception ex)
            {
                this.ShowMessageAsync(":( 出错了，但是是程序的错", ex.ToString());
            }           
        }

        private void choosejvav_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "应用程序|*.exe";
            if (fileDialog.ShowDialog() == true)
            {
                jvav.Text = fileDialog.FileName;
            }
        }
        public async void frpon(object sender, RoutedEventArgs e)
        {
            if (frp.IsOn == true)
            {
                MessageDialogResult messageDialogResult = await this.ShowMessageAsync("在开启内网映射服务之前你需要知道的", "除了GeFrp以外的任何Frp服务均不由 Crab Studio 监视或控制。\n在您使用这些服务的时候，您应遵守服务商的许可协议。\n保护好自己！不要用不知名的Frp服务，以防数据泄露！", MessageDialogStyle.AffirmativeAndNegative);
                if (messageDialogResult == MessageDialogResult.Negative)
                {
                    mainer.IsEnabled = false;
                    frp.IsOn = false;
                    return;
                }
                else
                {
                    try
                    {
                        settinginfo settings = new settinginfo();
                        string json = JsonMapper.ToJson(settings); //using LitJson
                        StreamWriter sw = new StreamWriter(System.Environment.CurrentDirectory + "\\settings.json");
                        sw.Write(json);
                        sw.Close();
                        string strJson = File.ReadAllText("settings.json", Encoding.UTF8);
                        JObject oJson = JObject.Parse(strJson); //using Newtonsoft.Json.Linq
                        oJson["Version"] = "0.15r2";
                        oJson["WindowTitle"] = "CrabSS Beta";
                        oJson["minRamSize"] = (int)min.Value;
                        oJson["maxRamSize"] = (int)max.Value;
                        oJson["CustomJavaPath"] = jvav.Text;
                        oJson["isFrpOn"] = true;
                        string strConvert = Convert.ToString(oJson); //将json装换为string
                        File.WriteAllText("settings.json", strConvert); //将内容写进json文件中
                        sw.Dispose();
                        mainer.IsEnabled = true;
                    }
                    catch (Exception ex)
                    {
                        await this.ShowMessageAsync(":( 出错了，但是是程序的错", ex.ToString());
                        System.Windows.Application app = new System.Windows.Application();
                        app.Shutdown();
                    }
                }
            }
            else
            {
                try
                {
                    settinginfo settings = new settinginfo();
                    string json = JsonMapper.ToJson(settings); //using LitJson
                    StreamWriter sw = new StreamWriter(System.Environment.CurrentDirectory + "\\settings.json");
                    sw.Write(json);
                    sw.Close();
                    string strJson = File.ReadAllText("settings.json", Encoding.UTF8);
                    JObject oJson = JObject.Parse(strJson); //using Newtonsoft.Json.Linq
                    oJson["Version"] = "0.15r2";
                    oJson["WindowTitle"] = "CrabSS Beta";
                    oJson["minRamSize"] = (int)min.Value;
                    oJson["maxRamSize"] = (int)max.Value;
                    oJson["CustomJavaPath"] = jvav.Text;
                    oJson["isFrpOn"] = false;
                    string strConvert = Convert.ToString(oJson); //将json装换为string
                    File.WriteAllText("settings.json", strConvert); //将内容写进json文件中
                    sw.Dispose();
                    mainer.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    await this.ShowMessageAsync(":( 出错了，但是是程序的错", ex.ToString());
                    System.Windows.Application app = new System.Windows.Application();
                    app.Shutdown();
                }
            }          
        }
        private async void start_Click(object sender, RoutedEventArgs e)
        {
            if (min.Value != null && max.Value != null)
            {
                    loading.Visibility = Visibility.Visible;
                    data.Content = "正在等待内核导入";
                    AddCore core = new();
                    core.Show();
                try
                {
                    settinginfo settings = new settinginfo();
                    string json = JsonMapper.ToJson(settings); //using LitJson
                    StreamWriter sw = new StreamWriter(System.Environment.CurrentDirectory + "\\settings.json");
                    sw.Write(json);
                    sw.Close();
                    string strJson = File.ReadAllText("settings.json", Encoding.UTF8);
                    JObject oJson = JObject.Parse(strJson); //using Newtonsoft.Json.Linq
                    oJson["Version"] = "0.15r2";
                    oJson["WindowTitle"] = "CrabSS Beta";
                    oJson["minRamSize"] = (int)min.Value;
                    oJson["maxRamSize"] = (int)max.Value;
                    oJson["CustomJavaPath"] = jvav.Text;
                    oJson["isFrpOn"] = false;
                    string strConvert = Convert.ToString(oJson); //将json装换为string
                    File.WriteAllText("settings.json", strConvert); //将内容写进json文件中
                    sw.Dispose();
                }
                catch (Exception ex)
                {
                    await this.ShowMessageAsync(":( 出错了，但是是程序的错", ex.ToString());
                    System.Windows.Application app = new System.Windows.Application();
                    app.Shutdown();
                }
            }
            else
            {
               await this.ShowMessageAsync(":( 出错了，但不是程序的错", "宁的内存无了捏（");
            }
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
        private async void DialogsBeforeExit()
        {
            MessageDialogResult result = await this.ShowMessageAsync(this.Title, "确定退出 CrabSS 吗？", MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Negative)
            {
                return;
            }
            else//确认退出
            {
                this.Shutdown();
            }
        }

        private void Shutdown()
        {
            this.Close();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
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
                counts.Content = pluginlist.Items.Count;
                this.ShowMessageAsync("成功", "已刷新插件列表");
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync(":( 发生错误，但不是程序的错", ex.ToString());
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("server.properties");
            sw.WriteLine(servers.Text);
            sw.Close();
            this.ShowMessageAsync("成功", "文件已保存");
        }

        private void reload_Click(object sender, RoutedEventArgs e)
        {
            servers.Text = string.Empty;
            StreamReader sr = new StreamReader("server.properties");
            servers.Text = sr.ReadToEnd();
            sr.Close();
        }
        int sakura = 0;
        int moss = 0;
        int ge = 0;
        int other = 0;
        private void SakuraFrp_Checked(object sender, RoutedEventArgs e)
        {
            if(sakura == 0)
            {
                moss = 0;
                ge = 0;
                other = 0;
                error.Visibility = Visibility.Visible;
                sakura = 1;
            }
        }

        private void MossFrp_Checked(object sender, RoutedEventArgs e)
        {
            sakura = 0;
            moss = 1;
            ge = 0;
            other = 0;
            error.Visibility = Visibility.Hidden;
            mossfrp.Visibility = Visibility.Visible;
            gefrp.Visibility = Visibility.Hidden;
            others.Visibility = Visibility.Hidden;
        }

        private void GeFrp_Checked(object sender, RoutedEventArgs e)
        {
            sakura = 0;
            moss = 0;
            ge = 1;
            other = 0;
            error.Visibility = Visibility.Hidden;
            mossfrp.Visibility = Visibility.Hidden;
            gefrp.Visibility = Visibility.Visible;
            others.Visibility = Visibility.Hidden;
        }

        private void Other_Checked(object sender, RoutedEventArgs e)
        {
            sakura = 0;
            moss = 0;
            ge = 0;
            other = 1;
            error.Visibility = Visibility.Hidden;
            mossfrp.Visibility = Visibility.Hidden;
            gefrp.Visibility = Visibility.Hidden;
            others.Visibility = Visibility.Visible;
        }
    }
}
