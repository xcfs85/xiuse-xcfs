using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_restaurant] 实体类
    /// </summary>
    public class xiuse_restaurant
    {
        public xiuse_restaurant(){}

        #region 成员变量...
	private string _RestaurantId;
	private string _RestaurantName;
	private string _Phone;
	private string _Site;
	private string _Remark;
	private DateTime _Time;
        #endregion

        #region 成员属性...
	
	        /// <summary>
	        /// 餐厅的Id[RestaurantId]
	        /// </summary>
	        public string RestaurantId
	        {
	            get{ return _RestaurantId; }
	            set{ _RestaurantId=value; }
	        }
		
	
	
	        /// <summary>
	        /// 餐厅名称[RestaurantName]
	        /// </summary>
	        public string RestaurantName
	        {
	            get{ return _RestaurantName; }
	            set{ _RestaurantName=value; }
	        }
		
	
	
	        /// <summary>
	        /// 餐厅的电话[Phone]
	        /// </summary>
	        public string Phone
	        {
	            get{ return _Phone; }
	            set{ _Phone=value; }
	        }
		
	
	
	        /// <summary>
	        /// 餐厅的地址[Site]
	        /// </summary>
	        public string Site
	        {
	            get{ return _Site; }
	            set{ _Site=value; }
	        }
		
	
	
	        /// <summary>
	        /// 餐厅的说明[Remark]
	        /// </summary>
	        public string Remark
	        {
	            get{ return _Remark; }
	            set{ _Remark=value; }
	        }
		
	
	
	        /// <summary>
	        /// 更新时间[Time]
	        /// </summary>
	        public DateTime Time
	        {
	            get{ return _Time; }
	            set{ _Time=value; }
	        }
		
        #endregion
    }
}
