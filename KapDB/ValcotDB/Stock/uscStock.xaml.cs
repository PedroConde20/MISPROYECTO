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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KapDB.Stock
{
    /// <summary>
    /// Lógica de interacción para uscStock.xaml
    /// </summary>
    public partial class uscStock : UserControl
    {
        public uscStock()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //CAMBIAR DE LUGAR
            winAdmTiposdeVinos win = new winAdmTiposdeVinos();
            win.ShowDialog();
        }

        private void TextBlock_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            //ABRIRA LA COMPRA DE VINOS 
            winIngresoVinos win = new winIngresoVinos(1);
            win.ShowDialog();

        }
    }
}
