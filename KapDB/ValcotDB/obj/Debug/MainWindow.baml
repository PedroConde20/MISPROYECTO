   M S B A M L   `   `   `  ����C  ?ValcotDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KapDBKapDB  5   	       KapDB.MainWindow   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:KapDB     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.1.2567, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      
�������  MaterialDesignFont#���  5       � WindowState$ Normal=�5       � WindowStyle$
 None=�6    � Title$ 
MainWindow��5      $	��680��6   $
��1273��6%    � WindowStartupLocation$ CenterScreen=�62    � 	Resources 5        menuCollapse �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame	 O� KeyTime
 O� Value  menuOpen��%�  &	       &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ gridMenu��6a   .\�5        $	 0��6'   $	
 120Q�63     5      $	 0:0:0:1��6'   $
 60Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ gridMenu��6a   .\�5        $	 0��6'   $
 60Q�63     5      $	 0:0:0:1��6'   $	
 120Q�69   5      5      5        � Triggers 5"      :� 5#   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ btnCollapseMenu��66   .[�5$      �� #��[ 6   5%      :� 5'   
   $ ButtonBase.Click��6   $ btnOpenMenu��66   .[�5(      �� #��[ 6   5)      .��5+      � ��5,   
   �� 5-       �� ImageSource$ Imagenes/microKap.jpg��6    j� Stretch$ UniformToFill=�6=   .+�50   
   � -   5         �Name$ gridMain��50      $
��Auto��6!   $
��Auto��6.   $��0,125,0.4,-0.4q�6<   ��51      �� 52       j� TileMode$ FlipY=�6   .+�54      �� $��/Imagenes/microKap.jpg��6   $
��auto��64   $
��auto��6B   $��-384,-163,-380,-1q�6O   55      � 56   
   $	��120��6   $	��Top=�6   ���	#FFDAA10D$��	0,0,0,400q�6N   .+�57      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�62   $��0,68,0,0q�6M   .+�58      '  !MaterialDesignThemes.Wpf.PopupBox     PlacementMode$ BottomAndAlignRightEdges=�6*      	StaysOpen .  
�������   PopupContent. 59      �� $	��180��6!   .+�5:      �� -   5         ��Name$ btnChangePassword��5:   A   $��Cambiar tu contraseña��6!   6\   �� 5;      -   5        $ btnOlvidoPassword��5;   @   $��Olvido de Contraseña��6!   6[   �� 5<      $��Ayuda��6!   �� 5=      -   5        $ btnAcercaDe��5=   !   $��Acerca de...��66   6M   �� 5>      �� 5?      -   5        $ btnSalir��5?   !   $��Salir��63   6C   5@      5A      �� 5B      -   5         ��Name$ txtUserInfo��5B      $��Bahnschrift Light)�61   $��Usuario : admin��6Q   
�������$��Center=�6{   $��5q�6�   5C      5D      � 5E   
   $��70��6   $	��Top=�6   ���	#FF2D2D35.+�5F      �� -   5        $ 	btnVentas��5F      $��20(�6(   $��Ventas��6c   $��809,10,352.4,10q�6�   $
��Auto��6�   ��66   Z� ��6L   Z� 6�   �� 5G      -	   5        $ btnUsuarios��5G      $��20(�6*   $��Usuarios��6e   $��935,10,214.4,10q�6�   $
��Auto��6�   ��68   Z� ��6N   Z� 6�   �� 5H      -
   5        $ btnReportes��5H      $��20(�6*   $��Reportes��6e   $��1061,10,68.4,10q�6�   $
��Auto��6�   ��68   Z� ��6N   Z� 6�   �� 5I      -   5        $ btnProducts��5I      $��20(�6*   $��Almacen��68   $��667,10,478.4,10q�6�   $
��Auto��6�    � Cursor$
 Hand��6�   ��6J   Z� ��6`   Z� 6�   �� 5J      -   5        $ 
btnClients��5J      $��20(�6)   $��Clientes��67   $��528,10,626.4,10q�6�   $
��Auto��6�   $
 Hand��6�   ��6J   Z� ��6`   Z� 6�   �� 5K      -   5        $ btnProveedores��5K      $��20(�6-   $��Proveedores��6;   $��356,19,750,19q�6   $
��Auto��6�   $
 Hand��6�   ��6Q   Z� ��6g   Z� 6�   �� 5L      -   5        $ 	btnInicio��5L      $��20(�6(   $��Inicio��66   $��10,10,1158.4,10q�6�   $
��Auto��6�   ��6G   Z� ��6]   Z� 6�   �� 5M      -   5        $ btnClose��5M      $��65��6(   $��70��63   $��Right=�6?   $	��Top=�6[   $��0q�6�   $
��Bold"�6�   $��	0,0,0.4,0q�6�   ��6s   Z� ��6�   Z� .��5N      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Power=�6*   $��25��67   $��30��6B   ���	#FFDC71146h   5O      5P      � 5Q   
   -   5        $ gridMenu��5Q      $	��125��6!   $��Right=�6-   $y�	Collapsed=�6I   ���	#FF2D2D35$��	0,120,0,0q�6w   .+�5R      �� .+�5S      � $	��136��6   .+�5T      �� -   5        $ btnCollapseMenu��5T      $��60��66   $��33��6A   $��Right=�6M   $	��Top=�6i   ��6�   Z� ��6�   Z� .��5U        $ 
ArrowRight=�62   $��25��6D   $��25��6O   
�������6q   5V      �� 5W      -   5        $ btnOpenMenu��5W      $��60��62   $��60��6=   $��Right=�6I   $	��Top=�6e   $y�	Collapsed=�6�   ��6}   Z� ��6�   Z� .��5X        $
 Menu=�62   $��25��6>   $��25��6I   
���   �6j   5Y      5Z      5[      �� 5\      -   5         ��Name$ lvwMenu2��5\      $��Disabled=�6)   $��56,73,0,409.6q�6�   5^      �� 5_      $��Disabled=�6   $��56,149,0,336.6q�6N   .@�5`      �� -   5         ��Name$ itemE��5`      $��63��6.   $��72��69    J� RenderTransformOrigin$ 0.5,0.5&�6E   z�5a      V� 5b      .~�5c      �� �� 5d       �� AngleY$ 0.239Q�6,   �� 5e      T� 5f       T� Y$ 0.162Q�61   5g      .��5i      �� -   5        $
��Left=�5i   5   $	��Top=�6P   $��51��6h   $��56��6s   ���	#FFDC7114���	#FF002602.��5j        $ Search=�62   $��Center=�6@   $��25��6]   $��25��6h   
�������$��Center=�6�   6�   5k      5l      5m      5n      5o      5p      