   M S B A M L   `   `   `  ����A  =CrabSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CrabSSCrabSS  5   	       CrabSS.console   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:CrabSS     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	     � Title$  	控制台��5	   	   $	��450��6   $	��800��6"    � WindowStartupLocation$ CenterScreen=�6.   .��5
      � .+�5   
   �� $��	控制台��6   $
��Left=�6   $��28��69   $��	15,23,0,0q�6E   $	��Top=�6X   $	��108��6p   $��16(�6|   �� 5   
   -   5         ��Name$
 time��5      $(��"当前时间   9999-13-32 25:61:61��6   $��Right=�6C   $��24��6_   $��	0,25,22,0q�6k   $	��Top=�6~   $	��218��6�   $��Right=�6�   �� 5   
   -   5         ��Name$
 cons��5      $
��Left=�6$   $	��281��6?   $	��Top=�6L   $	��774��6d   $��	17,68,0,0q�6p   . �5      /� .T�5      J� .*�6   .*�5      �� $!�已准备好开启服务器��6   5      5      5      +  %MahApps.Metro.Controls.DropDownButton  5   
      Content$$ 快捷命令（点击选项）��6   $
��Left=�62   $��28��6M   $��
15,375,0,0q�6Y   $	��Top=�6m   $	��136��6�   $��Microsoft YaHei Light)�6�   @�5      m� 5      -   5         m�Name$ start��5       � Cursor$  ��6@   $��火速开服��6J   m� 5      -   5        $ op��5      $  ��6:   $��立刻神权��6D   m� 5      -   5        $	 ban��5      $  ��6;   $��ban熊孩子��6E   m� 5      -   5        $ gm��5      $  ��6:   $��调整模式��6D   m� 5      -   5        $
 list��5      $  ��6=   $��玩家列表��6G   m� 5      -   5        $ shutdown��5      $  ��6E   $��火速关服��6O   5      �� 5   
   -	   5         ��Name$	 cmd��5      $
��Left=�6    $��28��6;   $��160,375,0,0q�6G    �� TextWrapping$
 Wrap=�6\   $��输入命令 不用带/��6p   $	��Top=�6�   $	��530��6�   �� 5    
   -
   5        	 ��Name$	 go��5        '  #MahApps.Styles.Button.Square.Accent#��[  6   $��发送命令��6Z   $
��Left=�6i   $��32��6�   $��706,373,0,0q�6�   $	��Top=�6�   $��84��6�   6�   5!      5"      