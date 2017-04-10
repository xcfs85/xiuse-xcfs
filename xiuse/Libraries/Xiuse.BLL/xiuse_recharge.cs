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
    /// [xiuse_recharge] 业务逻辑处理
    /// </summary>
    public class xiuse_recharge 
    {
       
        private readonly Xiuse.DAL.xiuse_recharge dal=new Xiuse.DAL.xiuse_recharge();

        public xiuse_recharge(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_recharge model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 增加一条存储过程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertProcedure(Model.xiuse_recharge model)
        {
            return dal.InsertProcedure(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_recharge model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="RechargeId">RechargeId</param>
        public bool Delete(string RechargeId)
        {
            return dal.Delete(RechargeId);
        }
        
        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <param name="RechargeId">RechargeId</param>
        public bool Exists(string RechargeId)
        {
            return dal.Exists(RechargeId);
        }
        
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="RechargeId">RechargeId</param>
        public Xiuse.Model.xiuse_recharge GetModel(string RechargeId)
        {
            return dal.GetModel(RechargeId);
        }

        #region 作者 xcf  时间2016/12/16
        /// <summary>
        /// 获取店铺内的会员充值记录实体
        /// </summary>
        /// <param name="RechargeId">RechargeId</param>
        public List<Xiuse.Model.xiuse_recharge> GetModelsAtRestaurant(string RestaurantId)
        {
            return DataSetTransModelListNoExpand(dal.GetModelsAtRestaurant(RestaurantId));
        }
        /// <summary>
        /// 搜索店内会员充值记录
        /// </summary>
        /// <param name="RestaurantId">餐厅的ID</param>
        /// <param name="Condition">搜索条件：会员名称、会员手机号、会员卡号</param>
        /// <returns></returns>
        public List<Xiuse.Model.xiuse_recharge> Search(string RestanrantId,string Condition)
        {
            return DataSetTransModelListNoExpand(dal.Search(RestanrantId, Condition));
        }
        #endregion

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">会员的Id[MemberId]</param>
        /// <param name="">充值类型[RechargeType]</param>
        /// <param name="">充值金额[RechargeAmount]</param>
        /// <param name="">可用余额[Balance]</param>
        /// <param name="">会员的卡号[MemberCardNo]</param>
        /// <param name="">[RechargeTime]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string MemberId,byte RechargeType,decimal RechargeAmount,decimal Balance,string MemberCardNo,string RechargeTime, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(MemberId,RechargeType,RechargeAmount,Balance,MemberCardNo,RechargeTime,StartIndex,PageSize,out count);
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
        /// 把DataSet转成泛型(expand无关联实体)
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
        /// 工具类DataSet转换为List
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
