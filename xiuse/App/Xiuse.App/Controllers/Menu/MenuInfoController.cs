/*******************************************************************************
             菜单接口类                                   
             本类主要实现对菜单menu各种操作的接口              
             创建：zy       2016/12/18    
//1、获取当前餐厅当前分类下的所有菜品信息（条件菜品分类ID）
//2、添加菜品信息。
//3、更新菜品信息。
//4、删除菜品信息。
 /******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse.App.Base;
using Xiuse.App.Models;

namespace Xiuse.App.Controllers.Menu
{
    [RoutePrefix("api/Menu")]
    public class MenuInfoController : BaseResultMsg
    {
        BLL.xiuse_menus MenuBLL = new BLL.xiuse_menus();
        Model.xiuse_menus MenuModel = new Model.xiuse_menus();
        /// <summary>
        /// 获取当前餐厅当前分类下的所有菜品信息（条件菜品分类ID）
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <param name="MenuClassifyId"></param>
        /// <returns></returns>
        [Route("GetAllMenus")]
        public List<Model.xiuse_menus> GetAllMenus(string RestaurantId,string MenuClassifyId)
        {
            if (RestaurantId == null || MenuClassifyId==null)
            {
                throw new HttpRequestException();
            }
            return MenuBLL.GetMenuInfo(RestaurantId,MenuClassifyId);
        }

        /// <summary>
        /// 添加菜品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddMenu")]
        public HttpResponseMessage PostAddMenu(dynamic obj)
        {
            MenuModel.SaleState = Convert.ToInt16(obj.SaleState);
            MenuModel.MenuName= Convert.ToString(obj.MenuName);
            MenuModel.ClassifyId = Convert.ToString(obj.ClassifyId);
            MenuModel.RestaurantId = Convert.ToString(obj.RestaurantId);
            MenuModel.MenuNo = Convert.ToInt32(obj.MenuNo);
            MenuModel.MenuPrice = Convert.ToDecimal(obj.MenuPrice);
            MenuModel.MenuTag = Convert.ToString(obj.MenuTag);
            MenuModel.MenuImage = Convert.ToString(obj.MenuImage);
            MenuModel.MenuId = Guid.NewGuid().ToString("N");
            MenuModel.MenuTime = DateTime.Now;
            MenuModel.MenuShortcut = Convert.ToString(obj.MenuShortcut);
            MenuModel.MenuInstruction = Convert.ToString(obj.MenuInstruction);
            if (MenuBLL.Insert(MenuModel))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }

        /// <summary>
        /// 更新菜品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UpdateMenu")]
        public HttpResponseMessage PostUpdateMenu(dynamic obj)
        {
            MenuModel.MenuId = Convert.ToString(obj.MenuId);
            MenuModel.MenuNo = Convert.ToInt32(obj.MenuNo);
            MenuModel.ClassifyId = Convert.ToString(obj.ClassifyId);
            MenuModel.MenuTime = DateTime.Now;
            MenuModel.RestaurantId = Convert.ToString(obj.RestaurantId);
            MenuModel.MenuImage = Convert.ToString(obj.MenuImage);
            MenuModel.MenuInstruction = Convert.ToString(obj.MenuInstruction);
            MenuModel.MenuTag = Convert.ToString(obj.MenuTag);
            MenuModel.MenuTime = DateTime.Now;
            MenuModel.MenuState = Convert.ToInt16(obj.MenuState);
            MenuModel.SaleState = Convert.ToInt16(obj.SaleState);
            MenuModel.MenuQuantity = Convert.ToInt32(obj.MenuQuantity);
            MenuModel.MenuPrice = Convert.ToInt32(obj.MenuPrice);
            MenuModel.MenuName = Convert.ToString(obj.MenuName);
            MenuModel.MenuShortcut = Convert.ToString(obj.MenuShortcut);
            if (obj == null || MenuBLL.Exists(MenuModel.MenuId) == false)
            {
                return base.ReturnData("0", "菜品不存在！", StatusCodeEnum.Error);
            }
            List<Model.xiuse_menus> GetMenuLst = MenuBLL.GetAllMenusWithoutUpdate(MenuModel.RestaurantId, MenuModel.ClassifyId, MenuModel.MenuId);
            if (MenuModel.MenuNo > GetMenuLst.Count)
                MenuModel.MenuNo = GetMenuLst.Count+1;
            GetMenuLst.Insert(MenuModel.MenuNo - 1, MenuModel);
            for (int i = 0; i < GetMenuLst.Count; i++)
            {
                GetMenuLst[i].MenuNo = i + 1;
            }
            if (MenuBLL.UpdateList(GetMenuLst,MenuModel))
            {
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            }
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }


        /// <summary>
        /// 删除菜品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DeleteMenu")]
        public HttpResponseMessage PostDelMenu(dynamic obj)
        {
            MenuModel.MenuId = Convert.ToString(obj.MenuId);
            MenuModel.ClassifyId = Convert.ToString(obj.ClassifyId);
            MenuModel.MenuNo = Convert.ToInt32(obj.MenuNo);
            MenuModel.RestaurantId = Convert.ToString(obj.RestaurantId);
            if (obj == null || MenuBLL.Exists(MenuModel.MenuId) == false)
            {
                return base.ReturnData("0", "菜品不存在！", StatusCodeEnum.Error);
            }
            List<Xiuse.Model.xiuse_menus> GetMenuLst = MenuBLL.GetAllMenusWithoutUpdate(MenuModel.RestaurantId, MenuModel.ClassifyId, MenuModel.MenuId);
            for (int i = 0; i < GetMenuLst.Count; i++)
            {
                GetMenuLst[i].MenuNo = i + 1;
            }
            if (MenuBLL.DeleteList(MenuModel.MenuId, GetMenuLst))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }

    }
}
