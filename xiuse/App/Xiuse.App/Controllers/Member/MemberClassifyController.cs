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
    /// 会员类型接口
    /// </summary>
    public class MemberClassifyController : ApiController
    {
        BLL.xiuse_memberclassify BllMemberClassify = new BLL.xiuse_memberclassify();
        /// <summary>
        /// 获取当前餐厅的所有会员的类型
        /// </summary>
        /// <param name="ResaurantId">餐厅Id</param>
        /// <returns></returns>
        [Route("MemberClassify")]
        public List<Model.xiuse_memberclassify> GetMemberClassify(string ResaurantId)
        {
            return BllMemberClassify.GetModels(ResaurantId);
        }
        /// <summary>
        /// 更新当前餐厅的会员类型
        /// </summary>
        /// <param name="ResaurantId">餐厅Id</param>
        /// <returns></returns>
        [Route("UpdateMemberClassify")]
        public HttpResponseMessage PostUpdateMemberClassify(Model.xiuse_memberclassify MemberClassify)
        {
            if (MemberClassify == null)
                throw new HttpRequestException();
            if (BllMemberClassify.Update(MemberClassify))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
        /// <summary>
        /// 添加会员类型
        /// </summary>
        /// <param name="memberconsumption">会员类型对象</param>
        /// <returns></returns>
        [Route("AddMemberClassify")]
        public HttpResponseMessage PostAddMemberClassify(Model.xiuse_memberclassify MemberClassify)
        {
            if (MemberClassify == null)
                throw new HttpRequestException();
            if (BllMemberClassify.Insert(MemberClassify))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
        /// <summary>
        /// 删除会员类型
        /// </summary>
        /// <param name="memberconsumption">会员类型对象</param>
        /// <returns></returns>
        [Route("DeleteMemberClassify")]
        public HttpResponseMessage GetDeleteMemberClassify(string MemberClassifyId)
        {
            if (MemberClassifyId == null)
                throw new HttpRequestException();
            if (BllMemberClassify.SetMemberClassify(2,MemberClassifyId))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
        /// <summary>
        /// 启用会员类型
        /// </summary>
        /// <param name="memberconsumption">会员类型对象</param>
        /// <returns></returns>
        [Route("StartUpMemberClassify")]
        public HttpResponseMessage GetStartUpMemberClassify(string MemberClassifyId)
        {
            if (MemberClassifyId == null)
                throw new HttpRequestException();
            if (BllMemberClassify.SetMemberClassify(0, MemberClassifyId))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
        /// <summary>
        /// 停用会员类型
        /// </summary>
        /// <param name="memberconsumption">会员类型对象</param>
        /// <returns></returns>
        [Route("StopMemberClassify")]
        public HttpResponseMessage GetStopMemberClassify(string MemberClassifyId)
        {
            if (MemberClassifyId == null)
                throw new HttpRequestException();
            if (BllMemberClassify.SetMemberClassify(1, MemberClassifyId))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
    }
}
