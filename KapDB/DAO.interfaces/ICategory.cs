using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;
using System.Data;

namespace DAO.interfaces
{
    public interface ICategory:IDAO<Category>
    {
        DataTable SelectLikeByName(string txt);

        Category Get(byte id );

        DataTable SelectIDName();

        DataTable SelectForanea();

    }
}
