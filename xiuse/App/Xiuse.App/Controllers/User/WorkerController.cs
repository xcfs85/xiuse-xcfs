﻿/*******************************************************************************
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
using Xiuse;

namespace Xiuse.App.Controllers.User
{
    [RoutePrefix("api/User")]
    public class WorkerController : ApiController
    {
        BLL.xiuse_user BLLWorker = new BLL.xiuse_user();

        [Route("GetAllWorkers")]
        //查询所有的用户
        public List<Model.xiuse_user> GetAllXiuse_Workers()
        {
            List<Model.xiuse_user> worker = BLLWorker.GetWorkerModels();
            return worker;
        }
        [Route("SearchWorkerbyId")]
        //通过用户id号查询
        public Model.xiuse_user GetWorker(string id)
        {
            if (id == null||BLLWorker.WorkerExists(id)==false)
            {
                throw new HttpRequestException();
            }
            Model.xiuse_user user = BLLWorker.GetModel(id);
            return user;
        }


        [Route("AddWorker")]
        //新建一个用户
        public HttpResponseMessage PostAddWorker([FromBody] Model.xiuse_user user)
        {
            if (user == null|| BLLWorker.WorkerExists(user.UserId)==false)
            {
                throw new HttpRequestException();
            }
            if (BLLWorker.Insert(user) == true)
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);

        }


        [Route("FixWorkerbyId")]
        ///设置员工权限
        /// 0:正常
        /// 1：禁止
        /// 2：删除
        public HttpResponseMessage PostFixWorker(string WorkerId,int tag)
        {
            if (WorkerId== null || BLLWorker.WorkerExists(WorkerId)==false)
            {
                throw new HttpRequestException();
            }
            if (BLLWorker.FixWorker(WorkerId,tag) == true)
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
    }
}