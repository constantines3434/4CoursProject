   M S B A M L   `   `   `  ����H  DEnigmaProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EnigmaProject.ViewEnigmaProject.View  5      -    'EnigmaProject.View.InterfaceAddEditUser   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:EnigmaProject.View     5        N� Title$  InterfaceAddEditUser��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   �� $��
Логин��5      $��0��5      $��0��5      �� 5   
   $��Роль��5      $
��Wrap=�5      $��1��5      $��0��5      �� 5    
   $��Пароль��5!      $��2��5"      $��0��5#      �� 5$   
      CustomTextBoxStyle#��[  5%      $	��550��5&       �� 	MaxLength$	 100��5'      $��1��5(      $��0��5)      $
��Left=�5*      
���   �$��1,1,1,1q�5-      ��5+      �� *LoginOfUser+5-      �� 5.   
   -   5         ��Name$ 	ComboRole��50      $��1��51      $��1��52      $	��300��53      $
��Left=�54      �� 57   
   #��[  58      $	��550��59      $	 100��5:      $��1��5;      $��2��5<      $
��Left=�5=      ��5>      �� *PasswordOfUser+�� 5@   
   -   5         ��Name$ 
ButtonSave��5@      $��Сохранение��5B      $��1��5C      $��4��5D      $��Right=�5E        CustomButtonStyle#��[ 5F      $��60��5G      5I      5J      