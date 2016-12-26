﻿/*
*作者：xcf
*整合Bill详细信息类
*时间：2016/12/19
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiuse.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderBill
    {
        private order_ _order;
        private List<ordermenu_> _ordermenu;

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
        public List<ordermenu_> Ordermenu
        {
            get { return _ordermenu; }
            set { _ordermenu = value; }
        }
    }
}