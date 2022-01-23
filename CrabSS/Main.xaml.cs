﻿using LitJson;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Toolkit.Uwp.Notifications;
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
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : MetroWindow
    {
        public Main()
        {
            InitializeComponent();
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
                    Close();
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
                        /** bg.Text = background;
                        if (background != "default"){
                             MainWindow mw = new();
                             mw.Background = Background;
                         }**/
                    }
                }
                broadcast.Content = lingqi.GetHttpResponse("https://v6.crabapi.cn/api/crabss/broadcast?channel=beta&encode=text", 1600);
                string version = lingqi.GetHttpResponse("https://v6.crabapi.cn/api/crabss/version?channel=beta", 3200);
                string hikotoko = lingqi.GetHttpResponse("https://v1.hitokoto.cn/?encode=text", 1600);
                Title = "CrabSS 总控中心 | " + hikotoko;
                version_online.Content = "联网版本号[" + version + "]";
                // Requires Microsoft.Toolkit.Uwp.Notifications NuGet package version 7.0 or greater
                try
                {
                    String path = @"plugins";
                    string[] files = Directory.GetFiles(path, "*.jar");
                    int i = 0;
                    foreach (string file in files)
                    {
                        i++;
                    }
                    plugins.Title = $"插件管理 | 总数{i.ToString()}";
                }
                catch (Exception ex)
                {
                    this.ShowMessageAsync(":( 发生错误，但不是程序的错", ex.ToString());
                }
               string ver2 = lingqi.GetHttpResponse("https://v6.crabapi.cn/api/crabss/version?channel=beta", 3200);
            }
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            你被骗了 rickroll = new();
            rickroll.Show();
        }

        private void server_Click(object sender, RoutedEventArgs e)
        {
            kaifu kaifu = new();
            kaifu.Show();
        }

        private void plugins_Click(object sender, RoutedEventArgs e)
        {
            plugins p = new();
            p.Show();   
        }

        private void peanutio_Click(object sender, RoutedEventArgs e)
        {
            peanutio p = new();
            p.ShowDialog();
        }

        private void old_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new();
            mw.Show();
        }
    }
}
