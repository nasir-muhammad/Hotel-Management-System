   M S B A M L   `   `   `  ����  WpfApp2    WpfApp2.AddMedicineUc   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      $	��200��5      $	��350��6     � 	Resources  5         bitSaveImage �� 	UriSource  	saveImage  bitCancelImage  cancelImage J� Opacity��%�   &	        &	 )    7   &	 A     &	 l    7  �� 5	   
   $ images/save.jpg?�6+   �� 5
   
   8��  63   �� 5   
   $ images/cancel.jpg?�6-   �� 5   
   $	 0.9Q�65   8��  6C   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��0.35* �6   �� 5      $��0.35* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   .+�5   
   � $��0��6   $��0��6   $��Right=�6,   .+�5      �� $��Medicine Name��6   $��Center=�6,   $��30��6I   5      � 5   
   $��1��6   $��0��6   $
��Left=�6,   .+�5      �� -   5         ��Name$ 
mednametxt��5      $��Center=�6*   $��30��6G   $	��165��6S   $��Center=�6_   5      � 5   
   $��0��6   $��1��6   $��Right=�6,   .+�5      �� $��Price��6   $��Center=�6$   $��30��6A   $	��100��6M   $��Center=�6Y   5       � 5!   
   $��1��6   $��1��6   $
��Left=�6,   .+�5"      %  Xceed.Wpf.Toolkit.IntegerUpDown  -   5          Name$ medpricetxt��5"   !   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�66   $��Center=�6B   $��30��6_   $	��165��6k   5#      � 5$   
   $��1��6   $��2��6   $
��Left=�6,   .+�5%      �� -   5         ��Name$ btn_Save��5%      #��[ 6'   $��Center=�6L   $��0,0,80,1q�6�   ��6g   Z� ��6~   Z� 6�   �� 5&      -   5        $ 
btn_Cancel��5&      #��[ 6)   $��50��6P   $��Center=�6[   $��80,0,0,0q�6�   ��6x   Z� ��6�   Z� 6�   5'      5(      5)      