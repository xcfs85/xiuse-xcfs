using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiuse.BLL
{
    public class revenue
    {
        private readonly Xiuse.DAL.revenue dal = new Xiuse.DAL.revenue();
        public revenue() { }

        public DataSet SearchTurnover()
        {
            return dal.SearchTurnover();
        }

        public DataSet BillCounts()
        {
            return dal.BillCounts();
        }


        public DataSet SortofOrders()
        {
            return dal.SortofOrders();
        }
    }
}
