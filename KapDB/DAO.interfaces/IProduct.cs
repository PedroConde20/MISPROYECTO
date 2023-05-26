using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;
using System.Data;

namespace DAO.interfaces
{
    public interface IProduct:IDAO<Product>
    {
        Product Get(int id);
        DataTable Find(Product product);

        DataTable SelectLikeByName(string txt);
        //Imagen
        int SaveId();
    }
}
