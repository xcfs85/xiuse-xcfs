using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_rebates] 实体类
    /// </summary>
    public class xiuse_rebates
    {
        public xiuse_rebates(){}

        #region 成员变量...
	private string _RebatesId;
	private string _MemberId;
	private string _MemberCardNo;
	private string _RebatesType;
	private decimal _RebatesAmount;
        private decimal _Balance;
    private DateTime _DateTime;
        #endregion

        #region 成员属性...
        /// <summary>
        /// 返现后可用余额
        /// </summary>
        public decimal Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
	        /// <summary>
	        /// 返现记录Id[RebatesId]
	        /// </summary>
	        public string RebatesId
	        {
	            get{ return _RebatesId; }
	            set{ _RebatesId=value; }
	        }
		
	
	
	        /// <summary>
	        /// 会员Id[MemberId]
	        /// </summary>
	        public string MemberId
	        {
	            get{ return _MemberId; }
	            set{ _MemberId=value; }
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
	        /// 返现类型[RebatesType]
	        /// </summary>
	        public string RebatesType
	        {
	            get{ return _RebatesType; }
	            set{ _RebatesType=value; }
	        }
		
	
	
	        /// <summary>
	        /// 返现金额[RebatesAmount]
	        /// </summary>
	        public decimal RebatesAmount
	        {
	            get{ return _RebatesAmount; }
	            set{ _RebatesAmount=value; }
	        }
		
	
	
	        /// <summary>
	        /// 日期[DateTime]
	        /// </summary>
	        public DateTime DateTime
	        {
	            get{ return _DateTime; }
	            set{ _DateTime=value; }
	        }
		
        #endregion
    }
}
