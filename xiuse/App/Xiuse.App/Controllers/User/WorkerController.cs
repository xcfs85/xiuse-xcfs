/*******************************************************************************
             员工接口类                                   
             本类主要实现对Worker各种操作的接口              
             创建：zy       2016/12/18
//1、获取餐厅的全部员信息，条件餐厅ID。
//2、添加新员工。
//3、修改员工信息。
//4、启用、禁用员工。      
 * *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse.App.Base;
using Xiuse;
using Xiuse.App.Models;
using System.Web;
using DotNet.Utilities;

namespace Xiuse.App.Controllers.User
{
    [RoutePrefix("api/User")]
    public class WorkerController : BaseResultMsg
    {
        BLL.xiuse_user BLLWorker = new BLL.xiuse_user();

        /// <summary>
        /// 查询一个饭店中所有的Worker
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        [Route("GetAllWorkers")]      
        public List<Model.xiuse_user> GetAllXiuse_Workers(string restaurantId)
        {
            List<Model.xiuse_user> worker = BLLWorker.GetWorkerModels(restaurantId);
            return worker;
        }
       // public HttpResponseMessage UpdateWorker()

        /// <summary>
        ///  通过用户id号查询Worker信息
        /// </summary>
        [Route("SearchWorkerbyId")]
        public Model.xiuse_user GetWorker(string id)
        {
            if (id == null||BLLWorker.WorkerExists(id)==false)
            {
                throw new HttpRequestException();
            }
            Model.xiuse_user user = BLLWorker.GetModel(id);
            return user;
        }

        /// <summary>
        /// 新建一个worker
        /// UserRole=1,为员工
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("AddWorker")]
        public HttpResponseMessage PostAddWorker([FromBody] Model.xiuse_user user)
        {
            if (user == null)
            {
                throw new HttpRequestException();
            }
            string key = HttpRuntime.Cache.Get("key").ToString();
            if(!string.IsNullOrEmpty(user.Password))
                user.Password = DESEncrypt.DecryptJS(Convert.ToString(user.Password), key);
            user.UserId = Guid.NewGuid().ToString("N");
            user.Time = DateTime.Now;
            user.DelTag = 0;
        
            if (BLLWorker.Insert(user) == true)
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);

        }
        /// <summary>
        /// 更新worker（如果密码为空，维持不变！）
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("UpdateWorker")]
        [HttpPost]
        public HttpResponseMessage UpdateWorker(Model.xiuse_user user)
        {
            string key = HttpRuntime.Cache.Get("key").ToString();
            if (!string.IsNullOrEmpty(user.Password))
                user.Password = DESEncrypt.DecryptJS(Convert.ToString(user.Password), key);
            if (BLLWorker.Update(user))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }

        /// <summary>
        /// 设置员工状态( 0:正常,1：禁止,2：删除)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("FixWorkerbyId")]
        public HttpResponseMessage PostFixWorker([FromBody] Model.xiuse_user user)
        {
            if (user.UserId == null || !BLLWorker.WorkerExists(user.UserId))
            {
                return base.ReturnData("0", "员工不存在！", StatusCodeEnum.Error);
            }
            if (BLLWorker.FixWorker(user.UserId,user.DelTag))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
    }
}
