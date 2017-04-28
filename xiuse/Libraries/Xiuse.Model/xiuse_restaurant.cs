using System;

namespace Xiuse.Model
{
    /// <summary>
    /// [xiuse_restaurant] ʵ����
    /// </summary>
    public class xiuse_restaurant
    {
        public xiuse_restaurant(){}

        #region ��Ա����...
	private string _RestaurantId;
	private string _RestaurantName;
	private string _Phone;
	private string _Site;
	private string _Remark;
	private DateTime _Time;
        #endregion

        #region ��Ա����...
	
	        /// <summary>
	        /// ������Id[RestaurantId]
	        /// </summary>
	        public string RestaurantId
	        {
	            get{ return _RestaurantId; }
	            set{ _RestaurantId=value; }
	        }
		
	
	
	        /// <summary>
	        /// ��������[RestaurantName]
	        /// </summary>
	        public string RestaurantName
	        {
	            get{ return _RestaurantName; }
	            set{ _RestaurantName=value; }
	        }
		
	
	
	        /// <summary>
	        /// �����ĵ绰[Phone]
	        /// </summary>
	        public string Phone
	        {
	            get{ return _Phone; }
	            set{ _Phone=value; }
	        }
		
	
	
	        /// <summary>
	        /// �����ĵ�ַ[Site]
	        /// </summary>
	        public string Site
	        {
	            get{ return _Site; }
	            set{ _Site=value; }
	        }
		
	
	
	        /// <summary>
	        /// ������˵��[Remark]
	        /// </summary>
	        public string Remark
	        {
	            get{ return _Remark; }
	            set{ _Remark=value; }
	        }
		
	
	
	        /// <summary>
	        /// ����ʱ��[Time]
	        /// </summary>
	        public DateTime Time
	        {
	            get{ return _Time; }
	            set{ _Time=value; }
	        }
		
        #endregion
    }
}
