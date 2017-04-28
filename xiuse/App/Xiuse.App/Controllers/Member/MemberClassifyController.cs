using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse.App.Base;
using Xiuse.App.Models;

namespace Xiuse.App.Controllers.Member
{
    /// <summary>
    /// 会员类型接口
    /// </summary>
   [RoutePrefix("api/Members")]
    public class MemberClassifyController : BaseResultMsg
    {
        BLL.xiuse_memberclassify BllMemberClassify = new BLL.xiuse_memberclassify();
        /// <summary>
        /// 获取当前餐厅的所有会员的类型
        /// </summary>
        /// <param name="RestaurantId">餐厅Id</param>
        /// <returns></returns>
        [Route("MemberClassify")]
        public List<Model.xiuse_memberclassify> GetMemberClassify(string RestaurantId)
        {
            return BllMemberClassify.GetModels(RestaurantId);
        }
        /// <summary>
        /// 更新当前餐厅的会员类型=>编辑
        /// </summary>
        /// <param name="RestaurantId">餐厅Id</param>
        /// <returns></returns>
        [Route("UpdateMemberClassify")]
        public HttpResponseMessage PostUpdateMemberClassify([FromBody]Model.xiuse_memberclassify MemberClassify)
        {
            if (MemberClassify == null)
                throw new HttpRequestException();
            if (BllMemberClassify.Update(MemberClassify))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
        /// <summary>
        /// 添加会员类型，并更新数目
        /// </summary>
        /// <param name="memberconsumption">会员类型对象</param>
        /// <returns></returns>
        [Route("AddMemberClassify")]
        public HttpResponseMessage PostAddMemberClassify([FromBody]Model.xiuse_memberclassify MemberClassify)
        {
            if (MemberClassify == null)
                throw new HttpRequestException();
            MemberClassify.MemberClassifyId = Guid.NewGuid().ToString("N");
            MemberClassify.ClassifyTime = DateTime.Now;
            MemberClassify.DelTag = 0;
            if (BllMemberClassify.Insert(MemberClassify))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
        /// <summary>
        /// 删除会员类型(MemberClassifyId)
        /// </summary>
        /// <param name="memberconsumption">会员类型对象</param>
        /// <returns></returns>
        [Route("DeleteMemberClassify")]
        public HttpResponseMessage PostDeleteMemberClassify(dynamic obj)
        {
            string MemberClassifyId = Convert.ToString(obj.MemberClassifyId);
            if (MemberClassifyId == null)
                throw new HttpRequestException();
            if (BllMemberClassify.SetMemberClassify(2,MemberClassifyId))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
        /// <summary>
        /// 启用会员类型
        /// </summary>
        /// <param name="memberconsumption">会员类型对象</param>
        /// <returns></returns>
        [Route("StartUpMemberClassify")]
        public HttpResponseMessage PostStartUpMemberClassify(dynamic obj)
        {
            string MemberClassifyId = Convert.ToString(obj.MemberClassifyId);
            if (MemberClassifyId == null)
                throw new HttpRequestException();
            if (BllMemberClassify.SetMemberClassify(0, MemberClassifyId))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
        /// <summary>
        /// 停用会员类型
        /// </summary>
        /// <param name="memberconsumption">会员类型对象</param>
        /// <returns></returns>
        [Route("StopMemberClassify")]
        public HttpResponseMessage PostStopMemberClassify(dynamic obj)
        {
            string MemberClassifyId = Convert.ToString(obj.MemberClassifyId);
            if (MemberClassifyId == null)
                throw new HttpRequestException();
            if (BllMemberClassify.SetMemberClassify(1, MemberClassifyId))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
    }
}
