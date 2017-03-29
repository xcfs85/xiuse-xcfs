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
    /// <summary>
    /// 登录、秘钥
    /// </summary>
    public class ServiceController : ApiController
    {
        /// <summary>
        /// 验证登录(参数：UserNameDS，PassWordDS)
        /// </summary>
        /// <param name="obj">参数：UserNameDS，PassWordDS</param>
        /// <returns></returns>
        [Route("api/Authenticated")]
        [HttpPost]
        public HttpResponseMessage Authenticated(dynamic obj)
        {

            string key = HttpRuntime.Cache.Get("key").ToString();
            string UserName = DESEncrypt.DecryptJS(Convert.ToString(obj.UserNameDS), key);
            string PassWord = DESEncrypt.DecryptJS(Convert.ToString(obj.PassWordDS), key);
            //string UserName = Convert.ToString(obj.UserNameDS);
            //string PassWord = Convert.ToString(obj.PassWordDS);
            Xiuse.BLL.xiuse_user user = new BLL.xiuse_user();
            ResultMsg resultMsg;
            string staffId = "";
            //验证用户名密码
            staffId = user.AffirmUser(UserName, PassWord);
            //判断参数是否合法
            if (string.IsNullOrEmpty(staffId))
            {
                resultMsg = new ResultMsg();
                resultMsg.StatusCode = (int)StatusCodeEnum.Success;
                //resultMsg.Info = StatusCodeEnum.ParameterError.GetEnumText();
                resultMsg.Info = "1";
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
            resultMsg.Info = "0";
            resultMsg.Data = token;

            return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));
            //return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));
        }

        /// <summary>
        /// 获取秘钥
        /// </summary>
        /// <returns></returns>
        [Route("api/key")]
        [HttpGet]
        public HttpResponseMessage Key()
        {
            string key = String.Empty;
            if (HttpRuntime.Cache.Get("key") == null)
            {
                key = RandomHelper.GetRandomString(8, true, true, true, false, "");
                HttpRuntime.Cache.Insert("key", key, null, DateTime.Now.AddHours(1), TimeSpan.Zero);
                //SessionHelper.SetSession("key", key);
            }
            else
                key = HttpRuntime.Cache.Get("key").ToString();

            ResultMsg resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            //resultMsg.Info = StatusCodeEnum.ParameterError.GetEnumText();
            resultMsg.Info = "1";
            resultMsg.Data = key;
            return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));

          
        }
    }
}
