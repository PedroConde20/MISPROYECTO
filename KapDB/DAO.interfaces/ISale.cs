using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;


namespace DAO.interfaces
{
    public interface ISale:IDAO<Sale>
    {
        void Insert(Sale t, List<SaleDetail> d);
    }
}
