using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [memberconsumption] ʵ����
    /// </summary>
    public class memberconsumption
    {
        public memberconsumption(){}

        #region ��Ա����...
	private string _ConsumptionRecordsId;
	private string _MemberId;
	private string _MemberCardNo;
	private Int16 _CRecordsType;
	private decimal _Amount;
	private decimal _Balance;
	private DateTime _ConsumptionTime;
	private string _OrderId;
        #endregion

        #region ��Ա����...
	
	        /// <summary>
	        /// [ConsumptionRecordsId]
	        /// </summary>
	        public string ConsumptionRecordsId
	        {
	            get{ return _ConsumptionRecordsId; }
	            set{ _ConsumptionRecordsId=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��ԱId[MemberId]
	        /// </summary>
	        public string MemberId
	        {
	            get{ return _MemberId; }
	            set{ _MemberId=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��Ա������[MemberCardNo]
	        /// </summary>
	        public string MemberCardNo
	        {
	            get{ return _MemberCardNo; }
	            set{ _MemberCardNo=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��������[CRecordsType]
	        /// </summary>
	        public Int16 CRecordsType
	        {
	            get{ return _CRecordsType; }
	            set{ _CRecordsType=value; }
	        }
		
	
	
	        /// <summary>
	        /// ���ѽ��[Amount]
	        /// </summary>
	        public decimal Amount
	        {
	            get{ return _Amount; }
	            set{ _Amount=value; }
	        }
		
	
	
	        /// <summary>
	        /// ���[Balance]
	        /// </summary>
	        public decimal Balance
	        {
	            get{ return _Balance; }
	            set{ _Balance=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��������[ConsumptionTime]
	        /// </summary>
	        public DateTime ConsumptionTime
	        {
	            get{ return _ConsumptionTime; }
	            set{ _ConsumptionTime=value; }
	        }
		
	
	
	        /// <summary>
	        /// ����Id[OrderId]
	        /// </summary>
	        public string OrderId
	        {
	            get{ return _OrderId; }
	            set{ _OrderId=value; }
	        }
		
        #endregion
    }
}
