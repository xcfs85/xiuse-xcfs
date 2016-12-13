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
        [Route("SearchMembers")]
        public List<Model.xiuse_member> GetSearchMembers(string exp)
        {
            //todo
            return null;
        }
        /// <summary>
        /// 添加餐厅的会员
        /// </summary>
        /// <param name="member">会员信息</param>
        /// <returns></returns>
        [Route("GetMembers")]
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
        
        #endregion
    }
}
