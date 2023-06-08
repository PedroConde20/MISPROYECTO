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
using DAO.Implementation;
using DAO.Model;


namespace KapDB.Transacciones
{
    /// <summary>
    /// Lógica de interacción para winTransaction.xaml
    /// </summary>
    public partial class winTransaction : Window
    {
        SaleImpl implSale;
        Sale sale;
        List<SaleDetail> productList = new List<SaleDetail>();
        public winTransaction()
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
            dtpSalePicker.SelectedDate = DateTime.Now;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ESTE NO HACE NADA
        }

        private void dgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Error
        }

        private void dgvDatos_Loaded(object sender, RoutedEventArgs e)
        {
            //Error
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            double totalp = 0;
            try
            {
                foreach (SaleDetail item in productList)
                {
                    totalp += item.Price * item.Quantiy;

                    int productId = item.WineID; 
                    int soldQuantity = item.Quantiy; 

                    ProductStoreImpl productSImpl = new ProductStoreImpl(); 
                    PublicStore publicStore = productSImpl.Get(productId); 
                    int currentStock = publicStore.Stock; 
                    // Restar la cantidad de productos vendidos de la cantidad actual en stock
                    int newStock = currentStock - soldQuantity;
                    // Actualizar la cantidad actual en stock del producto en la base de datos
                    publicStore.Stock = newStock; productSImpl.Update(publicStore);

                }
                sale = new Sale(totalp,dtpSalePicker.SelectedDate.Value,short.Parse(cbxClient.SelectedValue.ToString()));
                implSale = new SaleImpl();
                int id = implSale.SaveId();
                implSale.Insert(sale, productList);
                
                MessageBox.Show("Venta Ejecutada con exito");
              
                crReceipt cr1 = new crReceipt();
                cr1.Load(@"crReceipt.rpt");
                cr1.SetParameterValue("@id", Convert.ToInt32(id));
                
                viewerReceiptTwo.ViewerCore.ReportSource = cr1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancerlar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbxCategoryWine_Loaded(object sender, RoutedEventArgs e)
        {

        }

        void LoadComboClients()
        {
            try
            {
                ClienteImpl implClient = new ClienteImpl();
                cbxClient.DisplayMemberPath = "Client";
                cbxClient.SelectedValuePath = "clientID";
                cbxClient.ItemsSource = implClient.SelectIDDescription().DefaultView;
                cbxClient.SelectedIndex = 0;
            }
            catch (Exception)
            {

                MessageBox.Show("Error al Ingresar los datos");
            }
        }

        

        private void cbxClient_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComboClients();
        }

        private void cbxStore_Loaded(object sender, RoutedEventArgs e)
        {
           // LoadComboStores();
        }

        private void mitAddProduct_Click(object sender, RoutedEventArgs e)
        {
            Cliente.winFindClientByName  win = new Cliente.winFindClientByName();
            DataClass.ClassID = "";
            win.ShowDialog();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (DataClass.ClassID!="")
            {
                SaleDetail sale = new SaleDetail( short.Parse(DataClass.ClassID),int.Parse(DataClass.ClassData3), double.Parse(DataClass.ClassData2),DataClass.ClassData1);
                productList.Add(sale);
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = productList;
                DataClass.ClassID = "";
            }
        }

        private void mitDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mitClear_Click(object sender, RoutedEventArgs e)
        {
            productList.Clear();
            dgvDatos.ItemsSource = null;
            dgvDatos.ItemsSource = productList;
        }

        private void btnReceipt_Click(object sender, RoutedEventArgs e)
        {
            winReceipt win = new winReceipt();
            win.ShowDialog();
        }
    }
}
