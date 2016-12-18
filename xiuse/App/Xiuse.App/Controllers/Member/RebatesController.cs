using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse;

namespace Xiuse.App.Controllers.Member
{
    public class RebatesController : ApiController
    {

        BLL.xiuse_rebates BllResbates = new BLL.xiuse_rebates();
        /// <summary>
        /// 获取餐厅的的所有的会员的返现记录
        /// </summary>
        /// <param name="RestaurantId">餐厅的Id</param>
        /// <returns></returns>
        [Route("Rebates")]
        public List<Model.xiuse_rebates> GetRebates(string RestaurantId)
        {
            return BllResbates.GetModelAt(RestaurantId);
        }
        /// <summary>
        /// 搜索餐厅内会员的的返现记录
        /// </summary>
        /// <param name="RestaurantId">餐厅ID</param>
        /// <param name="Condition">搜索条件</param>
        /// <returns></returns>
        [Route("SearchResbates")]
        public List<Model.xiuse_rebates> GetSearchResbates(string RestaurantId,string Condition)
        {
            return BllResbates.Search(RestaurantId,Condition);
        }
        /// <summary>
        /// 添加会员返现记录
        /// </summary>
        /// <param name="Rebates">返现实体</param>
        /// <returns></returns>
        [Route("AddRebates")]
        public HttpResponseMessage PostAddRebates(Model.xiuse_rebates Rebates)
        {
            if (Rebates == null)
                throw new HttpRequestException();
            if (BllResbates.Insert(Rebates))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
    }
}
