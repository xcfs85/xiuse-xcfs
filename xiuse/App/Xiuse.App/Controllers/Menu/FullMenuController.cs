/*******************************************************************************
    获取当前餐厅有菜品分类和菜品信息分类接口类                                                       
             创建：zy       2016/12/25（要求分类和菜品的集合）
数据结构
{
MenuClassify（菜品分类）:[{....}]，
MenuItems （菜品集合）:[{.....},{.....},{.....}]
}
*******************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Xiuse.App.Controllers.Menu
{
    [RoutePrefix("api/Menu")]
    public class FullMenuController : ApiController
    {
        /// <summary>
        ///  获取当前餐厅有菜品分类和菜品信息分类接口类  
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        [Route("FullinRestaurant")]
        public List<Xiuse.Model.MenuAll> GetAllClassifies(string RestaurantId)
        {

            List < Xiuse.Model.MenuAll> mAllList = new List<Xiuse.Model.MenuAll>();
            BLL.xiuse_menuclassify MenuBLL = new BLL.xiuse_menuclassify();
            MenuInfoController mic = new MenuInfoController();
            List<Xiuse.Model.xiuse_menuclassify> mClassifyLst = new List<Model.xiuse_menuclassify>();
            mClassifyLst = MenuBLL.GetClassifies(RestaurantId);
            for (int i = 0; i < mClassifyLst.Count; i++)
            {
                Xiuse.Model.MenuAll mAll = new Xiuse.Model.MenuAll();
                mAll.MenuClassifies = mClassifyLst[i];
                mAll.LstMenuItems.AddRange(mic.GetAllMenus(RestaurantId, mAll.MenuClassifies.ClassifyId));
                mAllList.Add(mAll);
            }


            return mAllList;


        }
    }
}


