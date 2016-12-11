using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DAL;
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
    }
}
