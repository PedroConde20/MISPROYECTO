   M S B A M L   `   `   `  ����C  ?ValcotDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KapDB.StockKapDB.Stock  5   	   !    KapDB.Stock.winIngresoVinos   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:KapDB.Stock     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.1.2567, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�6A   ���	#FF2E2A25$��2q�6o    � Title$ winIngresoVinos��5   	   $	��500��6!   $	��800��6.   .��5      � .+�5   
   �� .+�5      � ���	#FF2D2D35$��60��6*   .+�5      �� -   5         ��Name$ btnClose��5      $��30��6+   $��30��66   $��Right=�6B   $	��Top=�6^   $��0q�6�   $
��Bold"�6�   ��6v   Z� ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6.   $��25��6;   $��25��6F   
���   �6g   5      �� 5      -   5         ��Name$ txtTitle��5      $��Bahnschrift Light)�6.   $�� _______ Producto��6M   $��Center=�6f   $��Center=�6�   $��10q�6�   $��30(�6�   
�������$
��Bold"�6�   ��6�   Z� 5      � 5      $��10q�6   	 � RowDefinitions	 5      �� 5      $	��70* �6$   �� 5      $
��135* �6$   �� 5      $
��204* �6$   
 � ColumnDefinitions
 5       �� 5!      �� 5"      .+�5%      �� $��3��6   .+�5&      � 
 5'      �� 5(      �� 5)      	 5+      �� 5,      �� 5-      �� 5.      �� 5/      �� 50      �� 51      �� 52      �� 53      .+�56      �� $ ��Seleccione una categoría:��6    
���   �$
��Bold"�6W   �� 57      -   5         ��Name$ cbxCategoryProduct��57   #   {�.  $��1��6Q   6�   �� 58      $��1��6    $��Nombre del producto:��6-   
���   �$
��Bold"�6_   �� 59      -   5         ��Name$ txtNombreProduct��59   A   {�.  $��1��64   $��1��6[   6m   �� 5;      $��2��6    $��Precio Unitario(Bs):��6-   
���   �$
��Bold"�6_   �� 5<      -   5        $ 	txtPrecio��5<   A   {�.  $��2��64   $��1��6T   6f   �� 5>      $��3��6    $��Stock:��6-   
���   �$
��Bold"�6Q   �� 5?      -   5        $ txtStock��5?   A   {�.  $��3��64   $��1��6S   6e   �� 5A      $��4��6    $ ��Descripción del producto:��6-   
���   �$
��Bold"�6d   �� 5B      -   5        $ txtDescripcion��5B   U   {�.  $��2��64   $��5��6H    �� TextWrapping$
 Wrap=�6m    �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�6�   6�   �� 5D      $��Seleccione un proveedor:��6    $��6��6C   
���   �$
��Bold"�6c   �� 5E      -	   5        $ cbxProveedorProduct��5E   #   $��5��6@   {�.  $��1��6_   $��2��6�   $	��Top=�6�   $��0,42,0,0q�6�   6
  5F      �� 5G      $��10q�6!   .+�5H      ��  �� Orientation$ 
Horizontal=�6%   $��Right=�6>   $	��358��6Z   .+�5I      �� -
   5        $ txtPhoto��5I   J   {�.  $��0 0 20 0q�68   $	��116��6\   �� 5J      $��0 0 20 0q�6$   $��Imagen del producto:��66   
���   �$
��Bold"�6h   �� 5K      -   5        $ btnAgregarImagen��5K   e   {�.  $��. . .��67   $��30��6G   $��	20 0 0 0 q�6R   $��30��6�   $��Right=�6�   $	��Top=�6�   ���	#FF2E2A25���	#FF2E2A25$��0q�6  
�������$
��Bold"�6,  5L      �� 5N      -   5         ��Name$ imgFoto��5N       $��10q�61   $	��120��6=   6L   5O      5P      �� 5Q      ���	#FF2D2D35$��1��64   $��3��6D   $��0.2,0,-0.2,18q�6U   .+�5R      &   System.Windows.Controls.DataGrid  -   5          Name$ dgvDatos��5R      $��auto ��61   $��10q�6?   $	��317��6K      
IsReadOnly .    CanUserAddRows .  6�   5S      5T      �� 5U      $ 
Horizontal=�6   $
��Left=�62   $	��559��6M   .+�5V      �� -   5        $ btnSave��5V      $��10q�6*   $��Guardar��66   $��93��6^   ���	#FF0271116i   �� 5W      -   5        $ btnCancelar��5W      $��10q�6.   $��Cancelar��6:   $	��101��6M   ���	#FF0271116p   �� 5X      -   5        $ btnInsertar��5X      $��10q�6.   $��Insertar��6:   $��96��6M   ���	#FFDC7114���	#FFDC71146�   �� 5Y      -   5        $ 	btnUpdate��5Y      $��10q�6,   $��	Modificar��68   
��� ���
��� ���$��93��6�   �� 5Z      -   5        $ 	btnDelete��5Z      $��Eliminar��6,   ���	#FFEE6A4D���	#FFEE6A4D$��92��6�   5[      5\      5]      5^      