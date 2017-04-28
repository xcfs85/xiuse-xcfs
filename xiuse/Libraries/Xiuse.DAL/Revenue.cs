using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiuse.DbUtility;

namespace Xiuse.DAL
{
    public class revenue
    {
        public revenue() { }

        ///查询当天每小时的营业额
        /// 
        public DataSet SearchTurnover(string RestaurantId)
        {
            string strSql = string.Format(@"select  ws.Account,ws.Hour,ts.MenusCount from 
(select sum(accountspayable) as Account, hour(orderendtime) as Hour  from order_ o left join xiuse_desk d on o.DeskId = d.DeskId where OrderState = 1  and d.RestaurantId = '{0}'  and    date(orderendtime) = date(curdate()) group by hour(orderendtime)) ws
left join
(select sum(menunum) as MenusCount, hour(orderendtime) as Hour from ordermenu_ m left join order_ o on m.OrderId = o.OrderId left join xiuse_desk d  on o.DeskId = d.DeskId   where OrderState = 1  and d.RestaurantId = '{0}' and date(orderendtime) = date(curdate()) group by hour(orderendtime)) ts
on ws.Hour = ts.Hour", RestaurantId);
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            return ds;
        }

        ///查询当天每个小时的点单量 
        public DataSet BillCounts(string RestaurantId)
        {
            string strSql = ("select sum(menunum),hour(orderendtime) from ordermenu_ m left join order_ o on m.OrderId=o.OrderId left join xiuse_desk d  on o.DeskId = d.DeskId   where OrderState=1  and d.RestaurantId='"
                + RestaurantId + "' and date(orderendtime)=date(curdate()) group by hour(orderendtime)");
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            return ds;
        }

        //当天所点菜，按点餐量排序
        public DataSet SortofOrders(string RestaurantId)
        {
            string strSql = ("select sum(menunum) as AllNum,MenuName from ordermenu_ m left join order_ o on m.OrderId=o.OrderId left join xiuse_desk d  on o.DeskId = d.DeskId   where   OrderState=1  and d.RestaurantId='"
                + RestaurantId + "' and date(orderendtime)=date(curdate()) group by menuname order by allnum  desc ;");
            DataSet ds= AosyMySql.ExecuteforDataSet(strSql);
            return ds;

        }


    }
}
