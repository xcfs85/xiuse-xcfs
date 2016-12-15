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

        //查询所有的用户
        public List<Model.xiuse_user> GetAllXiuse_users()
        {
            List<Model.xiuse_user> users = new_user.GetModels();
            return users;
        }

        //用id号查询
        public IHttpActionResult GetXiuse_users(string id)
        {
            List<Model.xiuse_user> users = new_user.GetModels();
            var user = users.FirstOrDefault((p) => p.UserId == id);
            if (user == null)
            {
                   return NotFound();
            }
            return Ok(user);
        }
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
                return NotFound();
            }
           
        }
        //删除一个用户
        public IHttpActionResult PostDeleteXiuse_users(string id)
        {
            if (new_user.Delete(id) == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
