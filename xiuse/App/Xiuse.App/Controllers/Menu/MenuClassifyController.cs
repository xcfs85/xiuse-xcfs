/*******************************************************************************
             菜单分类接口类                                   
             本类主要实现对菜单种类各种操作的接口              
             创建：zy       2016/12/18    
//1、获取当前餐厅的所有菜品分类，条件餐厅ID。（数据库菜品分类的表新添加了字段RestaurantId，注意修改一下Model和基础类）
//2、添加菜品的分类。
//3、更新菜品分类。
//4、删除菜品分类。            
 * *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse;
using Xiuse.App.Base;
using Xiuse.App.Models;

namespace Xiuse.App.Controllers.Menu
{
    [RoutePrefix("api/Menu")]
    public class MenuClassifyController : BaseResultMsg
    {
        BLL.xiuse_menuclassify MenuBLL = new BLL.xiuse_menuclassify();
        Model.xiuse_menuclassify MenuModel = new Model.xiuse_menuclassify();
        /// <summary>
        ///   
        ///获取当前餐厅的所有菜品分类，条件餐厅ID
        ///
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        [Route("GetMenuClassifies")]
      
        public DataSet GetMenuClassifies(string RestaurantId)
        {
            if (RestaurantId == null)
            {
                throw new HttpRequestException();
            }
            return MenuBLL.GetMenuClassifies(RestaurantId);
        }
        /// <summary>
        /// 添加菜品的分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddMenuClassify")]
        public HttpResponseMessage PostAddMenuClassify(dynamic obj)
        {
            if (obj== null)
            {
                throw new HttpRequestException();
            }
            MenuModel.ClassifyId=Guid.NewGuid().ToString("N");
            MenuModel.ClassifyTime= DateTime.Now;
            MenuModel.ClassifyInstruction = Convert.ToString(obj.ClassifyInstruction);
            MenuModel.ClassifyNet = Convert.ToInt32(obj.ClassifyNet);
            MenuModel.ClassifyNo = Convert.ToInt32(obj.ClassifyNo);
            MenuModel.ClassifyTag = Convert.ToString(obj.ClassifyTag);
            MenuModel.RestaurantId = Convert.ToString(obj.RestaurantId);        
            if(MenuBLL.Insert(MenuModel))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
        /// <summary>
        /// 更新菜品分类
        /// todo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UpdateMenuClassify")]
        public HttpResponseMessage PostUpdateMenuClassify(dynamic obj)
        {
            MenuModel.ClassifyNo = Convert.ToInt32(obj.ClassifyNo);
            MenuModel.ClassifyId = Convert.ToString(obj.ClassifyId);
            MenuModel.ClassifyInstruction = Convert.ToString(obj.ClassifyInstruction);
            MenuModel.ClassifyTag = Convert.ToString(obj.ClassifyTag);
            MenuModel.ClassifyTime = DateTime.Now;

            MenuModel.RestaurantId = Convert.ToString(obj.RestaurantId);
            if (obj == null || MenuBLL.Exists(MenuModel.ClassifyId) == false)
            {
                throw new HttpRequestException();
            }     
            List<Xiuse.Model.xiuse_menuclassify> GetClassifies = MenuBLL.GetClassifies(MenuModel.RestaurantId,MenuModel.ClassifyId);
     
            GetClassifies.Insert(MenuModel.ClassifyNo-1, MenuModel);
            for (int i = 0; i < GetClassifies.Count; i++)
            {
                GetClassifies[i].ClassifyNo = i + 1;
            } 
            if (MenuBLL.UpdateList(GetClassifies,MenuModel))
            {         
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            } 
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }
        /// <summary>
        /// 删除菜品分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteMenuClassify")]
        public HttpResponseMessage PostDelMenuClassify(dynamic obj)
        {
            MenuModel.ClassifyId = Convert.ToString(obj.ClassifyId);
            MenuModel.RestaurantId = Convert.ToString(obj.RestaurantId);
            if (obj == null || MenuBLL.Exists(MenuModel.ClassifyId) == false)
            {
                throw new HttpRequestException();
            }
            List<Xiuse.Model.xiuse_menuclassify> GetClassifies = MenuBLL.GetClassifies(MenuModel.RestaurantId, MenuModel.ClassifyId);
            for (int i = 0; i < GetClassifies.Count; i++)
            {
                GetClassifies[i].ClassifyNo = i + 1;
            }
            if (MenuBLL.DeleteList(MenuModel.ClassifyId, GetClassifies))
                return base.ReturnData("1", "", StatusCodeEnum.Success);
            else
                return base.ReturnData("0", "", StatusCodeEnum.Error);
        }


    }


}

