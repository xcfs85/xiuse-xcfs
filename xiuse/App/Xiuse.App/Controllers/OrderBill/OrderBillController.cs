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
using Xiuse.App.Base;
using Xiuse.Model;
using Xiuse.Model.ViewModel;

namespace Xiuse.App.Controllers.OrderBill
{
    [RoutePrefix("api/Bill")]
    /// <summary>
    /// 账单操作接口
    ///  
    /// </summary>
    public class OrderBillController : BaseResultMsg
    {
        BLL.order_ Order = new BLL.order_();

        /// <summary>
        /// 获取当天餐厅的餐桌的所有未清台的账单
        /// </summary>
        /// <param name="DeskId">餐桌Id</param>
        /// <param name="RestaurantId">餐厅Id</param>
        /// <returns></returns>
        [Route("SameDayOrderDesk")]
        public List<Model.ViewModel.OrderBill> GetSameDayOrderDesk(string DeskId)
        {
            return Order.GetUncleanedDesksbyId(DeskId);
        }
        /// <summary>
        /// 获取当天餐厅的所有未清台的账单
        /// </summary>
        /// <param name="RestaurantId">餐厅Id</param>
        /// <returns></returns>
        [Route("SameDayOrder")]
        public List<Model.ViewModel.OrderBill> GetSameDayOrder(string RestaurantId)
        {
           return  Order.GetAllUncleanedDesks(RestaurantId);

        }
        /// <summary>
        /// 获取订单的详单,带有菜品折扣
        /// </summary>
        /// <param name="OrderId">订单Id</param>
        /// <returns></returns>
        [Route("OrderBill")]
        public Model.ViewModel.OrderBill GetOrderBill(string OrderId)
        {
            return Order.GetOrderBill(OrderId);
            
        }
        /// <summary>
        /// 获取当前餐桌的未支付的最近的订单
        /// </summary>
        /// <param name="DeskId"></param>
        /// <returns></returns>
        [Route("DefaultOrderBill")]
        [HttpGet]
        public HttpResponseMessage DefaultOrderBill(string DeskId)
        {
            Model.order_ model = Order.GetDefaultModel(DeskId);
            if (model != null)
                return ReturnData("1", Order.GetOrderBill(model.OrderId), Models.StatusCodeEnum.Success);
            else
                return ReturnData("0", "没有未支付的订单！", Models.StatusCodeEnum.Error);
        }

        /// <summary>
        ///获取账单 (id)
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        [Route("BillById")]
        public Model.order_ GetBillById(string OrderId)
        {
            return Order.GetModel(OrderId);
        }
        /// <summary>
        /// 提交结账订单
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CheckoutOrderBill")]
        public HttpResponseMessage CheckoutOrderBill(dynamic bill)
        {
            return ReturnData("1", "", Models.StatusCodeEnum.Success);
        }
    }
}
