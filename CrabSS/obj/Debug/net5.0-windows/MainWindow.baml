   M S B A M L   `   `   `  ����A  =CrabSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CrabSSCrabSS  5   	       CrabSS.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:CrabSS     5   	   0ui!http://schemas.modernwpf.com/2019     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   ;Controls,http://metro.mahapps.com/winfx/xaml/controls  5	      ^ ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.BootstrapIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag	 cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag
 cMahApps.Metro.IconPacks.Codicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Coolicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.FileIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Fontaudio, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Fontisto, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.ForkAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.PixelartIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RadixIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah  dMahApps.Metro.IconPacks.RemixIcon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai! eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj" fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag# cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af$ bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj% fMahApps.Metro.IconPacks.VaadinIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak& gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah' dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a}	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks!   	 
                        ! " # $ % & ' 5
   	   -   5          � Title$  CrabSS Beta��5   	   $	��900��6   $
��1600��6*   
������� � WindowStartupLocation$ CenterScreen=�6J   ��5      �� 5   
    �� ImageSource$ /00.jpg��6   .��5      � .+�5   
   �� $K��E测试版程序，可能有很多不确定的错误，请积极反馈��6   $
��Left=�62   $��44��6M   $��	18,21,0,0q�6Y   $	��Top=�6l   $	��744��6�   
�������6�   �� 5   
   $D��>我们的GitHub地址是：https://github.com/CrabTechs/CrabSS��6   $
��Left=�6K   $��44��6f   $��	18,42,0,0q�6r   $	��Top=�6�   $	��744��6�   
�������6�   �� 5   
   -   5         ��Name$ hitokoto��5      $��一言...？��6"   $
��Left=�63   $��29��6N   $��
10,840,0,0q�6Z   $	��Top=�6n   $	��911��6�   
�������6�   �� 5   
   -   5        $ version��5      $��当前版本号[0.15r2]��6!   $��Right=�69   $��29��6U   $��	0,0,-25,0q�6a   $��Bottom=�6t   $	��259��6�   
������� J� SnapsToDevicePixels$
 True��6�    J� Opacity$	 0.7Q�6�   �� 5   
   -   5        $ version_online��5      $��联网版本号[未知]��6(   $��Right=�6<   $��29��6X   $��
0,0,-135,0q�6d   $��Bottom=�6x   $	��259��6�   
�������$
 True��6�   $	 0.7Q�6�   =  7MahApps.Metro.Controls.MetroAnimatedSingleRowTabControl  5   
   $
��Left=�64   $	��749��6O   $��	22,86,0,0q�6\   $	��Top=�6o   $
��1550��6�   .@�5      �� $��主页��6   
���������6"   Z� .��5      � ���	#66FFFFFF$��-2,0,2,0q�6.   .+�5      �� $��宁好��6   $
��Left=�6)   $��45��6D   $��	14,13,0,0q�6P   $	��Top=�6c   $	��435��6{   
�������$��24(�6�   $��Microsoft YaHei UI Light)�6�   �� 5      $��欢迎使用 CrabSS��6   $
��Left=�62   $��45��6M   $��	14,47,0,0q�6Y   $	��Top=�6l   $	��435��6�   
�������$��18(�6�   $��Microsoft YaHei UI Light)�6�   �� 5      -   5        $
��Left=�5      $	��145��67   $��
19,108,0,0q�6D   $	��Top=�6X   $	��145��6p   $!��/QQ图片20210721191245.png��6|   $
��Fill=�6�   6�   �� 5      $R��L一张神奇的图片？点点试试 ——一位屑旅行者曾这样说过��6   $
��Left=�6A   $��89��6\   $��198,167,0,0q�6h   $	��Top=�6}   $	��590��6�   
�������$��22(�6�   �� 5      -   5         ��Name$ content��5      $��这个版本的公告 :D��60   $
��Left=�6D   $	��263��6_   $��
20,312,0,0q�6l   $	��Top=�6�   $	��765��6�   ���	#FF3A3A3A���	#B2FFFFFF$��null~��6�   5      5       �� 5!      $+��%开一个简简单单的服务器 :-D��6   
���������6/   Z� .��5"      � ���	#66FFFFFF.+�5#      �� $?��9绝对《不会》让你脑血栓的那种（（（（（��6   $
��Left=�6:   $��40��6U   $��	21,17,0,0q�6a   $	��Top=�6t   $	��386��6�   
�������$��24(�6�   $��Microsoft YaHei UI Light)�6�   *  $MahApps.Metro.Controls.NumericUpDown  5$      -   5          Name$	 min��5$   -   $��145,93,1250,576q�6:   �� 5%      $��最小内存��6   $
��Left=�6+   $��20(�6F   $��36��6U   $��	22,96,0,0q�6a   $	��Top=�6t   $	��122��6�   
�������6�     5&      -   5        $	 max��5&   -   $��145,167,1250,502q�6:   �� 5'      $��最大内存��6   $
��Left=�6+   $��20(�6F   $��36��6U   $��
22,170,0,0q�6a   $	��Top=�6u   $	��122��6�   
�������6�   �� 5(      $��
宁的Jvav��6   $
��Left=�6-   $��20(�6H   $��36��6W   $��
22,241,0,0q�6c   $	��Top=�6w   $	��122��6�   
�������6�   �� 5)      -	   5         ��Name$
 jvav��5)      $
��Left=�6,   $��34��6G   $��155,242,0,0q�6S   	 �� TextWrapping$
	 Wrap=�6h   $	��Top=�6|   $	��561��6�   $��Segoe UI Semilight)�6�   $��16(�6�   
 � ToolTip$%
 为空则使用默认Java环境��6�   �� 5*      -
   5         ��Name$ 
choosejvav��5*      $��选择��61   $
��Left=�6>   $��48��6Y   $��734,232,0,0q�6e   $	��Top=�6z   $	��134��6�   $��16(�6�   $��Normal"�6�   
�������
����������	#FF0080FF6�   �� 5+      $��自定义参数��6   $
��Left=�6,   $��20(�6G   $��36��6V   $��
22,320,0,0q�6b   $	��Top=�6v   $	��122��6�   
�������6�   �� 5,      -   5        $ 
customcode��5,      $
��Left=�62   $��34��6M   $��155,321,0,0q�6Y   $
	 Wrap=�6n   $	��Top=�6�   $	��561��6�   $��Segoe UI Semilight)�6�   $��16(�6�   $
 为空则使用-nogui��6�   $��-nogui��6�   �� 5-      -   5        $ start��5-      $*��$自然选择，前进四！（（（��6,   $
��Left=�6C   $��50��6^   $��
38,425,0,0q�6j   $	��Top=�6~   $	��199��6�   
����������	#FF12B91A
�������$��Normal"�6�   $��14(�6�   6  � 5.      -   5         �Name$ loading��5.      $
��Left=�6,   $��58��6G   $��
42,499,0,0q�6S   $	��Top=�6g   $	��285��6   .+�5/      )  #MahApps.Metro.Controls.ProgressRing  $
��Left=�60   $��44��6K   $��7,0,0,0q�6W   $��43��6h   
�������6s   �� 50      -   5        $
 data��50       $��提示��6.   $
��Left=�6;   $��31��6V   $��64,0,0,0q�6b   $��Center=�6t   $	��186��6�   
�������$��Microsoft YaHei UI Light)�6�   $��18(�6�   51      52      53      �� 54      $��插件管理��6   
���������6$   Z� .��55      � ���	#66FFFFFF.+�56      �� -   5        $	 add��56      $��+ 导入插件��6*   $
��Left=�6;   $��34��6V   $��	16,17,0,0q�6b   $	��Top=�6u   $	��107��6�   $��Normal"�6�   $��Segoe UI)�6�   $��12(�6�   ���	#FF00A9DA
����������	#FF00C5FF6  �� 57      -   5        $ refresh��57      $��刷新��6.   $
��Left=�6;   $��34��6V   $��
162,17,0,0q�6b   $	��Top=�6v   $	��107��6�   $��Normal"�6�   $��Segoe UI)�6�   $��12(�6�   ��6�   Z� 6�   �� 58      -   5         ��Name$ 
pluginlist��58      $
��Left=�62   $	��618��6M   $��	14,65,0,0q�6Z   $	��Top=�6m   $
��1517��6�   
����������	#66FFFFFF��6�   Z� 6�   �� 59      $��插件总数��6   $
��Left=�6+   $��23��6F   $��1392,18,0,0q�6R   $	��Top=�6g   $��60��6   
�������6�   �� 5:      -   5        $ counts��5:      $��0��6,   $
��Left=�68   $��36��6S   $��1453,12,0,0q�6_   $	��Top=�6t   $��70��6�   
�������$��Segoe UI Light)�6�   $��18(�6�   5;      5<      �� 5=      $��配置管理��6   
���������6$   Z� .��5>      � ���	#66FFFFFF.+�5?      �� -   5        $ servers��5?      ���	#66FFFFFF���	#FF7E7E7E$��TextBox��6]   $
	 Wrap=�6l    �� SelectionBrush �	#FF008DFF$��18(�6�   $��0,59,0,0q�6�   ��6�   Z�  �� 
CaretBrush 6�   Z� 6�   �� 5@      -   5        $
 save��5@      $��保存��6+   $
��Left=�68   $��34��6S   $��	16,17,0,0q�6_   $	��Top=�6r   $	��107��6�   $��Normal"�6�   $��Segoe UI)�6�   $��12(�6�   ���	#FF00A9DA
����������	#FF00C5FF6  �� 5A      -   5        $ reload��5A      $��刷新��6-   $
��Left=�6:   $��34��6U   $��
162,17,0,0q�6a   $	��Top=�6u   $	��107��6�   $��Normal"�6�   $��Segoe UI)�6�   $��12(�6�   ��6�   Z� 6�   5B      5C      �� 5D      $��内网映射��6   
���������6$   Z� .��5E      � ���	#66FFFFFF.+�5F      )  #MahApps.Metro.Controls.ToggleSwitch  -   5          Name$	 frp��5F   ,   $��66��69   $��开启内网映射功能��6E   $	��100��6W   $��	11,12,0,0q�6c   $	��Top=�6v   
���   �   
OffContent$ 关闭��6�      	OnContent$ 开启��6�   2  ,MahApps.Metro.Controls.HeaderedControlHelper   HeaderBackground
 �����   ContentDirection$ RightToLeft=�6�      IsOn$ false��6'  � 5G      -   5        $ mainer��5G      $��0,77,0,0q�6+   .+�5H      �� $��内网映射服务��6    $
��Left=�61   $��38��6L   $��	12,16,0,0q�6X   $	��Top=�6k   $	��146��6�   
�������$��20(�6�   $��Microsoft YaHei UI Light)�6�   	� 5I      -   5         	�Name$ 	SakuraFrp��5I   &   $��
Sakura Frp��69   $
��Left=�6N   $��36��6i   $��	16,87,0,0q�6u   $	��Top=�6�   $	��107��6�   
���������6�   Z� ��6�   Z� 6�   	� 5J      -   5        $ MossFrp��5J   &   $��MossFrp��67   $
��Left=�6I   $��36��6d   $��
120,87,0,0q�6p   $	��Top=�6�   $	��107��6�   
���������6�   Z� ��6�   Z� 6�   	� 5K      -   5        $ GeFrp��5K   &   $��GeFrp��65   $
��Left=�6E   $��36��6`   $��
210,87,0,0q�6l   $	��Top=�6�   $	��107��6�   
���������6�   Z� ��6�   Z� 6�   	� 5L      -   5        $ Other��5L   &   $��Other��65   $
��Left=�6E   $��36��6`   $��
280,87,0,0q�6l   $	��Top=�6�   $	��107��6�   
���������6�   Z� ��6�   Z� 6�   �� 5M      $��	服务商��6    $
��Left=�6.   $��31��6I   $��	12,50,0,0q�6U   $	��Top=�6h   $	��146��6�   
�������$��16(�6�   $��Microsoft YaHei UI Light)�6�   �� 5N      -   5         ��Name$ error��5N   !   $��1q�60   $
��Left=�6D   $��37��6_   $��
12,138,0,0q�6k   $y�Hidden=�6   $	��Top=�6�   $	��804��6�   ���	#FFFF3A00 �� CornerRadius$ 20,20,20,20��6�   ._�5O      � $
��Left=�6#   $��37��6>   $��0,0,0,0q�6J   $	��Top=�6[   $	��804��6s   .+�5P   "   �� 
�������$��这一块不想写了:(��6;   $
��Left=�6O   $��	10,-2,0,0q�6j   $��Center=�6}   $	��760��6�   5Q      5R      �� 5S      $��1q�6!   $
��Left=�65   $��37��6P   $��
157,16,0,0q�6\   $	��Top=�6p   $	��804��6�   ���	#FF00CC6A$ 20,20,20,20��6�   ._�5T      � $
��Left=�6#   $��37��6>   $��0,0,0,0q�6J   $	��Top=�6[   $	��804��6s   .+�5U   "   �� 
�������$D��>推荐使用MossFrp，稳定实惠，具体请加群1072507973��6;   $
��Left=�6f   $��	10,-2,0,0q�6�   $��Center=�6�   $	��760��6�   5V      5W      � 5X      -   5        $ mossfrp��5X      $
��Left=�60   $	��386��6K   $��
24,137,0,0q�6X   $	��Top=�6l   $
��1105��6�   .+�5Y      �� -   5         ��Name$
 node��5Y   '   $��30��65   $��96,23,902,333q�6A   $��Microsoft YaHei)�6X    �� SelectedIndex$ 0��6u   .@�5Z   "   �� $��	宿迁一��6/   �� 5[   "   $��	四川二��6/   �� 5\   "   $��许昌一（付费）��6/   �� 5]   "   $
��test��6/   5^      �� 5_      $��选择节点��6$   ���	#FFFFFFFF$��16(�6J   $
��Left=�6X   $��33��6s   $��	12,24,0,0q�6   $	��Top=�6�   $��75��6�   �� 5`      $��宁的Token��6$   ���	#FFFFFFFF$��16(�6M   $
��Left=�6[   $��33��6v   $��	12,69,0,0q�6�   $	��Top=�6�   $��89��6�   �� 5a      -   5        $ token��5a   &   $
��Left=�65   $��32��6P   $��
104,71,0,0q�6\   $
	 Wrap=�6p   $��Give me your token!��6�   $	��Top=�6�   $	��391��6�   �� 5b      $��专属服务器端口��6$   ���	#FFFFFFFF$��16(�6M   $
��Left=�6[   $��33��6v   $��
12,112,0,0q�6�   $	��Top=�6�   $	��125��6�   5c      � 5d      -    5        $ gefrp��5d      $
��Left=�6.   $	��386��6I   $��
24,137,0,0q�6V   $	��Top=�6j   $
��1105��6�   5f      � 5g      -!   5        $ others��5g      $
��Left=�6/   $	��386��6J   $��
24,137,0,0q�6W   $	��Top=�6k   $
��1105��6�   5i      5j      �� 5k      $
��Left=�6   $��26��69   $��172,329,0,0q�6E   $
	 Wrap=�6Z   $��0��6n   $	��Top=�6w   $��78��6�   5l      5m      �� 5n      $��设置��6   
���������6"   Z� .��5o      � ���	#66FFFFFF.+�5p      �� $��偏好设置��6   ���	#FFFFFFFF$��24(�6B   $
��Left=�6P   $��43��6k   $��	22,29,0,0q�6w   $	��Top=�6�   $	��114��6�   �� 5q      $4��.应用背景（default为使用默认背景）��6   ���	#FFFFFFFF$
��Left=�6S   $��25��6n   $��	22,84,0,0q�6z   $	��Top=�6�   $	��198��6�   �� 5r      -"   5        $ bg��5r      $
��Left=�6*   $��23��6E   $��
232,83,0,0q�6Q   $
	 Wrap=�6e   $��default��6y   $	��Top=�6�   $	��319��6�   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$- '请不要使用白色！！！！！！��6�   $`
 Z请不要使用白色！！！！！！！！！！！！！！！！！！！！！！！��6�   �� 5s      -#   5        $ saved��5s      $��保存设置��6,   $
��Left=�6;   $��35��6V   $��
29,655,0,0q�6b   $	��Top=�6v   $��68��6�   5u      5v      5w      5x      5y      