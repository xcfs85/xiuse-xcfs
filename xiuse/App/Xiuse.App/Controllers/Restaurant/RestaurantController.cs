/*****************************************************************************
             餐厅接口类                                   
             本类主要实现对餐厅操作的接口              
             创建：zy       2016/12/19
1、添加餐厅。
2、修改餐厅。
3、删除餐厅。
4、获取当前系统中的所有餐厅。
5、查询餐厅（通过餐厅id号）。

******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse.App.Base;
using Xiuse.App.Models;

namespace Xiuse.App.Controllers.Restaurant
{
    [RoutePrefix("api/Restaurant")]
    public class RestaurantController : BaseResultMsg
    {
        
        BLL.xiuse_restaurant RestBLL = new BLL.xiuse_restaurant();


        /// <summary>
        /// 添加餐厅
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("AddRest")]
        public HttpResponseMessage PostAddRest([FromBody]Model.xiuse_restaurant model)
        {
            if (model == null)
            {
                throw new HttpRequestException();
            }
            model.RestaurantId = Guid.NewGuid().ToString("N");
            model.Time = DateTime.Now;

            if (RestBLL.Insert(model))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }


        /// <summary>
        /// 更新餐厅信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UpdateRest")]
        public HttpResponseMessage PostUpdateRest([FromBody]Model.xiuse_restaurant model)
        {
            if (model == null || RestBLL.Exists(model.RestaurantId)==false)
            {
                throw new HttpRequestException();
            }
            if (RestBLL.Update(model))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }

        /// <summary>
        /// 删除餐厅
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DeleteRest")]
        public HttpResponseMessage DeleteAddRest([FromBody]string id)
        {
            if (id == null || RestBLL.Exists(id)==false)
            {
                throw new HttpRequestException();
            }
            if (RestBLL.Delete(id))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
        /// <summary>
        /// 获取当前系统中的所有餐厅
        /// </summary>
        /// <returns></returns>
        [Route("GetAllRestaurants")]
        public List<Model.xiuse_restaurant> GetAllRest()
        {
            return RestBLL.GetAllRestaurants();
        }
        /// <summary>
        /// 查询餐厅（通过餐厅id号）
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        [Route("SearchRestaurantbyId")]
        public Model.xiuse_restaurant GetModel(string RestaurantId)
        {
            return RestBLL.GetModel(RestaurantId);
        }



        
    }
}
