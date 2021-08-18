/*
 * Hi,旅行者。
 * 当你看着这个注释时，
 * 说明你很幸运，发现了这个彩蛋
 * 请 好 好 的 看 着 我
 * 我要说——————————
 * 派蒙可以当作应急食品。
 */
/*
 * 许可协议：GNU General Public License 3.0
* 文件名称: Form1.cs
* 创建者: @是螃蟹aaaaa
* 创建日期: 2021 / 08 /12
* 最后编辑日期: 2021 / 08 /15
* 编译环境: .NET FrameWork 4.5(Visual Studio 2022)、Windows 11 （10.0.22000.120）
* 注:禁止商业用途
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using LitJson;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;

namespace CrabMCSM
{
    public partial class Form1 : MaterialForm
    {

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
        public Form1()//主程序部分
        {
            InitializeComponent();
            MaterialSkinManager skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(Primary.Indigo400, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Blue400, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)//初始化主页面
        {
            if (!File.Exists("settings.json"))
            {//初始化Json部分
                try
                {
                    settinginfo settings = new settinginfo();
                    string json = JsonMapper.ToJson(settings); //using LitJson
                    StreamWriter sw = new StreamWriter(System.Environment.CurrentDirectory);
                    sw.Write(json);
                    sw.Close();
                    string strJson = File.ReadAllText("settings.json", Encoding.UTF8);
                    JObject oJson = JObject.Parse(strJson); //using Newtonsoft.Json.Linq
                    oJson["Version"] = "0.13a2";
                    oJson["WindowTitle"] = "CrabSS | Crab MCServer Starter";
                    oJson["minRamSize"] = "512";
                    oJson["maxRamSize"] = "2048";
                    oJson["IsCustomJavaSeted"] = "false";
                    oJson["CustomJavaPath"] = "";
                    string strConvert = Convert.ToString(oJson); //将json装换为string
                    File.WriteAllText("settings.json", strConvert); //将内容写进json文件中
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("无法生成配置文件\nUnauthorizedAccessException:对路径" + System.Environment.CurrentDirectory + " 的访问被拒绝。\n程序将继续执行，但非常不建议您继续使用，因为无法保存你的更改。", "关键错误", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
                    Application.Exit();
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
                        groupBox1.Text = "版本公告 版本：" + version;
                        Form1 f = new Form1();
                        f.Text = title;
                        decimal min = decimal.Parse(minRamSize);
                        decimal max = decimal.Parse(maxRamSize);
                        numericUpDown1.Value = min;
                        numericUpDown2.Value = max;
                        if (IsCustomJavaSeted == "false")
                        {
                            DefaultJavaChosed.Checked = true;
                        }
                        else if (IsCustomJavaSeted == "true")
                        {
                            UseYourOwnJava.Checked = true;
                        }
                        if (CustomJavaPath != "")
                        {
                            JavaRoute.Text = CustomJavaPath;
                        }
                    }
                }
            }
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Committed Bytes");
            float ram = ramCounter.NextValue();
            numericUpDown2.Maximum = (decimal)(ram / 2);
            label1.Text = "最大可分配的 Ram ：" + ram / 1048576 + "MB";
            if (UseYourOwnJava.Checked == true)
            {
                JavaRoute.Enabled = true;
                JavaFile.Enabled = true;
            }
            else
            {
                JavaRoute.Enabled = false;
                JavaFile.Enabled = false;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 退出_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void materialRaisedButton1_Click_1(object sender, EventArgs a)//密恐慎入！if套娃
        {
            if (UseYourOwnJava.Checked == true)
            {
                if (JavaRoute.Text == "你的 Java 路径（请去掉我）" ){
                    MessageBox.Show("你填了个空路径？？？", "¿", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
                else if (DefaultJavaChosed.Checked == true)
                {
                    if (!File.Exists("Start.jar"))//检查核心是否存在
                    {
                        MessageBox.Show("核心不存在，请检查核心文件名是否正确！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }
                    else if (JavaRoute.Text == "")
                    {
                        MessageBox.Show("你填了个空路径？？？", "¿", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }
                    else if (UseYourOwnJava.Checked == false)
                    {
                        if (numericUpDown1.Value >= numericUpDown2.Value)// 检查最小内存值是否大于最大内存值（如果大于会报错）
                        {
                            MessageBox.Show("最小内存值不能超过最大内存值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                        }
                        else
                        {
                            if (!File.Exists("eula.txt"))
                            {
                                //MessageBox.Show(filePath + "  not exists!");
                                FileStream fs = File.Create("eula.txt");// 创建eula
                                string eula = "eula=true";
                                byte[] eulaB = System.Text.Encoding.Default.GetBytes(eula);
                                fs.Write(eulaB, 0, eulaB.Length);
                                fs.Close();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("已准备好开启服务器\n最小内存值：" + numericUpDown1.Value + "mb\n最大内存值：" + numericUpDown2.Value + "mb\n启动参数：" + "java -Xms" + numericUpDown1.Value + "m -Xmx" + numericUpDown2.Value + "m -jar Start.jar", "擦腚 开稽？", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                Process p = Process.Start(@"java", "-Xms" + numericUpDown1.Value + "m -Xmx" + numericUpDown2.Value + "m -jar Start.jar");//启动java
                                p.StartInfo.UseShellExecute = false;
                                p.StartInfo.CreateNoWindow = true;
                                p.StartInfo.RedirectStandardOutput = true;
                                p.StartInfo.RedirectStandardError = true;


                               //启动进程
                                p.Start();

                                //准备读出输出流和错误流
                                string outputData = string.Empty;
                                string errorData = string.Empty;
                                p.BeginOutputReadLine();
                                p.BeginErrorReadLine();

                                p.OutputDataReceived += (s, b) =>
                                {
                                    outputData += (b.Data + "\n");
                                };

                                p.ErrorDataReceived += (fuck, e) =>
                                {
                                    errorData += (e.Data + "\n");
                                };

                                //等待退出
                                p.WaitForExit();

                                //关闭进程
                                p.Close();
                            }
                        }
                    }
                }
                else if (UseYourOwnJava.Checked == true && JavaRoute.Text != "" && JavaRoute.Text != "你的 Java 路径（请去掉我）")
                {
                    MessageBox.Show("已准备好开启服务器\n最小内存值：" + numericUpDown1.Value + "mb\n最大内存值：" + numericUpDown2.Value + "mb\n启动参数：" + "java" + "  -Xms" + numericUpDown1.Value + "m -Xmx" + numericUpDown2.Value + "m -jar Start.jar", "擦腚 开稽？", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    Process p = Process.Start(@JavaRoute.Text, "-Xms" + numericUpDown1.Value + "m -Xmx" + numericUpDown2.Value + "m -jar Start.jar");//启动java
                }
            }
            else
            {
                DefaultJavaChosed.Checked = true;
                MessageBox.Show("已准备好开启服务器\n最小内存值：" + numericUpDown1.Value + "mb\n最大内存值：" + numericUpDown2.Value + "mb\n启动参数：" + "java  -Xms" + numericUpDown1.Value + "m -Xmx" + numericUpDown2.Value + "m -jar Start.jar", "擦腚 开稽？", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                Process p = new Process();
                //启动进程
                Process.Start(@"java", "-Xms" + numericUpDown1.Value + "m -Xmx" + numericUpDown2.Value + "m -jar Start.jar");
            }
        }

        private void materialRaisedButton3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("即将冷关闭服务器，请确认地图保存后再使用此指令，否则将引起未保存的数据丢失！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);//警告提示
            Process p = Process.Start(@"taskkill", "-f -im javaw.exe");//炸掉javaw
            Process pp = Process.Start(@"taskkill", "-f -im java.exe");//炸掉java
            MessageBox.Show("冷关闭成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }

        private void materialRaisedButton2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("即将冷重启服务器，请确认地图保存后再使用此指令，否则将引起未保存的数据丢失！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2); // 警告提示
            Process p = Process.Start(@"taskkill", "-f -im javaw.exe");// 炸掉Javaw
            Process pp = Process.Start(@"taskkill", "-f -im java.exe");// 炸掉Java
            MessageBox.Show("冷关闭成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            MessageBox.Show("已准备好开启服务器\n最小内存值：" + numericUpDown1.Value + "mb\n最大内存值：" + numericUpDown2.Value + "mb\n启动参数：" + "java -Xms" + numericUpDown1.Value + "m -Xmx" + numericUpDown2.Value + "m -jar Start.jar", "擦腚 开稽？", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2); // 重新确认启动参数
            Process ppp = Process.Start(@"java", "-Xms" + numericUpDown1.Value + "m -Xmx" + numericUpDown2.Value + "m -jar Start.jar");//启动java
        }
            
        // 要HTTP请求直接调用此函数 你WEB端写的啥？？？？？你到时候GET又不会运行你的JS 那没事了 我还是直接写静态文件吧
        static string httpGet(string url) //https://www.crabapi.cn/api/v5/crabss/data/getData
        {
            WebRequest request = WebRequest.Create("https://www.crabapi.cn/api/v5/crabss/data/getData");
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close(); // 能读到我里面写的\n吗 这个不一定 你运行到时候看看 公告上的GITHUB地址还没有创建？我重命名仓库呢 好了 他妈的我最近上GitHub都得挂代理 我他妈谢谢GFW
            return responseFromServer;
        }

        private void materialRaisedButton4_Click_1(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void materialRaisedButton5_Click_1(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void UseYourOwnJava_CheckedChanged(object sender, EventArgs e)
        {
            if (UseYourOwnJava.Checked == true)
            {
                JavaRoute.Enabled = true;
                JavaFile.Enabled = true;
            }
            else
            {
                JavaRoute.Enabled = false;
                JavaFile.Enabled = false;
            }
        }

        private void DefaultJavaChosed_CheckedChanged(object sender, EventArgs e)
        {
            if (UseYourOwnJava.Checked == true)
            {
                JavaRoute.Enabled = true;
                JavaFile.Enabled = true;
            }
            else
            {
                JavaRoute.Enabled = false;
                JavaFile.Enabled = false;
            }
        }

        private void JavaFile_Click(object sender, EventArgs e)
        {
            choosejava.ShowDialog();
        }

        private void choosejava_FileOk(object sender, CancelEventArgs e)
        {
            JavaRoute.Text = System.IO.Path.GetFullPath(choosejava.FileName);
        }

        private void BypassZZ_CheckedChanged(object sender, EventArgs e)
        {
            if (BypassZZ.Checked == true)
            {
                label1.Text = "您已绕过限制，取消打勾可返回正常限制状态";
                label1.ForeColor = Color.Red;
                numericUpDown1.Maximum = 2147483647;
                numericUpDown2.Maximum = 2147483647;
            }
            else
            {
                PerformanceCounter ram0 = new PerformanceCounter("Memory", "Available MBytes");
                float ram1 = ram0.NextValue();
                numericUpDown2.Maximum = (decimal)(ram1 / 2);
                label1.Text = "最大可分配的 Ram ：" + ram1 / 2 + "MB";
                label1.ForeColor = Color.White;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("确定退出吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
