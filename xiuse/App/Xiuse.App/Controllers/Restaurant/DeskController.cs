﻿/*******************************************************************************
             餐桌接口类                                   
             本类主要实现对餐桌操作的接口              
             创建：zy       2016/12/19
1、添加餐桌。
2、修改餐桌。
3、删除餐桌。
4、获取餐厅的所有餐桌。
5、获取某一餐厅的所有未结账餐桌的金额
6、获取某一餐厅最近一笔已支付的金额
7、清理已付款的餐桌
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Xiuse.App.Controllers.Restaurant
{
    [RoutePrefix("api/Restaurant")]
    public class DeskController : ApiController
    {
        BLL.xiuse_desk DeskBLL = new BLL.xiuse_desk();
        BLL.order_ OrderBLL = new BLL.order_();

        [Route("AddDesk")]
        public HttpResponseMessage PostAddDesk([FromBody]Model.xiuse_desk model)
        {
            if (model == null || DeskBLL.Exists(model.DeskId) == false)
            {
                throw new HttpRequestException();
            }
            if (DeskBLL.Insert(model))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
        
       
        [Route("UpdateDesk")]
        public HttpResponseMessage PostUpdateDesk([FromBody]Model.xiuse_desk model)
        {
            if (model == null || DeskBLL.Exists(model.DeskId) == false)
            {
                throw new HttpRequestException();
            }
            if (DeskBLL.Update(model))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }

        [Route("DeleteDesk")]
        public HttpResponseMessage DeleteDelDeskClassify([FromBody]String id)
        {
            if (id == null || DeskBLL.Exists(id) == false)
            {
                throw new HttpRequestException();
            }
            if (DeskBLL.Delete(id))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }

        /// <summary>
        /// 获取餐厅的所有餐桌。
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        [Route("GetAllDesks")]
        public List<Model.xiuse_desk> GetAllDesks(string RestaurantId)
        {
            if (RestaurantId == null || DeskBLL.RestaurantExists(RestaurantId) == false)
            {
                throw new HttpRequestException();
            }
            return DeskBLL.GetAllDesk(RestaurantId);
        }

        [Route("AllDesksWithAccount")]

        /// <summary>
        /// 获取某一餐厅所有餐桌信息（包含餐桌费用）
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        public DataSet GetAllDesksWithAccount(string RestaurantId)
        {
            if (RestaurantId == null || DeskBLL.RestaurantExists(RestaurantId) == false)
            {
                throw new HttpRequestException();
            }
            return DeskBLL.GetAllDesksWithAccount(RestaurantId);
        }



        [Route("GetUnpaidDesks")]
        ///
        ///获取某一餐厅的所有未结账餐桌的金额
        ///
        public List<Model.order_> GetUnpaidDesks(string RestaurantId)
        {
            if (RestaurantId == null || DeskBLL.RestaurantExists(RestaurantId) == false)
            {
                throw new HttpRequestException();
            }
            return OrderBLL.GetUnpaidDesks(RestaurantId);
        }

        /// <summary>
        /// 获取某一餐厅最近一笔已支付的金额
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        [Route("GetPaidLatest")]
        public List<Model.order_> GetPaidLatest(string RestaurantId)
        {
            if (RestaurantId == null || DeskBLL.RestaurantExists(RestaurantId) == false)
            {
                throw new HttpRequestException();
            }
            return OrderBLL.GetPaidLatest(RestaurantId);
        }

        /// <summary>
        /// 清理已付款的餐桌
        /// </summary>
        /// <param name="DeskId"></param>
        /// <returns></returns>
        [Route("CleanDesk")]
        public HttpResponseMessage PostClearDesk(string DeskId)
        {
            if (DeskId == null || DeskBLL.Exists(DeskId) == false)
            {
                throw new HttpRequestException();
            }
            if (DeskBLL.ClearDesk(DeskId))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
    }
}