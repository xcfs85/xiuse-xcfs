using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse;

namespace Xiuse.App.Controllers.Test
{
    [RoutePrefix("api/User")]
    public class TestUserController : ApiController
    {
        BLL.xiuse_user test = new BLL.xiuse_user();
       
        public IQueryable<Model.xiuse_user> GetAllXiuse_users()
        {
            List<Model.xiuse_user> users = test.GetModels();
            
            return users.AsQueryable<Model.xiuse_user>() ;
        }
        public IHttpActionResult GetXiuse_users(string id)
        {
            List<Model.xiuse_user> users = test.GetModels();
            var user = users.FirstOrDefault((p) => p.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}
