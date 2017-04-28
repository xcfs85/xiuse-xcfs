using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Xiuse.Model;

namespace Xiuse.App.App_Start
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =false)]
    public class WebApiTrackerAttribute:ActionFilterAttribute
    {
        private readonly string Key = "This is Webapi on Action Monitor Log!";
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            SysLog Log = new SysLog();
            Log.LogTime = DateTime.Now;
            //获取action参数
            
        }
    }
    
}