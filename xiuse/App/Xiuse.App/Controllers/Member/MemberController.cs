/*******************************************************************************
             会员Web api接口类                                   
             本类主要实现对会员Member各种操作的接口              
             创建：xcf       2016/12/13                
 * *****************************************************************************/
using DotNet.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using Xiuse.App.Common;
using Xiuse.App.Models;
using System.Net.Http;
using System.Web.Http;
using Xiuse.App.Base;
using System.Web;
using System.Data;
namespace Xiuse.App.Controllers.Member
{
    [RoutePrefix("api/Members")]
    /// <summary>
    /// 会员信息接口
    /// </summary>
    public class MemberController : BaseResultMsg
    {
        BLL.xiuse_member MemberBLL = new BLL.xiuse_member();
        #region 系统管理员

        #endregion
        #region 用户
        /// <summary>
        /// 获取本餐厅的所有会员
        /// </summary>
        /// <param name="RestaurantId">餐厅ID</param>
        /// <returns></returns>
        [Route("GetMembers")]
        public DataSet GetMembers(string RestaurantId)
        {
            return MemberBLL.GetModels_RestaurantId(RestaurantId);
        }
        /// <summary>
        /// 搜索会员，条件：会员号、手机号、会员名称
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        [Route("SearchMembers")]
        public List<Model.xiuse_member> GetSearchMembers(string exp)
        {
            return MemberBLL.Search(exp, exp, exp); ;
        }



        /// <summary>
        /// 随机生成一个会员卡编号
        /// </summary>
        /// <returns></returns>
        [Route("GetMemberCardId")]
        public HttpResponseMessage GetMemberCardId()
        {
             
            ResultMsg resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            resultMsg.Info = "1";
            resultMsg.Data = DateTime.Now.ToString("yyMMddhhmmss") + RandomHelper.GetRandomString(4, true, false, false, false, "");
            return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg)); ;
        }


        /// <summary>
        /// 添加餐厅的会员
        /// </summary>
        /// <param name="member">会员信息</param>
        /// <returns></returns>
        [Route("AddMembers")]
        public HttpResponseMessage PostAddMmeber([FromBody]Model.xiuse_member member)
        {
            if (member == null)
            {
                throw new HttpRequestException();
            }
            member.MemberState = 1;
            member.MemberId =Guid.NewGuid().ToString("N");
            member.MemberTime = DateTime.Now;
            if (MemberBLL.Insert(member))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
        /// <summary>
        /// 修改会员信息
        /// 判断会员信息是否存在(卡号和手机号都必不可少)
        /// </summary>
        /// <param name="member">会员信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateMembers")]
        public HttpResponseMessage PostUpdateMember([FromBody]Model.xiuse_member member)
        {

            if (member == null||MemberBLL.ExistsMember(member)==false)
            {
                throw new HttpRequestException();
            }
            if (MemberBLL.Update(member))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MberPassword")]
        public HttpResponseMessage MemberPassword([FromBody]Model.xiuse_member member)
        {
            string key = HttpRuntime.Cache.Get("key").ToString();
            member.MemberPassword= DESEncrypt.DecryptJS(member.MemberPassword, key);
            if (MemberBLL.UpdatePassword(member))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);

        }

        /// <summary>
        /// 设置会员的启用状态
        /// </summary>
        /// <param name="MemberId">会员的ID</param>
        /// <param name="flag">会员的启用状态</param>
        /// <returns></returns>
        [HttpPost]
        [Route("SetMemberState")]
        public HttpResponseMessage PostSetMemberState(dynamic obj)
        {
            string MemberId = Convert.ToString(obj.MemberId);
            int State = Convert.ToInt32(obj.MemberState);
            if (MemberId == null)
                throw new HttpRequestException();
            if(MemberBLL.SetMemberState(MemberId,State))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);

        }
        /// <summary>
        /// 检测某饭店会员手机是否重复
        /// 参数：string MemberCell;string RestaurantId
        /// </summary>
        /// <param name="cell">会员手机号</param>
        /// <returns></returns>
        [Route("CheckCell")]
        public HttpResponseMessage PostCheckCell(dynamic obj)
        {
            string cell = Convert.ToString(obj.MemberCell);
            string rest = Convert.ToString(obj.RestaurantId);
            if (cell == null||rest==null)
                throw new HttpRequestException();
           
            if (!MemberBLL.CheckCellExist(cell,rest))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
       
        #endregion
    }
}
