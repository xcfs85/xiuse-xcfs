
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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xiuse.Model;

namespace Xiuse.App.Controllers.Menu
{
 [RoutePrefix("api/Menu")]
    public class MenuAll : ApiController
    {
        [Route("GetAllClassifies")]
        public Xiuse.Model.MenuAll GetAllMenuClassify(string RestaurantId)
        {

            Xiuse.Model.MenuAll ma = new Xiuse.Model.MenuAll();
            MenuClassifyController mcc = new MenuClassifyController();
            ma.LstMenuClassifies = mcc.GetMenuClassifies(RestaurantId);
            MenuInfoController mic = new MenuInfoController();
            foreach (xiuse_menuclassify mc in ma.LstMenuClassifies)
            {
                ma.LstMenuItems.AddRange(mic.GetAllMenus(RestaurantId, mc.ClassifyId));
            }
            return ma;
              
          
        }
    }
}
