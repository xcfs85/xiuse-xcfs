using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_member] ʵ����
    /// </summary>
    public class xiuse_member
    {
        public xiuse_member(){}

        #region ��Ա����...
	private string _MemberId;
	private string _MemberClassifyId;
	private string _MemberCardNo;
	private string _MemberName;
	private decimal _MemberAmount;
	private string _MemberCell;
	private string _MemberReference;
	private string _MemberPassword;
	private int _MemberState;
	private DateTime _MemberTime;
	private string _RestaurantId;
	private string _MemberEmail;
	private int _MemberEnabledPassWord;
        #endregion

        #region ��Ա����...
	
	        /// <summary>
	        /// ��ԱId[MemberId]
	        /// </summary>
	        public string MemberId
	        {
	            get{ return _MemberId; }
	            set{ _MemberId=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��Ա����ID[MemberClassifyId]
	        /// </summary>
	        public string MemberClassifyId
	        {
	            get{ return _MemberClassifyId; }
	            set{ _MemberClassifyId=value; }
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
	        /// ��Ա����[MemberName]
	        /// </summary>
	        public string MemberName
	        {
	            get{ return _MemberName; }
	            set{ _MemberName=value; }
	        }
		
	
	
	        /// <summary>
	        /// �������[MemberAmount]
	        /// </summary>
	        public decimal MemberAmount
	        {
	            get{ return _MemberAmount; }
	            set{ _MemberAmount=value; }
	        }
		
	
	
	        /// <summary>
	        /// �ֻ���[MemberCell]
	        /// </summary>
	        public string MemberCell
	        {
	            get{ return _MemberCell; }
	            set{ _MemberCell=value; }
	        }
		
	
	
	        /// <summary>
	        /// �Ƽ���[MemberReference]
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
	        /// ��Ա״̬��0�����ã�1�����ã���[MemberState]
	        /// </summary>
	        public int MemberState
	        {
	            get{ return _MemberState; }
	            set{ _MemberState=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��Ա����ʱ��[MemberTime]
	        /// </summary>
	        public DateTime MemberTime
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
		
	
	
	        /// <summary>
	        /// ��Ա��Email[MemberEmail]
	        /// </summary>
	        public string MemberEmail
	        {
	            get{ return _MemberEmail; }
	            set{ _MemberEmail=value; }
	        }
		
	
	
	        /// <summary>
	        /// �Ƿ��������롣��0�������ã�1���������룩[MemberEnabledPassWord]
	        /// </summary>
	        public int MemberEnabledPassWord
	        {
	            get{ return _MemberEnabledPassWord; }
	            set{ _MemberEnabledPassWord=value; }
	        }
		
        #endregion
    }
}
