using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class PublicStore : BaseModel
    {
        public byte publicStoreID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Image { get; set; }
        public int Stock { get; set; }
        public string DescriptionProduct { get; set; }
        public byte CategoryID { get; set; }
        public byte productId { get; set; }

        public PublicStore() { }

        public PublicStore(byte publicStoreID, string productName, double price, int image, int stock, string descriptionProduct, byte categoryID, byte productId)
        {
            this.publicStoreID = publicStoreID;
            ProductName = productName;
            Price = price;
            Image = image;
            Stock = stock;
            DescriptionProduct = descriptionProduct;
            CategoryID = categoryID;
            this.productId = productId;
        }
        public PublicStore(int stock)
        {
            Stock = stock;
        }
    }

}
