using DAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.interfaces
{
    public interface ISupplier
    {
        DataTable SelectLikeByName(string txt);

        Supplier Get(byte id);
    }
}
