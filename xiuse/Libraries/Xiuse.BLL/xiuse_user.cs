using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DAL;
namespace Xiuse.BLL
{
    /// <summary>
    /// [xiuse_user] ҵ���߼�����
    /// </summary>
    public class xiuse_user 
    {
       
        private readonly Xiuse.DAL.xiuse_user dal=new Xiuse.DAL.xiuse_user();

        public xiuse_user(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_user model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_user model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="UserId">UserId</param>
        public bool Delete(string UserId)
        {
            return dal.Delete(UserId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="UserId">UserId</param>
        public bool Exists(string UserId)
        {
            return dal.Exists(UserId);
        }
        
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="UserId">UserId</param>
        public Xiuse.Model.xiuse_user GetModel(string UserId)
        {
            return dal.GetModel(UserId);
        }
        

		/// <summary>
        /// ��������
        /// </summary>
        /// <param name="">����ID[RestaurantId]</param>
        /// <param name="">����[UserName]</param>
        /// <param name="">΢�ź�[Weixin]</param>
        /// <param name="">�ֻ���[CellPhone]</param>
        /// <param name="">Email[Email]</param>
        /// <param name="">����[Password]</param>
        /// <param name="">0,�ǹ���Ա��1����Ա����[UserRole]</param>
        /// <param name="">�ϼ��û�Id������Ϊ�գ�[ParentUserId]</param>
        /// <param name="">��������Ȩ��0���ޣ�1�����У���[OwnRestaurant]</param>
        /// <param name="">�޸�ʱ��[Time]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string RestaurantId,string UserName,string Weixin,decimal CellPhone,string Email,string Password,int UserRole,string ParentUserId,bool OwnRestaurant,string Time, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(RestaurantId,UserName,Weixin,CellPhone,Email,Password,UserRole,ParentUserId,OwnRestaurant,Time,StartIndex,PageSize,out count);
            RecordCount=count;
            return ds;
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="Fields">�ֶ��ַ���[ȫ��Ϊ*]</param>
        /// <param name="Wheres">����[��Ϊ��]</param>
        public DataSet GetData(string Fields, string Wheres)
        {
            return dal.GetData(Fields,Wheres);
        }


        /// <summary>
        /// ��ȡ����[���ڷ�ҳ]
        /// </summary>
        /// <param name="Fields">�ֶ��ַ���[ȫ��Ϊ*]</param>
        /// <param name="Wheres">����[��Ϊ��]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet GetData(string Fields, string Wheres,int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.GetData(Fields,Wheres,StartIndex,PageSize,out count);
            RecordCount=count;
            return ds;
        }
        
        /// <summary>
        /// ��ȡȫ������
        /// </summary>
        public DataSet GetAll()
        {
            return dal.GetAll();
        }
       
        /// <summary>
        /// ��ȡȫ������[���ڷ�ҳ]
        /// </summary>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet GetAll(int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;                              //��¼����
            DataSet ds=dal.GetAll(StartIndex,PageSize,out count);
            RecordCount=count;
            return ds;
        }   

        /// <summary>
        /// ִ�и���SQL���
        /// </summary>
        /// <param name="filed">Ҫ���µ��ֶΣ�����["name='"+name+"',pwd='"+pwd+"'"]</param>
        /// <param name="wheres">��������������["id="+id]</param>
        public int ExecuteUpdate(string updatefield, string wheres)
        {
           return dal.ExecuteUpdate(updatefield,wheres);
        }
    }
}
