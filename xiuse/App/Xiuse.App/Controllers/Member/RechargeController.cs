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

        public List<Model.xiuse_recharge> GetRecharge(string RestaurantId)
        {
            return BllRecharge.get
        }
        /// <summary>
        /// 会员卡充值
        /// </summary>
        /// <param name="Recharge">充值记录</param>
        /// <returns></returns>
        [Route("Recharge")]
        public HttpResponseMessage PostRecharge([FromBody] Model.xiuse_recharge Recharge)
        {
            if (Recharge == null)
                throw new HttpRequestException();
            BllRecharge.Insert(Recharge);
            if (true)
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
    }
}
