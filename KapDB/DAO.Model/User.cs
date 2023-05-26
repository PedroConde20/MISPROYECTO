using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class User : BaseModel
    {
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte RegisterUserID { get; set; }  //ESTE SE USA COMO SI FUESE UN ID YA QUE EL USERID ESTA EN BASEMODEL
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserCI { get; set; }
        public byte NewUser { get; set; }
        public int Image { get; set; }

        public User()
        {

        }

        //PARA USER ADMIN

        //                  0              1                2                   3                  4                     5               6                7                 8         9                     10                  11           12
        public User(byte registerUserID,string userName, string password, string role, string userFirstName, string userLastName, string userEmail, string userCI, byte newUser, short userID, DateTime registerDate, DateTime lastUpdate, byte status, int image)
           : base(status , registerDate,lastUpdate , userID)
        {
            RegisterUserID = registerUserID;
            UserName = userName;
            Password = password;
            Role = role;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            UserEmail = userEmail;
            UserCI = userCI;
            NewUser = newUser;
            Image = image;
        }
        /////////////////
        //                  0              1                2                   3                  4                     5               6                7                 8              9                     10                  11           12
        public User(string role, string userName, string password, byte registerUserID, string userFirstName, string userLastName, string userEmail, string userCI, byte newUser, short userID, DateTime registerDate, DateTime lastUpdate, byte status, int image)
        : base(status, registerDate, lastUpdate, userID)
        {
            Role = role;
            UserName = userName;
            Password = password;
            RegisterUserID = registerUserID;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            UserEmail = userEmail;
            UserCI = userCI;
            NewUser = newUser;
            Image = image;
        }





        /// <summary>
        /// INSERT
        /// </summary>
        /// <param name="role"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="userFirstName"></param>
        /// <param name="userLastName"></param>
        /// <param name="userEmail"></param>
        /// <param name="userCI"></param>
        /// <param name="newUser"></param>
        /// <param name="userID"></param>
        public User(string role, string userName, string password, string userFirstName, string userLastName, string userEmail, string userCI,  short userID , byte registerUserID,int image)
        {
            Role = role;
            UserName = userName;
            Password = password;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            UserEmail = userEmail;
            UserCI = userCI;
            UserID = userID;
            RegisterUserID = registerUserID;
            Image = image;
        }

    }
}
