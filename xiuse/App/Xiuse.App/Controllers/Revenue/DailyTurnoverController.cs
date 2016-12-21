/*******************************************************************************
             当日营业额接口类                                   
             本类主要实现对当日营业额操作的接口              
             创建：zy       2016/12/21
1、<菜品数量>MenuNum
2、<账单金额>MenuBill 

******************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse;
namespace Xiuse.App.Controllers.Revenue
{
    [RoutePrefix("api/Revenue")]
    public class DailyTurnoverController : ApiController
    {
        [Route("DailyTurnover")]
        public DataSet GetDailyTurnover()
        {
            BLL.revenue DailyBLL = new BLL.revenue();
            DataSet ds1 = DailyBLL.SearchTurnover();
            DataSet ds2 = DailyBLL.BillCounts();
            ds1.Merge(ds2, true, MissingSchemaAction.AddWithKey);
            return ds1;
        }
    }
}
