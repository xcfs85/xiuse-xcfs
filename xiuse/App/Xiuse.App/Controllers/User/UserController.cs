/*******************************************************************************
             用户接口类                                   
             本类主要实现对用户各种操作的接口              
             创建：zy       2016/12/18
//1、查询所有的用户
//2、通过ID号查询用户，返回model
//3、新建一个用户。
//4、更新用户信息。
//4、删除用户信息。            
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
        //通过用户id号查询
        public Model.xiuse_user GetXiuse_users(string id)
        {
            if(id==null && new_user.Exists(id))
            {
                throw new HttpRequestException();
            }
            Model.xiuse_user user = new_user.GetModel(id);
            return user;
        }


        [Route("AddUser")]
        //新建一个用户
        public HttpResponseMessage PostSetXiuse_users([FromBody] Model.xiuse_user user)
        {
           if(user==null&&new_user.Exists(user.UserId))
            {
                throw new HttpRequestException();
            }
            if (new_user.Insert(user) == true)
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);

        }


        [Route("DeletebyId")]
        //删除一个用户
        public HttpResponseMessage DeleteDelXiuse_users(string id)
        {
            if (id== null && new_user.Exists(id))
            {
                throw new HttpRequestException();
            }
            if (new_user.Delete(id) == true)
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }

    }
}
