﻿/*******************************************************************************
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


namespace Xiuse.App.Controllers.Menu
{
    [RoutePrefix("api/Menu")]
    public class MenuClassifyController : ApiController
    {
        BLL.xiuse_menuclassify MenuBLL = new BLL.xiuse_menuclassify();

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
            if (RestaurantId == null||MenuBLL.ExistsRestaurant(RestaurantId)==false)
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
        [Route("AddMenuClassify")]
        public HttpResponseMessage PostAddMenuClassify([FromBody]Model.xiuse_menuclassify model)
        {
            if (model == null|| MenuBLL.Exists(model.ClassifyId)==false)
            {
                throw new HttpRequestException();
            }
            if(MenuBLL.Insert(model))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
        /// <summary>
        /// 更新菜品分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UpdateMenuClassify")]
        public HttpResponseMessage PostUpdateMenuClassify([FromBody]Model.xiuse_menuclassify model)
        {
            if (model == null || MenuBLL.Exists(model.ClassifyId)==false)
            {
                throw new HttpRequestException();
            }
            if (MenuBLL.Update(model))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }
        /// <summary>
        /// 删除菜品分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DeleteMenuClassify")]
        public HttpResponseMessage DeleteDelMenuClassify([FromBody]String id)
        {
            if (id == null || MenuBLL.Exists(id)==false)
            {
                throw new HttpRequestException();
            }
            if(MenuBLL.Delete(id))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.Gone);
        }


    }


}

