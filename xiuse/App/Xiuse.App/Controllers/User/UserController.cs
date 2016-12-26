/*******************************************************************************
             用户接口类                                   
             本类主要实现对会员Member各种操作的接口              
             创建：zy       2016/12/15 
//1、查询所有的用户
//2、添加菜品的分类。
//3、更新菜品分类。
//4、删除菜品分类。            
 * *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse;

namespace Xiuse.App.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        BLL.xiuse_user new_user = new BLL.xiuse_user();

        [Route("GetAllUsers")]
        //查询所有的用户
        public List<Model.xiuse_user> GetAllXiuse_users()
        {
            List<Model.xiuse_user> users = new_user.GetModels();
            return users;
        }
        [Route("SearchbyId")]
        //用id号查询
        public IHttpActionResult GetXiuse_users(string id)
        {
            if(id==null && new_user.Exists(id))
            {
                throw new HttpRequestException();
            }
            List<Model.xiuse_user> users = new_user.GetModels();
            var user = users.FirstOrDefault((p) => p.UserId == id);
       
            return Ok(user);
        }
        [Route("AddUser")]
        //新建一个用户{重复检测如何实现}
        public IHttpActionResult PostSetXiuse_users([FromBody] Model.xiuse_user user)
        {
            //List<Model.xiuse_user> users = new_user.GetModels();
            if (new_user.Insert(user) == true)
            {
                return Ok(user);
            }
            else
            {
                throw new HttpRequestException();
            }
           
        }


        [Route("DeletebyId")]
        //删除一个用户
        public IHttpActionResult DeleteXiuse_users(string id)
        {
            if (new_user.Delete(id) == true)
            {
                return Ok();
            }
            else
            {
                throw new HttpRequestException();
            }
        }

    }
}
