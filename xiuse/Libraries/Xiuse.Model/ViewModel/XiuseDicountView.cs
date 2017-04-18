using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiuse.Model.ViewModel
{
    public class XiuseDicountView:Xiuse.Model.xiuse_discount
    {
        /// <summary>
        /// 菜品详细信息
        /// </summary>
        private List<Xiuse.Model.xiuse_menus> _MenusDetail = new List<xiuse_menus>();
        public List<Xiuse.Model.xiuse_menus> MenusDetail
        {
            get { return _MenusDetail; }
            set { _MenusDetail = value; }
        }
    }
}
