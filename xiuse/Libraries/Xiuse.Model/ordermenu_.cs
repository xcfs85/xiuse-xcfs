using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [ordermenu_] ʵ����
    /// </summary>
    public class ordermenu_
    {
        public ordermenu_(){}

        #region ��Ա����...
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

        #region ��Ա����...
        /// <summary>
        ///��Ʒ����
        /// </summary>
        public int MenuNum
        {
            get { return _MenuNum; }
            set { _MenuNum = value; }
        }

	        /// <summary>
	        /// ����ID[OrderMenuId]
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
	        /// ��Ʒ����[MenuName]
	        /// </summary>
	        public string MenuName
	        {
	            get{ return _MenuName; }
	            set{ _MenuName=value; }
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
	        /// ��Ʒ��ǩ[MenuTag]
	        /// </summary>
	        public string MenuTag
	        {
	            get{ return _MenuTag; }
	            set{ _MenuTag=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��ƷͼƬ[MenuImage]
	        /// </summary>
	        public string MenuImage
	        {
	            get{ return _MenuImage; }
	            set{ _MenuImage=value; }
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
	        /// �Ƿ����ۿۣ�0,1��[DiscoutFlag]
	        /// </summary>
	        public Int16 DiscoutFlag
	        {
	            get{ return _DiscoutFlag; }
	            set{ _DiscoutFlag=value; }
	        }
		
	
	
	        /// <summary>
	        /// �ۿ�����[DiscountName]
	        /// </summary>
	        public string DiscountName
	        {
	            get{ return _DiscountName; }
	            set{ _DiscountName=value; }
	        }
		
	
	
	        /// <summary>
	        /// �ۿ۽��[DiscountContent]
	        /// </summary>
	        public decimal DiscountContent
	        {
	            get{ return _DiscountContent; }
	            set{ _DiscountContent=value; }
	        }
		
	
	
	        /// <summary>
	        /// �ۿ�����(0:�ٷֱ� 1���̶����)[DiscountType]
	        /// </summary>
	        public Int16 DiscountType
	        {
	            get{ return _DiscountType; }
	            set{ _DiscountType=value; }
	        }
		
	
	
	        /// <summary>
	        /// �Ƿ��ϲ�[MenuServing]
	        /// </summary>
	        public short MenuServing
	        {
	            get{ return _MenuServing; }
	            set{ _MenuServing=value; }
	        }
		/// <summary>
        /// ��Ʒ��Id
        /// </summary>
        public string MenuId
        {
            get { return _MenuId; }
            set { _MenuId = value; }
        }
        #endregion
    }
}
