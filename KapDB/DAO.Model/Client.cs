using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Client:BaseModel
    {
        #region Properties
        public byte ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientCI { get; set; }
        public string ClientDirection { get; set; }
        public string ClientTelephone { get; set; }
        public string ClientEmail { get; set; }

        #endregion


        public Client()
        {

        }



        public Client(byte clientID, string clientName, string clientLastName, string clientCI, string clientDirection, string clientTelephone, string clientEmail, short userID, DateTime registerDate, DateTime lastUpdate, byte status)
            : base(status, registerDate, lastUpdate, userID)
        {
            ClientID = clientID;
            ClientName = clientName;
            ClientLastName = clientLastName;
            ClientCI = clientCI;
            ClientDirection = clientDirection;
            ClientTelephone = clientTelephone;
            ClientEmail = clientEmail;
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
        public Client(string clientName, string clientLastName, string clientCI, string clientDirection, string clientTelephone, string clientEmail, short userID)
        {
            ClientName = clientName;
            ClientLastName = clientLastName;
            ClientCI = clientCI;
            ClientDirection = clientDirection;
            ClientTelephone = clientTelephone;
            ClientEmail = clientEmail;
            UserID = userID;
        }
    }
}
