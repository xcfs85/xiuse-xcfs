/*******************************************************************************
             当日账单统计接口类                                   
             本类主要实现对当日账单统计各种操作的接口              
             创建：zy       2016/12/21   
//1、*获取当日全部账单
//2、*获取某一账单详情（用id号查询）
 /******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse;

namespace Xiuse.App.Controllers.Revenue
{
    [RoutePrefix("api/Revenue")]
    public class DailyBillsController : ApiController
    {
        /// <summary>
        /// 获取查询当日全部账单
        /// </summary>
        /// <returns></returns>
        [Route("DailyBills")]
        public List<Model.order_> GetDailyBills(string resId)
        {
            BLL.order_ BLLOrder = new BLL.order_();
           
            return BLLOrder.GetDailyRes(resId);
        }

        /// <summary>
        /// 获取某一账单详情（用id号查询）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [Route("BillDetal")]
        public Model.ordermenu_ GetBillDetal(string str)
        {
            BLL.ordermenu_ BLLMenu = new BLL.ordermenu_();
            return BLLMenu.GetModel(str);
           
        }



        /// <summary>
        /// 获取当天某餐桌 已完成的订单
        /// </summary>
        /// <param name="deskId"></param>
        /// <returns></returns>
        [Route("DeskPaid")]
        public List<Model.order_> GetDeskPaid(string deskId)
        {
            BLL.order_ BLLMenu = new BLL.order_();
            return BLLMenu.GetDailyBills(deskId);
            
        }
    }
}
