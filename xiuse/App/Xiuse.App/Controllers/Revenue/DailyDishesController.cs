using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Xiuse.App.Controllers.Revenue
{
    [RoutePrefix("api/Revenue")]
    public class DailyDishesController : ApiController
    {
        /// <summary>
        /// 当天所点菜，按点餐量排序
        /// </summary>
        /// <returns></returns>
        [Route("DailySortDishes")]
        public DataSet GetDailySortDishes()
        {
            BLL.revenue DailyBLL = new BLL.revenue();
            DataSet ds1 = DailyBLL.SortofOrders();        
            return ds1;
        }
    }
}
