using System;
using ValcotDB;
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
    /// Lógica de interacción para winCristarlReportOne.xaml
    /// </summary>
    public partial class winCristarlReportOne : Window
    {
        public winCristarlReportOne()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnIngresoPorVenta_Click(object sender, RoutedEventArgs e)
        {
            
            string fin = Convert.ToString(dpFin.SelectedDate);
            CrystalReportReporteUno cr1 = new CrystalReportReporteUno();
            cr1.Load(@"CrystalReport1.rpt");
            cr1.SetParameterValue("@inicio", Convert.ToString(dpInicio.SelectedDate));
            cr1.SetParameterValue("@fin", fin);
            viewerReceiptOne.ViewerCore.ReportSource = cr1;
        }
    }
}
