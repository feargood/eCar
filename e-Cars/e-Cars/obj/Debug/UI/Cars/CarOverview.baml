   M S B A M L   `   `   `  ����A  =e-Cars, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:e_Cars.UI.Carse_Cars.UI.Cars  5           e_Cars.UI.Cars.CarOverview   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:e_Cars.UI.Cars     5      -   5           UserControlStyle#��[  5      .��5      �   � RowDefinitions  5   
   �� 5      $��20 �6   �� 5      $
��Auto �6   �� 5      $��40 �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0q�6   $��0��6     �� Orientation$ 
Horizontal=�6-   .+�5      �� -   5         ��Name$ 
ButtonBack��5      $��_Zurück��6)   $��60��6T   �� 5      -   5        $ ButtonCreateNew��5      $��_Neu anlegen...��6.   $	��100��6f   5      � 5   
   $��2��6   .+�5      �� $��10,8,0,7q�6   $
��Left=�6&   .��6C   	Filter:6L   �� 5      -   5         ��Name$ TextBoxFilter��5       �� TextAlignment$
 Left=�6-   $	��Top=�6B   $��
54,12,10,0q�6Z   $��18��6n   5      � 5   
   $��4��6   .+�5      �� $��5q�6   $��1q�6    ._�5       �� -   5         ��Name$ 
myListView��5       ��6/   �� *listCarsInfo+ �� View 5!      �� 5"      .P�5#      �� $��Seriennummer��6-    �� Width$
 Auto��6C    �� DisplayMemberBinding 6P   �� *Seriennummer+6�   �� 5$      $��Wartungstermin��6-   $
 Auto��6E    6R   �� *Wartungstermin+6�   �� 5%      $��	Kilometer��6-   $
 Auto��6@    6M   �� *	Kilometer+6z   �� 5&      $��Batterieladung��6-   $
 Auto��6E    6R   �� *Batterieladung+6�   �� 5'      $��Tankvorgänge��6-   $
 Auto��6C    6P   �� *Tankvorgaenge+6�   �� 5,      $��Gesperrt��6-   $
 Auto��6?   	 �� CellTemplate	 5-   "   �� 5.   &   .R�5/   *   �� 
 J� IsHitTestVisible
 .  |�.   d� 	IsChecked 63   ��  �� Path$ Gesperrt�6�   50   '   52      �� 55      $��Spontanenutzung gesperrt��6-   $
 Auto��6O   	 56   "   �� 57   &   .R�58   *   �� 
 .  |�.   63   �� $ SpontaneNutzungGesperrt�6�   59   '   5;      �� 5>      $��Reservierung gesperrt��6-   $
 Auto��6L   	 5?   "   �� 5@   &   .R�5A   *   �� 
 .  |�.   63   �� $ ReservierungGesperrt�6�   5B   '   5D      5G      5I      5J      5K      5L      5M      