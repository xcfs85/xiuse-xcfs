using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DAL;
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
    }
}
