   M S B A M L   `   `   `  ����B  >CRUDApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CRUDAppCRUDApp  5          CRUDApp.App   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      'localclr-namespace:CRUDApp     5      c _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5        �� 	Resources  5         	topButton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value  
menuButton  menuButtonIcon.  (MahApps.Metro.IconPacks.PackIconMaterial  DataGridRowStyle1)  #System.Windows.Controls.DataGridRow  DataGridColumnHeaderStyle1=  7System.Windows.Controls.Primitives.DataGridColumnHeader  DataGridCellStyle1*  $System.Windows.Controls.DataGridCell  DataGridStyle1&   System.Windows.Controls.DataGrid��%%  &	        &	 B    &	 �    &	 j    &	      &	 �    &	 �    �� 5	   
   " ��6"   .�5
      ��  � ��
 ���� 6+   �� 5       � �� �#6e77836+   �� 5       �@�FocusVisualStyle 61   Z� �� 5       � ��$ 30��6&   �� 5       � ��$ 30��6'   �� 5       � ��$
 Left=�64   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 50��6K   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#dcdcdc63   5      5       �� 5"   
   " ��6#   .�5#      ��  � ��
 ���� 6+   �� 5$       � �� �#d0c0ff6+   �� 5%       �@�FocusVisualStyle 61   Z� �� 5&       � ��$ 30��6&   �� 5'       � ��$
 15 3q�6'   �� 5(       � ��$ 13(�6)   �� 5)       � �� 5*      �� 5+      " ��6&   .R�5,      �� #��z��6!   $ 7��6K   ._�5-      �� $
��Left=�6/   $��Center=�6J   5.      5/      51       53      P� 54       �@J�IsMouseOver$
 True��61   . �55      ��  � �� �#7b5cd663   �� 56       � �� �#ffffff63   57      5:      �� 5<   
   "  6'   .�5=      ��  � ��$ 15��6&   �� 5>       � ��$ 15��6'   �� 5?       � ��$ Center=�62   �� 5@       � ��$ 	20 2 20 0q�6'   5B      �� 5D   
   "  6*   .�5E      ��  � ��
 �����6+   �� 5F       � ��$ 52��6'    5G      P� 5H       �@J�IsMouseOver$
 True��61   . �5I      ��  � �� �#623ed063   �� 5J       � ��
 �����63   5K      P� 5L       �@ 
IsSelected$
 True��60   . �5M      ��  � �� �#623ed063   �� 5N       � ��
 �����63   5O      5Q      �� 5S   
   "  63   .�5T      ��  � ��$ 45��6'   �� 5U       � ��
 �����6+   �� 5V       � �� �#69717d6+   �� 5W       � ��$ 14(�6)   �� 5X       � ��$ SemiBold"�6+   5Y      �� 5[   
   "  6+   .�5\      ��  � ��$ 13(�6)   �� 5]       � ��$ Medium"�6+   �� 5^       � ��$ 15 0 0 0q�6(    5_      P� 5`       �@ 
IsSelected$
 True��60   . �5a      ��  � ��
 �����63   5b      5d      �� 5f   
   "  6'   .�5g      ��  �@ ColumnHeaderHeight$ 45Q�63   �� 5h       � ��$ 0q�60   �� 5i       �@ GridLinesVisibility$
 None=�64   �� 5j       �@ VerticalGridLinesBrush
 ���� 67   �� 5k        �@ HorizontalGridLinesBrush �#dcdcdc69   �� 5l       �@ RowHeaderWidth$ 0Q�6/   �� 5m       �@ SelectionMode$ Single=�6.   �� 5n       �@ SelectionUnit$ FullRow=�6.   �� 5o       �@ AutoGenerateColumns$ False��64   �� 5p       �@ CanUserAddRows$ False��6/   �� 5q       �@ CanUserResizeRows$ False��62   �� 5r       �@ CanUserReorderColumns$ False��66   �� 5s       �@ 
IsReadOnly$
 True��6+   5t      5z      5{      