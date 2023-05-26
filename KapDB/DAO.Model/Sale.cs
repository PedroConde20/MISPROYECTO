using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Sale:BaseModel
    {
        public double Total { get; set; }
        public DateTime FechaVenta { get; set; }
        public short ClientID { get; set; }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="total"></param>
        /// <param name="fechaVenta"></param>
        /// <param name="clientID"></param>
        public Sale(double total, DateTime fechaVenta, short clientID)
        {
            Total = total;
            FechaVenta = fechaVenta;
            ClientID = clientID;
        }
    }
}
