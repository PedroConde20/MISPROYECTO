using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Image:BaseModel
    {
        public byte ImageID { get; set; }
        public string ImagenName { get; set; }
        public string Img { get; set; }

        public Image()
        {

        }


        /// <summary>
        /// get
        /// </summary>
        /// <param name="imageID"></param>
        /// <param name="img"></param>
        /// <param name="shortDescription"></param>
        /// <param name="userID"></param>
        /// <param name="registerDate"></param>
        /// <param name="lastUpdate"></param>
        /// <param name="status"></param>
        /// 
        //                   1           2                 3                  4                5                      6             
        public Image(byte imageID,string imagenName ,string img, byte userID, DateTime registerDate, DateTime lastUpdate, byte status)
            : base(userID,registerDate,lastUpdate,status)
        {
            ImageID = imageID;
            ImagenName = imagenName;
            Img = img;
        }


        /// <summary>
        /// insert
        /// </summary>
        /// <param name="img"></param>
        /// <param name="shortDescription"></param>
        /// <param name="userID"></param>
        public Image(string imagenName,string img, short userID)
        {
            ImagenName = imagenName;
            Img = img;
            UserID = userID;
        }
    }
}
