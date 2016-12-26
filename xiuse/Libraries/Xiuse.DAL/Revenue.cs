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
        public DataSet SearchTurnover()
        {
            string strSql = ("select sum(accountspayable),hour(orderendtime) from order_ where day(orderendtime)=day(curdate()) group by hour(orderendtime);");
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            return ds;
        }

        ///查询当天每小时的点单量 
        public DataSet BillCounts()
        {
            string strSql = ("select sum(menunum),hour(orderendtime) from ordermenu_ left join order_ on ordermenu_.OrderId=order_.OrderId where day(orderendtime)=day(curdate()) group by hour(orderendtime);");
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            return ds;
        }

        //当天所点菜，按点餐量排序
        public DataSet SortofOrders()
        {
            string strSql = ("select sum(menunum) as allnum,menuname from order_  left join ordermenu_  on ordermenu_.OrderId=order_.OrderId where day(orderendtime)=day(curdate()) group by menuname order by allnum  desc ;");
            DataSet ds= AosyMySql.ExecuteforDataSet(strSql);
            return ds;

        }


    }
}
