using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_menus] 实体类
    /// </summary>
    public class xiuse_menus
    {
        public xiuse_menus(){}

        #region 成员变量...
	private string _MenuId;
	private string _RestaurantId;
	private string _ClassifyId;
	private string _MenuName;
	private int _MenuQuantity;
	private decimal _MenuPrice;
	private string _MenuShortcut;
	private string _MenuTag;
	private string _MenuImage;
	private int _MenuNo;
	private string _MenuInstruction;
	private Int16 _SaleState;
	private Int16 _MenuState;
	private DateTime _MenuTime;
        #endregion

        #region 成员属性...
	
	        /// <summary>
	        /// 品餐Id[MenuId]
	        /// </summary>
	        public string MenuId
	        {
	            get{ return _MenuId; }
	            set{ _MenuId=value; }
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
	        /// 菜品种类[ClassifyId]
	        /// </summary>
	        public string ClassifyId
	        {
	            get{ return _ClassifyId; }
	            set{ _ClassifyId=value; }
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
	        /// (当天)菜品剩余数量[MenuQuantity]
	        /// </summary>
	        public int MenuQuantity
	        {
	            get{ return _MenuQuantity; }
	            set{ _MenuQuantity=value; }
	        }
		
	
	
	        /// <summary>
	        /// 餐品价格[MenuPrice]
	        /// </summary>
	        public decimal MenuPrice
	        {
	            get{ return _MenuPrice; }
	            set{ _MenuPrice=value; }
	        }
		
	
	
	        /// <summary>
	        /// 快捷码[MenuShortcut]
	        /// </summary>
	        public string MenuShortcut
	        {
	            get{ return _MenuShortcut; }
	            set{ _MenuShortcut=value; }
	        }
		
	
	
	        /// <summary>
	        /// 菜品标签（正常,微微辣,微辣,辣,超辣,变态辣,多糖）[MenuTag]
	        /// </summary>
	        public string MenuTag
	        {
	            get{ return _MenuTag; }
	            set{ _MenuTag=value; }
	        }
		
	
	
	        /// <summary>
	        /// 餐品图片的路径[MenuImage]
	        /// </summary>
	        public string MenuImage
	        {
	            get{ return _MenuImage; }
	            set{ _MenuImage=value; }
	        }
		
	
	
	        /// <summary>
	        /// 菜品排序[MenuNo]
	        /// </summary>
	        public int MenuNo
	        {
	            get{ return _MenuNo; }
	            set{ _MenuNo=value; }
	        }
		
	
	
	        /// <summary>
	        /// 餐品介绍[MenuInstruction]
	        /// </summary>
	        public string MenuInstruction
	        {
	            get{ return _MenuInstruction; }
	            set{ _MenuInstruction=value; }
	        }
		
	
	
	        /// <summary>
	        /// 菜品销售状态（1限量销售，0不限量销售）[SaleState]
	        /// </summary>
	        public Int16 SaleState
	        {
	            get{ return _SaleState; }
	            set{ _SaleState=value; }
	        }
		
	
	
	        /// <summary>
	        /// 餐品状态（0，正常。1，停用。2，已删除。）[MenuState]
	        /// </summary>
	        public Int16 MenuState
	        {
	            get{ return _MenuState; }
	            set{ _MenuState=value; }
	        }
		
	
	
	        /// <summary>
	        /// 更新时间[MenuTime]
	        /// </summary>
	        public DateTime MenuTime
	        {
	            get{ return _MenuTime; }
	            set{ _MenuTime=value; }
	        }
		
        #endregion
    }
}
