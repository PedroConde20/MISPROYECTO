using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAO.Model;
using System.Threading.Tasks;

namespace DAO.interfaces
{
    public interface IConfig
    {
        DataTable SelectConfig();
    }
}
