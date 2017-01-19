using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_user] 实体类
    /// </summary>
    public class xiuse_user
    {
        public xiuse_user(){}

        #region 成员变量...
	private string _UserId;
	private string _RestaurantId;
	private string _UserName;
	private string _Weixin;
	private string _CellPhone;
	private string _Email;
	private string _Password;
	private Int16 _UserRole;
	private string _ParentUserId;
	private Int16 _OwnRestaurant;
	private string _Time;
        private Int16 _DelTag;
        #endregion

        #region 成员属性...
	
	        /// <summary>
	        /// Id编号[UserId]
	        /// </summary>
	        public string UserId
	        {
	            get{ return _UserId; }
	            set{ _UserId=value; }
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
	        /// 姓名[UserName]
	        /// </summary>
	        public string UserName
	        {
	            get{ return _UserName; }
	            set{ _UserName=value; }
	        }
		
	
	
	        /// <summary>
	        /// 微信号[Weixin]
	        /// </summary>
	        public string Weixin
	        {
	            get{ return _Weixin; }
	            set{ _Weixin=value; }
	        }
		
	
	
	        /// <summary>
	        /// 手机号[CellPhone]
	        /// </summary>
	        public string CellPhone
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
	        /// 密码[Password]
	        /// </summary>
	        public string Password
	        {
	            get{ return _Password; }
	            set{ _Password=value; }
	        }
		
	
	
	        /// <summary>
	        /// 0,是管理员；1，是员工。[UserRole]
	        /// </summary>
	        public short UserRole
	        {
	            get{ return _UserRole; }
	            set{ _UserRole=value; }
	        }
		
	
	
	        /// <summary>
	        /// 上级用户Id，顶级为空！[ParentUserId]
	        /// </summary>
	        public string ParentUserId
	        {
	            get{ return _ParentUserId; }
	            set{ _ParentUserId=value; }
	        }
		
	
	
	        /// <summary>
	        /// 餐厅所有权（0，无；1，所有；）[OwnRestaurant]
	        /// </summary>
	        public short OwnRestaurant
	        {
	            get{ return _OwnRestaurant; }
	            set{ _OwnRestaurant=value; }
	        }
		
	
	
	        /// <summary>
	        /// 修改时间[Time]
	        /// </summary>
	        public string Time
	        {
	            get{ return _Time; }
	            set{ _Time=value; }
	        }

        public short DelTag
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
