   M S B A M L   `   `   `  ����>  :POS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:POS.ViewPOS.View  5   	   -clr-namespace:POS.ViewModelPOS.ViewModel  5   	       POS.View.userWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:POS.View     5   	   1	viewModelclr-namespace:POS.ViewModel     5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$
 User��5   	   $	��750��6   $	��550��6#    � DataContext 5          POS.ViewModel.UserWindowVM  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   � $��0��6   
�������.+�5      �� $!��/Images/online-shopping.png��6   $��30��69   $��30��6D    J� RenderTransformOrigin$ 0.489,0.564&�6P   $��	0,0,520,0q�6t   �� 5      $��15(�6   $
��User��6&   $��35,0,0,0q�62   $
��Bold"�6D   �� 5      -   5         ��Name$ closeButton��5         CloseBtn#��[  6Q   $��	525,0,0,0q�6s   ��6*   �� *CloseWindowCommand+6s   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��214* �6#   �� 5      $	��79* �6#   �� 5      $
��254* �6#   �� 5      $��3* �6#   .+�5"      �� 	 �� CornerRadius$	 0 0 0 0��6   
������ $��4��6F   ._�5#      �  5$      �� 5%      $	��63* �6+   �� 5&      $
��487* �6+   ��5(      �� 5)      
 �� 
StartPoint$	
 0,1&�6.    �� EndPoint$	 1,0&�6?   .��5*      �  � Color$ #159957��6+    � Offset$ 1Q�6;   � 5+      $ #302b63��6+   $ 0Q�6;   � 5,      $ #24243e��6+   $ 2Q�6;   5-      .+�5/      &   System.Windows.Controls.DataGrid  -   5          Name$ ProductGrid��5/      $��50,20,50,386q�6�      ColumnHeaderHeight$ 30Q�50   !      RowHeaderWidth$ 0Q�69      CanUserAddRows$ False��6L      CanUserDeleteRows$ False��6c      AutoGenerateColumns$ False��51   !      GridLinesVisibility$
 None=�6=   
���OO/� J� Opacity$
 0.96Q�6s   $��1q�52   !   
������ $��2��6O   ��5/   4   �� *
Products+ �� SelectedItem 6U   �� *SelectedProduct+ �� Mode$ TwoWay=� � 	Resources 54      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value��%g  '        '  /    '      �� 55      "  6$   .�56   "   ��  � ��$ Center=�6H   �� 57   "    � ��
 ���� 6?   �� 58   "    � ��
 �����6?   �� 59   "    � ��$ 0q�6D   �� 5:   "    � ��$
 Bold"�6?   �� 5;   "    � ��$ Segoe UI)�6?   �� 5<   "    � ��$ 14(�6=   5=      �� 5?      "  6$   .�5@   "   ��  � ��$ Center=�6H   �� 5A   "    � ��$ 0q�6D   �� 5B   "    � ��$ 8q�6<   �� 5C   "    � ��$ Segoe UI)�6?   �� 5D   "    � ��$ 12(�6=   5E      �� 5G      "  6$   .�5H   "   ��  � �� �#DDDDDD6@   �� 5I   "    � ��$ 0 1 0 1q�6D   �� 5J   "    � ��$ Segoe UI)�6?   �� 5K   "    � ��$ 12(�6=    5L   "   P� 5M   &    �@J�IsMouseOver$
 True��6E   . �5N   *   ��  � �� �#F0F0F06G   5O   '   5Q      5R         Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn    Header$  
Product ID��61   !   Width5  /System.Windows.Controls.DataGridLengthConverter$! * 6\   1	  +System.Windows.Controls.DataGridBoundColumn" 	  Binding" 6E   �� *Id+6\     5V      $  Product Name��61   $! * 6g   " 6G   �� *ProductName+6g     5W      $  Price��61   $! * 6Z   " 6@   �� *Price+6Z   5Z      5[      5\      �� 5^      $��Product Bucket��6   
���   �$��20(�5`      $��88,356,30,287q�5a      $��	ExtraBold"�5b      $��2��6(   �� 5d      -   5        $��
cartBucket��5g      
����  �$��1q�5f      # �� SelectionMode$# Single=�5i      $��20,386,179,4q�5j      
������ $��3��6<   ��5h      �� *ProductBucket+��5k      �� 5l      .R�5m      �� $ �� Orientation$$ 
Horizontal=�6%   .+�5n      �� $��5q�6<   ��6(   �� *Id+6<   �� 5o      $��5q�6E   ��6(   �� *ProductName+6E   �� 5p      $��5q�6Y   ��6(   �� *Price+% �� StringFormat$% ${0:F2}��6Y   �� 5q      $��20��6e   $��20��6p   $��5q�6|   ��6&   �� *
Quantity+& �� UpdateSourceTrigger$& PropertyChanged=�6|   5r      5s      5u      �� 5w      $��20(�6   $��98,393,32,254q�6#   $ 	0.7,0.631&�6�   
������ $��2��5x   &   ��5w   :   �� *AddToCartCommand+��6_   �� *SelectedProduct+.��5y      �� $��/Images/add-cart.png��6   $��60��66   $��60��6A   $��5q�6M   5z      �� 5|      $��98,510,32,128q�5~   K   
������ $��2��6{   ��5}   	   �� *RemoveFromCartCommand+$& PropertyChanged=���5~   	   �� *SelectedItem+' �� ElementName$' 
cartBucket��.��5      �� $$ 
Horizontal=�6   .+�5�      �� $��/Images/delete.png��6   $��60��68   $��60��6C   $��5q�6O   5�      5�      �� 5�      $��98,629,32,10q�5�   (   
������ $��2��6W   ��6	   �� *
PayCommand+.��5�      �� $$ 
Horizontal=�6   .+�5�      �� $��/Images/pay.png��6   $��60��65   $��60��6@   $��5q�6L   5�      5�      5�      5�      5�      