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

        /// <summary>
        /// 查询当天每小时的营业额
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        public DataSet SearchTurnover(string RestaurantId)
        {
            return dal.SearchTurnover(RestaurantId);
        }
        /// <summary>
        /// 查询当天每个小时的点单量 
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        public DataSet BillCounts(string RestaurantId)
        {
            return dal.BillCounts(RestaurantId);
        }

        /// <summary>
        /// 当天所点菜，按点餐量排序
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        public DataSet SortofOrders(string RestaurantId)
        {
            return dal.SortofOrders(RestaurantId);
        }
    }
}
