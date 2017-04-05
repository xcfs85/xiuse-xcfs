using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_recharge] ʵ����
    /// </summary>
    public class xiuse_recharge
    {
        public xiuse_recharge(){}

        #region ��Ա����...
	private string _RechargeId;
	private string _MemberId;
	private Int16 _RechargeType;
	private decimal _RechargeAmount;
	private decimal _Balance;
	private string _MemberCardNo;
	private DateTime _RechargeTime;
        #endregion

        #region ��Ա����...
	
	        /// <summary>
	        /// ��ֵ��¼Id[RechargeId]
	        /// </summary>
	        public string RechargeId
	        {
	            get{ return _RechargeId; }
	            set{ _RechargeId=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��Ա��Id[MemberId]
	        /// </summary>
	        public string MemberId
	        {
	            get{ return _MemberId; }
	            set{ _MemberId=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��ֵ����[RechargeType]
	        /// </summary>
	        public Int16 RechargeType
	        {
	            get{ return _RechargeType; }
	            set{ _RechargeType=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��ֵ���[RechargeAmount]
	        /// </summary>
	        public decimal RechargeAmount
	        {
	            get{ return _RechargeAmount; }
	            set{ _RechargeAmount=value; }
	        }
		
	
	
	        /// <summary>
	        /// �������[Balance]
	        /// </summary>
	        public decimal Balance
	        {
	            get{ return _Balance; }
	            set{ _Balance=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��Ա�Ŀ���[MemberCardNo]
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
		
        #endregion
    }
}
