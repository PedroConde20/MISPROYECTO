   M S B A M L   `   `   `  ����C  ?ValcotDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:KapDB.UsuariosKapDB.Usuarios  5          KapDB.Usuarios.Usuarios   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:KapDB.Usuarios     5      b ^MaterialDesignThemes.Wpf, Version=4.1.1.2567, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      -   5           MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � .+�5   
   � $��56��6   $	��Top=�6   ���	#FF2D2D35.+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0,10,0,0q�6O   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Account=�6*   $��66��69   $��48��6D   
�������$��Center=�6c   $��0,0,0,8q�6~   6�   �� 5      $��Añadir nuevo Usuario��6   
�������$��Bahnschrift Light)�6K   $��Center=�6j   $��Center=�6�   $��20(�6�   $
��Bold"�6�   $��10,11,0,4.4q�6�   $��31��6�   $	��276��6�   5      5      �� 5   
   $��0,61,0,-0.4q�6   
�������.+�5      �� $ 
Horizontal=�6   $
��Left=�62   $��10q�6M   .+�5      �� $��Nombre:��6   ���	#FFDAA10D$��14(�6A   $��Bahnschrift Light)�6O   $
��Bold"�6n   $��5q�6�   �� 5      -   5         ��Name$ 	txtNombre��5      $	��111��6.   {�.  $��Bahnschrift Light)�6L   $��5q�6k   �� 5      $��	Apellido:��6   ���	#FFDAA10D$��Bahnschrift Light)�6C   $��14(�6b   $
��Bold"�6p   $��5q�6�   �� 5      -   5        $ txtApellido��5      $	��111��60   {�.  $��Bahnschrift Light)�6N   $��5q�6m   �� 5      $	��CI:��6   $��Bahnschrift Light)�6&   ���	#FFDAA10D$��14(�6\   $
��Bold"�6j   $��5q�6|   �� 5       -   5        $ txtCi��5       $	��110��6*   {�.  $��5q�6H   $��Bahnschrift Light)�6S   �� 5!      $��E-Mail:��6   ���	#FFDAA10D$��Bahnschrift Light)�6A   $��14(�6`   $
��Bold"�6n   $��5q�6�   �� 5"      -   5        $ txtemail��5"      $	��148��6-   {�.  $��5q�6K   $��Bahnschrift Light)�6V   5#      �� 5$      $ 
Horizontal=�6   $��10q�62   $
��Left=�6>   .+�5%      �� -   5        $��Bahnschrift Light)�5%   D   $��Nombre de Usuario��6c   ���	#FFDAA10D$��14(�6�   $
��Bold"�6�   $��5q�6�   �� 5&      -   5        $ txtNombreusuario��5&      $	��161��65   {�.  $��5q�6S   $��Bahnschrift Light)�6^   �� 5'      $
��Rol:��6   ���	#FFDAA10D$��Bahnschrift Light)�6>   $��14(�6]   $
��Bold"�6k   $��5q�6}   �� 5(      -   5        $ txtRol��5(      $	��114��6+   {�.  $��5q�6I   $��Bahnschrift Light)�6T   �� 5)      -	   5        $��Bahnschrift Light)�5)   F   $��Contraseña:��6e   ���	#FFDAA10D$��14(�6�   $
��Bold"�6�   $��5q�6�   �� 5*      -
   5        $ txtContraseña��5*      $	��127��62   {�.  $��5q�6P   $��Bahnschrift Light)�6[   5+      �� 5,      $ 
Horizontal=�6   $��Right=�62   .+�5-      &   System.Windows.Controls.DataGrid  -   5          Name$ dgvDatos��5-   d   
����������	#FF2D2D35$��Bahnschrift Light)�6E   $	��538��6v   $��507,10,0,10q�6�   $	��220��6�      
IsReadOnly .    CanUserAddRows .  6�   �� 5.      -   5        $��imageCapture��5.      $	��218��6-   $	��202��6:   �� 5/      -   5         ��Name$ 	btnCargar��5/      $��Bahnschrift Light)�6,   $��10(�6K   $��Prender��6Y   $��76��6k   $��5q�6v   
��� ���
��� ���6�   �� 50      -   5        $ 	btnApagar��50      $��Bahnschrift Light)�6,   $��10(�6K   $��Apagar��6Y   $��63��6j   $��5q�6u   
��� ���
��� ���6�   �� 51      -   5        $ btnCapturar��51      $��Bahnschrift Light)�6.   $��10(�6M   $��Capturar��6[   $��80��6n   $��5q�6y   
��� ���
��� ���6�   �� 52      -   5        $��cbxDispositivo��52   '   $	��101��6   6?   53      �� 54      $ 
Horizontal=�6   $��10q�62   .+�55      �� -   5        $ 	btnInsert��55      $��Bahnschrift Light)�6,   $��Intertar��6K   $	��110��6^   $��5q�6j   
��� ���
��� ���6�   �� 56      -   5        $ 	btnUpdate��56      $��Bahnschrift Light)�6,   $��	Modificar��6K   $	��110��6_   $��5q�6k   
��� ���
��� ���6�   �� 57      -   5        $ 	btnDelete��57      $��Bahnschrift Light)�6,   $��Eliminar��6K   $	��110��6^   $��5q�6j   ���	#FFEE6A4D���	#FFEE6A4D6�   �� 58      -   5        $ btnSave��58      $��Bahnschrift Light)�6*   $��Guardar��6I   $	��110��6[   $��5q�6g   {�.  ���	#FF027111���	#FF04BD196�   �� 59      -   5        $ btnCancerlar��59      $��Bahnschrift Light)�60   $��Cancelar��6O   $	��110��6b   $��5q�6n   {�.  ���	#FFEE6A4D���	#FFEE6A4D6�   5:      5;      5<      5=      