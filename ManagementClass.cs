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

namespace CrabMCSM
{
    internal class ManagementClass
    {
        private string v;

        public ManagementClass(string v)
        {
            this.v = v;
        }

        internal ManagementObjectCollection GetInstances()
        {
            throw new NotImplementedException();
        }
    }
}