using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DAL;
namespace Xiuse.BLL
{
    /// <summary>
    /// [xiuse_member] ҵ���߼�����
    /// </summary>
    public class xiuse_member 
    {
       
        private readonly Xiuse.DAL.xiuse_member dal=new Xiuse.DAL.xiuse_member();

        public xiuse_member(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_member model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_member model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="MemberId">MemberId</param>
        public bool Delete(string MemberId)
        {
            return dal.Delete(MemberId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="MemberId">MemberId</param>
        public bool Exists(string MemberId)
        {
            return dal.Exists(MemberId);
        }
        
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="MemberId">MemberId</param>
        public Xiuse.Model.xiuse_member GetModel(string MemberId)
        {
            return dal.GetModel(MemberId);
        }
        

		/// <summary>
        /// ��������
        /// </summary>
        /// <param name="">��Ա����ID[MemberClassifyId]</param>
        /// <param name="">��Ա����[MemberCardNo]</param>
        /// <param name="">��Ա����[MemberName]</param>
        /// <param name="">�������[MemberAmount]</param>
        /// <param name="">�ֻ���[MemberCell]</param>
        /// <param name="">�Ƽ���[MemberReference]</param>
        /// <param name="">[MemberPassword]</param>
        /// <param name="">��Ա״̬��0�����ã�1�����ã���[MemberState]</param>
        /// <param name="">��Ա����ʱ��[MemberTime]</param>
        /// <param name="">[RestaurantId]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string MemberClassifyId,string MemberCardNo,string MemberName,decimal MemberAmount,string MemberCell,string MemberReference,string MemberPassword,bool MemberState,string MemberTime,string RestaurantId, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(MemberClassifyId,MemberCardNo,MemberName,MemberAmount,MemberCell,MemberReference,MemberPassword,MemberState,MemberTime,RestaurantId,StartIndex,PageSize,out count);
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
