   M S B A M L   `   `   `  ����B  >CRUDApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CRUDAppCRUDApp  5   	       CRUDApp.DetailWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:CRUDApp     5   	   -   5          � Title$  Player Details��5   	   $	��755��6    $
��1150��6-   ���#F0F0F0 � 
ResizeMode$ NoResize=�6O    � WindowStartupLocation$ CenterScreen=�6e   .��5
      � .+�5   
   �� -   5         ��Name$ DetailWindowModeLabel��5      $��Create | Update Player��6/   $
��Left=�6P   $��80��6k   $��	38,20,0,0q�6w   $	��Top=�6�   $	��814��6�   $
��Bold"�5      $��40(�6"   ���#4B0082$��Italic$�6E   �� 5   
   $
��Left=�6   $	��565��6/   $��
38,128,0,0q�6<   ���#D3D3D3$	��Top=�6a   $	��875��6y   ���#E6E6FA �� RadiusX$ 10��6�    �� RadiusY$ 10��6�   �� 5   
   $��ID��6   $
��Left=�6   $��45��68   $��
58,155,0,0q�6D   $	��Top=�6X   $	��107��6p   ���#4B00826|   �� 5   
   -   5         ��Name$ PlayerIdTextBox��5      $
��Left=�6+   $��45��6F   $��223,153,0,0q�6R    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��275��6�   $��0��6�   �� 5   
   $��Player Name��6   $
��Left=�6&   $��45��6A   $��
58,218,0,0q�6M   $	��Top=�6a   $	��147��6y   ���#4B00826�   �� 5   
   -   5        $ PlayerNameTextBox��5      $
��Left=�6-   $��45��6H   $��223,216,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $	��635��6�   $��1��6�   �� 5   
   $��Position��6   $
��Left=�6#   $��45��6>   $��
58,284,0,0q�6J   $	��Top=�6^   $	��107��6v   ���#4B00826�   �� 5   
   -   5         ��Name$ PositonComboBox��5      $
��Left=�6,   $��224,289,0,0q�6G   $	��Top=�6\   $	��174��6t   	 �� SelectedValuePath$	 Content��6�   
 �� SelectedValue
 6�   �� *EditedOne.Position+ �� Mode$ TwoWay=� �� FallbackValue$ Forward��.@�5      �� $��Forward��6   �� 5      $��Midfield��6   �� 5      $��Defender��6   �� 5      $��
Goalkeeper��6   5      �� 5    
   $��Number��6   $
��Left=�6!   $��45��6<   $��
58,351,0,0q�6H   $	��Top=�6\   $	��107��6t   ���#4B00826�   �� 5!   
   -   5        $ NumberTextBox��5!      $
��Left=�6)   $��45��6D   $��223,350,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��635��6�   $��3��6�   �� 5#   
   $��Date Of Birth��6   $
��Left=�6(   $��45��6C   $��
58,422,0,0q�6O   $	��Top=�6c   $	��147��6{   ���#4B00826�   (  "System.Windows.Controls.DatePicker  5$   
   -   5          Name$ DateOfBirthDatePicker��5$      $
��Left=�64   $��45��6O   $��223,420,0,0q�6[   $	��Top=�6p   $	��275��6�   $��4��6�      SelectedDateFormat$ Short=�6�   �� 5&   
   $��Nationality��6   $
��Left=�6&   $��45��6A   $��
58,488,0,0q�6M   $	��Top=�6a   $	��147��6y   ���#4B00826�   �� 5'   
   -   5        $ NationalityTextBox��5'      $
��Left=�6.   $��45��6I   $��223,485,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��635��6�   $��5��6�   �� 5)   
   $��	Team Name��6   $
��Left=�6$   $��45��6?   $��
58,554,0,0q�6K   $	��Top=�6_   $	��147��6w   ���#4B00826�   �� 5*   
   -	   5        $ TeamNameTextBox��5*      $
��Left=�6+   $��45��6F   $��223,553,0,0q�6R   $	��Top=�6g   $	��290��6   $��6��6�   $
��Bold"�6�   $��18(�6�   �� 5-   
   -
   5         ��Name$ 
SaveButton��5-      $��Save Player��6%   $
��Left=�6;   $��50��6V   $��945,128,0,0q�6b   $	��Top=�6w   $	��165��6�   $��7��6�   ���#6A5ACD
�������$
��Bold"�5.   9   6K   �� 50   
   -   5        $ CloseButton��50      $��Close��6&   $
��Left=�66   $��50��6Q   $��945,208,0,0q�6]   $	��Top=�6r   $	��165��6�   $��8��6�   ���#4B0082
�������$
��Bold"�51   9   6K   53      54      