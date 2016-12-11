using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_memberclassify] 实体类
    /// </summary>
    public class xiuse_memberclassify
    {
        public xiuse_memberclassify(){}

        #region 成员变量...
	private string _MemberClassifyId;
	private string _DiscountId;
	private string _ClassifyName;
	private string _ClassRemark;
	private int _ClassifyMemberNum;
	private string _ClassifyTime;
	private byte _DelTag;
        #endregion

        #region 成员属性...
	
	        /// <summary>
	        /// 会员类型[MemberClassifyId]
	        /// </summary>
	        public string MemberClassifyId
	        {
	            get{ return _MemberClassifyId; }
	            set{ _MemberClassifyId=value; }
	        }
		
	
	
	        /// <summary>
	        /// 折扣ID[DiscountId]
	        /// </summary>
	        public string DiscountId
	        {
	            get{ return _DiscountId; }
	            set{ _DiscountId=value; }
	        }
		
	
	
	        /// <summary>
	        /// 类型名称[ClassifyName]
	        /// </summary>
	        public string ClassifyName
	        {
	            get{ return _ClassifyName; }
	            set{ _ClassifyName=value; }
	        }
		
	
	
	        /// <summary>
	        /// 说明[ClassRemark]
	        /// </summary>
	        public string ClassRemark
	        {
	            get{ return _ClassRemark; }
	            set{ _ClassRemark=value; }
	        }
		
	
	
	        /// <summary>
	        /// 会员数量[ClassifyMemberNum]
	        /// </summary>
	        public int ClassifyMemberNum
	        {
	            get{ return _ClassifyMemberNum; }
	            set{ _ClassifyMemberNum=value; }
	        }
		
	
	
	        /// <summary>
	        /// 修改时间[ClassifyTime]
	        /// </summary>
	        public string ClassifyTime
	        {
	            get{ return _ClassifyTime; }
	            set{ _ClassifyTime=value; }
	        }
		
	
	
	        /// <summary>
	        /// 删除标志，(0,启用；1，停用；2，删除。)[DelTag]
	        /// </summary>
	        public byte DelTag
	        {
	            get{ return _DelTag; }
	            set{ _DelTag=value; }
	        }
		
        #endregion
    }
}
