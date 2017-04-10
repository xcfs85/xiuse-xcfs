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
    /// [xiuse_recharge] ҵ���߼�����
    /// </summary>
    public class xiuse_recharge 
    {
       
        private readonly Xiuse.DAL.xiuse_recharge dal=new Xiuse.DAL.xiuse_recharge();

        public xiuse_recharge(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_recharge model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ���洢����
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertProcedure(Model.xiuse_recharge model)
        {
            return dal.InsertProcedure(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_recharge model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="RechargeId">RechargeId</param>
        public bool Delete(string RechargeId)
        {
            return dal.Delete(RechargeId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="RechargeId">RechargeId</param>
        public bool Exists(string RechargeId)
        {
            return dal.Exists(RechargeId);
        }
        
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="RechargeId">RechargeId</param>
        public Xiuse.Model.xiuse_recharge GetModel(string RechargeId)
        {
            return dal.GetModel(RechargeId);
        }

        #region ���� xcf  ʱ��2016/12/16
        /// <summary>
        /// ��ȡ�����ڵĻ�Ա��ֵ��¼ʵ��
        /// </summary>
        /// <param name="RechargeId">RechargeId</param>
        public List<Xiuse.Model.xiuse_recharge> GetModelsAtRestaurant(string RestaurantId)
        {
            return DataSetTransModelListNoExpand(dal.GetModelsAtRestaurant(RestaurantId));
        }
        /// <summary>
        /// �������ڻ�Ա��ֵ��¼
        /// </summary>
        /// <param name="RestaurantId">������ID</param>
        /// <param name="Condition">������������Ա���ơ���Ա�ֻ��š���Ա����</param>
        /// <returns></returns>
        public List<Xiuse.Model.xiuse_recharge> Search(string RestanrantId,string Condition)
        {
            return DataSetTransModelListNoExpand(dal.Search(RestanrantId, Condition));
        }
        #endregion

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="">��Ա��Id[MemberId]</param>
        /// <param name="">��ֵ����[RechargeType]</param>
        /// <param name="">��ֵ���[RechargeAmount]</param>
        /// <param name="">�������[Balance]</param>
        /// <param name="">��Ա�Ŀ���[MemberCardNo]</param>
        /// <param name="">[RechargeTime]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string MemberId,byte RechargeType,decimal RechargeAmount,decimal Balance,string MemberCardNo,string RechargeTime, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(MemberId,RechargeType,RechargeAmount,Balance,MemberCardNo,RechargeTime,StartIndex,PageSize,out count);
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
        private List<Xiuse.Model.xiuse_recharge> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_recharge> list = new List<Xiuse.Model.xiuse_recharge>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_recharge>(dataSet, 0));
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
        private Xiuse.Model.xiuse_recharge DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_recharge>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// ������DataSetת��ΪList
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_recharge> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_recharge> Tmp = new List<Model.xiuse_recharge>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_recharge model = new Xiuse.Model.xiuse_recharge();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.RechargeId = (string)dr["RechargeId"];
                    model.MemberId = (string)dr["MemberId"];
                    model.RechargeType = (byte)dr["RechargeType"];
                    model.RechargeAmount = (decimal)dr["RechargeAmount"];
                    model.Balance = (decimal)dr["Balance"];
                    model.MemberCardNo = dr["MemberCardNo"].ToString();
                    model.RechargeTime = (DateTime)dr["RechargeTime"];
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
