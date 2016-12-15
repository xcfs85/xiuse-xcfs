/*******************************************************************************
             会员Web api接口类                                   
             本类主要实现对会员Member各种操作的接口              
             创建：xcf       2016/12/13                
 * *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse;
namespace Xiuse.App.Controllers.Member
{

    public class MemberController : ApiController
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
        public List<Model.xiuse_member> GetMembers(string RestaurantId)
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
        /// 添加餐厅的会员
        /// </summary>
        /// <param name="member">会员信息</param>
        /// <returns></returns>
        [Route("AddMembers")]
        public HttpResponseMessage PostAddMmeber([FromBody]Model.xiuse_member member)
        {
            if (member == null && MemberBLL.ExistsMember(member))
            {
                throw new HttpRequestException();
            }
            if (MemberBLL.Insert(member))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="member">会员信息</param>
        /// <returns></returns>
        [Route("UpdateMembers")]
        public HttpResponseMessage PostUpdateMmeber([FromBody]Model.xiuse_member member)
        {

            if (member == null && MemberBLL.ExistsMember(member))
            {
                throw new HttpRequestException();
            }
            if (MemberBLL.Update(member))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
        /// <summary>
        /// 设置会员的启用状态
        /// </summary>
        /// <param name="MemberId">会员的ID</param>
        /// <param name="flag">会员的启用状态</param>
        /// <returns></returns>
        [Route("SetMemberState")]
        public HttpResponseMessage PostSetMemberState([FromBody] string MemberId,bool flag)
        {
            if (MemberId == null)
                throw new HttpRequestException();
            if(MemberBLL.SetMemberState(MemberId,flag))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);

        }
        /// <summary>
        /// 检测会员手机号是否重复
        /// </summary>
        /// <param name="cell">会员手机号</param>
        /// <returns></returns>
        [Route("CheckCell")]
        public HttpResponseMessage PostCheckCell([FromBody] string cell)
        {
            if (cell == null)
                throw new HttpRequestException();
           
            if (!MemberBLL.CheckCellExist(cell))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
       
        #endregion
    }
}
