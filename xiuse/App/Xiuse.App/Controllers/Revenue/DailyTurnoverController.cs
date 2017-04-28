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
using Xiuse.Model.ViewModel;
namespace Xiuse.App.Controllers.Revenue
{
    [RoutePrefix("api/Revenue")]
    public class DailyTurnoverController : ApiController
    {
        BLL.revenue DailyBLL = new BLL.revenue();

        //[Route("DailyTurnover")]
        //public DataSet GetDailyTurnover(string RestaurantId)
        //{

        //    DataSet ds1 = DailyBLL.SearchTurnover(RestaurantId);
        //    DataSet ds2 = DailyBLL.BillCounts(RestaurantId);
        //    ds1.Merge(ds2, true, MissingSchemaAction.AddWithKey);
        //    return ds1;
        //}


        /// <summary>
        /// 获取当日热门菜品（RestaurantId：餐厅Id）
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        [Route("DailyHotMenus")]
        public IList<HotMenus> GetDailyHotMenus(string RestaurantId)
        {
            IList<HotMenus> list =  DotNet.Utilities.ConvertHelper.DataSetToEntityList<HotMenus>(DailyBLL.SortofOrders(RestaurantId), 0);
            return list ;
        }

        /// <summary>
        /// 当日营业额接口类 （RestaurantId：餐厅Id）
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        [Route("DailyTurnover")]
        public List<TurnOverView> GetDailyTurnover(string RestaurantId)
        {
            List<TurnOverView> list = (List<TurnOverView>)DotNet.Utilities.ConvertHelper.DataSetToEntityList<TurnOverView>(DailyBLL.SearchTurnover(RestaurantId), 0);
           
            for(int i =0; i < 24; i++)
            {
                 List<TurnOverView> tmp = list.Where(p => p.Hour == i).ToList();
                if (tmp.Count() == 0)
                {
                    TurnOverView tv = new TurnOverView();
                    tv.Account = 0;
                    tv.Hour = i;
                    tv.MenusCount = 0;
                    list.Add(tv);
                }  
            }
            list.Sort((x, y) =>
            {
                int value = x.Hour.CompareTo(y.Hour);
                if (value == 0)
                    value = x.MenusCount.CompareTo(y.MenusCount);
                return value;
            });
            return list;
        }
    }
}
