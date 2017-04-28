using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiuse.Model.ViewModel
{
    public class ordermenu_dicount :Model.ordermenu_
    {
        /// <summary>
        /// 菜品拥有的折扣
        /// </summary>
        public Model.xiuse_discount MenuDiscount
        {
            get;set;
        }
        /// <summary>
        /// 折扣是否激活
        /// </summary>
        public Boolean DisState
        {
            get;set;
        }
    }
}
