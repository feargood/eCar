   M S B A M L   `   `   `  ����
  e-Cars1    +e_Cars.UI.Reservierung.ReservierungOverview   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5         UserControlStyle#��[  5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��20 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0q�6   $��0��6     �� Orientation$ 
Horizontal=�6-   .+�5      �� -   5         ��Name$ 
ButtonBack��5      $��_Zurück��6)   $��60��6T   �� 5      -   5        $ ButtonCreateNew��5      $��_Neu anlegen...��6.   $	��100��6f   5      � 5   
   $��2��6   .+�5      �� .+�5      � .+�5      �� $��10,0,0,0q�6   $
��Left=�6.   .��6K   	Filter:6T   �� 5      -   5         ��Name$ TextBoxFilter��5       �� TextAlignment$
 Left=�65   $	��Top=�6J   $��	70,4,10,0q�6b   $��18��6u   5      � 5      .+�5      �� $��10,0,0,0q�6   $��Datum: ��6.   $	��Top=�6@   $
��Left=�6X   $��50��6s   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ DatepickerDatum��5   !   $
��Left=�6�   $��70,0,0,0q�6�   $	��Top=�6�   $	��140��6�      SelectedDate 6:   �� *WartungsTermin+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5      � 5       .+�5!      �� -   5         ��Name$ CheckBoxReservierung��5!      $��15,0,0,0q�6=   $��Reservierung gesperrrt��6O   6r   5"      5$      5%      � 5'   
   $��3��6   .+�5(      �� $��5q�6   
���   �$��1q�64   ._�5)      �� -   5        	 ��Name$	 
myListView��5)      ��6/   �� *listTankstelleInfo+
 �� View
 5*      �� 5+      .P�5,      �� $	��Von��6-    �� Width$
 Auto��6:    �� DisplayMemberBinding 6G   �� *ID+6m   �� 5-      $	��Bis��6-   $
 Auto��6:    6G   �� *
Standort+6s   �� 5.      $��Start��6-   $
 Auto��6<    6I   �� *State+6r   �� 5/      $
��Ziel��6-   $
 Auto��6;    6H   �� *Wartungsdatum+6y   �� 50      $
��Auto��6-   $
 Auto��6;    6H   �� *State+6q   �� 51      $��Kunde��6-   $
 Auto��6<    6I   �� *Wartungsdatum+6z   53      55      56      57      58      59      