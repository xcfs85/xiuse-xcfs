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
    /// [xiuse_menuclassify] 业务逻辑处理
    /// </summary>
    public class xiuse_menuclassify 
    {
       
        private readonly Xiuse.DAL.xiuse_menuclassify dal=new Xiuse.DAL.xiuse_menuclassify();

        public xiuse_menuclassify(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_menuclassify model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_menuclassify model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="ClassifyId">ClassifyId</param>
        public bool Delete(string ClassifyId)
        {
            return dal.Delete(ClassifyId);
        }
        
        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <param name="ClassifyId">ClassifyId</param>
        public bool Exists(string ClassifyId)
        {
            return dal.Exists(ClassifyId);
        }

        /// <summary>
        ///  判断饭店是否存在
        /// </summary>
        public bool ExistsRestaurant(string RestaurantId)
        {
            return dal.Exists(RestaurantId);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="ClassifyId">ClassifyId</param>
        public Xiuse.Model.xiuse_menuclassify GetModel(string ClassifyId)
        {
            return dal.GetModel(ClassifyId);
        }
        

		/// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">品餐分类介绍[ClassifyInstruction]</param>
        /// <param name="">餐品排列顺序[ClassifyNo]</param>
        /// <param name="">隐藏分类 (网上点单客户无法使用) 1,隐藏分类。0不隐藏分类。[ClassifyNet]</param>
        /// <param name="">[ClassifyTag]</param>
        /// <param name="">分类更新时间[ClassifyTime]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string ClassifyInstruction,int ClassifyNo,int ClassifyNet,string ClassifyTag,string ClassifyTime, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(ClassifyInstruction,ClassifyNo,ClassifyNet,ClassifyTag,ClassifyTime,StartIndex,PageSize,out count);
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


        ///获取当前餐厅的所有菜品分类，条件餐厅ID
        ///以list形式返回
        /// 
        public List<Xiuse.Model.xiuse_menuclassify> GetAllMenuClassify(string ResaurantId)
        {
            return DataSetTransModelListNoExpand(GetData("*", "Resaurant=" + ResaurantId));
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
       private List<Xiuse.Model.xiuse_menuclassify> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_menuclassify> list = new List<Xiuse.Model.xiuse_menuclassify>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_menuclassify>(dataSet, 0));
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
       private  Xiuse.Model.xiuse_menuclassify DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_menuclassify>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// 工具类DataSet转换为List
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
      private  List<Xiuse.Model.xiuse_menuclassify> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_menuclassify> Tmp = new List<Model.xiuse_menuclassify>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_menuclassify model = new Xiuse.Model.xiuse_menuclassify();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.ClassifyId = (string)dr["ClassifyId"];
                    model.ClassifyInstruction = dr["ClassifyInstruction"].ToString();
                    model.ClassifyNo = (int)dr["ClassifyNo"];
                    model.ClassifyNet = (int)dr["ClassifyNet"];
                    model.ClassifyTag = dr["ClassifyTag"].ToString();
                    model.ClassifyTime = dr["ClassifyTime"].ToString();
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
