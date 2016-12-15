using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse;

namespace Xiuse.App.Controllers.Member
{
    public class RechargeController : ApiController
    {
        Xiuse.BLL.xiuse_recharge BllRecharge = new BLL.xiuse_recharge();

        /// <summary>
        /// 获取店铺内的会员充值记录
        /// </summary>
        /// <param name="RestaurantId">店铺的ID</param>
        /// <returns></returns>
        [Route("RechargeAtRestaurant")]
        public List<Model.xiuse_recharge> GetRechargeAtRestaurant(string RestaurantId)
        {
            return BllRecharge.GetModelsAtRestaurant(RestaurantId);
        }
        /// <summary>
        /// 搜索会员充值记录
        /// </summary>
        /// <param name="condition">条件：会员卡号，会员手机号</param>
        /// <returns></returns>
        public List<Model.xiuse_recharge> GetSearchRecharge(string condition)
        {
            //todo
            return null;
        }
        /// <summary>
        /// 会员卡充值
        /// </summary>
        /// <param name="Recharge">充值记录</param>
        /// <returns></returns>
        [Route("AddRecharge")]
        public HttpResponseMessage PostAddRecharge([FromBody] Model.xiuse_recharge Recharge)
        {
            if (Recharge == null)
                throw new HttpRequestException();
            if (BllRecharge.Insert(Recharge))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
    }
}
