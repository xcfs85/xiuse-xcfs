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
using Xiuse;

namespace Xiuse.App.Controllers.Menu
{
    [RoutePrefix("api/Menu")]
    public class MenuInfoController : ApiController
    {
        BLL.xiuse_menus MenuBLL = new BLL.xiuse_menus();
        [Route("GetAllMenus")]
        public List<Model.xiuse_menus> GetAllMenus(string ResaurantId,string MenuClassifyId)
        {
            if (ResaurantId == null || MenuClassifyId==null)
            {
                throw new HttpRequestException();
            }
            return MenuBLL.GetMenuInfo(ResaurantId,MenuClassifyId);
        }

        [Route("AddMenu")]
        public HttpResponseMessage PostAddMenu([FromBody]Model.xiuse_menus model)
        {
            if (model == null|| MenuBLL.Exists(model.MenuId)==false)
            {
                throw new HttpRequestException();
            }
            if (MenuBLL.Insert(model))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }

        [Route("UpdateMenu")]
        public HttpResponseMessage PostUpdateMenu([FromBody]Model.xiuse_menus model)
        {
            if (model == null ||MenuBLL.Exists(model.MenuId)==false)
            {
                throw new HttpRequestException();
            }
            if (MenuBLL.Update(model))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }

        [Route("DeleteMenu")]
        public HttpResponseMessage DeleteDelMenuClassify([FromBody]String id)
        {
            if (id == null|| MenuBLL.Exists(id)==false)
            {
                throw new HttpRequestException();
            }
            if (MenuBLL.Delete(id))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }

    }
}
