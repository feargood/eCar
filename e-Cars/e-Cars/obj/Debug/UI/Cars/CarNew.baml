   M S B A M L   `   `   `  ����A  =e-Cars, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:e_Cars.UI.Carse_Cars.UI.Cars  5          e_Cars.UI.Cars.CarNew   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,locclr-namespace:e_Cars.UI.Cars     5         UserControlStyle#��[  5        � 	Resources  5      *   $e_Cars.UI.Cars.IntToProzentConverter  	converter��%   &	         5   
   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0q�6    �� Orientation$ 
Horizontal=�6!   .+�5      �� -   5         ��Name$ ButtonZurueck��5      $��_Zurück��6,   $��60��6Z   5      � 5   
   $��1��6   .+�5      �� $��
Stammdaten��6   $��5q�6+   $	��Top=�66   $��2��6N   .��5      � .+�5      �� -   5         ��Name$ LabelSeriennummer��5      $��	10,10,0,0q�67   $��Seriennummer: ��6J   $	��Top=�6c   $
��Left=�6{   $	��105��6�   �� 5      -   5         ��Name$ TextBoxSeriennummer��5      $��120,10,10,0q�6�   $	��Top=�6�   ��6;   ��  �� Path$ Seriennummer� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5       $��	10,41,0,0q�6   $��Wartungstermin: ��6/   $	��Top=�6K   $
��Left=�6c   $	��105��6~   (  "System.Windows.Controls.DatePicker  5!      -   5          Name$ DatepickerWartungstermin��5!   !   $
��Left=�6�   $��
120,42,0,0q�6�   $	��Top=�6�   $	��140��6�   	   SelectedDate	 6C   �� *WartungsTermin+$ PropertyChanged=�6�   �� 5"      $��	10,72,0,0q�6   $��Batterieladung: ��6/   $	��Top=�6K   $
��Left=�6c   $	��105��6~   �� 5#      $��
120,72,0,0q�6   $	��Top=�6�   $
��Left=�6�   $��55��6�   $��26��6�   ��60   �� $ Batterieladung�
 �� 	Converter#
 [ 6�   �� 5$       � SmallChange$ 1Q�6h    � Minimum$ 0Q�6x    � Maximum$	 100Q�6�   $	��Top=�6�   $��180,72,10,0q�6�   $��26��6�    � Value 6   �� $ Batterieladung�$ PropertyChanged=�6�   �� 5&      -   5        $ LabelKilometerstand��5&      $��
10,103,0,0q�69   $��Kilometerstand: ��6M   $	��Top=�6h   $
��Left=�6�   $	��105��6�   �� 5'      -   5        $ TextBoxKilometerstand��5'       �� 	MaxLength$ 7��6=   $��120,107,10,0q�6�   $	��Top=�6�   ��6�   �� $ Kilometerstand�$ PropertyChanged=�6�   �� 5)      -   5        $ LabelTankvorgaenge��5)      $��
10,134,0,0q�68   $��Tankvorgänge: ��6L   $	��Top=�6e   $
��Left=�6}   $	��105��6�   �� 5*      -   5        $ TextBoxTankvorgaenge��5*      $ 7��6<   $��120,138,10,0q�6�   $	��Top=�6�   ��6�   �� $ Tankvorgaenge�$ PropertyChanged=�6�   �� 5,      -	   5        $ LabelStatus��5,      $��
10,165,0,0q�61   $��Status: ��6E   $	��Top=�6X   $
��Left=�6p   $	��105��6�   �� 5-      -
   5         ��Name$ ComboBoxStatus��5-      $��120,168,10,0q�67   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   ��6M   �� $ 
listStatus� �� SelectedItem 6u   �� *selectedStatus+��5/      �� 50      .R�51   "   �� $ 
Horizontal=�6-   .+�52   &   �� $��30��6K   $��0,2,5,2q�6V   ��60   �� *	Status_ID+6V   �� 53   &   ��60   �� *Statusbezeichnung+54   #   55      58      59      5:      �� 5<      -   5        $ ButtonAnlegen��5<      $��anlegen��6H   $��	0,0,10,10q�6Z   $��Bottom=�6m   $��Right=�6�   $��75��6�   5=      5>      5?      