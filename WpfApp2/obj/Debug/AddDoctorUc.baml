   M S B A M L   `   `   `  ����  WpfApp2    WpfApp2.AddDoctorUc   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      $	��300��5      $	��460��6     � 	Resources  5         bitSaveImage �� 	UriSource  	saveImage  bitCancelImage  cancelImage��%�   &	        &	 )    7   &	 A     &	 l    7  �� 5	   
   $ images/save.jpg?�6+   �� 5
   
   8��  64   �� 5   
   $ images/cancel.jpg?�6-   �� 5   
   8��  65   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��0.35* �6   �� 5      $��0.35* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   .+�5   
   � $��0��6   $��0��6   $��Right=�6,   .+�5      �� $��	FirstName��6   $��11(�6(   $��Time New Roman)�66   $��Center=�6R   $
��Left=�6m   $��	0,0,170,0q�6�   �� 5      -   5         ��Name$ firstnametxt��5      $��20��6,   $	��150��68   $��Center=�6D   $��Right=�6_   5      � 5   
   $��1��6   $��0��6   $
��Left=�6,   .+�5      �� $��UserName��6   $��11(�6'   $��Time New Roman)�65   $��Center=�6Q   $
��Left=�6l   $��	5,0,165,0q�6�   �� 5       -   5        $ usernametxt��5       $��20��6,   $	��150��68   $��Center=�6D   $��Right=�6_   5!      � 5"   
   $��0��6   $��1��6   $��Right=�6,   .+�5#      �� $��LastName��6   $��11(�6'   $��Time New Roman)�65   $��Center=�6Q   $
��Left=�6l   $��	0,0,170,0q�6�   �� 5$      -   5        $ lastnametxt��5$      $��20��6+   $	��150��67   $��Center=�6C   $��Right=�6^   5%      � 5&   
   $��1��6   $��1��6   $
��Left=�6,   .+�5'      �� $��Password��6   $��11(�6'   $��Time New Roman)�65   $��Center=�6Q   $
��Left=�6l   $��	5,0,170,0q�6�   G� 5(      -   5         G�Name$ passwordbox��5(      $��20��6/   $	��150��6;   $��Center=�6G   $��Right=�6b    G� PasswordChar$ *��6~   5)      � 5*   
   $��0��6   $��2��6   $��Right=�6,   .+�5+      �� $��Date of Birth��6   $��11(�6,   $��Time New Roman)�6:   $��Center=�6V   $
��Left=�6q   $��	0,0,158,0q�6�   (  "System.Windows.Controls.DatePicker  5,      -   5          Name$ 
datepicker��5,      $��22��6-   $	��150��69   $��Center=�6E   $��Right=�6`   5-      � 5.   
   $��1��6   $��2��6   $
��Left=�6,   .+�5/      �� $��Specialization��6   $��11(�6-   $��Time New Roman)�6;   $��Center=�6W   $
��Left=�6r   $��	5,0,151,0q�6�   �� 50      -   5        $ experty��50      $��20��6'   $	��150��63   $��Center=�6?   $��Right=�6Z   51      � 52   
   $��0��6   $��3��6   $��Right=�6,   $��0,2,0,49q�6H   $��2��6Z   .+�53      �� $��Phone��6   $��11(�6$   $��Time New Roman)�62   $��Center=�6N   $
��Left=�6i   $��	0,0,185,0q�6�   %  Xceed.Wpf.Toolkit.MaskedTextBox  54      -   5          Name$ cellno��54   !   	   Mask$	 0000-0000000��61   $��20��6E   $	��150��6Q   $��Center=�6]   $��Right=�6x   55      � 56   
   $��1��6   $��3��6   $
��Left=�6,   .+�57      �� $��Salary��6   $��11(�6%   $��Time New Roman)�63   $��Center=�6O   $
��Left=�6j   $��	5,0,185,0q�6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  58      -   5        
  Name$
 
paymenttxt��58   !   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 15000X�65      Maximum$ 100000X�6E   $��20��6V   $	��150��6b   $��Center=�6n   $��Right=�6�   59      � 5:   
   $��0��6   $��4��6   $��Right=�6,   .+�5;      �� $��Gender��6   $��11(�6%   $��Time New Roman)�63   $��Center=�6O   $
��Left=�6j   $��	0,0,180,0q�6�   	� 5<      -	   5         	�Name$ radiofemale��5<      $��Female��6/   $��Right=�6@   $��center=�6\   	� 5=      -
   5        $ 	radiomale��5=      $
��Male��6-    d� 	IsChecked$
 TrueY�6<   $��Right=�6M   $��center=�6i   $��0,0,60,0q�6�   5>      � 5?   
   $��1��6   $��4��6   $
��Left=�6,   .+�5@      �� -   5         ��Name$ save_btn��5@      #��[ 6'   $��50��6X   $
��Left=�6�   $��20,0,0,0q�6�   ��6c   Z� ��6z   Z� 6�   �� 5A      -   5        $ 
cancel_btn��5A      #��[ 6)   $��50��6\   $��Center=�6�   $��	100,0,0,0q�6�   ��6g   Z� ��6~   Z� 6�   5B      5C      5D      