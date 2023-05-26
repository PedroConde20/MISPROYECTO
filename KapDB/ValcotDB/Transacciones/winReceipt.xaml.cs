using ValcotDB;
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


namespace KapDB.Transacciones
{
    /// <summary>
    /// Lógica de interacción para winReceipt.xaml
    /// </summary>
    public partial class winReceipt : Window
    {
        public winReceipt()
        {
            InitializeComponent();
            crReceipt cr1 = new crReceipt();
            viewerReceipt.ViewerCore.ReportSource = cr1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
