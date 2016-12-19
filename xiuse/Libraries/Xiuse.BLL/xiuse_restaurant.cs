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
    /// [xiuse_restaurant] 业务逻辑处理
    /// </summary>
    public class xiuse_restaurant 
    {
       
        private readonly Xiuse.DAL.xiuse_restaurant dal=new Xiuse.DAL.xiuse_restaurant();

        public xiuse_restaurant(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_restaurant model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_restaurant model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="RestaurantId">RestaurantId</param>
        public bool Delete(string RestaurantId)
        {
            return dal.Delete(RestaurantId);
        }
        
        /// <summary>
        ///  判断餐厅是否存在
        /// </summary>
        /// <param name="RestaurantId">RestaurantId</param>
        public bool Exists(string RestaurantId)
        {
            return dal.Exists(RestaurantId);
        }
        
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="RestaurantId">RestaurantId</param>
        public Xiuse.Model.xiuse_restaurant GetModel(string RestaurantId)
        {
            return dal.GetModel(RestaurantId);
        }
        

		/// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">餐厅名称[RestaurantName]</param>
        /// <param name="">餐厅的电话[Phone]</param>
        /// <param name="">餐厅的地址[Site]</param>
        /// <param name="">餐厅的说明[Remark]</param>
        /// <param name="">更新时间[Time]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string RestaurantName,string Phone,string Site,string Remark,string Time, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(RestaurantName,Phone,Site,Remark,Time,StartIndex,PageSize,out count);
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
        private List<Xiuse.Model.xiuse_restaurant> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_restaurant> list = new List<Xiuse.Model.xiuse_restaurant>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_restaurant>(dataSet, 0));
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
        private Xiuse.Model.xiuse_restaurant DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_restaurant>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// 工具类DataSet转换为List
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_restaurant> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_restaurant> Tmp = new List<Model.xiuse_restaurant>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_restaurant model = new Xiuse.Model.xiuse_restaurant();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.RestaurantId = (string)dr["RestaurantId"];
                    model.RestaurantName = dr["RestaurantName"].ToString();
                    model.Phone = dr["Phone"].ToString();
                    model.Site = dr["Site"].ToString();
                    model.Remark = dr["Remark"].ToString();
                    model.Time = dr["Time"].ToString();
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
