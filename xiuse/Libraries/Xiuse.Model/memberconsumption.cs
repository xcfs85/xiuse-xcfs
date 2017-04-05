using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [memberconsumption] 实体类
    /// </summary>
    public class memberconsumption
    {
        public memberconsumption(){}

        #region 成员变量...
	private string _ConsumptionRecordsId;
	private string _MemberId;
	private string _MemberCardNo;
	private Int16 _CRecordsType;
	private decimal _Amount;
	private decimal _Balance;
	private DateTime _ConsumptionTime;
	private string _OrderId;
        #endregion

        #region 成员属性...
	
	        /// <summary>
	        /// [ConsumptionRecordsId]
	        /// </summary>
	        public string ConsumptionRecordsId
	        {
	            get{ return _ConsumptionRecordsId; }
	            set{ _ConsumptionRecordsId=value; }
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
	        /// 会员卡卡号[MemberCardNo]
	        /// </summary>
	        public string MemberCardNo
	        {
	            get{ return _MemberCardNo; }
	            set{ _MemberCardNo=value; }
	        }
		
	
	
	        /// <summary>
	        /// 消费类型[CRecordsType]
	        /// </summary>
	        public Int16 CRecordsType
	        {
	            get{ return _CRecordsType; }
	            set{ _CRecordsType=value; }
	        }
		
	
	
	        /// <summary>
	        /// 消费金额[Amount]
	        /// </summary>
	        public decimal Amount
	        {
	            get{ return _Amount; }
	            set{ _Amount=value; }
	        }
		
	
	
	        /// <summary>
	        /// 余额[Balance]
	        /// </summary>
	        public decimal Balance
	        {
	            get{ return _Balance; }
	            set{ _Balance=value; }
	        }
		
	
	
	        /// <summary>
	        /// 消费日期[ConsumptionTime]
	        /// </summary>
	        public DateTime ConsumptionTime
	        {
	            get{ return _ConsumptionTime; }
	            set{ _ConsumptionTime=value; }
	        }
		
	
	
	        /// <summary>
	        /// 订单Id[OrderId]
	        /// </summary>
	        public string OrderId
	        {
	            get{ return _OrderId; }
	            set{ _OrderId=value; }
	        }
		
        #endregion
    }
}
