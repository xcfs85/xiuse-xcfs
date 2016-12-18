using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_user] ʵ����
    /// </summary>
    public class xiuse_user
    {
        public xiuse_user(){}

        #region ��Ա����...
	private string _UserId;
	private string _RestaurantId;
	private string _UserName;
	private string _Weixin;
	private decimal _CellPhone;
	private string _Email;
	private string _Password;
	private int _UserRole;
	private string _ParentUserId;
	private int _OwnRestaurant;
	private string _Time;
        private int _DelTag;
        #endregion

        #region ��Ա����...
	
	        /// <summary>
	        /// Id���[UserId]
	        /// </summary>
	        public string UserId
	        {
	            get{ return _UserId; }
	            set{ _UserId=value; }
	        }
		
	
	
	        /// <summary>
	        /// ����ID[RestaurantId]
	        /// </summary>
	        public string RestaurantId
	        {
	            get{ return _RestaurantId; }
	            set{ _RestaurantId=value; }
	        }
		
	
	
	        /// <summary>
	        /// ����[UserName]
	        /// </summary>
	        public string UserName
	        {
	            get{ return _UserName; }
	            set{ _UserName=value; }
	        }
		
	
	
	        /// <summary>
	        /// ΢�ź�[Weixin]
	        /// </summary>
	        public string Weixin
	        {
	            get{ return _Weixin; }
	            set{ _Weixin=value; }
	        }
		
	
	
	        /// <summary>
	        /// �ֻ���[CellPhone]
	        /// </summary>
	        public decimal CellPhone
	        {
	            get{ return _CellPhone; }
	            set{ _CellPhone=value; }
	        }
		
	
	
	        /// <summary>
	        /// Email[Email]
	        /// </summary>
	        public string Email
	        {
	            get{ return _Email; }
	            set{ _Email=value; }
	        }
		
	
	
	        /// <summary>
	        /// ����[Password]
	        /// </summary>
	        public string Password
	        {
	            get{ return _Password; }
	            set{ _Password=value; }
	        }
		
	
	
	        /// <summary>
	        /// 0,�ǹ���Ա��1����Ա����[UserRole]
	        /// </summary>
	        public int UserRole
	        {
	            get{ return _UserRole; }
	            set{ _UserRole=value; }
	        }
		
	
	
	        /// <summary>
	        /// �ϼ��û�Id������Ϊ�գ�[ParentUserId]
	        /// </summary>
	        public string ParentUserId
	        {
	            get{ return _ParentUserId; }
	            set{ _ParentUserId=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��������Ȩ��0���ޣ�1�����У���[OwnRestaurant]
	        /// </summary>
	        public int OwnRestaurant
	        {
	            get{ return _OwnRestaurant; }
	            set{ _OwnRestaurant=value; }
	        }
		
	
	
	        /// <summary>
	        /// �޸�ʱ��[Time]
	        /// </summary>
	        public string Time
	        {
	            get{ return _Time; }
	            set{ _Time=value; }
	        }

        public int DelTag
        {
            get
            {
                return _DelTag;
            }

            set
            {
                _DelTag = value;
            }
        }

        #endregion
    }
}
