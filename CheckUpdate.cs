using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CrabMCSM.Form1;
using static System.Net.WebRequestMethods;

namespace CrabMCSM
{
    public partial class CheckUpdate : Form
    {
        public CheckUpdate()
        {
            InitializeComponent();
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
        private void CheckUpdate_Load(object sender, EventArgs e)
        {
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
            settinginfo readed = new settinginfo();
            using (StreamReader readFile = System.IO.File.OpenText("settings.json"))
            {
                using (JsonTextReader reader = new JsonTextReader(readFile)) //using Newtonsoft.Json
                {
                    JObject oJson = (JObject)JToken.ReadFrom(reader);
                    string version = readed.Version = oJson["Version"].ToString();
                    if (httpGet("https://www.crabapi.cn/api/v5/crabss/update/getVersion") != version)
                    {
                        //try {
                            label1.Text = "正在下载更新";
                            MessageBox.Show("发现新版本！\n最新版本：" + httpGet("https://www.crabapi.cn/api/v5/crabss/update/getVersion") + "\n更新内容：" + httpGet("https://www.crabapi.cn/api/v5/crabss/update/getUpdateLog") + "\n即将开始更新！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            HttpDownloadFile("https://cdn.heycrab.xyz/staticFile/crabss_updatefile/temp_crabss.exe", Environment.CurrentDirectory + "\\temp_crabss.exe");
                            HttpDownloadFile("https://www.crabapi.cn/api/v5/crabss/update/getUpdateScript/update.cmd", Environment.CurrentDirectory + "\\update.cmd");
//                         HttpDownloadFile("https://www.crabapi.cn/api/v5/crabss/update/getUpdateScript/settings.json", Environment.CurrentDirectory + "\\settings.json");
                            label1.Text = "正在关闭应用";
                            Process.Start("C:\\Windows\\system32\\taskkill.exe","-f -im CrabSS.exe");
                            Application.Exit();
                            Process.Start("update.cmd");
                        //}                            
                        /**catch
                        {
                            MessageBox.Show("网络异常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                            Close();
                        }*/
                    }
                    else
                    {
                        System.IO.File.Delete("update.cmd");
                        MessageBox.Show("当前已是最新版本", "提示", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        label1.Text = "当前已是最新版本";
                        Close();
                    }
                }
            }
        }
    }
}
