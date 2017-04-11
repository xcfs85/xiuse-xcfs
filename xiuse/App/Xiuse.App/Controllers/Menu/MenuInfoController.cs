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
        [Route("AddMenu")]
        public HttpResponseMessage PostAddMenu([FromBody]Model.xiuse_menus model)
        {
            if (model == null|| MenuBLL.Exists(model.MenuId)==false)
            {
                throw new HttpRequestException();
            }
            model.MenuId = Guid.NewGuid().ToString("N");
            model.MenuTime = DateTime.Now;
            if (MenuBLL.Insert(model))
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
        public HttpResponseMessage PostUpdateMenu([FromBody]Model.xiuse_menus model)
        {
            if (model == null ||MenuBLL.Exists(model.MenuId)==false)
            {
                throw new HttpRequestException();
            }
            model.MenuTime = DateTime.Now;
            if (MenuBLL.Update(model))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }


        /// <summary>
        /// 删除菜品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DeleteMenu")]
        public HttpResponseMessage DeleteDelMenuClassify([FromBody]String id)
        {
            if (id == null|| MenuBLL.Exists(id)==false)
            {
                throw new HttpRequestException();
            }
            if (MenuBLL.Delete(id))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }

    }
}
