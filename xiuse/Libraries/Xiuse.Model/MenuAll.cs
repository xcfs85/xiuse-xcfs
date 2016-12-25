
/*******************************************************************************
    当前餐厅有菜品分类和菜品信息的类                                                     
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
using System.Text;
using System.Threading.Tasks;

namespace Xiuse.Model
{
    public class MenuAll
    {
        List<xiuse_menuclassify> _LstMenuClassifies;
        List<xiuse_menus> _LstMenuItems;
        public MenuAll()
        {
            _LstMenuClassifies = new List<xiuse_menuclassify>();
            _LstMenuItems = new List<xiuse_menus>();
        }

        public List<xiuse_menuclassify> LstMenuClassifies
        {
            get
            {
                return _LstMenuClassifies;
            }

            set
            {
                _LstMenuClassifies = value;
            }
        }

        public List<xiuse_menus> LstMenuItems
        {
            get
            {
                return _LstMenuItems;
            }

            set
            {
                _LstMenuItems = value;
            }
        }
    }
}
