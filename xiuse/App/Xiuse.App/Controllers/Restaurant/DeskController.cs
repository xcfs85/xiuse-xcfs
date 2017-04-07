/*******************************************************************************
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
using Xiuse.App.Base;

namespace Xiuse.App.Controllers.Restaurant
{
    [RoutePrefix("api/Restaurant")]
    public class DeskController : BaseResultMsg
    {
        BLL.xiuse_desk DeskBLL = new BLL.xiuse_desk();
        BLL.order_ OrderBLL = new BLL.order_();
        /// <summary>
        /// 添加餐桌
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        
       /// <summary>
       /// 更新餐桌
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
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
        /// <summary>
        /// 删除餐桌
        /// </summary>
        /// <param name="id">餐桌ID</param>
        /// <returns></returns>
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
        /// <returns>List Model.xiuse_desk </returns>
        [Route("GetAllDesks")]
        public List<Model.xiuse_desk> GetAllDesks(string RestaurantId)
        {
            if (RestaurantId == null || DeskBLL.RestaurantExists(RestaurantId) == false)
            {
                throw new HttpRequestException();
            }
            return DeskBLL.GetAllDesk(RestaurantId);
        }


        /// <summary>
        /// 获取某一餐厅所有餐桌信息（包含餐桌费用）
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        [Route("AllDesksWithAccount")]

   
        //public IQueryable<DataRow> GetAllDesksWithAccount(string RestaurantId)
        public DataSet GetAllDesksWithAccount(string RestaurantId)
        {
            if (RestaurantId == null || DeskBLL.RestaurantExists(RestaurantId) == false)
            {
                throw new HttpRequestException();
            }
            return DeskBLL.GetAllDesksWithAccount(RestaurantId);
        }


        /// <summary>
        /// 获取某一餐厅的所有未结账餐桌的金额
        /// </summary>
        [Route("GetUnpaidDesks")]
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
        [HttpPost]
        [Route("CleanDesk")]
        public HttpResponseMessage PostClearDesk([FromBody]dynamic DeskId)
        {
           
            if (DeskId == null || DeskBLL.Exists(DeskId.DeskId.ToString()) == false)
            {
                return base.ReturnData("0", "餐桌不存在或者参数有误！", Models.StatusCodeEnum.ParameterError);
            }
            if (DeskBLL.ClearDesk(DeskId.DeskId.ToString()))
                return base.ReturnData("1", "", Models.StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "清理失败！", Models.StatusCodeEnum.Error);
        }
    }
}
