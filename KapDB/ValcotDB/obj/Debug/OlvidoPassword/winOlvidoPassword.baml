   M S B A M L   `   `   `  ����C  ?ValcotDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:KapDB.OlvidoPasswordKapDB.OlvidoPassword  5   	   ,    &KapDB.OlvidoPassword.winOlvidoPassword   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:KapDB.OlvidoPassword     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.1.2567, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      -   5          � Title$  winOlvidoPassword��5   	   $	��340��6#   $
��1000��60    � WindowStartupLocation$ CenterScreen=�6=      MaterialDesignBody#���   5
   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � WindowState$ Normal=�5       � WindowStyle$
 None=�6"   .��5      � 
������� � RowDefinitions 5   
   �� 5      $	��23* �6   �� 5      $	��19* �6   .+�5   
   � $��61��6   $	��Top=�6   ���	#FF2D2D35.+�5      �� -   5         ��Name$ btnClose��5      $��57��6'   $��51��62   $��Right=�6>   $	��Top=�6Z   $��0q�6�   $
��Bold"�6�   ��6r   Z� ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6*   $��50��67   $��50��6B   ���	#FFDAA10D6g   5      �� 5      	 �� Orientation$	 
Horizontal=�6   $
��Left=�62   $��0,10,0,0q�6M   .+�5         $ Password=�6*   $��66��6:   $��48��6E   ���	#FFDAA10D$��Center=�6h   $��0,-2,0,5q�6�   �� 5!      $��Nueva Contraseña��6   $��Bahnschrift Light)�64   $��Center=�6S   $
��Left=�6n   ���	#FFDAA10D$��20(�6�   $
��Bold"�6�   $��	10,12,0,7q�6�   $��32��6�   $	��222��6�   5"      5#      �� 5$   
   $��	0,61,10,0q�6   
�������$��2��6;   .+�5&      �� $	 Vertical=�6   $��0,0,0,1q�60   $
��Left=�6A   $	��150��6\   $	��305��6i   .+�5'      �� -   5        
 ��Name$
 lblrandompassword��5'      $��Bahnschrift Light)�63   $��Center=�6�   $��Generar Contraseña:��6�   
���   �$��14(�6�   $
��Bold"�6�   $��5q�6�   �� 5(      -   5         ��Name$ txtContraseña��5(      $	��161��62   {�.  $��5q�6P   �� 5)      $��Center=�6   $��Bahnschrift Light)�65   $��Correo Electronico:��6T   
���   �$��14(�6�   $
��Bold"�6�   $��5q�6�   �� 5*      -   5        $ txtCorreoElectroinico��5*      $	��110��6:   {�.  $��5q�6X   5+      �� 5,      $	 
Horizontal=�6   $��0,10,338,10q�62   $	��110��6G   .+�5-      �� -   5        $ 	btnUpdate��5-      $��	Modificar��6,   $��Bahnschrift Light)�6@   $	��110��6`   $��5q�6l   ���#137fd9���#2196f36�   �� 5.      -   5        $ btnSave��5.      $��Guardar��6*   $��Bahnschrift Light)�6<   $	��110��6[   $��5q�6g   {�.  ���	#FF9AD740���	#FF04BD196�   �� 5/      -   5        $ btnCancerlar��5/      $��Bahnschrift Light)�6/   $��Cancelar��6N   $	��110��6a   $��5q�6m   {�.  
��� ������	#FFDAA10D6�   50      �� 51      $��Label��6   52      �� 53   
   $��372,61,0,47q�6   $��2��6*   .+�54      &   System.Windows.Controls.DataGrid  -	   5          Name$ dgvDatos��54   *   
�������$��auto ��6<   $	��222��6K      
IsReadOnly .    CanUserAddRows .  $��Bahnschrift Light)�6�   6�   55      �� 56   
   -
   5        $
 
lblUsuario��56      $	��...��6$   $��Bahnschrift Light)�62   $
��Left=�6Q   $��463,118.5,0,0q�6l   $	��Top=�6�   $	��128��6�   $��1��6�   �� 57   
   -   5        $
 lblId��57      $	��...��6   $��Bahnschrift Light)�6-   $
��Left=�6L   $��596,118.5,0,0q�6g   $	��Top=�6~   $	��128��6�   $��1��6�   58      59      