using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiuse;

namespace Xiuse.Model
{
    public class Revenue
    {
        private int _DailyNum;
        private double _DailyMoney;
        private List<xiuse_menus> _XiuMenus;

        public int DailyNum
        {
            get
            {
                return _DailyNum;
            }

            set
            {
                _DailyNum = value;
            }
        }

        public double DailyMoney
        {
            get
            {
                return _DailyMoney;
            }

            set
            {
                _DailyMoney = value;
            }
        }

        public List<xiuse_menus> XiuMenus
        {
            get
            {
                return _XiuMenus;
            }

            set
            {
                _XiuMenus = value;
            }
        }
    }
}
