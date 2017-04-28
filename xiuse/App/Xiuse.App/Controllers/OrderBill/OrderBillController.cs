/*
*作者：zy        账单统计功能
*搜索当日餐桌的全部账单（条件：当日、餐厅Id、餐桌Id）
*账单详细信息（条件：账单Id）
*
*/
using DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
        BLL.xiuse_discount discountBll = new BLL.xiuse_discount();

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
            string key = HttpRuntime.Cache.Get("key").ToString();
            //todo
            string orderId =Convert.ToString(bill.OrderId);
            Dictionary<string, bool> dt = new Dictionary<string, bool>();
            for (int i = 0; i < bill.Menus.Count; i++)
                dt.Add(Convert.ToString(bill.Menus[i].OrderMenuId), Convert.ToBoolean(bill.Menus[i].DisState));
            //bill.Menus
            Model.ViewModel.OrderBill orderBill = GetOrderBill(orderId);
            foreach (Model.ViewModel.ordermenu_dicount item in orderBill.Ordermenu)
                if (dt.Keys.Contains(item.OrderMenuId))
                    item.DisState = dt[item.OrderMenuId];
            if (bill.EntireDiscount.Value != null)
                orderBill.EntireDiscount = discountBll.GetModel(bill.EntireDiscount.DiscountId.Value);
            orderBill.Order.BillAmount = bill.Total;
            orderBill.Order.AccountsPayable = bill.AccountsPayable;
            orderBill.Order.Alipay = bill.Alipay;
            orderBill.Order.BankCard = bill.BankCard;
            orderBill.Order.Cash = bill.Cash;
            orderBill.Order.MembersCard = bill.MembersCard;
            orderBill.Order.WeiXin = bill.WeiXin;
            orderBill.Order.Tip = bill.Tip.Value;
            orderBill.Order.SameChange = bill.SameChange;
            orderBill.Order.ChangePay = bill.Change;
            orderBill.Order.CurrentPay = bill.CurrentPay;
            orderBill.EntireDiscount = new xiuse_discount();
            if(bill.TellUser != null)
            {
                orderBill.TellUser = new xiuse_user();
                orderBill.TellUser.UserName = DESEncrypt.DecryptJS(Convert.ToString(bill.TellUser.UserName), key);
                orderBill.TellUser.Password = DESEncrypt.DecryptJS(Convert.ToString(bill.TellUser.PassWord), key);
            }
           
           
            Order.CheckoutBill(orderBill);


            return ReturnData("1", "", Models.StatusCodeEnum.Success);
        }
    }
}
