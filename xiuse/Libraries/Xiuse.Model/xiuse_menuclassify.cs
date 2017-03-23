using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_menuclassify] ʵ����
    /// </summary>
    public class xiuse_menuclassify
    {
        public xiuse_menuclassify(){}

        #region ��Ա����...
	private string _ClassifyId;
	private string _ClassifyInstruction;
	private int _ClassifyNo;
	private int _ClassifyNet;
	private string _ClassifyTag;
	private DateTime _ClassifyTime;
        private string _RestaurantId;
        
            #endregion

            #region ��Ա����...

            /// <summary>
            /// �˵�����[ClassifyId]
            /// </summary>
            public string ClassifyId
	        {
	            get{ return _ClassifyId; }
	            set{ _ClassifyId=value; }
	        }
		
	
	
	        /// <summary>
	        /// Ʒ�ͷ������[ClassifyInstruction]
	        /// </summary>
	        public string ClassifyInstruction
	        {
	            get{ return _ClassifyInstruction; }
	            set{ _ClassifyInstruction=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��Ʒ����˳��[ClassifyNo]
	        /// </summary>
	        public int ClassifyNo
	        {
	            get{ return _ClassifyNo; }
	            set{ _ClassifyNo=value; }
	        }
		
	
	
	        /// <summary>
	        /// ���ط��� (���ϵ㵥�ͻ��޷�ʹ��) 1,���ط��ࡣ0�����ط��ࡣ[ClassifyNet]
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
	        /// �������ʱ��[ClassifyTime]
	        /// </summary>
	        public DateTime ClassifyTime
	        {
	            get{ return _ClassifyTime; }
	            set{ _ClassifyTime=value; }
	        }

  

        public string RestaurantId
        {
            get
            {
                return _RestaurantId;
            }

            set
            {
                _RestaurantId = value;
            }
        }

        #endregion
    }
}
