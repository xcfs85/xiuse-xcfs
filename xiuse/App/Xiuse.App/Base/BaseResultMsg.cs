using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Xiuse.App.Common;
using Xiuse.App.Models;

namespace Xiuse.App.Base
{
    public class BaseResultMsg: ApiController
    {
        public ResultMsg resultMsg = new ResultMsg();
        public HttpResponseMessage ReturnData(string info,object data, StatusCodeEnum state)
        {
            resultMsg.Info = info;
            resultMsg.Data = data;
            resultMsg.StatusCode = (int)state;
            return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));
        }
    }
}