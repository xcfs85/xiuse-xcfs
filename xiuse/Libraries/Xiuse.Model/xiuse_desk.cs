using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_desk] 实体类
    /// </summary>
    public class xiuse_desk
    {
        public xiuse_desk(){}

        #region 成员变量...
	private string _DeskId;
	private string _RestaurantId;
	private string _DeskName;
	private Int16 _TakeOut;
	private Int16 _DeskDel;
	private Int16 _DeskState;
	private DateTime _DeskTime;
     //   private float _AccountPayable;
        #endregion

        #region 成员属性...
	
	        /// <summary>
	        /// 餐桌主键ID[DeskId]
	        /// </summary>
	        public string DeskId
	        {
	            get{ return _DeskId; }
	            set{ _DeskId=value; }
	        }
		
	
	
	        /// <summary>
	        /// 餐厅ID[RestaurantId]
	        /// </summary>
	        public string RestaurantId
	        {
	            get{ return _RestaurantId; }
	            set{ _RestaurantId=value; }
	        }
		
	
	
	        /// <summary>
	        /// 餐桌名称[DeskName]
	        /// </summary>
	        public string DeskName
	        {
	            get{ return _DeskName; }
	            set{ _DeskName=value; }
	        }
		
	
	
	        /// <summary>
	        /// 是否接受外卖（0，不接受外卖。1接受外卖）[TakeOut]
	        /// </summary>
	        public Int16 TakeOut
	        {
	            get{ return _TakeOut; }
	            set{ _TakeOut=value; }
	        }
		
	
	
	        /// <summary>
	        /// 0,已删除。1正常[DeskDel]
	        /// </summary>
	        public Int16 DeskDel
	        {
	            get{ return _DeskDel; }
	            set{ _DeskDel=value; }
	        }
		
	
	
	        /// <summary>
	        /// 餐桌的状态：0，空桌；1，未支付；2，已支付；[DeskState]
	        /// </summary>
	        public Int16 DeskState
	        {
	            get{ return _DeskState; }
	            set{ _DeskState=value; }
	        }
		
	
	
	        /// <summary>
	        /// 更新时间[DeskTime]
	        /// </summary>
	        public DateTime DeskTime
	        {
	            get{ return _DeskTime; }
	            set{ _DeskTime=value; }
	        }

        //public float AccountPayable
        //{
        //    get
        //    {
        //        return _AccountPayable;
        //    }

        //    set
        //    {
        //        _AccountPayable = value;
        //    }
        //}

        #endregion
    }
}
