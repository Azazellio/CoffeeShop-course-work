   M S B A M L   `   `   `  ����L  HCoffeeShopWPFCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CoffeeShopWPFCoreCoffeeShopWPFCore  5   	   "    CoffeeShopWPFCore.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:CoffeeShopWPFCore     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      -   5         ��Name$ MenuRow��5   *   $
��auto �6   6*   �� 5      -   5        $ MainRow��5      .+�5   
   o� $��25��6   $	��Top=�6   $��0��63   .@�5      m� $
��File��6   .@�5      m� -   5        $��Guess��5      6C   m� 5      -   5        $��Find By Name��5      .@�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��Find Id:��6    65   �� 5      $��25��6"   5      m� 5      $	��WPF��6   6/   5      �� 5      m� 5      $
��Exit��6   6,   5      m� 5      $
��Edit��6    m� Command 6&   �� *
AddCommand+6G   m� 5      $
��View��6   6(   5       � 5"   
   -   5          �Name$ 	Container��5"      $��1��6#     � NavigationUIVisibility$ Hidden=�60   5#      5%      5&      