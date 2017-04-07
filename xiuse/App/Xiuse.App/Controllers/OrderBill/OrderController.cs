/******************************************
订单操作   作者：zy    时间：2017/1/4
*添加订单
*添加菜品
*修改订单
*删除菜品
*退单操作
*设定已上菜品
*添加订单折扣。
*修改订单的折扣。
*添加小费。
*增加抹零折扣。
********************************************/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse.App.Base;
using Xiuse.App.Common;
using Xiuse.App.Models;

namespace Xiuse.App.Controllers.OrderBill
{

    [RoutePrefix("api/Order")]
    public class OrderController : BaseResultMsg
    {
        BLL.order_ OrderBLL = new BLL.order_();
        BLL.ordermenu_ OrderMenuBLL = new BLL.ordermenu_();





        /// <summary>
        /// 添加订单，订单中有菜品信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("OrderwithMenu")]
        public HttpResponseMessage OrderwithMenu(dynamic obj)
        {
            ResultMsg resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            string flag = OrderBLL.NewOrder(obj);
            if (flag == "0")
            {
                resultMsg.Info = "0";
                resultMsg.Data = "";
            }
            else
            {
                resultMsg.Info = "1";
                resultMsg.Data = flag;
            }
            return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg)); 



        }

        /// <summary>
        /// 订单换桌
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="tableId"></param>
        /// <returns></returns>
        [Route("ChangeDesk")]
        public HttpResponseMessage PostDeskChanged(dynamic obj)
        {
            string orderId = Convert.ToString(obj.orderId);
            string tableId= Convert.ToString(obj.tableId);
            if (OrderBLL.DeskChanged(orderId, tableId))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
           
        }


        ///// <summary>
        ///// 添加订单
        ///// </summary>
        ///// <param name="member">订单信息</param>
        ///// <returns></returns>
        //[Route("AddOrder")]
        //public HttpResponseMessage PostAddOrder([FromBody]Model.order_ order)
        //{
        //    if (order == null || OrderBLL.Exists(order.OrderId))
        //    {
        //        throw new HttpRequestException();
        //    }
        //    if (OrderBLL.Insert(order))
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    else
        //        return new HttpResponseMessage(HttpStatusCode.Gone);
        //}




        /// <summary>
        /// 添加菜品
        /// </summary>
        /// <param name="member">菜品信息</param>
        /// <returns></returns>
        [Route("AddOrderMenu")]
        public HttpResponseMessage PostAddOrderMenu([FromBody]Model.ordermenu_ orderMenu)
        {
            if (orderMenu == null || OrderMenuBLL.Exists(orderMenu.OrderMenuId))
            {
                throw new HttpRequestException();
            }
            orderMenu.OrderMenuId = Guid.NewGuid().ToString("N");
            if (OrderMenuBLL.Insert(orderMenu))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }

        /// <summary>
        /// 批量添加菜品信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Route("AddOrderMenus")]
        public HttpResponseMessage PostAddOrderMenus(dynamic obj)
        {

            int count = OrderMenuBLL.AddOrderMenus(obj);
            if (count == 0)
                return base.ReturnData("0", "", StatusCodeEnum.Error);
            else
                return base.ReturnData("1", count, StatusCodeEnum.Success);
  
        }


        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="member">订单信息</param>
        /// <returns></returns>
        [Route("UpdateOrders")]
        public HttpResponseMessage PostUpdateOrders([FromBody]Model.order_ order)
        {

            if (order == null || OrderBLL.Exists(order.OrderId))
            {
                throw new HttpRequestException();
            }

            if (OrderBLL.Update(order))
                return base.ReturnData("1", "", StatusCodeEnum.Success); 
            else
               return base.ReturnData("0", "", StatusCodeEnum.Error);
        }


        /// <summary>
        /// 删除菜品
        /// </summary>
        /// <param name="member">订单信息</param>
        /// <returns></returns>
        [Route("DeleteOrderMenus")]
        public HttpResponseMessage DeleteOrderMenus([FromBody]Model.ordermenu_ orderMenu)
        {

            if (orderMenu == null || OrderMenuBLL.Exists(orderMenu.OrderId))
            {
                throw new HttpRequestException();
            }
            if (OrderMenuBLL.Delete(orderMenu.OrderMenuId))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
        ///<summary>
        /// 退单操作
        /// </summary>
        /// 
        [Route("BackOrder")]
        public HttpResponseMessage BackOrder([FromBody]Model.order_ Order)
        {
            if (Order == null || OrderBLL.Exists(Order.OrderId))
            {
                throw new HttpRequestException();
            }
            if (OrderBLL.BackOrder(Order))
            {
                Order.Refunds = Order.AccountsPayable;
                Order.Alipay = 0;
                Order.Cash = 0;
                Order.WeiXin = 0;
                Order.BankCard = 0;
                Order.OrderState = 2;
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            }
            else
               return base.ReturnData("0", "", StatusCodeEnum.Error);
           
        }

        ///<summary>
        /// 设定已上菜品
        /// 
        /// </summary>
        [HttpPost]
        [Route("IsOnTable")]

        public HttpResponseMessage SetOnTable([FromBody]Xiuse.Model.ordermenu_ model)
        {
            if(OrderMenuBLL.UpdateMenuState(model))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }


        ///<summary>
        /// 添加订单折扣   
        /// </summary>
        [Route("AddDiscount")]
        public HttpResponseMessage PostAddDiscount([FromBody]Model.ordermenu_ orderMenu, Model.xiuse_discount Discount)
        {

            if (orderMenu == null || OrderMenuBLL.Exists(orderMenu.OrderId))
            {
                throw new HttpRequestException();
            }
            if (OrderMenuBLL.Update(orderMenu))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }


        ///<summary>
        /// 修改订单折扣   
        /// 类型
        /// </summary>
        [Route("ChangeDiscount")]
        public HttpResponseMessage PostUpdateDiscount([FromBody]Model.ordermenu_ orderMenu)
        {
            orderMenu.MenuServing = 1;
            if (orderMenu == null || OrderMenuBLL.Exists(orderMenu.OrderId))
            {
                throw new HttpRequestException();
            }
            if (OrderMenuBLL.Update(orderMenu))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
        ///<summary>
        /// 添加小费
        /// </summary>
        //[Route("AddTips")]
        //public HttpResponseMessage PostAddTips([FromBody]Model.order_ Order)



        ///<summary>
        /// 增加抹零折扣
        /// </summary>
        [Route("AddMoveTailDiscount")]
        public HttpResponseMessage PostAddMoveTailDiscount([FromBody]Model.order_ Order, decimal Discount)
        {

            if (Order == null || OrderMenuBLL.Exists(Order.OrderId))
            {
                throw new HttpRequestException();
            }
            Order.AccountsPayable -= Discount;
            if (OrderBLL.Update(Order))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
    }
}