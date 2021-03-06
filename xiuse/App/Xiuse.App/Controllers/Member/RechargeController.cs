﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse;
using Xiuse.App.Base;
using Xiuse.App.Models;

namespace Xiuse.App.Controllers.Member
{
    [RoutePrefix("api/Members")]
    /// <summary>
    /// 会员充值记录接口
    /// </summary>
    public class RechargeController : BaseResultMsg
    {
        Xiuse.BLL.xiuse_recharge BllRecharge = new BLL.xiuse_recharge();

        /// <summary>
        /// 获取店铺内的会员充值记录
        /// </summary>
        /// <param name="RestaurantId">店铺的ID</param>
        /// <returns></returns>
        [Route("RechargeAt")]
        public List<Model.xiuse_recharge> GetRechargeAtRestaurant(string RestaurantId)
        {
            return BllRecharge.GetModelsAtRestaurant(RestaurantId);
        }
        /// <summary>
        /// 搜索店内会员充值记录
        /// </summary>
        /// <param name="RestaurantId">餐厅的ID</param>
        /// <param name="Condition">搜索条件：会员名称、会员手机号、会员卡号</param>
        /// <returns></returns>
        [Route("SearchRecharge")]
        public List<Model.xiuse_recharge> GetSearchRecharge(string RestaurantId,string condition)
        {
            return BllRecharge.Search(RestaurantId, condition);
        }
        /// <summary>
        /// 会员卡充值 生成充值记录，并更新会员可用余额
        /// </summary>
        /// <param name="Recharge">充值记录</param>
        /// <returns></returns>
        [Route("AddRecharge")]
        public HttpResponseMessage PostAddRecharge([FromBody] Model.xiuse_recharge Recharge)
        {
            
            if (Recharge == null)
                throw new HttpRequestException();
            Recharge.RechargeId = Guid.NewGuid().ToString("N");
            Recharge.RechargeTime = DateTime.Now;
            if (BllRecharge.InsertWords(Recharge)==4)
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
    }
}
