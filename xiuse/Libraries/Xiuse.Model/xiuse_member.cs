using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_member] 实体类
    /// </summary>
    public class xiuse_member
    {
        public xiuse_member(){}

        #region 成员变量...
	private string _MemberId;
	private string _MemberClassifyId;
	private string _MemberCardNo;
	private string _MemberName;
	private decimal _MemberAmount;
	private string _MemberCell;
	private string _MemberReference;
	private string _MemberPassword;
	private Int16 _MemberState;
	private string _MemberTime;
	private string _RestaurantId;
        #endregion

        #region 成员属性...
	
	        /// <summary>
	        /// 会员Id[MemberId]
	        /// </summary>
	        public string MemberId
	        {
	            get{ return _MemberId; }
	            set{ _MemberId=value; }
	        }
		
	
	
	        /// <summary>
	        /// 会员类型ID[MemberClassifyId]
	        /// </summary>
	        public string MemberClassifyId
	        {
	            get{ return _MemberClassifyId; }
	            set{ _MemberClassifyId=value; }
	        }
		
	
	
	        /// <summary>
	        /// 会员卡号[MemberCardNo]
	        /// </summary>
	        public string MemberCardNo
	        {
	            get{ return _MemberCardNo; }
	            set{ _MemberCardNo=value; }
	        }
		
	
	
	        /// <summary>
	        /// 会员名称[MemberName]
	        /// </summary>
	        public string MemberName
	        {
	            get{ return _MemberName; }
	            set{ _MemberName=value; }
	        }
		
	
	
	        /// <summary>
	        /// 卡内余额[MemberAmount]
	        /// </summary>
	        public decimal MemberAmount
	        {
	            get{ return _MemberAmount; }
	            set{ _MemberAmount=value; }
	        }
		
	
	
	        /// <summary>
	        /// 手机号[MemberCell]
	        /// </summary>
	        public string MemberCell
	        {
	            get{ return _MemberCell; }
	            set{ _MemberCell=value; }
	        }
		
	
	
	        /// <summary>
	        /// 推荐人[MemberReference]
	        /// </summary>
	        public string MemberReference
	        {
	            get{ return _MemberReference; }
	            set{ _MemberReference=value; }
	        }
		
	
	
	        /// <summary>
	        /// [MemberPassword]
	        /// </summary>
	        public string MemberPassword
	        {
	            get{ return _MemberPassword; }
	            set{ _MemberPassword=value; }
	        }
		
	
	
	        /// <summary>
	        /// 会员状态（0，禁用；1，启用；）[MemberState]
	        /// </summary>
	        public Int16 MemberState
	        {
	            get{ return _MemberState; }
	            set{ _MemberState=value; }
	        }
		
	
	
	        /// <summary>
	        /// 会员创建时间[MemberTime]
	        /// </summary>
	        public string MemberTime
	        {
	            get{ return _MemberTime; }
	            set{ _MemberTime=value; }
	        }
		
	
	
	        /// <summary>
	        /// [RestaurantId]
	        /// </summary>
	        public string RestaurantId
	        {
	            get{ return _RestaurantId; }
	            set{ _RestaurantId=value; }
	        }
		
        #endregion
    }
}
