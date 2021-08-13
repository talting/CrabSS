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
* 最后编辑日期: 2021 / 08 /13
* 编译环境: .NET FrameWork 4.5(Visual Studio 2017)、Windows 11 （10.0.22000.120）
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

namespace CrabMCSM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 退出_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists("Start.jar"))//检查核心是否存在
            {
                MessageBox.Show("核心不存在，请检查核心文件名是否正确！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else
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
                        var eula = "eula=true";
                        byte[] eulaB = System.Text.Encoding.Default.GetBytes(eula);
                        fs.Write(eulaB, 0, eulaB.Length);
                        fs.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("已准备好开启服务器\n最小内存值：" + numericUpDown1.Value + "mb\n最大内存值：" + numericUpDown2.Value + "mb\n启动参数：" + "java -Xms" + numericUpDown1.Value + "m -Xmx" + numericUpDown2.Value + "m -jar Start.jar", "擦腚 开稽？", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        Process p = Process.Start(@"java", "-Xms" + numericUpDown1.Value + "m -Xmx" + numericUpDown2.Value + "m -jar Start.jar");//启动java
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("即将冷关闭服务器，请确认地图保存后再使用此指令，否则将引起未保存的数据丢失！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);//警告提示
            Process p = Process.Start(@"taskkill" , "-f -im javaw.exe");//炸掉javaw
            Process pp = Process.Start(@"taskkill", "-f -im java.exe");//炸掉java
            MessageBox.Show("冷关闭成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("即将冷重启服务器，请确认地图保存后再使用此指令，否则将引起未保存的数据丢失！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2); // 警告提示
            Process p = Process.Start(@"taskkill", "-f -im javaw.exe");// 炸掉Javaw
            Process pp = Process.Start(@"taskkill", "-f -im java.exe");// 炸掉Java
            MessageBox.Show("冷关闭成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            MessageBox.Show("已准备好开启服务器\n最小内存值：" + numericUpDown1.Value + "mb\n最大内存值：" + numericUpDown2.Value + "mb\n启动参数：" + "java -Xms" + numericUpDown1.Value + "m -Xmx" + numericUpDown2.Value + "m -jar Start.jar", "擦腚 开稽？", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2); // 重新确认启动参数
            Process ppp = Process.Start(@"java", "-Xms" + numericUpDown1.Value + "m -Xmx" + numericUpDown2.Value + "m -jar Start.jar");//启动java
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }
    }
}
