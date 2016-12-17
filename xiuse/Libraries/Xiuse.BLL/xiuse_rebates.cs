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
    /// [xiuse_rebates] 业务逻辑处理
    /// </summary>
    public class xiuse_rebates 
    {
       
        private readonly Xiuse.DAL.xiuse_rebates dal=new Xiuse.DAL.xiuse_rebates();

        public xiuse_rebates(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_rebates model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_rebates model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="RebatesId">RebatesId</param>
        public bool Delete(string RebatesId)
        {
            return dal.Delete(RebatesId);
        }
        
        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <param name="RebatesId">RebatesId</param>
        public bool Exists(string RebatesId)
        {
            return dal.Exists(RebatesId);
        }
        
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="RebatesId">RebatesId</param>
        public Xiuse.Model.xiuse_rebates GetModel(string RebatesId)
        {
            return dal.GetModel(RebatesId);
        }
        #region 作者 xcf 时间 2016/12/17
        /// <summary>
        /// 获取餐厅的的所有的会员的返现记录
        /// </summary>
        /// <param name="RestaurantId">餐厅的Id</param>
        /// <returns></returns>
        public List<Model.xiuse_rebates> GetModelAt(string RestaurantId)
        {
            return DataSetTransModelListNoExpand(dal.GetModelAt(RestaurantId));
        }
        /// <summary>
        /// 搜索餐厅内会员的的返现记录
        /// </summary>
        /// <param name="RestaurantId">餐厅ID</param>
        /// <param name="Condition">搜索条件</param>
        /// <returns></returns>
        public List<Model.xiuse_rebates> Search(string RestaurantId, string Condition)
        {
            return DataSetTransModelListNoExpand(dal.Search(RestaurantId,Condition));
        }
        #endregion
        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">会员Id[MemberId]</param>
        /// <param name="">会员卡号[MemberCardNo]</param>
        /// <param name="">返现类型[RebatesType]</param>
        /// <param name="">返现金额[RebatesAmount]</param>
        /// <param name="">日期[DateTime]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string MemberId,string MemberCardNo,string RebatesType,decimal RebatesAmount,string DateTime, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(MemberId,MemberCardNo,RebatesType,RebatesAmount,DateTime,StartIndex,PageSize,out count);
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
        /// 把DataSet转成泛型(expand无关联实体)
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
        /// 工具类DataSet转换为List
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
