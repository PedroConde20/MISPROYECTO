   M S B A M L   `   `   `  ����C  ?ValcotDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:KapDB.ClienteKapDB.Cliente  5   	   !    KapDB.Cliente.winAdmClients   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:KapDB.Cliente     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.1.2567, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�6A   ���	#FF2E2A25$��2q�6o    � Title$ winAdmClients��5   	   $	��550��6   $
��1100��6,   .��5      � .+�5   
   �� .+�5      � ���	#FFE4CB54$��60��6*   .+�5      �� -   5         ��Name$ btnClose��5      $��30��6+   $��30��66   $��Right=�6B   $	��Top=�6^   $��0q�6�   $
��Bold"�6�   ��6v   Z� ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6.   $��25��6;   $��25��6F   
���   �6g   5      �� 5      $��40(�6   $��Clientes��6*   $��Center=�6:   $��Bahnschrift Light)�6U   $��Center=�6u   $��10q�6�   
�������$��	ExtraBold"�6�   ��6�   Z� 5      �� 5       �� Orientation$ 
Horizontal=�6   $��10q�62   $
��Left=�6>   .+�5      �� $��Nombre del Cliente:��6   $��Bahnschrift Light)�66   ���	#FF2D2D35$��14(�6m   $
��Bold"�6{   $��5q�6�   �� 5      -   5        	 ��Name$	 txtNombreCliente��5   ;   $��Bahnschrift Light)�6   $	��200��6U   {�.  $��5q�6s   �� 5      $��Apellidos del Cliente:��6   $��Bahnschrift Light)�6:   ���	#FF2D2D35$��14(�6p   $
��Bold"�6~   $��5q�6�   �� 5      -   5        $	 txtApellidoCliente��5   ;   $��Bahnschrift Light)�6   $	��200��6W   {�.  $��5q�6u   �� 5       $	��Ci:��6   $��Bahnschrift Light)�6&   ���	#FF2D2D35$��14(�6]   $
��Bold"�6k   $��5q�6}   �� 5!      -   5        $	 txtCiCliente��5!   ;   $��Bahnschrift Light)�6   $	��100��6Q   {�.  $��5q�6o   5%      �� 5&      $ 
Horizontal=�6   $��10q�62   $
��Left=�6>   .+�5'      �� $��
Direccion:��6   $��Bahnschrift Light)�6-   ���	#FF2D2D35$��14(�6d   $
��Bold"�6r   $��5q�6�   �� 5(      -   5        $	 txtDireccion��5(   :   $��Bahnschrift Light)�6   $	��200��6P   {�.  $��5q�6n   �� 5)      $��Bahnschrift Light)�6   $��	Telefono:��68   ���	#FF2D2D35$��14(�6c   $
��Bold"�6q   $��5q�6�   �� 5*      -   5        $	 txtTelefono��5*   :   $��Bahnschrift Light)�6   $	��100��6O   {�.  $��5q�6m   �� 5+      $��Bahnschrift Light)�6   $��E-Mail:��68   ���	#FF2D2D35$��14(�6a   $
��Bold"�6o   $��5q�6�   �� 5,      -   5        $	 txtemail��5,   ;   $��Bahnschrift Light)�6   $	��200��6M   {�.  $��5q�6k   5-      �� 5/      .+�50      &   System.Windows.Controls.DataGrid  -	   5        
  Name$
 dgvDatos��50   0   ���#fadc9b$��auto ��6B   $��10q�6P   $	��300��6\      
IsReadOnly .    CanUserAddRows .  6�   51      �� 52      $ 
Horizontal=�6   $��Right=�62   $��10q�6N   .+�53      �� -
   5        $ 	btnInsert��53      $��Intertar��6,   $	��110��6?   $��5q�6K   ���	#FFDC7114���	#FFDC71146�   �� 54      -   5        $ 	btnUpdate��54      $��	Modificar��6,   $	��110��6@   $��5q�6L   
��� ���
��� ���6�   �� 55      -   5        $ 	btnDelete��55      $��Eliminar��6,   $	��110��6?   $��5q�6K   ���	#FFEE6A4D���	#FFEE6A4D6�   �� 56      -   5        $ btnSave��56      $��Guardar��6*   $	��110��6<   $��5q�6H   {�.  ���	#FF027111���	#FF04BD196�   �� 57      -   5        $ btnCancerlar��57      $��Cancelar��6/   $	��110��6B   $��5q�6N   {�.  ���	#FF04BD19���	#FF04BD196�   58      59      5:      5;      