using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiuse.Model.ViewModel
{
    /// <summary>
    /// 当日营业额
    /// </summary>
    public class TurnOverView
    {
        /// <summary>
        /// 营业额a
        /// </summary>
        public decimal Account
        {
            get;
            set;
        }
        /// <summary>
        /// 时间小时
        /// </summary>
        public int Hour
        {
            get;
            set;
        }
        /// <summary>
        /// 菜品数量
        /// </summary>
        public decimal MenusCount
        {
            get;set;
        }
    }
    /// <summary>
    /// 热门菜品
    /// </summary>
    public class HotMenus
    {
        /// <summary>
        /// 菜品名称
        /// </summary>
        public string MenuName
        {
            get;
            set;
        }
        /// <summary>
        /// 菜品数量
        /// </summary>
        public decimal AllNum
        {
            get;
            set;
        }
    }
}
