   M S B A M L   `   `   `  ����H  DBinaryCalcNew, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:BinaryCalcNewBinaryCalcNew  5   	       BinaryCalcNew.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:BinaryCalcNew     5   	     � Title$  Binary Caculator��5   	   $	��450��6"   $	��500��6/    � WindowStartupLocation$ CenterScreen=�6;   .��5	      � $��10,195,2,-3q�6    � RowDefinitions 5
   
   �� 5      $
��111* �6   �� 5      $	��95* �6    � ColumnDefinitions 5   
   �� 5      $	��18* �6   �� 5      $
��102* �6   �� 5      $	��31* �6   �� 5      $	��89* �6   �� 5      $	��30* �6   �� 5      $	��90* �6   �� 5      $
��100* �6   �� 5      $	��20* �6   .+�5   
   �� -   5        $��btnCE��5   B   $��
7,10,10,19q�6   $��CE��6%   $��1��62   ���	#FFE26666$��36(�6f   $
��Bold"�6t   6�   �� 5   
   -   5        $��btnOne��5   B   $��25,10,10,19q�6   $��1��6&   $��2��62   $��2��6P    J� RenderTransformOrigin$ 0.498,-0.01&�6d   $��36(�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $��btnON��5   R   $��	7,0,10,12q�6   $��ON/AC��6$   $��1��64   $��1��6A   ���	#FFE2702F$��24(�6v   $
��Bold"�6�   6�   �� 5   
   -   5        $��btnMinus��5   B   $��25,10,10,19q�6   $��-��6&   $��6��62   $��2��6R   $��36(�6f   $
��Bold"�6t   6�   �� 5   
   -   5        $��btnPlus��5   B   $��25,10,10,19q�6   $��+��6&   $��4��62   $��2��6Q   $��36(�6e   $
��Bold"�6s   6�   �� 5   
   -   5        $��btnZero��5   N   $��
25,0,10,12q�6   $��0��6%   $��1��61   $��2��6>   $��2��6]   $��36(�6q   $
��Bold"�6   6�   �� 5   
   -   5        $
��btnC��5   N   $��
25,0,10,12q�6   $��C��6%   $��1��61   $��4��6>   $��2��6Z   ���	#FFE49999$��36(�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $��btnEquel��5   N   $��
25,0,10,12q�6   $��=��6%   $��1��61   $��6��6>   $��2��6^   $��36(�6r   $
��Bold"�6�   6�   � 5    
   $��8��6   $��Stretch=�6#   $��0,-192,0,147q�6A   $��Stretch=�6W    J� 	AllowDrop .   5!      �� 5"      $	��43* �6    �� 5#      $
��124* �6    .+�5%      �� -	   5         ��Name$ 
lblFormula��5%      $�� ��6(   $��Stretch=�63   $��	0,0,10,10q�6Q   $��Stretch=�6d   ���	#FFECE2A8{�.  6�   �� 5&      -
   5         ��Name$ 
txtDisplay��5&      $��Right=�6*   $��0,12,0,0q�6F   $��1��6X    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $��40(�6�   $
��Bold"�6�   	 �� TextAlignment$	 Right=�6�   {�.  6�   5'      5(      5)      