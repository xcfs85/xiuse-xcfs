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
    /// [memberconsumption] 业务逻辑处理
    /// </summary>
    public class memberconsumption 
    {
       
        private readonly Xiuse.DAL.memberconsumption dal=new Xiuse.DAL.memberconsumption();

        public memberconsumption(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.memberconsumption model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.memberconsumption model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="ConsumptionRecordsId">ConsumptionRecordsId</param>
        public bool Delete(string ConsumptionRecordsId)
        {
            return dal.Delete(ConsumptionRecordsId);
        }
        
        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <param name="ConsumptionRecordsId">ConsumptionRecordsId</param>
        public bool Exists(string ConsumptionRecordsId)
        {
            return dal.Exists(ConsumptionRecordsId);
        }
        
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="ConsumptionRecordsId">ConsumptionRecordsId</param>
        public Xiuse.Model.memberconsumption GetModel(string ConsumptionRecordsId)
        {
            return dal.GetModel(ConsumptionRecordsId);
        }
        

		/// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">会员Id[MemberId]</param>
        /// <param name="">会员卡卡号[MemberCardNo]</param>
        /// <param name="">消费类型[CRecordsType]</param>
        /// <param name="">消费金额[Amount]</param>
        /// <param name="">余额[Balance]</param>
        /// <param name="">消费日期[ConsumptionTime]</param>
        /// <param name="">订单Id[OrderId]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string MemberId,string MemberCardNo,byte CRecordsType,decimal Amount,decimal Balance,string ConsumptionTime,string OrderId, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(MemberId,MemberCardNo,CRecordsType,Amount,Balance,ConsumptionTime,OrderId,StartIndex,PageSize,out count);
            RecordCount=count;
            return ds;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="Fields">字段字符串[全部为*]</param>
        /// <param name="Wheres">条件[可为空]</param>
        public DataSet GetData(string Fields, string Wheres)
        {
            return dal.GetData(Fields,Wheres);
        }


        /// <summary>
        /// 获取数据[用于分页]
        /// </summary>
        /// <param name="Fields">字段字符串[全部为*]</param>
        /// <param name="Wheres">条件[可为空]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet GetData(string Fields, string Wheres,int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.GetData(Fields,Wheres,StartIndex,PageSize,out count);
            RecordCount=count;
            return ds;
        }
        
        /// <summary>
        /// 获取全部数据
        /// </summary>
        public DataSet GetAll()
        {
            return dal.GetAll();
        }
       
        /// <summary>
        /// 获取全部数据[用于分页]
        /// </summary>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet GetAll(int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;                              //记录总数
            DataSet ds=dal.GetAll(StartIndex,PageSize,out count);
            RecordCount=count;
            return ds;
        }   

        /// <summary>
        /// 执行更新SQL语句
        /// </summary>
        /// <param name="filed">要更新的字段，例：["name='"+name+"',pwd='"+pwd+"'"]</param>
        /// <param name="wheres">更新条件，例：["id="+id]</param>
        public int ExecuteUpdate(string updatefield, string wheres)
        {
           return dal.ExecuteUpdate(updatefield,wheres);
        }
        #region 工具类
        /// <summary>
        /// 把DataSet转成List泛型集合(expand无关联实体)
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
        /// 把DataSet转成泛型(expand无关联实体)
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
        /// 工具类DataSet转换为List
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
