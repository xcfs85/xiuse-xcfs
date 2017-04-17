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
    /// [xiuse_discount] 业务逻辑处理
    /// </summary>
    public class xiuse_discount 
    {
       
        private readonly Xiuse.DAL.xiuse_discount dal=new Xiuse.DAL.xiuse_discount();

        public xiuse_discount(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_discount model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_discount model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="DiscountId">DiscountId</param>
        public bool Delete(string DiscountId)
        {
            return dal.Delete(DiscountId);
        }
        
        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <param name="DiscountId">DiscountId</param>
        public bool Exists(string DiscountId)
        {
            return dal.Exists(DiscountId);
        }
        
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="DiscountId">DiscountId</param>
        public Xiuse.Model.xiuse_discount GetModel(string DiscountId)
        {
            return dal.GetModel(DiscountId);
        }
        #region 作者xcf  时间2016/12/19
        /// <summary>
        /// 获取餐厅所有的折扣信息
        /// </summary>
        /// <param name="RestaurantId">餐厅的Id</param>
        /// <returns></returns>
        public List<Model.xiuse_discount> GetModels(string RestaurantId)
        {
            return DataSetTransModelListNoExpand(dal.GetDiscountData(RestaurantId));
        }
        /// <summary>
        /// 获取餐厅整单折扣的信息
        /// </summary>
        /// <param name="RestaurantId">餐厅的Id</param>
        /// <returns></returns>
        public List<Model.xiuse_discount> GetEntireModels(string RestaurantId)
        {
            return DataSetTransModelListNoExpand(dal.GetEntireDiscountData(RestaurantId));
        }
        /// <summary>
        /// 获取单品的折扣
        /// </summary>
        /// <param name="RestaurantId">餐厅的Id</param>
        /// <param name="MenuId">菜品的Id</param>
        /// <returns></returns>
        public Model.xiuse_discount GetSingleModels(string RestaurantId,string MenuId)
        {
            return DataSetTransModelNoExpand(dal.GetSingleDiscountData(RestaurantId, MenuId));
        }
        /// <summary>
        /// 设置折扣的状态（1,启用；0，禁用;2,删除；）
        /// </summary>
        /// <param name="DiscountId">折扣的ID</param>
        /// <param name="State">折扣的状态（1,启用；0，禁用;2,删除；）</param>
        /// <returns></returns>
        public bool SetDiscountState(string DiscountId, int State)
        {
            return dal.SetDiscountState(DiscountId,State);
        }
        #endregion

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">[RestaurantId]</param>
        /// <param name="">折扣名称[DiscountName]</param>
        /// <param name="">折扣类型(0:百分比 1：固定金额)[DiscountType]</param>
        /// <param name="">折扣金额[DiscountContent]</param>
        /// <param name="">折扣菜品(-1，全部餐品；（菜品ID,菜品ID,菜品ID,菜品ID,菜品ID）,部门折扣)[DiscountMenus]</param>
        /// <param name="">0,整单折扣；1，单品折扣[DiscountSection]</param>
        /// <param name="">1,启用；0，禁用[DiscountState]</param>
        /// <param name="">0,启用管理员验证；1,禁用管理员验证；[DiscountVerification]</param>
        /// <param name="">更新时间[DiscountTime]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string RestaurantId,string DiscountName,byte DiscountType,decimal DiscountContent,string DiscountMenus,byte DiscountSection,bool DiscountState,int DiscountVerification,string DiscountTime, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(RestaurantId,DiscountName,DiscountType,DiscountContent,DiscountMenus,DiscountSection,DiscountState,DiscountVerification,DiscountTime,StartIndex,PageSize,out count);
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
        private  List<Xiuse.Model.xiuse_discount> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_discount> list = new List<Xiuse.Model.xiuse_discount>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_discount>(dataSet, 0));
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
        private Xiuse.Model.xiuse_discount DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_discount>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// 工具类DataSet转换为List
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_discount> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_discount> Tmp = new List<Model.xiuse_discount>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_discount model = new Xiuse.Model.xiuse_discount();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.DiscountId = (string)dr["DiscountId"];
                    model.RestaurantId = (string)dr["RestaurantId"];
                    model.DiscountName = dr["DiscountName"].ToString();
                    model.DiscountType = (byte)dr["DiscountType"];
                    model.DiscountContent = (decimal)dr["DiscountContent"];
                    model.DiscountMenus = dr["DiscountMenus"].ToString();
                    model.DiscountSection = (byte)dr["DiscountSection"];
                    model.DiscountState = (short)dr["DiscountState"];
                    model.DiscountVerification = (short)dr["DiscountVerification"];
                    model.DiscountTime = (DateTime)dr["DiscountTime"];
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
