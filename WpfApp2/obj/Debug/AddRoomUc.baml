   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5          WpfApp2.AddRoomUc   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      !localclr-namespace:WpfApp2  5      $	��200��5      $	��350��6     � 	Resources  5	         bitSaveImage �� 	UriSource  	saveImage  bitCancelImage  cancelImage J� Opacity��%�   &	        &	 )    7   &	 A     &	 l    7  �� 5
   
   $ images/save.jpg?�6+   �� 5   
   8��  63   �� 5   
   $ images/cancel.jpg?�6-   �� 5   
   $	 0.9Q�65   8��  6C   5      .��5      � -   5        ��5   
   �� 5       �� ImageSource$ images/roombed.jpg��6    �� Opacity$
 0.85Q�6:    � ColumnDefinitions 5   
   �� 5      $��0.35* �6   �� 5      $��0.35* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   .+�5   
   � $��0��6   $��0��6   $��Right=�6,   .+�5      �� $��
No of beds��6   $��Center=�6)   $��30��6F   $��90��6R   5      � 5   
   $��1��6   $��0��6   $
��Left=�6,   .+�5       %  Xceed.Wpf.Toolkit.IntegerUpDown  -   5          Name$ noofbedstxt��5    !   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�66   $��Center=�6B   $��30��6_   $	��165��6k   5!      � 5"   
   $��0��6   $��1��6   $��Right=�6,   .+�5#      �� $��Governed By��6   $��Center=�6*   $��30��6G   $	��100��6S   $��Center=�6_   5$      � 5%   
   $��1��6   $��1��6   $
��Left=�6,   .+�5&      �� -   5        	 ��Name$	 cboGovernedBy��5&   �   
 �� SelectedValuePath$
 nurse_id��6    �� DisplayMemberPath$ Employee.emp_firstname��6�   $
��Left=�6�   $��Center=�6�   $	��165��6  $��30��6   � ToolTip 64   ��  �� RelativeSource �� *Self+ �� Path$) #(Validation.Errors)[0].ErrorContent� �� Text 5'      �� 5(      $ 	nurselist�6    �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�5*       �� NotifyOnValidationError .  �� ValidationRules 5,      5  /System.Windows.Controls.ExceptionValidationRule  5-      5/      51      52      � 53   
   $��1��6   $��2��6   $
��Left=�6,   .+�54      �� -   5         ��Name$ Save_Btn��54      #��[ 6'   $	��Top=�6L   $��0,0,80,0q�6�   $��Right=�6�   $��50��6�   ��6d   Z� ��6{   Z� 6�   �� 55      -   5        $ 
Cancel_Btn��55      #��[ 6)   $��50��6P   $��Center=�6[   $��80,0,0,0q�6�   ��6x   Z� ��6�   Z� 6�   56      57      58      