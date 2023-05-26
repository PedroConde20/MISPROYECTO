using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO.Model
{
    public class Supplier:BaseModel
    {
        #region Properties
        public byte SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierLastName { get; set; }
        public string SupplierCI { get; set; }
        public string SupplierDirection { get; set; }
        public string SupplierCellphone { get; set; }
        public string SupplierEmail { get; set; }

        #endregion


        public Supplier()
        {

        }



        public Supplier(byte supplierID, string supplierName, string supplierLastName, string supplierCI, string supplierDirection, string supplierCellphone, string supplierEmail, short userID, DateTime registerDate, DateTime lastUpdate, byte status)
            : base(status, registerDate, lastUpdate, userID)
        {
            SupplierID = supplierID;
            SupplierName = supplierName;
            SupplierLastName = supplierLastName;
            SupplierCI = supplierCI;
            SupplierDirection = supplierDirection;
            SupplierCellphone = supplierCellphone;
            SupplierEmail = supplierEmail;
        }


        /// <summary>
        /// INSERT
        /// </summary>
        /// <param name="clientName"></param>
        /// <param name="clientLastName"></param>
        /// <param name="clientCI"></param>
        /// <param name="clientDirection"></param>
        /// <param name="clientTelephone"></param>
        /// <param name="clientEmail"></param>
        /// <param name="userID"></param>
        public Supplier(string clientName, string clientLastName, string clientCI, string clientDirection, string clientTelephone, string clientEmail, short userID)
        {
            SupplierName = clientName;
            SupplierLastName = clientLastName;
            SupplierCI = clientCI;
            SupplierDirection = clientDirection;
            SupplierCellphone = clientTelephone;
            SupplierEmail = clientEmail;
            UserID = userID;
        }
    }
}
