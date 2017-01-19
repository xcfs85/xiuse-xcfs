using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_menus] ʵ����
    /// </summary>
    public class xiuse_menus
    {
        public xiuse_menus(){}

        #region ��Ա����...
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

        #region ��Ա����...
	
	        /// <summary>
	        /// Ʒ��Id[MenuId]
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
	        /// ��Ʒ����[ClassifyId]
	        /// </summary>
	        public string ClassifyId
	        {
	            get{ return _ClassifyId; }
	            set{ _ClassifyId=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��Ʒ����[MenuName]
	        /// </summary>
	        public string MenuName
	        {
	            get{ return _MenuName; }
	            set{ _MenuName=value; }
	        }
		
	
	
	        /// <summary>
	        /// (����)��Ʒʣ������[MenuQuantity]
	        /// </summary>
	        public int MenuQuantity
	        {
	            get{ return _MenuQuantity; }
	            set{ _MenuQuantity=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��Ʒ�۸�[MenuPrice]
	        /// </summary>
	        public decimal MenuPrice
	        {
	            get{ return _MenuPrice; }
	            set{ _MenuPrice=value; }
	        }
		
	
	
	        /// <summary>
	        /// �����[MenuShortcut]
	        /// </summary>
	        public string MenuShortcut
	        {
	            get{ return _MenuShortcut; }
	            set{ _MenuShortcut=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��Ʒ��ǩ������,΢΢��,΢��,��,����,��̬��,���ǣ�[MenuTag]
	        /// </summary>
	        public string MenuTag
	        {
	            get{ return _MenuTag; }
	            set{ _MenuTag=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��ƷͼƬ��·��[MenuImage]
	        /// </summary>
	        public string MenuImage
	        {
	            get{ return _MenuImage; }
	            set{ _MenuImage=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��Ʒ����[MenuNo]
	        /// </summary>
	        public int MenuNo
	        {
	            get{ return _MenuNo; }
	            set{ _MenuNo=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��Ʒ����[MenuInstruction]
	        /// </summary>
	        public string MenuInstruction
	        {
	            get{ return _MenuInstruction; }
	            set{ _MenuInstruction=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��Ʒ����״̬��1�������ۣ�0���������ۣ�[SaleState]
	        /// </summary>
	        public Int16 SaleState
	        {
	            get{ return _SaleState; }
	            set{ _SaleState=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��Ʒ״̬��0��������1��ͣ�á�2����ɾ������[MenuState]
	        /// </summary>
	        public Int16 MenuState
	        {
	            get{ return _MenuState; }
	            set{ _MenuState=value; }
	        }
		
	
	
	        /// <summary>
	        /// ����ʱ��[MenuTime]
	        /// </summary>
	        public DateTime MenuTime
	        {
	            get{ return _MenuTime; }
	            set{ _MenuTime=value; }
	        }
		
        #endregion
    }
}
