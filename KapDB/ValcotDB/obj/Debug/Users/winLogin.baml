   M S B A M L   `   `   `  ����C  ?ValcotDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KapDB.UsersKapDB.Users  5   	       KapDB.Users.winLogin   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:KapDB.Users     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.1.2567, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  winLogin��5   	   $	��500��6   $	��700��6'    � WindowStartupLocation$ CenterScreen=�63   
������� � 
ResizeMode$ NoResize=�6l      MaterialDesignBody#���   5
   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � WindowState$ Normal=�5       � WindowStyle$
 None=�6"   .��5      � ���	#FFFFEBC3.+�5   
   �� $��-107,-8,-110,0q�6   .+�5      �� $.��(/ValcotDB;component/Imagenes/inicioA.png��6   $	��516��6F   $��10,0,392.8,0q�6S   5      �� 5   
   .+�5      � ���	#FFFFEBC3$��80��6*   $��	323,0,0,0q�66   .+�5      �� -   5         ��Name$ btnClose��5      $��30��6+   $��30��66   $��Right=�6B   $	��Top=�6^   $��0q�6�   $
��Bold"�6�   ��6v   Z� ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6.   $��30��6;   $��40��6F   ���	#FFDAA10D6k   5      �� 5      $��Center=�6   $��Bahnschrift medium)�69   ���	#FF2D2D35$��Center=�6p   $��38(�6�   $
��Bold"�6�   $��61,34,49,-7q�6�   $��53��6�   �� 6�   $�Inicio de Sesi��6�   �� 6�   $�ó��6�   �� 6�   $�n��6�   6  5      �� 5      $��377,10,41,10q�6   $	��252��6/   ���	#FFFFEBC3.+�5      �� 	 �� Orientation$	 
Horizontal=�6   $��10,10,44.4,10q�66   $��49��6M   .+�5         $ Account=�6.   $��25��6=   $��25��6I   ���	#FFDAA10D$��5,20,5,0q�6k   �� 5!      -   5        
 ��Name$
 txtUser��5!   ,   $��20(�6   ���	#FF2D2D35$��Bahnschrift Light)�6T   $	��212��6s   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombre de Usuario��6      
IsFloating . 6�   5"      �� 5$      $	 
Horizontal=�6   $��10,10,44,10q�66   .+�5%        $	 Key=�6.   $��36��69   $��25��6E   ���	#FFDAA10D$��5q�6g   G� 5&      -   5         G�Name$ txtPassword��5&   G   ���	#FF2D2D35$��20(�69   $��Bahnschrift Light)�6\   $	��199��6{   $ Contraseña��6�    . $��46��6�   5'      �� 5(      $	 
Horizontal=�6   $
��Left=�66   $��20q�6Q   .+�5)      �� -   5        $ btnLogin��5)   +   $��20(�6   ���	#FFDAA10D$��Bahnschrift Light)�6T   $��Ingresar��6s   $	��222��6�   $��0 0 10 0q�6�   6�   5*      5+      )  #MaterialDesignThemes.Wpf.DialogHost  5.      -   5          Name$ dhChangePassword��5.   N   $y�	Collapsed=�6(      IsOpen .     DialogContent 5/      �� 50      $	��250��6!   $	��250��6.   $��Center=�6:   $��Center=�6U   .+�51      �� $��20q�6$   $%��DEBES ACTUALIZAR TU CONTRASEÑA��60   $��Center=�6V    �� TextAlignment$ Center=�6s   $��Bottom=�6�   $
��Wrap=�6�   6�   G� 52      -   5        $ pwNewPassword��52   &   $ Nueva Contraseña��6=    . $��40��6�   
���   �6�   G� 53      -   5        $ pwConfirmPassword��53   &   $ CONRIFMAR CONTRASEÑA��6A    . $��40��6�   
���   �6�   �� 54      -   5        $ 	btnChange��54   !   $��	CONFIRMAR��6L   $��30��6`   $	��115��6l   
�������
��� � �$��Center=�6�   $��	0 15 0 20q�6�   ���	#FF26BD176�   �� 55      -	   5         ��Name$ txtMessagePassword��55   $   $��5q�6@   $��NoWrap=�6K   56      58      59      �� 5:   
   $��352,335,10,10q�6   .+�5;      #  MaterialDesignThemes.Wpf.Card  ���	#FFFFEBC3$��10,10,14.4,10q�6:   $	��135��6Q    � Cursor$
 Hand��6^   $��Center=�6l   $	��314��6�   .��5<      �� -
   5        $ txtInfo��5<   E   $��Center=�6    �� Padding$ 2q�69   $��Bahnschrift Light)�6V      MaterialDesignTitleTextBlock#���  6u   $��15(�6�   $��Center=�6�   $
 Hand��6�   $��0,56,-0.4,56.2q�6�   �� 6�   $0�*Por seguridad, jamas revele su contraseña��6   64  5=      5>      5?      5@      