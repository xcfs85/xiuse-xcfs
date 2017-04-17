using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [xiuse_menuclassify] 数据操作类
    /// </summary>
    public class xiuse_menuclassify
    {
        public xiuse_menuclassify(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_menuclassify model)
        {
            string strSql=String.Format(@"Insert Into xiuse_menuclassify(ClassifyInstruction,ClassifyNo,ClassifyNet,ClassifyTag,ClassifyTime,ClassifyId,RestaurantId) 
                                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                                        model.ClassifyInstruction,model.ClassifyNo,model.ClassifyNet,model.ClassifyTag,model.ClassifyTime,model.ClassifyId,model.RestaurantId);

            return AosyMySql.ExecuteforBool(strSql);
        }



        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_menuclassify model)
        {
            string strSql=String.Format(@"Update xiuse_menuclassify Set 
            ClassifyInstruction='{0}',ClassifyNo='{1}',ClassifyNet='{2}',ClassifyTag='{3}',ClassifyTime='{4}' 
            Where ClassifyId='{5}'",
            model.ClassifyInstruction,model.ClassifyNo,model.ClassifyNet,model.ClassifyTag,model.ClassifyTime,model.ClassifyId);
            return AosyMySql.ExecuteforBool(strSql);
        }


        public bool UpdateList(List<Xiuse.Model.xiuse_menuclassify> lst, Model.xiuse_menuclassify MenuModel)
        {
            List<string> newList = new List<string>();
            foreach (Model.xiuse_menuclassify model in lst)
            {
                string strSql = String.Format(@"update xiuse_menuclassify set ClassifyNo='{0}' where ClassifyId='{1}'",model.ClassifyNo,model.ClassifyId);
                newList.Add(strSql);
            }
            string strSql2 = String.Format(@"update xiuse_menuclassify set ClassifyInstruction ='{0}',ClassifyTag='{1}', ClassifyTime='{2}' where ClassifyId='{3}'", MenuModel.ClassifyInstruction, MenuModel.ClassifyTag, MenuModel.ClassifyTime,MenuModel.ClassifyId);
            newList.Add(strSql2);
            return AosyMySql.ExecuteListSQL(newList)==lst.Count+1;
        }


        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <parame name="ClassifyId">ClassifyId</param>
        public bool Delete(string ClassifyId)
        {
            string strSql=String.Format("Delete From xiuse_menuclassify Where ClassifyId='{0}'",ClassifyId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        /// <summary>
        /// 删除，并更新多条记录
        /// </summary>
        /// <param name="ClassifyId"></param>
        /// <param name="lst"></param>
        /// <returns></returns>
        public bool DeleteList(string ClassifyId, List<Xiuse.Model.xiuse_menuclassify> lst)
        {
            List<string> newList = new List<string>();
            string strSql= String.Format("Delete From xiuse_menuclassify Where ClassifyId='{0}'", ClassifyId);
            newList.Add(strSql);
            foreach (Model.xiuse_menuclassify model in lst)
            {
                strSql = String.Format(@"update xiuse_menuclassify set ClassifyNo='{0}' where ClassifyId='{1}'", model.ClassifyNo, model.ClassifyId);
                newList.Add(strSql);
            }
            return AosyMySql.ExecuteListSQL(newList) == (lst.Count+1);
        }

        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <parame name="ClassifyId">ClassifyId</param>
        public bool Exists(string ClassifyId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_menuclassify Where ClassifyId='{0}'",ClassifyId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }


        /// <summary>
        ///  判断这个饭店是否存在
        /// </summary>
        /// <parame name="ClassifyId">ClassifyId</param>
        public bool ExistsRestaurant(string RestaurantId)
        {
            string strSql = String.Format("Select Count(1) From xiuse_menuclassify Where Restaurant='{0}'", RestaurantId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString()) > 0;
        }


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <parame name="ClassifyId">ClassifyId</param>
        public Xiuse.Model.xiuse_menuclassify GetModel(string ClassifyId)
        {
             string strSql=String.Format(@"Select * From xiuse_menuclassify Where ClassifyId='{0}'",ClassifyId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.xiuse_menuclassify  model=new Xiuse.Model.xiuse_menuclassify();
                DataRow dr=ds.Tables[0].Rows[0];
				model.ClassifyId=(string)dr["ClassifyId"];
				model.ClassifyInstruction=dr["ClassifyInstruction"].ToString();
				model.ClassifyNo=(int)dr["ClassifyNo"];
				model.ClassifyNet=(short)dr["ClassifyNet"];
				model.ClassifyTag=dr["ClassifyTag"].ToString();
				model.ClassifyTime=(DateTime)dr["ClassifyTime"];
                model.RestaurantId = dr["RestaurantId"].ToString();
                return model;
            }
            else
            {
                return null;
            }
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
        public DataSet Search(string ClassifyInstruction,int ClassifyNo,short ClassifyNet,string ClassifyTag,string ClassifyTime, int StartIndex, int PageSize, out int RecordCount)
        {
            #region 条件语句...
            StringBuilder strWhere=new StringBuilder();

            if(ClassifyInstruction!=null && ClassifyInstruction.Length>0)
                strWhere.Append(" And ClassifyInstruction='"+ClassifyInstruction+"'");
            

            if(ClassifyNo.ToString().Length>0)
                strWhere.Append(" And ClassifyNo="+ClassifyNo);
            

            if(ClassifyNet.ToString().Length>0)
                strWhere.Append(" And ClassifyNet="+ClassifyNet);
            

            if(ClassifyTag!=null && ClassifyTag.Length>0)
                strWhere.Append(" And ClassifyTag='"+ClassifyTag+"'");
            

            if(ClassifyTime!=null && ClassifyTime.Length>0)
                strWhere.Append(" And ClassifyTime='"+ClassifyTime+"'");
            
            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From xiuse_menuclassify Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From xiuse_menuclassify Where");
            countSql.Append(where);

            int count=0;
            DataSet ds=AosyMySql.ExecuteforDataSet(StartIndex,PageSize,out count,strSql.ToString(),countSql.ToString());
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
            string strSql="Select "+ Fields +" From xiuse_menuclassify";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            return AosyMySql.ExecuteforDataSet(strSql);
        }
        /// <summary>
        /// 更新菜品分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataSet GetClassifies(string RestaurantId,string ClassifyId)
        {
            string strSql = String.Format(@"select * from xiuse_menuclassify where RestaurantId='{0}'and ClassifyId<>'{1}' order by ClassifyNo asc ",RestaurantId, ClassifyId);
            return AosyMySql.ExecuteforDataSet(strSql);
        }

        /// <summary>
        /// 获取数据[用于分页]
        /// </summary>
        /// <param name="Fields">字段字符串[全部为*]</param>
        /// <param name="Wheres">条件[可为空]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet GetData(string Fields, string Wheres, int StartIndex, int PageSize, out int RecordCount)
        {
            string strSql="Select "+ Fields +" From xiuse_menuclassify";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From xiuse_menuclassify";
	    if(Wheres.Length>0)countSql+=" Where "+ Wheres +"";
            int count=0;
            DataSet ds=AosyMySql.ExecuteforDataSet(StartIndex,PageSize,out count,strSql,countSql);
            RecordCount=count;
            return ds;
        }
        

    
        /// <summary>
        /// 获取全部数据
        /// </summary>
        public DataSet GetAll()
        {
            string strSql="Select * From xiuse_menuclassify ";
            return AosyMySql.ExecuteforDataSet(strSql);
        }


        /// <summary>
        /// 获取全部数据[用于分页]
        /// </summary>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet GetAll(int StartIndex, int PageSize, out int RecordCount)
        {
            string strSql="Select * From xiuse_menuclassify ";
            string countSql="Select Count(*) From xiuse_menuclassify ";
            int count=0;
            DataSet ds=AosyMySql.ExecuteforDataSet(StartIndex,PageSize,out count,strSql,countSql);
            RecordCount=count;
            return ds;
        }

        /// <summary>
        /// 执行更新SQL语句
        /// </summary>
        /// <param name="filed">要更新的字段，例：["name='"+name+"',pwd='"+pwd+"'"]</param>
        /// <param name="wheres">更新条件，例：["id="+id]</param>
        /// <returns></returns>
        public int ExecuteUpdate(string updatefield, string wheres)
        {
            string sql = "update xiuse_menuclassify set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

