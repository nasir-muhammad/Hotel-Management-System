   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5          WpfApp2.AddPatientUc   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp2     5      $	��290��5      $	��500��6     � 	Resources  5         bitSaveImage �� 	UriSource  	saveImage  bitCancelImage  cancelImage J� Opacity��%�   &	        &	 )    7   &	 A     &	 l    7  �� 5	   
   $ images/save.jpg?�6+   �� 5
   
   8��  64   �� 5   
   $ images/cancel.jpg?�6-   �� 5   
   8��  $	 0.9Q�6^   5      .��5      � -   5         � ColumnDefinitions 5   
   �� 5      $��0.35* �6   �� 5      $��0.35* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��65 �6   .+�5   
   � $��0��6   $��0��6   $��Right=�6,   .+�5      �� $
��Name��6   $��Right=�6#   $	��100��6?   $��Center=�6K   5      � 5   
   $��1��6   $��0��6   $
��Left=�6,   $	��150��6G   .+�5      �� -   5         ��Name$ 
patienttxt��5      $��25��6*   $	��150��66   $��Right=�6B   $��Center=�6^   5       � 5!   
   $��0��6   $��1��6   $��Right=�6,   .+�5"      �� $��Gender��6   $��Center=�6%   $	��100��6B   $��Center=�6N   5#      � 5$   
   $��1��6   $��1��6   $
��Left=�6,   .+�5%      	� -   5         	�Name$ 	radiomale��5%      $
��Male��6-    d� 	IsChecked$
 TrueY�6<   $
��Left=�6M   $��Center=�6h   	� 5&      -   5        $ radiofemale��5&      $��Female��60   $
��Left=�6A   $��Center=�6\   $��50,0,0,0q�6w   5'      � 5(   
   $��0��6   $��2��6   $��Right=�6,   .+�5)      �� $��Date Of Birth��6   $	��100��6,   $��Center=�68   $��Center=�6V   5*      � 5+   
   $��1��6   $��2��6   $
��Left=�6,   .+�5,      (  "System.Windows.Controls.DatePicker  -   5          Name$ 
datepicker��5,      $	��150��6-   $��25��69   $��Center=�6E   5-      � 5.   
   $��0��6   $��3��6   $��Right=�6,   .+�5/      �� $��Category��6   $	��100��6(   $��25��64   $��Center=�6@   50      � 51   
   $��1��6   $��3��6   $
��Left=�6,   .+�52      �� -   5        	 ��Name$	 comboCat��52      $
��Left=�6�   $��Center=�6�   $	��150��6�   
 � ToolTip
 6)   ��  �� RelativeSource �� *Self+ �� Path$) #(Validation.Errors)[0].ErrorContent� �� Text 53      �� 54      $ Category�6    �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�56       �� NotifyOnValidationError .  �� ValidationRules 58      5  /System.Windows.Controls.ExceptionValidationRule  59      5;      5=      5>      � 5?   
   $��1��6   $��4��6   $
��Left=�6,   .+�5@      �� -   5         ��Name$ 
Cancel_btn��5@      #��[ 6)   $��50��6\   $��80,0,0,0q�6h   ��6z   Z� ��6�   Z� 6�   �� 5A      -   5        $ Save_btn��5A      #��[ 6(   $��50��6Y   $��Right=�6d   $��49��6�   $	��Top=�6�   $��0,0,80,0q�6�   ��6�   Z� ��6�   Z� 6�   5B      5C      5D      