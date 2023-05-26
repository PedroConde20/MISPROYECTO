using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;
using System.Data;

namespace DAO.interfaces
{
    public interface IDAO<T>
    {
        int Insert(T t);
        int Update(T t);
        int Delete(T t);
        DataTable Selec();
    }
}
