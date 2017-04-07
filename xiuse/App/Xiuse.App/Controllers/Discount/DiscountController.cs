using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse;

namespace Xiuse.App.Controllers.Discount
{
    /// <summary>
    /// 折扣信息接口
    /// </summary>   

    [RoutePrefix("api/Dis")]
    public class DiscountController : ApiController
    {
        BLL.xiuse_discount BllDiscount = new BLL.xiuse_discount();
        /// <summary>
        /// 获取餐厅所有的折扣信息
        /// </summary>
        /// <param name="RestaurantId">餐厅的Id</param>
        /// <returns></returns>
        [Route("DiscountAt")]
        public  List<Model.xiuse_discount> GetDiscountAt(string RestaurantId)
        {
            return BllDiscount.GetModels(RestaurantId);
        }
        /// <summary>
        /// 添加折扣信息
        /// </summary>
        /// <param name="Discount">折扣的对象</param>
        /// <returns></returns>
        [Route("AddDiscount")]
        public HttpResponseMessage PostAddDiscount(Model.xiuse_discount Discount)
        {
            if (Discount == null)
               throw new HttpResponseException(HttpStatusCode.BadGateway);
            Discount.DiscountTime = DateTime.Now;
            Discount.DiscountId = Guid.NewGuid().ToString("N");
            if (BllDiscount.Insert(Discount))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
        /// <summary>
        /// 修改折扣信息
        /// </summary>
        /// <param name="Discount">折扣对象</param>
        /// <returns></returns>
        [Route("UpdateDiscount")]
        public HttpResponseMessage PostUpdateDiscount(Model.xiuse_discount Discount)
        {
            if (Discount == null)
                throw new HttpResponseException(HttpStatusCode.BadGateway);
            if (BllDiscount.Update(Discount))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
        /// <summary>
        /// 设置折扣的状态（1,启用；0，禁用;2,删除；）
        /// </summary>
        /// <param name="DiscountId">折扣的ID</param>
        /// <param name="State">折扣的状态（1,启用；0，禁用;2,删除；）</param>
        /// <returns></returns>
        [Route("SetDiscountState")]
        public HttpResponseMessage GetSetDiscountState(string DiscountId,int State)
        {
            if (DiscountId == null)
                throw new HttpResponseException(HttpStatusCode.BadGateway);
            if (BllDiscount.SetDiscountState(DiscountId,State))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
    }
}
