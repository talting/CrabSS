/**
 * 灵启引擎相关模块
 * 测试版本
 * 许可证：GNU
 * :)
 */
using LitJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrabSS
{
    internal class lingqi
    {
        public MainWindow mw = new();
        public class settinginfo //把我整不会了😅
        {
        }

        public static string DecodeCrabDriveShareLink(string sharelink) {
            return "";
        }
        public static string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            #region 添加Post 参数
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;

        }
        public static string GetHttpResponse(string url, int Timeout)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = Timeout;

            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Stream myResponseStream = response.GetResponseStream();
            //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            //string retString = myStreamReader.ReadToEnd();
            //myStreamReader.Close();
            //myResponseStream.Close();

            return "屑螃蟹，代码，屎山（）";
        }
        //新服务器创建模块
        /**public void createnewserver(string path)
        {
            CreateNewServer c = new();
            if (File.Exists("settings.json"))
            {
                settinginfo readed = new settinginfo();
                using (StreamReader readFile = File.OpenText("settings.json"))
                {
                    using (JsonTextReader reader = new JsonTextReader(readFile)) //using Newtonsoft.Json
                    {
                        JObject oJson = (JObject)JToken.ReadFrom(reader);
                        string title = readed.WindowTitle = oJson["WindowTitle"].ToString();
                        string Server1 = readed.Server1 = oJson["Server1"].ToString();
                        string Server2 = readed.Server2 = oJson["Server2"].ToString();
                        string Server3 = readed.Server3 = oJson["Server3"].ToString();
                        string Server4 = readed.Server4 = oJson["Server4"].ToString();
                        string Server5 = readed.Server5 = oJson["Server5"].ToString();
                        reader.Close();
                        try
                        {
                            settinginfo settings = new settinginfo();
                            string json = JsonMapper.ToJson(settings); //using LitJson
                            StreamWriter sw = new StreamWriter(System.Environment.CurrentDirectory + "\\settings.json");
                            sw.Write(json);
                            sw.Close();
                            string strJson = File.ReadAllText("settings.json", Encoding.UTF8);
                            if (c.servernum.SelectedIndex == 0)
                            {                            
                                oJson["WindowTitle"] = "CrabSS | 服务器管理中心";
                                oJson["Server1"] = path;
                                oJson["Server2"] = Server2;
                                oJson["Server3"] = Server3;
                                oJson["Server4"] = Server4;
                                oJson["Server5"] = Server5;
                                string strConvert = Convert.ToString(oJson); //将json装换为string
                                File.WriteAllText("settings.json", strConvert); //将内容写进json文件中
                                sw.Dispose();
                            }
                            else if (c.servernum.SelectedIndex == 1)
                            {
                                oJson["WindowTitle"] = "CrabSS | 服务器管理中心";
                                oJson["Server1"] = Server1;
                                oJson["Server2"] = path;
                                oJson["Server3"] = Server3;
                                oJson["Server4"] = Server4;
                                oJson["Server5"] = Server5;
                                string strConvert = Convert.ToString(oJson); //将json装换为string
                                File.WriteAllText("settings.json", strConvert); //将内容写进json文件中
                                sw.Dispose();
                            }
                            else if (c.servernum.SelectedIndex == 2)
                            {
                                oJson["WindowTitle"] = "CrabSS | 服务器管理中心";
                                oJson["Server1"] = Server1;
                                oJson["Server2"] = Server2;
                                oJson["Server3"] = path;
                                oJson["Server4"] = Server4;
                                oJson["Server5"] = Server5;
                                string strConvert = Convert.ToString(oJson); //将json装换为string
                                File.WriteAllText("settings.json", strConvert); //将内容写进json文件中
                                sw.Dispose();
                            }
                            else if (c.servernum.SelectedIndex == 3)
                            {
                                oJson["WindowTitle"] = "CrabSS | 服务器管理中心";
                                oJson["Server1"] = Server1;
                                oJson["Server2"] = Server2;
                                oJson["Server3"] = Server3;
                                oJson["Server4"] = path;
                                oJson["Server5"] = Server5;
                                string strConvert = Convert.ToString(oJson); //将json装换为string
                                File.WriteAllText("settings.json", strConvert); //将内容写进json文件中
                                sw.Dispose();
                            }
                            else if (c.servernum.SelectedIndex == 4)
                            {
                                oJson["WindowTitle"] = "CrabSS | 服务器管理中心";
                                oJson["Server1"] = Server1;
                                oJson["Server2"] = Server2;
                                oJson["Server3"] = Server3;
                                oJson["Server4"] = Server4;
                                oJson["Server5"] = path;
                                string strConvert = Convert.ToString(oJson); //将json装换为string
                                File.WriteAllText("settings.json", strConvert); //将内容写进json文件中
                                sw.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("宁耍猴？", "🤬😅", MessageBoxButton.OK, MessageBoxImage.Hand);
                            }
                            mw.serverlist.Items.Clear();
                            using (StreamReader redFile = File.OpenText("settings.json"))
                            {
                                using (JsonTextReader reder = new JsonTextReader(redFile)) //using Newtonsoft.Json
                                {
                                    reder.Close();
                                    mw.serverlist.Items.Add(Server1);
                                    mw.serverlist.Items.Add(Server2);
                                    mw.serverlist.Items.Add(Server3);
                                    mw.serverlist.Items.Add(Server4);
                                    mw.serverlist.Items.Add(Server5);
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("发生错误：" + ex.ToString(), "有一些不好的事情发生了....", MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("settings.json文件不存在", "Nope", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }**/
    }
}
