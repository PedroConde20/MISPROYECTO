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
using DAO.Model;
using DAO.Implementation;
using System.Data;

namespace ValcotDB.Stock
{
    /// <summary>
    /// Lógica de interacción para transaccionProductos.xaml
    /// </summary>
    public partial class transaccionProductos : Window
    {
        ProductStoreImpl productImplem;
        Product product;
        PublicStore publicStore;
        byte id;

        public transaccionProductos()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            try
            {
                productImplem = new ProductStoreImpl();
                cbxProductsList.ItemsSource = null;
                //mostrar elementos
                cbxProductsList.DisplayMemberPath = "productName";
                cbxProductsList.SelectedValuePath = "productID";

                cbxProductsList.ItemsSource = productImplem.SelectProducts().DefaultView;
                cbxProductsList.SelectedIndex = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbxProductsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = Convert.ToByte(cbxProductsList.SelectedValue);
                productImplem = new ProductStoreImpl();
                product = productImplem.GetjustStock(id);
                lblCantidadHay.Content = $"Cantidad: {product.Stock}";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnTransferir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                productImplem = new ProductStoreImpl();
                int res = productImplem.UpdateStockProductStore(Convert.ToInt32(txtCantidad.Text), id);
                int res2 = productImplem.UpdateStockProduct(Convert.ToInt32(txtCantidad.Text), id);

                if (res > 0)
                {
                    MessageBox.Show("Se realizo la transferencia con exito");
                    id = Convert.ToByte(cbxProductsList.SelectedValue);
                    productImplem = new ProductStoreImpl();
                    product = productImplem.GetjustStock(id);
                    lblCantidadHay.Content = $"Cantidad: {product.Stock}";
                    txtCantidad.Text = "";
                }


            }


            catch (Exception)
            {

                MessageBox.Show("No es posible completar la transaccion\nComuniquese con el adm de sistemas");
            } 
        }
    }
}
