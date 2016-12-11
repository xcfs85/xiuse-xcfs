using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_discount] 实体类
    /// </summary>
    public class xiuse_discount
    {
        public xiuse_discount(){}

        #region 成员变量...
	private string _DiscountId;
	private string _RestaurantId;
	private string _DiscountName;
	private byte _DiscountType;
	private decimal _DiscountContent;
	private string _DiscountMenus;
	private byte _DiscountSection;
	private bool _DiscountState;
	private int _DiscountVerification;
	private string _DiscountTime;
        #endregion

        #region 成员属性...
	
	        /// <summary>
	        /// 折扣ID[DiscountId]
	        /// </summary>
	        public string DiscountId
	        {
	            get{ return _DiscountId; }
	            set{ _DiscountId=value; }
	        }
		
	
	
	        /// <summary>
	        /// [RestaurantId]
	        /// </summary>
	        public string RestaurantId
	        {
	            get{ return _RestaurantId; }
	            set{ _RestaurantId=value; }
	        }
		
	
	
	        /// <summary>
	        /// 折扣名称[DiscountName]
	        /// </summary>
	        public string DiscountName
	        {
	            get{ return _DiscountName; }
	            set{ _DiscountName=value; }
	        }
		
	
	
	        /// <summary>
	        /// 折扣类型(0:百分比 1：固定金额)[DiscountType]
	        /// </summary>
	        public byte DiscountType
	        {
	            get{ return _DiscountType; }
	            set{ _DiscountType=value; }
	        }
		
	
	
	        /// <summary>
	        /// 折扣金额[DiscountContent]
	        /// </summary>
	        public decimal DiscountContent
	        {
	            get{ return _DiscountContent; }
	            set{ _DiscountContent=value; }
	        }
		
	
	
	        /// <summary>
	        /// 折扣菜品(-1，全部餐品；（菜品ID,菜品ID,菜品ID,菜品ID,菜品ID）,部门折扣)[DiscountMenus]
	        /// </summary>
	        public string DiscountMenus
	        {
	            get{ return _DiscountMenus; }
	            set{ _DiscountMenus=value; }
	        }
		
	
	
	        /// <summary>
	        /// 0,整单折扣；1，单品折扣[DiscountSection]
	        /// </summary>
	        public byte DiscountSection
	        {
	            get{ return _DiscountSection; }
	            set{ _DiscountSection=value; }
	        }
		
	
	
	        /// <summary>
	        /// 1,启用；0，禁用[DiscountState]
	        /// </summary>
	        public bool DiscountState
	        {
	            get{ return _DiscountState; }
	            set{ _DiscountState=value; }
	        }
		
	
	
	        /// <summary>
	        /// 0,启用管理员验证；1,禁用管理员验证；[DiscountVerification]
	        /// </summary>
	        public int DiscountVerification
	        {
	            get{ return _DiscountVerification; }
	            set{ _DiscountVerification=value; }
	        }
		
	
	
	        /// <summary>
	        /// 更新时间[DiscountTime]
	        /// </summary>
	        public string DiscountTime
	        {
	            get{ return _DiscountTime; }
	            set{ _DiscountTime=value; }
	        }
		
        #endregion
    }
}
