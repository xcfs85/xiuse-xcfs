using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DAL;
using DotNet.Utilities;
using System.Linq;

namespace Xiuse.BLL
{
    /// <summary>
    /// [ordermenu_] 业务逻辑处理
    /// </summary>
    public class ordermenu_ 
    {
       
        private readonly Xiuse.DAL.ordermenu_ dal=new Xiuse.DAL.ordermenu_();

        public ordermenu_(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.ordermenu_ model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.ordermenu_ model)
        {
            return dal.Update(model);
        }



        public bool UpdateMenuState(Xiuse.Model.ordermenu_ model)
        {
            return dal.UpdateMenuState(model);
        }
   
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="OrderMenuId">OrderMenuId</param>
        public bool Delete(string OrderMenuId)
        {
            return dal.Delete(OrderMenuId);
        }
        
        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <param name="OrderMenuId">OrderMenuId</param>
        public bool Exists(string OrderMenuId)
        {
            return dal.Exists(OrderMenuId);
        }
        
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="OrderMenuId">OrderMenuId</param>
        public Xiuse.Model.ordermenu_ GetModel(string OrderMenuId)
        {
            return dal.GetModel(OrderMenuId);
        }





        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">[OrderId]</param>
        /// <param name="">餐品名称[MenuName]</param>
        /// <param name="">菜品价格[MenuPrice]</param>
        /// <param name="">菜品标签[MenuTag]</param>
        /// <param name="">菜品图片[MenuImage]</param>
        /// <param name="">菜品介绍[MenuInstruction]</param>
        /// <param name="">是否有折扣（0,1）[DiscoutFlag]</param>
        /// <param name="">折扣名称[DiscountName]</param>
        /// <param name="">折扣金额[DiscountContent]</param>
        /// <param name="">折扣类型(0:百分比 1：固定金额)[DiscountType]</param>
        /// <param name="">是否上菜[MenuServing]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string OrderId,string MenuName,decimal MenuPrice,string MenuTag,string MenuImage,string MenuInstruction,bool DiscoutFlag,string DiscountName,decimal DiscountContent,byte DiscountType,bool MenuServing, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(OrderId,MenuName,MenuPrice,MenuTag,MenuImage,MenuInstruction,DiscoutFlag,DiscountName,DiscountContent,DiscountType,MenuServing,StartIndex,PageSize,out count);
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
        private  List<Xiuse.Model.ordermenu_> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.ordermenu_> list = new List<Xiuse.Model.ordermenu_>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.ordermenu_>(dataSet, 0));
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
        private  Xiuse.Model.ordermenu_ DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.ordermenu_>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// 工具类DataSet转换为List
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.ordermenu_> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.ordermenu_> Tmp = new List<Model.ordermenu_>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.ordermenu_ model = new Xiuse.Model.ordermenu_();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.OrderMenuId = (string)dr["OrderMenuId"];
                    model.OrderId = (string)dr["OrderId"];
                    model.MenuName = dr["MenuName"].ToString();
                    model.MenuPrice = (decimal)dr["MenuPrice"];
                    model.MenuTag = dr["MenuTag"].ToString();
                    model.MenuImage = dr["MenuImage"].ToString();
                    model.MenuInstruction = dr["MenuInstruction"].ToString();
                    model.DiscoutFlag = (short)dr["DiscoutFlag"];
                    model.DiscountName = dr["DiscountName"].ToString();
                    model.DiscountContent = (decimal)dr["DiscountContent"];
                    model.DiscountType = (short)dr["DiscountType"];
                    model.MenuServing = (short)dr["MenuServing"];
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
