using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;
using System.Data;

namespace DAO.interfaces
{
    public interface IPublicStore:IDAO<PublicStore>
    {

        PublicStore Get(int id);
        DataTable Find(PublicStore product);

        DataTable SelectLikeByName(string txt);
        //Imagen
        int SaveId();

    }
}
