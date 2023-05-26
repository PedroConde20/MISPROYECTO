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

namespace KapDB.Reportes
{
    /// <summary>
    /// Lógica de interacción para winReports.xaml
    /// </summary>
    public partial class winReports : Window
    {
        public winReports()
        {
            InitializeComponent();
        }
      
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btnIngresoVenta_Click(object sender, RoutedEventArgs e)
        {
            Reportes.winCristarlReportOne win = new Reportes.winCristarlReportOne();
            win.ShowDialog();
        }

        private void btnIngresoCategoria_Click(object sender, RoutedEventArgs e)
        {
            Reportes.winCristalReportCategory win = new Reportes.winCristalReportCategory();
            win.ShowDialog();
        }
        private void btnHistoricoVenta_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
