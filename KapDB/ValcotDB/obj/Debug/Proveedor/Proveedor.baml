   M S B A M L   `   `   `  ����C  ?ValcotDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ValcotDB.ProveedorValcotDB.Proveedor  5   	   "    ValcotDB.Proveedor.Proveedor   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ValcotDB.Proveedor     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.1.2567, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�6A   ���	#FF2E2A25$��2q�6o    � Title$ 	Proveedor��5   	   $	��572��6   $	��800��6(   .��5      � .+�5   
   �� .+�5      � ���	#FFE4CB54$��60��6*   .+�5      �� -   5         ��Name$ btnClose��5      $��30��6+   $��30��66   $��Right=�6B   $	��Top=�6^   $��0q�6�   $
��Bold"�6�   ��6v   Z� ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6.   $��25��6;   $��25��6F   
���   �6g   5      �� 5      $��40(�6   $��Proveedores��6*   $��Center=�6=   $��Bahnschrift Light)�6X   $��Center=�6w   $��10q�6�   
�������$��	ExtraBold"�6�   ��6�   Z� 5      �� 5       �� Orientation$ 
Horizontal=�6   $��10q�62   $
��Left=�6>   .+�5      �� $��Nombre del Proveedor:��6   $��Bahnschrift Light)�68   ���	#FF2D2D35$��14(�6n   $
��Bold"�6|   $��5q�6�   �� 5      -   5        	 ��Name$	 txtNombreProveedor��5   9   $��Bahnschrift Light)�6   $	��200��6U   $��5q�6a   �� 5      $��Apellido del Proveedor:��6   $��Bahnschrift Light)�6:   ���	#FF2D2D35$��14(�6p   $
��Bold"�6~   $��5q�6�   �� 5      -   5        $	 txtApellidoProveedor��5   9   $��Bahnschrift Light)�6   $	��200��6W   $��5q�6c   
 � Cursor$
 IBeam��6n   5       �� 5"      $ 
Horizontal=�6   $��10q�62   $
��Left=�6>   .+�5#      �� $��CI/NIT del Proveedor:��6   $��Bahnschrift Light)�68   ���	#FF2D2D35$��14(�6n   $
��Bold"�6|   $��5q�6�   �� 5$      -   5        $	 txtCodigoProveedor��5$   9   $��Bahnschrift Light)�6   $	��100��6U   $��5q�6a   �� 5%      $��Dirección:��6   $��Bahnschrift Light)�6-   ���	#FF2D2D35$��14(�6c   $
��Bold"�6q   $��5q�6�   �� 5&      -   5        $	 txtDireccion��5&   9   $��Bahnschrift Light)�6   $	��200��6O   $��5q�6[   5'      �� 5)      $ 
Horizontal=�6   $��10q�62   $
��Left=�6>   .+�5*      �� $��
Teléfono:��6   $��Bahnschrift Light)�6,   ���	#FF2D2D35$��14(�6b   $
��Bold"�6p   $��5q�6�   �� 5+      -   5        $	 txtTelefono��5+   9   $��Bahnschrift Light)�6   $	��100��6N   $��5q�6Z   �� 5,      $��E-Mail:��6   $��Bahnschrift Light)�6*   ���	#FF2D2D35$��14(�6`   $
��Bold"�6n   $��5q�6�   �� 5-      -   5        $	 txtemail��5-   9   $��Bahnschrift Light)�6   $	��200��6K   $��5q�6W   5.      �� 50      .+�51      &   System.Windows.Controls.DataGrid  -	   5          Name$ dgvDatos��51   0   ���#fadc9b$
��auto��6B   $��10q�6O   $	��250��6[      
IsReadOnly .    CanUserAddRows .  6�   52      �� 54      $ 
Horizontal=�6   $��Right=�62   $��10q�6N   .+�55      �� -
   5        $ 	btnInsert��55      $��Insertar��6,   $	��110��6?   $��5q�6K   ���	#FFDC7114���	#FFDC71146�   �� 56      -   5        $ 	btnUpdate��56      $��	Modificar��6,   $	��110��6@   $��5q�6L   
��� ���
��� ���6�   �� 57      -   5        $ 	btnDelete��57      $��Eliminar��6,   $	��110��6?   $��5q�6K   ���	#FFEE6A4D���	#FFEE6A4D6�   �� 58      -   5        $ btnSave��58      $��Guardar��6*   $	��110��6<   $��5q�6H   {�.  ���	#FF027111���	#FF04BD196�   �� 59      -   5        $ btnCancelar��59      $��Cancelar��6.   $	��110��6A   $��5q�6M   {�.  ���	#FF04BD19���	#FF04BD196�   5:      5;      5<      5>      