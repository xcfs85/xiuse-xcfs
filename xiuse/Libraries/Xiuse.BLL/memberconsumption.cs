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
    /// [memberconsumption] ҵ���߼�����
    /// </summary>
    public class memberconsumption 
    {
       
        private readonly Xiuse.DAL.memberconsumption dal=new Xiuse.DAL.memberconsumption();

        public memberconsumption(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.memberconsumption model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.memberconsumption model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="ConsumptionRecordsId">ConsumptionRecordsId</param>
        public bool Delete(string ConsumptionRecordsId)
        {
            return dal.Delete(ConsumptionRecordsId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="ConsumptionRecordsId">ConsumptionRecordsId</param>
        public bool Exists(string ConsumptionRecordsId)
        {
            return dal.Exists(ConsumptionRecordsId);
        }
        
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="ConsumptionRecordsId">ConsumptionRecordsId</param>
        public Xiuse.Model.memberconsumption GetModel(string ConsumptionRecordsId)
        {
            return dal.GetModel(ConsumptionRecordsId);
        }
        

		/// <summary>
        /// ��������
        /// </summary>
        /// <param name="">��ԱId[MemberId]</param>
        /// <param name="">��Ա������[MemberCardNo]</param>
        /// <param name="">��������[CRecordsType]</param>
        /// <param name="">���ѽ��[Amount]</param>
        /// <param name="">���[Balance]</param>
        /// <param name="">��������[ConsumptionTime]</param>
        /// <param name="">����Id[OrderId]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string MemberId,string MemberCardNo,byte CRecordsType,decimal Amount,decimal Balance,string ConsumptionTime,string OrderId, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(MemberId,MemberCardNo,CRecordsType,Amount,Balance,ConsumptionTime,OrderId,StartIndex,PageSize,out count);
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
        private  List<Xiuse.Model.memberconsumption> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.memberconsumption> list = new List<Xiuse.Model.memberconsumption>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.memberconsumption>(dataSet, 0));
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
        private  Xiuse.Model.memberconsumption DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.memberconsumption>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// ������DataSetת��ΪList
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.memberconsumption> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.memberconsumption> Tmp = new List<Model.memberconsumption>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.memberconsumption model = new Xiuse.Model.memberconsumption();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.ConsumptionRecordsId = (string)dr["ConsumptionRecordsId"];
                    model.MemberId = (string)dr["MemberId"];
                    model.MemberCardNo = (string)dr["MemberCardNo"];
                    model.CRecordsType = (byte)dr["CRecordsType"];
                    model.Amount = (decimal)dr["Amount"];
                    model.Balance = (decimal)dr["Balance"];
                    model.ConsumptionTime = dr["ConsumptionTime"].ToString();
                    model.OrderId = (string)dr["OrderId"];
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
