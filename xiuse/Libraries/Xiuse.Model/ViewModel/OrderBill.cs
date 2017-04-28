
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiuse.Model.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderBill
    {
        private order_ _order;
        private List<ordermenu_dicount> _ordermenu;

        public OrderBill()
        {
            _order = new order_();
            _ordermenu = new List<ordermenu_dicount>();
        }
        /// <summary>
        /// 订单
        /// </summary>
        public order_ Order
        {
            get { return _order; }
            set { _order = value; }
        }
        /// <summary>
        /// 所有的菜品
        /// </summary>
        public List<ordermenu_dicount> Ordermenu
        {
            get { return _ordermenu; }
            set { _ordermenu = value; }
        }
    }
}
