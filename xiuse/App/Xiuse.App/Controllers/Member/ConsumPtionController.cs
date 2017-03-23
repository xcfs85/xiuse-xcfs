using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse;

namespace Xiuse.App.Controllers.Member
{
    /// <summary>
    /// 会员消费信息接口
    /// </summary>
    [RoutePrefix("api/Members")]
    public class ConsumPtionController : ApiController
    {

        BLL.memberconsumption BllConsumption = new BLL.memberconsumption();
        /// <summary>
        /// 获取当前餐厅的所有会员的消费记录
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        [Route("ConsumPtion")]
        public List<Model.memberconsumption> GetConsumPtion(string RestaurantId)
        {
            return BllConsumption.GetModels(RestaurantId);
        }
        /// <summary>
        /// 搜索当前餐厅的的消费记录
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        [Route("SearchConsumPtion")]
        public List<Model.memberconsumption> GetSearchConsumPtion(string RestaurantId,string Condition)
        {
            return BllConsumption.Search(RestaurantId, Condition);
        }
        /// <summary>
        /// 添加会员的消费记录
        /// </summary>
        /// <param name="memberconsumption">消费记录对象</param>
        [HttpPost]
        [Route("AddConsumPtion")]
        public HttpResponseMessage PostAddConsumPtion(Model.memberconsumption memberconsumption)
        {
            if (memberconsumption == null)
                throw new HttpRequestException();
            if(BllConsumption.Insert(memberconsumption))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
    }
}
