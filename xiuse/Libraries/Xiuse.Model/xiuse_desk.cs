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
	private Int16 _TakeOut;
	private Int16 _DeskDel;
	private Int16 _DeskState;
	private DateTime _DeskTime;
     //   private float _AccountPayable;
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
	        public Int16 TakeOut
	        {
	            get{ return _TakeOut; }
	            set{ _TakeOut=value; }
	        }
		
	
	
	        /// <summary>
	        /// 0,��ɾ����1����[DeskDel]
	        /// </summary>
	        public Int16 DeskDel
	        {
	            get{ return _DeskDel; }
	            set{ _DeskDel=value; }
	        }
		
	
	
	        /// <summary>
	        /// ������״̬��0��������1��δ֧����2����֧����[DeskState]
	        /// </summary>
	        public Int16 DeskState
	        {
	            get{ return _DeskState; }
	            set{ _DeskState=value; }
	        }
		
	
	
	        /// <summary>
	        /// ����ʱ��[DeskTime]
	        /// </summary>
	        public DateTime DeskTime
	        {
	            get{ return _DeskTime; }
	            set{ _DeskTime=value; }
	        }

        //public float AccountPayable
        //{
        //    get
        //    {
        //        return _AccountPayable;
        //    }

        //    set
        //    {
        //        _AccountPayable = value;
        //    }
        //}

        #endregion
    }
}
