using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;
using System.Data;

namespace DAO.interfaces
{
    public interface IClient:IDAO<Client>
    {
        DataTable SelectLikeByName(string txt);

        Client Get(byte id);

        DataTable SelectIDDescription();
    }
}
