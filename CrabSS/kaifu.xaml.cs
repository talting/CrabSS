using LitJson;
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
    /// kaifu.xaml 的交互逻辑
    /// </summary>
    public partial class kaifu : MetroWindow
    {
        public kaifu()
        {
            InitializeComponent();
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
                }
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
        private async void start_Click(object sender, RoutedEventArgs e)
        {
            if (min.Value != null && max.Value != null)
            {
                Close();
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
    }
}
