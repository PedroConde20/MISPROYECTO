using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.interfaces;
using DAO.Model;

namespace DAO.interfaces
{
    public interface IUser : IDAO<User>
    {
        DataTable SelectLikeByName(string txt);
        DataTable Login(string userName, string password);
        User Get(byte id);

        DataTable SelectLikeByRole(string role);
    }
}
