   M S B A M L   `   `   `  ����J  FBeosztasTervezo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BeosztasTervezoBeosztasTervezo  5   	   O,clr-namespace:BeosztasTervezo.MVVM.ViewModelBeosztasTervezo.MVVM.ViewModel  5   	        BeosztasTervezo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:BeosztasTervezo     5   	   B	viewModel,clr-namespace:BeosztasTervezo.MVVM.ViewModel     5   	   $	��800��5	   	   $
��1250��6     � WindowStyle$
  None=�5
   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      2  ,BeosztasTervezo.MVVM.ViewModel.MainViewModel  5   
   .��5      �� ���#272537 �� CornerRadius$ 20��5   	   ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5       � RowDefinitions 5      �� 5      $��75 �6    �� 5      .+�5!      �� $��Beosztás tervező��6   $��Center=�5"      $
��Left=�5#      
�������$��22(�5%      $��20,0,0,0q�5&      �� 5(      $��1��6   $��0,50,0,0q�6&   .+�5)      	� $��Új résztvevő��6   $��50��5*      
�������$��15(�5,         MenuButtonTheme#��[  5-      ��5.      �� *UjresztvevoViewCommand+	� 5/      $��Résztvevők��6   $��50��50      
�������$��15(�52       d� 	IsChecked$
 TrueY�53      #��[  54      ��55      �� *ResztvevokViewCommand+	� 56      $��	Beosztás��6   $��50��57      
�������$��15(�59      #��[  5:      ��5;      �� *TervezoViewCommand+5<      �� 5=      $��Verziószám: 1.1��6   
�������$��22(�5?      $��1��5@      $��Center=�5A      $��30,0,0,0q�5B      �� 5D      $��1��6   $��1��5E      $��10q�5F      ��5G      �� *CurrentView+5I      5K      5L      5M      