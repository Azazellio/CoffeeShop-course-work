   M S B A M L   `   `   `  ����L  HCoffeeShopWPFCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CoffeeshopWPF.PagesCoffeeshopWPF.Pages  5      $    CoffeeshopWPF.Pages.FindByName   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CoffeeshopWPF.Pages     5        N� Title$  
FindByName��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��2* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ MachinesGrid1��5         AutoGenerateColumns$ False��6*      
IsReadOnly$
 True��5   l   ��6   �� *MachinesListSource+ �� SelectedItem 6>   �� *SelectedMachineModel+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6%      Header$ Id��60   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6<   �� *Id+  5      $ 50 6%   $
 Date��60   	 6>   �� *date+  5      $ * 6%   $ What's missing��6/   	 6G   �� *MissingIngredient+5      � 5   
   -   5        
 �Name$

 Info��5      $��
10,30,10,0q�6   $��1��61    � RowDefinitions 5      �� 5      -   5         ��Name$ enterId��5   ,   $��1* �6    6,   �� 5      -   5        $ ingr1��5   ,   $��1* �6    6,   �� 5      -   5        $ ingr2��5   ,   $��1* �6    6,   �� 5      -   5        $ ingr3��5   ,   $��1* �6    6,   �� 5      -   5        $ ingr4��5   ,   $��1* �6    6,   �� 5      -   5        $ refillNeeded��5   ,   $��1* �6    6,   .+�5"      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�62   $��20,0,0,0q�6M   .+�5#      �� $��Machine ID:��6   $��0��6/   #��� ��6?   $��Center=�6�   $��Center=�6�   $��26��6�   $��18(�6�   �� 5$      $��40��6   $��20��6%   $��0��61   $��5,0,0,0q�6A    �� 
IsReadOnly$
 True��6s   ��6R   �� *SelectedModelId+6s   �� 5%      $��40,0,0,0q�6   $��80��6+   $��40��66   ��6B   �� *UpdateCommand+.��6d   Show History6r   5&      �� 5(      $ 
Horizontal=�6   $
��Left=�62   $��20,0,0,0q�6M   $��1��6_   .+�5)      �� $��Coffee:��6   #��� ��6+   $��Center=�6x   $��Center=�6�   $��26��6�   $��18(�6�   �� 5*      $��40��6   $��20��6%   $��0��61   $��5,0,0,0q�6A   $
 True��6u   ��6R   �� *SelectedModelIng1+6u   5+      �� 5-      $ 
Horizontal=�6   $
��Left=�62   $��20,0,0,0q�6M   $��2��6_   .+�5.      �� $��Water:��6   #��� ��6*   $��Center=�6w   $��Center=�6�   $��26��6�   $��18(�6�   �� 5/      $��40��6   $��20��6%   $��0��61   $��5,0,0,0q�6A   $
 True��6u   ��6R   �� *SelectedModelIng2+6u   50      �� 52      $ 
Horizontal=�6   $
��Left=�62   $��20,0,0,0q�6M   $��3��6_   .+�53      �� $��Milk:��6   #��� ��6)   $��Center=�6v   $��Center=�6�   $��26��6�   $��18(�6�   �� 54      $��40��6   $��20��6%   $��0��61   $��5,0,0,0q�6A   $
 True��6u   ��6R   �� *SelectedModelIng3+6u   55      �� 57      $ 
Horizontal=�6   $
��Left=�62   $��20,0,0,0q�6M   $��4��6_   .+�58      �� $��Sugar:��6   #��� ��6*   $��Center=�6w   $��Center=�6�   $��26��6�   $��18(�6�   �� 59      $��40��6   $��20��6%   $��0��61   $��5,0,0,0q�6A   $
 True��6u   ��6R   �� *SelectedModelIng4+6u   5:      �� 5<      $ 
Horizontal=�6   $
��Left=�62   $��20,0,0,0q�6M   $��5��6_   .+�5=      �� $��Refill Needed:��6   #��� ��62   $��Center=�6   $��Center=�6�   $��26��6�   $��18(�6�   �� 5>      $	��130��6   $��20��6&   $��0��62   $��5,0,0,0q�6B   $
 True��6y   ��6S   �� *SelectedRefillNeeded+6y   5?      5@      5A      5B      