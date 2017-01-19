using Newtonsoft.Json;
using Xiuse.App.Common;
using Xiuse.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DotNet.Utilities;

namespace Xiuse.App.Controllers.Security
{
    public class ServiceController : ApiController
    {
        [Route("api/Authenticated")]
        public HttpResponseMessage PostAuthenticated(string UserNameDS,string PassWordDS)
        {
            string UserName = DESEncrypt.Decrypt(UserNameDS);
            string PassWord = DESEncrypt.Decrypt(PassWordDS);
            Xiuse.BLL.xiuse_user user = new BLL.xiuse_user();
            ResultMsg resultMsg;
            string staffId = "";
            //验证用户名密码
            staffId = user.AffirmUser(UserName, PassWord);
            //if (true)
            //{
            
                
            //}
            //else
            //{
            //    staffId = "";
            //}
            //判断参数是否合法
            if (string.IsNullOrEmpty(staffId))
            {
                resultMsg = new ResultMsg();
                resultMsg.StatusCode = (int)StatusCodeEnum.ParameterError;
                resultMsg.Info = StatusCodeEnum.ParameterError.GetEnumText();
                resultMsg.Data = "";
                return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));
            }

            //插入缓存
            Token token = (Token)HttpRuntime.Cache.Get(staffId);
            if (HttpRuntime.Cache.Get(staffId) == null)
            {
                token = new Token();
                token.StaffId = staffId;
                token.SignToken = Guid.NewGuid();
                token.ExpireTime = DateTime.Now.AddDays(1);
                HttpRuntime.Cache.Insert(token.StaffId.ToString(), token, null, token.ExpireTime, TimeSpan.Zero);
            }

            //返回token信息
            resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            resultMsg.Info = "";
            resultMsg.Data = token;

            return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));
            //return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));
        }
       
    }
}
