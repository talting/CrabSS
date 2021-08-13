/*
 * 许可协议：GNU General Public License 3.0
* 文件名称: Program.cs
* 创建者: @是螃蟹aaaaa
* 创建日期: 2021 / 08 /13
* 最后编辑日期: 2021 / 08 /13
* 编译环境: .NET FrameWork 4.5(Visual Studio 2017)、Windows 11 （10.0.22000.120）
* 注:禁止商业用途
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrabMCSM
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
