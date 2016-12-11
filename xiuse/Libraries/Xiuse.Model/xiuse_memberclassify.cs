using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_memberclassify] ʵ����
    /// </summary>
    public class xiuse_memberclassify
    {
        public xiuse_memberclassify(){}

        #region ��Ա����...
	private string _MemberClassifyId;
	private string _DiscountId;
	private string _ClassifyName;
	private string _ClassRemark;
	private int _ClassifyMemberNum;
	private string _ClassifyTime;
	private byte _DelTag;
        #endregion

        #region ��Ա����...
	
	        /// <summary>
	        /// ��Ա����[MemberClassifyId]
	        /// </summary>
	        public string MemberClassifyId
	        {
	            get{ return _MemberClassifyId; }
	            set{ _MemberClassifyId=value; }
	        }
		
	
	
	        /// <summary>
	        /// �ۿ�ID[DiscountId]
	        /// </summary>
	        public string DiscountId
	        {
	            get{ return _DiscountId; }
	            set{ _DiscountId=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��������[ClassifyName]
	        /// </summary>
	        public string ClassifyName
	        {
	            get{ return _ClassifyName; }
	            set{ _ClassifyName=value; }
	        }
		
	
	
	        /// <summary>
	        /// ˵��[ClassRemark]
	        /// </summary>
	        public string ClassRemark
	        {
	            get{ return _ClassRemark; }
	            set{ _ClassRemark=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��Ա����[ClassifyMemberNum]
	        /// </summary>
	        public int ClassifyMemberNum
	        {
	            get{ return _ClassifyMemberNum; }
	            set{ _ClassifyMemberNum=value; }
	        }
		
	
	
	        /// <summary>
	        /// �޸�ʱ��[ClassifyTime]
	        /// </summary>
	        public string ClassifyTime
	        {
	            get{ return _ClassifyTime; }
	            set{ _ClassifyTime=value; }
	        }
		
	
	
	        /// <summary>
	        /// ɾ����־��(0,���ã�1��ͣ�ã�2��ɾ����)[DelTag]
	        /// </summary>
	        public byte DelTag
	        {
	            get{ return _DelTag; }
	            set{ _DelTag=value; }
	        }
		
        #endregion
    }
}
