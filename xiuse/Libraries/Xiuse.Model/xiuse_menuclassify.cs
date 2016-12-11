using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_menuclassify] 实体类
    /// </summary>
    public class xiuse_menuclassify
    {
        public xiuse_menuclassify(){}

        #region 成员变量...
	private string _ClassifyId;
	private string _ClassifyInstruction;
	private int _ClassifyNo;
	private int _ClassifyNet;
	private string _ClassifyTag;
	private string _ClassifyTime;
        #endregion

        #region 成员属性...
	
	        /// <summary>
	        /// 菜单分类[ClassifyId]
	        /// </summary>
	        public string ClassifyId
	        {
	            get{ return _ClassifyId; }
	            set{ _ClassifyId=value; }
	        }
		
	
	
	        /// <summary>
	        /// 品餐分类介绍[ClassifyInstruction]
	        /// </summary>
	        public string ClassifyInstruction
	        {
	            get{ return _ClassifyInstruction; }
	            set{ _ClassifyInstruction=value; }
	        }
		
	
	
	        /// <summary>
	        /// 餐品排列顺序[ClassifyNo]
	        /// </summary>
	        public int ClassifyNo
	        {
	            get{ return _ClassifyNo; }
	            set{ _ClassifyNo=value; }
	        }
		
	
	
	        /// <summary>
	        /// 隐藏分类 (网上点单客户无法使用) 1,隐藏分类。0不隐藏分类。[ClassifyNet]
	        /// </summary>
	        public int ClassifyNet
	        {
	            get{ return _ClassifyNet; }
	            set{ _ClassifyNet=value; }
	        }
		
	
	
	        /// <summary>
	        /// [ClassifyTag]
	        /// </summary>
	        public string ClassifyTag
	        {
	            get{ return _ClassifyTag; }
	            set{ _ClassifyTag=value; }
	        }
		
	
	
	        /// <summary>
	        /// 分类更新时间[ClassifyTime]
	        /// </summary>
	        public string ClassifyTime
	        {
	            get{ return _ClassifyTime; }
	            set{ _ClassifyTime=value; }
	        }
		
        #endregion
    }
}
