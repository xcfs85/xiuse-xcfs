using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DAL;
namespace Xiuse.BLL
{
    /// <summary>
    /// [xiuse_memberclassify] ҵ���߼�����
    /// </summary>
    public class xiuse_memberclassify 
    {
       
        private readonly Xiuse.DAL.xiuse_memberclassify dal=new Xiuse.DAL.xiuse_memberclassify();

        public xiuse_memberclassify(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_memberclassify model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_memberclassify model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="MemberClassifyId">MemberClassifyId</param>
        public bool Delete(string MemberClassifyId)
        {
            return dal.Delete(MemberClassifyId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="MemberClassifyId">MemberClassifyId</param>
        public bool Exists(string MemberClassifyId)
        {
            return dal.Exists(MemberClassifyId);
        }
        
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="MemberClassifyId">MemberClassifyId</param>
        public Xiuse.Model.xiuse_memberclassify GetModel(string MemberClassifyId)
        {
            return dal.GetModel(MemberClassifyId);
        }
        

		/// <summary>
        /// ��������
        /// </summary>
        /// <param name="">�ۿ�ID[DiscountId]</param>
        /// <param name="">��������[ClassifyName]</param>
        /// <param name="">˵��[ClassRemark]</param>
        /// <param name="">��Ա����[ClassifyMemberNum]</param>
        /// <param name="">�޸�ʱ��[ClassifyTime]</param>
        /// <param name="">ɾ����־��(0,���ã�1��ͣ�ã�2��ɾ����)[DelTag]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string DiscountId,string ClassifyName,string ClassRemark,int ClassifyMemberNum,string ClassifyTime,byte DelTag, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(DiscountId,ClassifyName,ClassRemark,ClassifyMemberNum,ClassifyTime,DelTag,StartIndex,PageSize,out count);
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
