   M S B A M L   `   `   `  ����C  ?ValcotDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:KapDB.ClienteKapDB.Cliente  5   	   '    !KapDB.Cliente.winFindClientByName   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:KapDB.Cliente     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.1.2567, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�6A   ���	#FF2E2A25$��2q�6o    � Title$ winFindClientByName��5   	   $	��500��6%   $	��600��62   .��5      � .+�5   
   �� .+�5      � ���	#FF2D2D35$��39��6*   $��
0,0,-0.2,0q�66   .+�5      �� -   5         ��Name$ btnClose��5      $��30��6+   $��30��66   $��Right=�6B   $	��Top=�6^   $��0q�6�   $
��Bold"�6�   ��6v   Z� ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6.   $��30��6;   $��40��6F   
���   �6g   5      5      (  "MaterialDesignThemes.Wpf.ColorZone  5      $��54��6(   .��5      �� $��Bahnschrift Light)�6   ���	#FF2D2D35$��Center=�6S   $��38(�6n   $
��Bold"�6|   $��	96,0,61,8q�6�   $��Center=�6�   $	��439��6�   �� 6�   $�Seleccionar ��6�   �� 6�   $�Producto��6�   6�   5      �� 5      $
��Left=�6    �� Orientation$ 
Horizontal=�64   $��
10,10,0,10q�6M   $	��577��6a   .+�5        $ ShoppingCart=�6*   $��25��6>   $��25��6J   $��5q�6U   �� 5      -   5        	 ��Name$	 txtFind��5   L   $��Bahnschrift Light)�6   
�������$	��212��6]   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Nombre del Producto��6i      
IsFloating . $��37��6�   �� 5       -   5        $ Select��5       $��Seleccionar��6)   $	��120��6?   $��10q�6K   ���	#FF027111$��Bahnschrift Light)�6n   6�   �� 5!      -   5        $	 txtQuantity��5!   X   $��Bahnschrift Light)�6   $��10q�69   
�������$��92��6m   $
 Cantidad��6x    . 6�   5"      �� 5#      .+�5$      &   System.Windows.Controls.DataGrid  -   5          Name$ dgvDatos��5$   Q   $��Bahnschrift Light)�6   ���	#FFDAA10D$��auto ��6c   $��10,10,9.8,10q�6q   $	��303��6�      
IsReadOnly .    CanUserAddRows .  6�   5%      5&      5'      5(      