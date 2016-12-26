using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse;

namespace Xiuse.App.Controllers.OrderBill
{
    /// <summary>
    /// 账单操作接口
    /// </summary>
    public class OrderBillController : ApiController
    {
        /// <summary>
        /// 获取当天餐厅的餐桌的所有未清台的账单
        /// </summary>
        /// <param name="DeskId">餐桌Id</param>
        /// <param name="RestaurantId">餐厅Id</param>
        /// <returns></returns>
        [Route("SameDayOrder")]
        public List<Model.OrderBill> GetSameDayOrder(string DeskId,string RestaurantId)
        {
            //todo
            return null;
        }
        /// <summary>
        /// 获取订单的详单
        /// </summary>
        /// <param name="OrderId">订单Id</param>
        /// <returns></returns>
        [Route("OrderBill")]
        public Model.OrderBill GetOrderBill(string OrderId)
        {
            //todo
            return null;
        }
    }
}
