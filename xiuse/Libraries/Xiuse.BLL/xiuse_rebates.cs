using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DAL;
using DotNet.Utilities;

namespace Xiuse.BLL
{
    /// <summary>
    /// [xiuse_rebates] ҵ���߼�����
    /// </summary>
    public class xiuse_rebates 
    {
       
        private readonly Xiuse.DAL.xiuse_rebates dal=new Xiuse.DAL.xiuse_rebates();

        public xiuse_rebates(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_rebates model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_rebates model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="RebatesId">RebatesId</param>
        public bool Delete(string RebatesId)
        {
            return dal.Delete(RebatesId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="RebatesId">RebatesId</param>
        public bool Exists(string RebatesId)
        {
            return dal.Exists(RebatesId);
        }
        
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="RebatesId">RebatesId</param>
        public Xiuse.Model.xiuse_rebates GetModel(string RebatesId)
        {
            return dal.GetModel(RebatesId);
        }
        #region ���� xcf ʱ�� 2016/12/17
        /// <summary>
        /// ��ȡ�����ĵ����еĻ�Ա�ķ��ּ�¼
        /// </summary>
        /// <param name="RestaurantId">������Id</param>
        /// <returns></returns>
        public List<Model.xiuse_rebates> GetModelAt(string RestaurantId)
        {
            return DataSetTransModelListNoExpand(dal.GetModelAt(RestaurantId));
        }
        /// <summary>
        /// ���������ڻ�Ա�ĵķ��ּ�¼
        /// </summary>
        /// <param name="RestaurantId">����ID</param>
        /// <param name="Condition">��������</param>
        /// <returns></returns>
        public List<Model.xiuse_rebates> Search(string RestaurantId, string Condition)
        {
            return DataSetTransModelListNoExpand(dal.Search(RestaurantId,Condition));
        }
        #endregion
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="">��ԱId[MemberId]</param>
        /// <param name="">��Ա����[MemberCardNo]</param>
        /// <param name="">��������[RebatesType]</param>
        /// <param name="">���ֽ��[RebatesAmount]</param>
        /// <param name="">����[DateTime]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string MemberId,string MemberCardNo,string RebatesType,decimal RebatesAmount,string DateTime, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(MemberId,MemberCardNo,RebatesType,RebatesAmount,DateTime,StartIndex,PageSize,out count);
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

        #region ������
        /// <summary>
        /// ��DataSetת��List���ͼ���(expand�޹���ʵ��)
        /// Author:xcf Date:2015.01.26
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_rebates> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_rebates> list = new List<Xiuse.Model.xiuse_rebates>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_rebates>(dataSet, 0));
                return list;
            }
            return null;
        }
        /// <summary>
        /// ��DataSetת�ɷ���(expand�޹���ʵ��)
        /// Author:xcf Date:2015.01.26
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        private Xiuse.Model.xiuse_rebates DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_rebates>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// ������DataSetת��ΪList
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_rebates> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_rebates> Tmp = new List<Model.xiuse_rebates>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_rebates model = new Xiuse.Model.xiuse_rebates();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.RebatesId = dr["RebatesId"].ToString();
                    model.MemberId = dr["MemberId"].ToString();
                    model.MemberCardNo = dr["MemberCardNo"].ToString();
                    model.RebatesType = dr["RebatesType"].ToString();
                    model.RebatesAmount = (decimal)dr["RebatesAmount"];
                    model.DateTime = dr["DateTime"].ToString();
                    Tmp.Add(model);
                }
            }
            else
                Tmp = null;
            return Tmp;
        }
        #endregion
    }
}
