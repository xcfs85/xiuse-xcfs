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
using Xiuse;

namespace Xiuse.App.Controllers.Restaurant
{
    [RoutePrefix("api/Restaurant")]
    public class RestaurantController : ApiController
    {
        
        BLL.xiuse_restaurant RestBLL = new BLL.xiuse_restaurant();
        [Route("AddRest")]
        public HttpResponseMessage PostAddRest([FromBody]Model.xiuse_restaurant model)
        {
            if (model == null && RestBLL.Exists(model.RestaurantId))
            {
                throw new HttpRequestException();
            }
            if (RestBLL.Insert(model))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }

        [Route("UpdateRest")]
        public HttpResponseMessage PostUpdateRest([FromBody]Model.xiuse_restaurant model)
        {
            if (model == null && RestBLL.Exists(model.RestaurantId))
            {
                throw new HttpRequestException();
            }
            if (RestBLL.Update(model))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }


        [Route("DeleteRest")]
        public HttpResponseMessage DeleteAddRest([FromBody]string id)
        {
            if (id == null && RestBLL.Exists(id))
            {
                throw new HttpRequestException();
            }
            if (RestBLL.Delete(id))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }


        [Route("SearchRestaurantbyId")]
        public Model.xiuse_restaurant GetModel(string RestaurantId)
        {
            return RestBLL.GetModel(RestaurantId);
        }



        
    }
}
