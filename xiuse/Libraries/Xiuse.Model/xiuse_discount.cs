using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_discount] ʵ����
    /// </summary>
    public class xiuse_discount
    {
        public xiuse_discount(){}

        #region ��Ա����...
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

        #region ��Ա����...
	
	        /// <summary>
	        /// �ۿ�ID[DiscountId]
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
	        /// �ۿ�����[DiscountName]
	        /// </summary>
	        public string DiscountName
	        {
	            get{ return _DiscountName; }
	            set{ _DiscountName=value; }
	        }
		
	
	
	        /// <summary>
	        /// �ۿ�����(0:�ٷֱ� 1���̶����)[DiscountType]
	        /// </summary>
	        public byte DiscountType
	        {
	            get{ return _DiscountType; }
	            set{ _DiscountType=value; }
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
	        /// �ۿ۲�Ʒ(-1��ȫ����Ʒ������ƷID,��ƷID,��ƷID,��ƷID,��ƷID��,�����ۿ�)[DiscountMenus]
	        /// </summary>
	        public string DiscountMenus
	        {
	            get{ return _DiscountMenus; }
	            set{ _DiscountMenus=value; }
	        }
		
	
	
	        /// <summary>
	        /// 0,�����ۿۣ�1����Ʒ�ۿ�[DiscountSection]
	        /// </summary>
	        public byte DiscountSection
	        {
	            get{ return _DiscountSection; }
	            set{ _DiscountSection=value; }
	        }
		
	
	
	        /// <summary>
	        /// 1,���ã�0������[DiscountState]
	        /// </summary>
	        public bool DiscountState
	        {
	            get{ return _DiscountState; }
	            set{ _DiscountState=value; }
	        }
		
	
	
	        /// <summary>
	        /// 0,���ù���Ա��֤��1,���ù���Ա��֤��[DiscountVerification]
	        /// </summary>
	        public int DiscountVerification
	        {
	            get{ return _DiscountVerification; }
	            set{ _DiscountVerification=value; }
	        }
		
	
	
	        /// <summary>
	        /// ����ʱ��[DiscountTime]
	        /// </summary>
	        public string DiscountTime
	        {
	            get{ return _DiscountTime; }
	            set{ _DiscountTime=value; }
	        }
		
        #endregion
    }
}
