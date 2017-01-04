﻿/******************************************
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Xiuse.App.Controllers.OrderBill
{

    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
     BLL.order_ OrderBLL=new BLL.order_();
        BLL.ordermenu_ OrderMenuBLL = new BLL.ordermenu_();
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="member">订单信息</param>
        /// <returns></returns>
        [Route("AddOrder")]
        public HttpResponseMessage PostAddOrder([FromBody]Model.order_ order)
        {
            if (order == null||OrderBLL.Exists(order.OrderId) )
            {
                throw new HttpRequestException();
            }
            if (OrderBLL.Insert(order))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }




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
            if (OrderMenuBLL.Insert(orderMenu))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
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
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
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
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
        ///<summary>
        /// 退单操作---理解为删除订单操作
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
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
                
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
            ///<summary>
            /// 设定已上菜品
            /// 
            /// </summary>
        [Route("IsOnTable")]
        public HttpResponseMessage PostSetOnTable([FromBody]Model.ordermenu_ orderMenu)
        {
            orderMenu.MenuServing = true;
            if (orderMenu == null || OrderMenuBLL.Exists(orderMenu.OrderId))
            {
                throw new HttpRequestException();
            }
            if (OrderMenuBLL.Update(orderMenu))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }


        ///<summary>
        /// 添加订单折扣   
        /// </summary>
       [Route("AddDiscount")]
        public HttpResponseMessage PostAddDiscount([FromBody]Model.ordermenu_ orderMenu,Model.xiuse_discount Discount)
        {
            
            if (orderMenu == null || OrderMenuBLL.Exists(orderMenu.OrderId))
            {
                throw new HttpRequestException();
            }
            if (OrderMenuBLL.Update(orderMenu))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }


        ///<summary>
        /// 修改订单折扣   
        /// 类型
        /// </summary>
        [Route("AddDiscount")]
        public HttpResponseMessage PostUpdateDiscount([FromBody]Model.ordermenu_ orderMenu)
        {
            orderMenu.MenuServing = true;
            if (orderMenu == null || OrderMenuBLL.Exists(orderMenu.OrderId))
            {
                throw new HttpRequestException();
            }
            if (OrderMenuBLL.Update(orderMenu))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
        ///<summary>
        /// 添加小费
        /// </summary>




        ///<summary>
        /// 增加抹零折扣
        /// </summary>
        [Route("AddMoveTailDiscount")]
        public HttpResponseMessage PostAddMoveTailDiscount([FromBody]Model.order_ Order,decimal Discount)
        {
          
            if (Order == null || OrderMenuBLL.Exists(Order.OrderId))
            {
                throw new HttpRequestException();
            }
            Order.AccountsPayable -= Discount;
            if (OrderBLL.Update(Order))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
    }
