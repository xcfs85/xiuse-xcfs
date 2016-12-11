using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DAL;
namespace Xiuse.BLL
{
    /// <summary>
    /// [ordermenu_] ҵ���߼�����
    /// </summary>
    public class ordermenu_ 
    {
       
        private readonly Xiuse.DAL.ordermenu_ dal=new Xiuse.DAL.ordermenu_();

        public ordermenu_(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.ordermenu_ model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.ordermenu_ model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="OrderMenuId">OrderMenuId</param>
        public bool Delete(string OrderMenuId)
        {
            return dal.Delete(OrderMenuId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="OrderMenuId">OrderMenuId</param>
        public bool Exists(string OrderMenuId)
        {
            return dal.Exists(OrderMenuId);
        }
        
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="OrderMenuId">OrderMenuId</param>
        public Xiuse.Model.ordermenu_ GetModel(string OrderMenuId)
        {
            return dal.GetModel(OrderMenuId);
        }
        

		/// <summary>
        /// ��������
        /// </summary>
        /// <param name="">[OrderId]</param>
        /// <param name="">��Ʒ����[MenuName]</param>
        /// <param name="">��Ʒ�۸�[MenuPrice]</param>
        /// <param name="">��Ʒ��ǩ[MenuTag]</param>
        /// <param name="">��ƷͼƬ[MenuImage]</param>
        /// <param name="">��Ʒ����[MenuInstruction]</param>
        /// <param name="">�Ƿ����ۿۣ�0,1��[DiscoutFlag]</param>
        /// <param name="">�ۿ�����[DiscountName]</param>
        /// <param name="">�ۿ۽��[DiscountContent]</param>
        /// <param name="">�ۿ�����(0:�ٷֱ� 1���̶����)[DiscountType]</param>
        /// <param name="">�Ƿ��ϲ�[MenuServing]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string OrderId,string MenuName,decimal MenuPrice,string MenuTag,string MenuImage,string MenuInstruction,bool DiscoutFlag,string DiscountName,decimal DiscountContent,byte DiscountType,bool MenuServing, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(OrderId,MenuName,MenuPrice,MenuTag,MenuImage,MenuInstruction,DiscoutFlag,DiscountName,DiscountContent,DiscountType,MenuServing,StartIndex,PageSize,out count);
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
