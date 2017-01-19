/*
*作者：zy        账单统计功能
*搜索当日餐桌的全部账单（条件：当日、餐厅Id、餐桌Id）
*账单详细信息（条件：账单Id）
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse;

namespace Xiuse.App.Controllers.OrderBill
{
    [RoutePrefix("api/Bill")]
    /// <summary>
    /// 账单操作接口
    ///  
    /// </summary>
    public class OrderBillController : ApiController
    {
        BLL.order_ Order = new BLL.order_();

        /// <summary>
        /// 获取当天餐厅的餐桌的所有未清台的账单
        /// </summary>
        /// <param name="DeskId">餐桌Id</param>
        /// <param name="RestaurantId">餐厅Id</param>
        /// <returns></returns>
        [Route("SameDayOrderDesk")]
        public List<Model.OrderBill> GetSameDayOrderDesk(string DeskId)
        {
            return Order.GetUncleanedDesksbyId(DeskId);
         
        }
        /// <summary>
        /// 获取当天餐厅的所有未清台的账单
        /// </summary>
        /// <param name="RestaurantId">餐厅Id</param>
        /// <returns></returns>
        [Route("SameDayOrder")]
        public List<Model.OrderBill> GetSameDayOrder(string RestaurantId)
        {
           return  Order.GetAllUncleanedDesks(RestaurantId);

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
            return Order.GetOrderBill(OrderId);
            
        }
        /// <summary>
        ///获取账单 
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        [Route("BillById")]
        public Model.order_ GetBillById(string OrderId)
        {
            return Order.GetModel(OrderId);
        }
    }
}
