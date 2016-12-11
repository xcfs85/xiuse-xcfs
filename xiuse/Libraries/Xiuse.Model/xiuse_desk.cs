using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_desk] ʵ����
    /// </summary>
    public class xiuse_desk
    {
        public xiuse_desk(){}

        #region ��Ա����...
	private string _DeskId;
	private string _RestaurantId;
	private string _DeskName;
	private bool _TakeOut;
	private bool _DeskDel;
	private byte _DeskState;
	private string _DeskTime;
        #endregion

        #region ��Ա����...
	
	        /// <summary>
	        /// ��������ID[DeskId]
	        /// </summary>
	        public string DeskId
	        {
	            get{ return _DeskId; }
	            set{ _DeskId=value; }
	        }
		
	
	
	        /// <summary>
	        /// ����ID[RestaurantId]
	        /// </summary>
	        public string RestaurantId
	        {
	            get{ return _RestaurantId; }
	            set{ _RestaurantId=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��������[DeskName]
	        /// </summary>
	        public string DeskName
	        {
	            get{ return _DeskName; }
	            set{ _DeskName=value; }
	        }
		
	
	
	        /// <summary>
	        /// �Ƿ����������0��������������1����������[TakeOut]
	        /// </summary>
	        public bool TakeOut
	        {
	            get{ return _TakeOut; }
	            set{ _TakeOut=value; }
	        }
		
	
	
	        /// <summary>
	        /// 0,��ɾ����1����[DeskDel]
	        /// </summary>
	        public bool DeskDel
	        {
	            get{ return _DeskDel; }
	            set{ _DeskDel=value; }
	        }
		
	
	
	        /// <summary>
	        /// ������״̬��0��������1��δ֧����2����֧����[DeskState]
	        /// </summary>
	        public byte DeskState
	        {
	            get{ return _DeskState; }
	            set{ _DeskState=value; }
	        }
		
	
	
	        /// <summary>
	        /// ����ʱ��[DeskTime]
	        /// </summary>
	        public string DeskTime
	        {
	            get{ return _DeskTime; }
	            set{ _DeskTime=value; }
	        }
		
        #endregion
    }
}
