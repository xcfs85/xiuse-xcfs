using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_rebates] ʵ����
    /// </summary>
    public class xiuse_rebates
    {
        public xiuse_rebates(){}

        #region ��Ա����...
	private string _RebatesId;
	private string _MemberId;
	private string _MemberCardNo;
	private string _RebatesType;
	private decimal _RebatesAmount;
        private decimal _Balance;
    private DateTime _DateTime;
        #endregion

        #region ��Ա����...
        /// <summary>
        /// ���ֺ�������
        /// </summary>
        public decimal Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
	        /// <summary>
	        /// ���ּ�¼Id[RebatesId]
	        /// </summary>
	        public string RebatesId
	        {
	            get{ return _RebatesId; }
	            set{ _RebatesId=value; }
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
	        /// ��Ա����[MemberCardNo]
	        /// </summary>
	        public string MemberCardNo
	        {
	            get{ return _MemberCardNo; }
	            set{ _MemberCardNo=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��������[RebatesType]
	        /// </summary>
	        public string RebatesType
	        {
	            get{ return _RebatesType; }
	            set{ _RebatesType=value; }
	        }
		
	
	
	        /// <summary>
	        /// ���ֽ��[RebatesAmount]
	        /// </summary>
	        public decimal RebatesAmount
	        {
	            get{ return _RebatesAmount; }
	            set{ _RebatesAmount=value; }
	        }
		
	
	
	        /// <summary>
	        /// ����[DateTime]
	        /// </summary>
	        public DateTime DateTime
	        {
	            get{ return _DateTime; }
	            set{ _DateTime=value; }
	        }
		
        #endregion
    }
}
