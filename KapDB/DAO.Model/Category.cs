using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Category: BaseModel
    {
        #region Properties
        public byte CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        #endregion


        public Category()
        {

        }


        /// <summary>
        /// GET
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="categoryName"></param>
        /// <param name="categoryDescription"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="lastUpdate"></param>
        /// <param name="userID"></param>
        public Category(byte categoryID, string categoryName, string categoryDescription, byte status, DateTime registerDate, DateTime lastUpdate, short userID)
            : base(status, registerDate, lastUpdate, userID) 
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
        }


        /// <summary>
        /// INSERT
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="userID"></param>

        public Category(string categoryName , string categoryDescription ,short userID)
        {
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
            UserID = userID;
        }
    }


}
