using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ValcotDB.Proveedor
{
    /// <summary>
    /// Lógica de interacción para uscProveedores.xaml
    /// </summary>
    public partial class uscProveedores : Window
    {
        public uscProveedores()
        {
            InitializeComponent();
        }



        private void TextBlock_MouseLeftButtonUpVerProveedor(object sender, MouseButtonEventArgs e)
        {
            verProveedores win = new verProveedores();
            win.ShowDialog();
        }

        private void TextBlock_MouseLeftButtonUpAgregarProveedor(object sender, MouseButtonEventArgs e)
        {
            Proveedor win = new Proveedor();
            win.ShowDialog();
        }
    }
}
