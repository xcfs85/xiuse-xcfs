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
    /// [xiuse_memberclassify] 业务逻辑处理
    /// </summary>
    public class xiuse_memberclassify 
    {
       
        private readonly Xiuse.DAL.xiuse_memberclassify dal=new Xiuse.DAL.xiuse_memberclassify();

        public xiuse_memberclassify(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_memberclassify model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_memberclassify model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="MemberClassifyId">MemberClassifyId</param>
        public bool Delete(string MemberClassifyId)
        {
            return dal.Delete(MemberClassifyId);
        }
        
        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <param name="MemberClassifyId">MemberClassifyId</param>
        public bool Exists(string MemberClassifyId)
        {
            return dal.Exists(MemberClassifyId);
        }
        
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="MemberClassifyId">MemberClassifyId</param>
        public Xiuse.Model.xiuse_memberclassify GetModel(string MemberClassifyId)
        {
            return dal.GetModel(MemberClassifyId);
        }

        #region 作者xcf  修改时间 2016/12/18

        /// <summary>
        /// 获取餐厅的所有的会员类型
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        public List<Model.xiuse_memberclassify> GetModels(string RestaurantId)
        {
            return DataSetTransModelListNoExpand(dal.GetData("*","RestaurantId='"+RestaurantId+"'and DelTag=0"));
        }

        /// <summary>
        /// 设置会员类型的状态（0,启用；1，停用；2，删除。）
        /// </summary>
        /// <param name="State">（0,启用；1，停用；2，删除。）</param>
        /// <param name="MemberClassifyId">会员类别Id</param>
        /// <returns></returns>
        public bool SetMemberClassify(int State, string MemberClassifyId)
        {
            return dal.SetMemberClassify(State,MemberClassifyId);
        }
        #endregion

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">折扣ID[DiscountId]</param>
        /// <param name="">类型名称[ClassifyName]</param>
        /// <param name="">说明[ClassRemark]</param>
        /// <param name="">会员数量[ClassifyMemberNum]</param>
        /// <param name="">修改时间[ClassifyTime]</param>
        /// <param name="">删除标志，(0,启用；1，停用；2，删除。)[DelTag]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string DiscountId,string ClassifyName,string ClassRemark,int ClassifyMemberNum,string ClassifyTime,byte DelTag,string RestaurantId, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(DiscountId,ClassifyName,ClassRemark,ClassifyMemberNum,ClassifyTime,DelTag, RestaurantId, StartIndex,PageSize,out count);
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
        private List<Xiuse.Model.xiuse_memberclassify> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_memberclassify> list = new List<Xiuse.Model.xiuse_memberclassify>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_memberclassify>(dataSet, 0));
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
        private Xiuse.Model.xiuse_memberclassify DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_memberclassify>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// 工具类DataSet转换为List
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_memberclassify> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_memberclassify> Tmp = new List<Model.xiuse_memberclassify>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_memberclassify model = new Xiuse.Model.xiuse_memberclassify();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.MemberClassifyId = (string)dr["MemberClassifyId"];
                    model.DiscountId = (string)dr["DiscountId"];
                    model.ClassifyName = dr["ClassifyName"].ToString();
                    model.ClassRemark = dr["ClassRemark"].ToString();
                    model.ClassifyMemberNum = (int)dr["ClassifyMemberNum"];
                    model.ClassifyTime = (DateTime)dr["ClassifyTime"];
                    model.DelTag = (byte)dr["DelTag"];
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
