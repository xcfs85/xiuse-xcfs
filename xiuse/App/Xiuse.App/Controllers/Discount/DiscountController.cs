using DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Xiuse;
using Xiuse.App.Base;

namespace Xiuse.App.Controllers.Discount
{
    /// <summary>
    /// 折扣信息接口
    /// </summary>   

    [RoutePrefix("api/Dis")]
    public class DiscountController : BaseResultMsg
    {
        BLL.xiuse_discount BllDiscount = new BLL.xiuse_discount();
        Xiuse.BLL.xiuse_user user = new BLL.xiuse_user();
        BLL.xiuse_menus BllMenus = new BLL.xiuse_menus();
        /// <summary>
        /// 获取餐厅所有的折扣信息
        /// </summary>
        /// <param name="RestaurantId">餐厅的Id</param>
        /// <returns></returns>
        [Route("DiscountAt")]
        public  List<Model.ViewModel.XiuseDicountView> GetDiscountAt(string RestaurantId)
        {
            List<Model.ViewModel.XiuseDicountView> tmp = BllDiscount.GetModelsView(RestaurantId);
            foreach (Model.ViewModel.XiuseDicountView item in tmp)
            {
                if(item.DiscountSection == 1&&item.DiscountMenus != "-1")
                {
                    string tmpMenus = "MenuId in ('" + item.DiscountMenus.Replace(",", "','") + "')";
                    item.MenusDetail = BllMenus.DataSetTransModelListNoExpand(BllMenus.GetData("*", tmpMenus));
                   
                }
            }
            return tmp;
        }
        /// <summary>
        /// 获取整单折扣的信息(RestaurantId)
        /// </summary>
        /// <param name="RestaurantId">餐厅的Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("EntireDiscount")]
        public HttpResponseMessage EntireDiscount(string RestaurantId)
        {
            IList<Model.xiuse_discount> tmp = BllDiscount.GetEntireModels(RestaurantId);
            if(tmp  != null)
                return ReturnData("1", tmp, Models.StatusCodeEnum.Success);
            else
                return ReturnData("0", "", Models.StatusCodeEnum.Error);
        }
        /// <summary>
        /// 获取单品折扣的信息（参数：RestaurantId，MenuId）
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SingleDiscount")]
        public HttpResponseMessage SingleDiscount(string RestaurantId,string MenuId)
        {
            Model.xiuse_discount tmp = BllDiscount.GetSingleModels(RestaurantId, MenuId);
            if(tmp != null)
                return ReturnData("1", tmp, Models.StatusCodeEnum.Success);
            else
                return ReturnData("0", "", Models.StatusCodeEnum.Error);
        }
        /// <summary>
        /// 添加折扣信息
        /// </summary>
        /// <param name="Discount">折扣的对象</param>
        /// <returns></returns>
        [Route("AddDiscount")]
        public HttpResponseMessage PostAddDiscount(Model.xiuse_discount Discount)
        {
            if (Discount == null)
                return ReturnData("0", "参数不正确！", Models.StatusCodeEnum.ParameterError);
            Discount.DiscountTime = DateTime.Now;
            Discount.DiscountId = Guid.NewGuid().ToString("N");
            if (BllDiscount.Insert(Discount))
                return ReturnData("1", "添加成功！", Models.StatusCodeEnum.Success);
            else
                return ReturnData("0", "添加失败！", Models.StatusCodeEnum.Error);
        }
        /// <summary>
        /// 修改折扣信息
        /// </summary>
        /// <param name="Discount">折扣对象</param>
        /// <returns></returns>
        [Route("UpdateDiscount")]
        public HttpResponseMessage PostUpdateDiscount(Model.xiuse_discount Discount)
        {
            if (Discount == null)
                return ReturnData("0", "参数不正确！", Models.StatusCodeEnum.ParameterError);
            if (BllDiscount.Update(Discount))
                return ReturnData("1", "修改成功！", Models.StatusCodeEnum.Success);
            else
                return ReturnData("0", "修改失败！", Models.StatusCodeEnum.Error);
        }
        /// <summary>
        /// 设置折扣的状态（1,启用；0，禁用;2,删除；）
        /// </summary>
        /// <param name="DiscountId">折扣的ID</param>
        /// <param name="State">折扣的状态（1,启用；0，禁用;2,删除；）</param>
        /// <returns></returns>
        [Route("SetDiscountState")]
        public HttpResponseMessage GetSetDiscountState(string DiscountId,int State)
        {
            if (DiscountId == null)
                throw new HttpResponseException(HttpStatusCode.BadGateway);
            if (BllDiscount.SetDiscountState(DiscountId,State))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
        /// <summary>
        /// 获取管理员用户
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        [Route("MangeUser")]
        [HttpGet]
        public HttpResponseMessage MangeUser(string RestaurantId)
        {
            IList<Model.xiuse_user> tmp =  user.GetManager(RestaurantId);
            if(tmp != null)
                return ReturnData("1", tmp, Models.StatusCodeEnum.Success);
            else
                return ReturnData("0", "", Models.StatusCodeEnum.Success);

        }
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Route("TellDiscount")]
        [HttpPost]
        public HttpResponseMessage TellDiscount(dynamic obj)
        {
            if(obj.Name == null||obj.Psw == null)
                return ReturnData("0", "参数不正确！", Models.StatusCodeEnum.ParameterError);
            string key = HttpRuntime.Cache.Get("key").ToString();
            string UserName = DESEncrypt.DecryptJS(Convert.ToString(obj.Name), key);
            string PassWord = DESEncrypt.DecryptJS(Convert.ToString(obj.Psw), key);      
            //验证用户名密码
            string staffId = user.AffirmUser(UserName, PassWord, Convert.ToString(obj.RestaurantId));
            if (string.IsNullOrEmpty(staffId))
                return ReturnData("0", "验证失败！", Models.StatusCodeEnum.Success);
            else
                return ReturnData("1", "", Models.StatusCodeEnum.Success);
          
        }

    }
}
