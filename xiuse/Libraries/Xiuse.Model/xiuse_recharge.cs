using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_recharge] 实体类
    /// </summary>
    public class xiuse_recharge
    {
        public xiuse_recharge(){}

        #region 成员变量...
	private string _RechargeId;
	private string _MemberId;
	private int _RechargeType;
	private decimal _RechargeAmount;
	private decimal _Balance;
	private string _MemberCardNo;
	private DateTime _RechargeTime;
	private decimal _BeforeBalance;
        #endregion

        #region 成员属性...
	
	        /// <summary>
	        /// 充值记录Id[RechargeId]
	        /// </summary>
	        public string RechargeId
	        {
	            get{ return _RechargeId; }
	            set{ _RechargeId=value; }
	        }
		
	
	
	        /// <summary>
	        /// 会员的Id[MemberId]
	        /// </summary>
	        public string MemberId
	        {
	            get{ return _MemberId; }
	            set{ _MemberId=value; }
	        }
		
	
	
	        /// <summary>
	        /// 充值类型[RechargeType]
	        /// </summary>
	        public int RechargeType
	        {
	            get{ return _RechargeType; }
	            set{ _RechargeType=value; }
	        }
		
	
	
	        /// <summary>
	        /// 充值金额[RechargeAmount]
	        /// </summary>
	        public decimal RechargeAmount
	        {
	            get{ return _RechargeAmount; }
	            set{ _RechargeAmount=value; }
	        }
		
	
	
	        /// <summary>
	        /// 可用余额[Balance]
	        /// </summary>
	        public decimal Balance
	        {
	            get{ return _Balance; }
	            set{ _Balance=value; }
	        }
		
	
	
	        /// <summary>
	        /// 会员的卡号[MemberCardNo]
	        /// </summary>
	        public string MemberCardNo
	        {
	            get{ return _MemberCardNo; }
	            set{ _MemberCardNo=value; }
	        }
		
	
	
	        /// <summary>
	        /// [RechargeTime]
	        /// </summary>
	        public DateTime RechargeTime
	        {
	            get{ return _RechargeTime; }
	            set{ _RechargeTime=value; }
	        }
		
	
	
	        /// <summary>
	        /// 充值前的可用余额[BeforeBalance]
	        /// </summary>
	        public decimal BeforeBalance
	        {
	            get{ return _BeforeBalance; }
	            set{ _BeforeBalance=value; }
	        }
		
        #endregion
    }
}
