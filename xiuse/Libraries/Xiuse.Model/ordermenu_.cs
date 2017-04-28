using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [ordermenu_] 实体类
    /// </summary>
    public class ordermenu_
    {
        public ordermenu_(){}

        #region 成员变量...
	private string _OrderMenuId;
	private string _OrderId;
	private string _MenuName;
        private int _MenuNum;
	private decimal _MenuPrice;
	private string _MenuTag;
	private string _MenuImage;
	private string _MenuInstruction;
	private Int16 _DiscoutFlag;
	private string _DiscountName;
	private decimal _DiscountContent;
	private Int16 _DiscountType;
	private short _MenuServing;
    private string _MenuId;
        #endregion

        #region 成员属性...
        /// <summary>
        ///菜品数量
        /// </summary>
        public int MenuNum
        {
            get { return _MenuNum; }
            set { _MenuNum = value; }
        }

	        /// <summary>
	        /// 订单ID[OrderMenuId]
	        /// </summary>
	        public string OrderMenuId
	        {
	            get{ return _OrderMenuId; }
	            set{ _OrderMenuId=value; }
	        }
		
	
	
	        /// <summary>
	        /// [OrderId]
	        /// </summary>
	        public string OrderId
	        {
	            get{ return _OrderId; }
	            set{ _OrderId=value; }
	        }
		
	
	
	        /// <summary>
	        /// 餐品名称[MenuName]
	        /// </summary>
	        public string MenuName
	        {
	            get{ return _MenuName; }
	            set{ _MenuName=value; }
	        }
		
	
	
	        /// <summary>
	        /// 菜品价格[MenuPrice]
	        /// </summary>
	        public decimal MenuPrice
	        {
	            get{ return _MenuPrice; }
	            set{ _MenuPrice=value; }
	        }
		
	
	
	        /// <summary>
	        /// 菜品标签[MenuTag]
	        /// </summary>
	        public string MenuTag
	        {
	            get{ return _MenuTag; }
	            set{ _MenuTag=value; }
	        }
		
	
	
	        /// <summary>
	        /// 菜品图片[MenuImage]
	        /// </summary>
	        public string MenuImage
	        {
	            get{ return _MenuImage; }
	            set{ _MenuImage=value; }
	        }
		
	
	
	        /// <summary>
	        /// 菜品介绍[MenuInstruction]
	        /// </summary>
	        public string MenuInstruction
	        {
	            get{ return _MenuInstruction; }
	            set{ _MenuInstruction=value; }
	        }
		
	
	
	        /// <summary>
	        /// 是否有折扣（0,1）[DiscoutFlag]
	        /// </summary>
	        public Int16 DiscoutFlag
	        {
	            get{ return _DiscoutFlag; }
	            set{ _DiscoutFlag=value; }
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
	        /// 折扣金额[DiscountContent]
	        /// </summary>
	        public decimal DiscountContent
	        {
	            get{ return _DiscountContent; }
	            set{ _DiscountContent=value; }
	        }
		
	
	
	        /// <summary>
	        /// 折扣类型(0:百分比 1：固定金额)[DiscountType]
	        /// </summary>
	        public Int16 DiscountType
	        {
	            get{ return _DiscountType; }
	            set{ _DiscountType=value; }
	        }
		
	
	
	        /// <summary>
	        /// 是否上菜[MenuServing]
	        /// </summary>
	        public short MenuServing
	        {
	            get{ return _MenuServing; }
	            set{ _MenuServing=value; }
	        }
		/// <summary>
        /// 菜品的Id
        /// </summary>
        public string MenuId
        {
            get { return _MenuId; }
            set { _MenuId = value; }
        }
        #endregion
    }
}
