   M S B A M L   `   `   `  ����
  e-Cars.    (e_Cars.UI.Tankstellen.TankstelleOverview   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5           UserControlStyle#��[  5      .��5
      �   � RowDefinitions  5   
   �� 5      $��20 �6   �� 5      $
��Auto �6   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� $��0q�6   $��0��6     �� Orientation$ 
Horizontal=�6-   .+�5      �� -   5         ��Name$ 
ButtonBack��5      $��_Zurück��6)   $��60��6T   �� 5      -   5        $ ButtonCreateNew��5      $��_Neu anlegen...��6.   $	��100��6f   5      � 5   
   $��2��6   .+�5      �� $��10,8,0,7q�6   $
��Left=�6&   .��6C   	Filter:6L   �� 5      -   5         ��Name$ TextBoxFilter��5       �� TextAlignment$
 Left=�6-   $	��Top=�6B   $��
54,12,10,0q�6Z   $��18��6n   5      � 5   
   $��3��6   .+�5      �� $��5q�6   
���   �$��1q�64   ._�5      �� -   5         ��Name$ 
myListView��5      ��6/   �� *listTankstelleInfo+ �� View 5!      �� 5"      .P�5#      �� $��ID��6-    �� Width$
 Auto��69    �� DisplayMemberBinding 6F   �� *ID+6l   �� 5$      $��Standort��6-   $
 Auto��6?    6L   �� *
Standort+6x   �� 5%      $��Status��6-   $
 Auto��6=    6J   �� *State+6s   �� 5&      $��Wartungsdatum��6-   $
 Auto��6D    6Q   �� *Wartungsdatum+6�   5(      5*      5+      5,      5.      5/      