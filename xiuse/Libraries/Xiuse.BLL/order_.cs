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
    /// [order_] ҵ���߼�����
    /// </summary>
    public class order_ 
    {
       
        private readonly Xiuse.DAL.order_ dal=new Xiuse.DAL.order_();

        public order_(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.order_ model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.order_ model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="OrderId">OrderId</param>
        public bool Delete(string OrderId)
        {
            return dal.Delete(OrderId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="OrderId">OrderId</param>
        public bool Exists(string OrderId)
        {
            return dal.Exists(OrderId);
        }
        
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="OrderId">OrderId</param>
        public Xiuse.Model.order_ GetModel(string OrderId)
        {
            return dal.GetModel(OrderId);
        }
        

		/// <summary>
        /// ��������
        /// </summary>
        /// <param name="">����Id[DeskId]</param>
        /// <param name="">�˵�[BillAmount]</param>
        /// <param name="">Ӧ����[AccountsPayable]</param>
        /// <param name="">�˿�[Refunds]</param>
        /// <param name="">��Ʒ����[DishCount]</param>
        /// <param name="">����״̬��0��δ֧����1����֧����[OrderState]</param>
        /// <param name="">�ֽ𸶿�[Cash]</param>
        /// <param name="">���п�����[BankCard]</param>
        /// <param name="">΢�Ÿ���[WeiXin]</param>
        /// <param name="">֧��������[Alipay]</param>
        /// <param name="">��Ա������[MembersCard]</param>
        /// <param name="">�µ�ʱ��[OrderbeginTime]</param>
        /// <param name="">�òͽ���ʱ��[OrderEndTime]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string DeskId,decimal BillAmount,decimal AccountsPayable,decimal Refunds,byte DishCount,byte OrderState,decimal Cash,decimal BankCard,decimal WeiXin,decimal Alipay,decimal MembersCard,string OrderbeginTime,string OrderEndTime, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(DeskId,BillAmount,AccountsPayable,Refunds,DishCount,OrderState,Cash,BankCard,WeiXin,Alipay,MembersCard,OrderbeginTime,OrderEndTime,StartIndex,PageSize,out count);
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
        ///��ȡ�������е��˵�
        /// 
        public List<Model.order_> GetDailyBills(string condition)
        {
            return DataSetTransModelListNoExpand(GetData("*", condition));
        }

        ///
        ///��ȡĳһ����������δ���˲����Ľ��
        /// 

        public List<Xiuse.Model.order_> GetUnpaidDesks(string RestaurantId)
        {
            return DataSetTransModelListNoExpand(dal.GetUnpaidDesks(RestaurantId));
        }


        ///��ȡĳһ�������һ����֧���Ľ��
        public List<Xiuse.Model.order_> GetPaidLatest(string RestaurantId)
        {
            return DataSetTransModelListNoExpand(dal.GetPaidLatest(RestaurantId));
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
        private  List<Xiuse.Model.order_> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.order_> list = new List<Xiuse.Model.order_>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.order_>(dataSet, 0));
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
        private  Xiuse.Model.order_ DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.order_>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// ������DataSetת��ΪList
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.order_> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.order_> Tmp = new List<Model.order_>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.order_ model = new Xiuse.Model.order_();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.OrderId = dr["OrderId"].ToString();
                    model.DeskId = (string)dr["DeskId"];
                    model.BillAmount = (decimal)dr["BillAmount"];
                    model.AccountsPayable = (decimal)dr["AccountsPayable"];
                    model.Refunds = (decimal)dr["Refunds"];
                    model.DishCount = (int)dr["DishCount"];
                    model.OrderState = (bool)dr["OrderState"];
                    model.Cash = (decimal)dr["Cash"];
                    model.BankCard = (decimal)dr["BankCard"];
                    model.WeiXin = (decimal)dr["WeiXin"];
                    model.Alipay = (decimal)dr["Alipay"];
                    model.MembersCard = (decimal)dr["MembersCard"];
                    model.OrderbeginTime = (DateTime)dr["OrderbeginTime"];
                    model.OrderEndTime = (DateTime)dr["OrderEndTime"];
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
