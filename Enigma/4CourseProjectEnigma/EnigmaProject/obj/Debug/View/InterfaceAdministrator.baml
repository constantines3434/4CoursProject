   M S B A M L   `   `   `  ����H  DEnigmaProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EnigmaProject.ViewEnigmaProject.View  5      /    )EnigmaProject.View.InterfaceAdministrator   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:EnigmaProject.View     5        N� Title$  InterfaceAdministrator��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �  � Orientation$ 
Horizontal=�6   $��Center=�6-   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   .+�5      �� $#��Поиск по логину:��6   $	��175��64   $
��Left=�6@    �� TextAlignment$ Right=�5      �� 5      -   5        $��
TBoxSearch��5   !      CustomTextBoxStyle#��[  5      $	��225��5      $
��Left=�6X   5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5        $��AddEmployee��5   %   $��20q�5      $��1��6%   $��13(�5      $	��150��5      $��Center=�5   /     CustomButtonStyle#��[ 5      $/��)Добавить пользователя��5      5       �� 5!      $ 
Horizontal=�6   .+�5"      �� -   5        $��
GoToEnigma��5"   >   $��20q�6   $��1��6%   $	��150��62   $��Center=�5#   2   #��[ 5$      $��Энигма��5%      5&      5'      �� 5(   
   -   5        $��ListViewEmployees��5(       $��2��6   $��Disabled=�69   $��Center=�5)      ��5*      �� 5+      .R�5,      � $ 
Horizontal=�6    $��Center=�5-       6?   5.      ��50      �� 51      .R�52      � $��20q�6   $	��400��6'    53      �� 54      $��40 �6,   �� 55      $
��auto �6,   �� 56      $
��auto �6,   �� 57      $
��auto �6,   �� 58      $
��auto �6,   �� 59      $
��auto �6,   �� 5:      $
��auto �6,   �� 5;      $
��auto �6,   .+�5>      �� $��Center=�5@      $ Center=�5A      $	��390��5B      $
��Wrap=�5C      $��Center=�5D      $
��5, 5q�5E      $��20(�5F      $��0��5G      ��5H      �� *
RoleOfUser+�� 5I      $��2��6A   $��5 5 5 15q�6N   $��Center=�6`   $��26(�6}   $
��Bold"�6�   ��6$   �� *LoginOfUser+6�   �� 5J      -   5        #��[ 5J   !   $��40��5K   M   $	��120��5L   M   $��Удалить��5M   M   $��Center=�6_   $��6��5N   M   6[   �� 5O      -   5        #��[ 5O   !   $��40��6L   $	��120��5P   M   $ ��Редактировать��6Y   $��Center=�6q   $��7��6�   6�   5Q      5R      5T      5U      5V      