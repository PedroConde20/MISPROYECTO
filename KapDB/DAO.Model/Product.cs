using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Product: BaseModel 
    {
        #region Properties
        public byte ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Image { get; set; }
        public int Stock { get; set; }
        public string DescriptionProduct { get; set; }
        public byte CategoryID { get; set; }

        public byte SupplierID { get; set; }
        #endregion

        #region Constructors
        public Product()
        {

        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="productID"></param>
       /// <param name="productName"></param>
       /// <param name="price"></param>
       /// <param name="image"></param>
       /// <param name="stock"></param>
       /// <param name="descriptionWine"></param>
       /// <param name="categoryID"></param>
       /// <param name="status"></param>
       /// <param name="registerDate"></param>
       /// <param name="lastUpdate"></param>
       /// <param name="userID"></param>
        //                 0            1              2                3      4                  5                   6          7                  8                     9                  10
        public Product(byte productID, string productName, double price, int image,int stock, string descriptionWine, byte categoryID ,byte status, DateTime registerDate, DateTime lastUpdate, short userID, byte supplierID)
            : base(status, registerDate, lastUpdate, userID)
        {
            ProductID = productID;
            ProductName = productName;
            Price = price;
            Image = image;
            Stock = stock;
            DescriptionProduct = descriptionWine;
            CategoryID = categoryID;
            SupplierID = supplierID;
        }

       /// <summary>
       /// /
       /// </summary>
       /// <param name="categoryID"></param>
       /// <param name="productName"></param>
       /// <param name="price"></param>
       /// <param name="image"></param>
       /// <param name="stock"></param>
       /// <param name="descriptionWine"></param>
       /// <param name="userID"></param>
        public Product(byte categoryID, string productName, double price, int image, int stock, string descriptionWine, short userID, byte supplierID)
        {
            CategoryID = categoryID;
            ProductName = productName;
            Price = price;
            Image = image;
            Stock = stock;
            DescriptionProduct = descriptionWine;
            UserID = userID;
            SupplierID = supplierID;
        }

        public Product( string productName, int stock, short userID)
        {
            ProductName = productName;
            Stock = stock;
            UserID = userID;
        }
        #endregion


      
    }
}
