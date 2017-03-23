using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [xiuse_restaurant] 数据操作类
    /// </summary>
    public class xiuse_restaurant
    {
        public xiuse_restaurant(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_restaurant model)
        {
            string strSql=String.Format(@"Insert Into xiuse_restaurant(RestaurantName,Phone,Site,Remark,Time) 
                                        values('{0}','{1}','{2}','{3}','{4}')",
                                        model.RestaurantName,model.Phone,model.Site,model.Remark,model.Time);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_restaurant model)
        {
            string strSql=String.Format(@"Update xiuse_restaurant Set 
            RestaurantName='{0}',Phone='{1}',Site='{2}',Remark='{3}',Time='{4}' 
            Where RestaurantId={5}",
            model.RestaurantName,model.Phone,model.Site,model.Remark,model.Time,model.RestaurantId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <parame name="RestaurantId">RestaurantId</param>
        public bool Delete(string RestaurantId)
        {
            string strSql=String.Format("Delete From xiuse_restaurant Where RestaurantId={0}",RestaurantId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <parame name="RestaurantId">RestaurantId</param>
        public bool Exists(string RestaurantId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_restaurant Where RestaurantId={0}",RestaurantId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }


        ///
        ///获取用户对应的所有餐厅
        ///
        public DataSet UserRestaurant(string UserId)
        {
            string strSql = string.Format(@"Select * from xiuse_restaurant where RestaurantId=(select RestaurantId from xiuse_user where UserId={0})", UserId);
            return AosyMySql.ExecuteforDataSet(strSql);
        }



        /// <summary>
        /// 获取实体
        /// </summary>
        /// <parame name="RestaurantId">RestaurantId</param>
        public Xiuse.Model.xiuse_restaurant GetModel(string RestaurantId)
        {
             string strSql=String.Format(@"Select * From xiuse_restaurant Where RestaurantId={0}",RestaurantId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.xiuse_restaurant  model=new Xiuse.Model.xiuse_restaurant();
                DataRow dr=ds.Tables[0].Rows[0];
				model.RestaurantId=(string)dr["RestaurantId"];
				model.RestaurantName=dr["RestaurantName"].ToString();
				model.Phone=dr["Phone"].ToString();
				model.Site=dr["Site"].ToString();
				model.Remark=dr["Remark"].ToString();
                model.Time = (DateTime)dr["Time"];
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
            #region 条件语句...
            StringBuilder strWhere=new StringBuilder();

            if(RestaurantName!=null && RestaurantName.Length>0)
                strWhere.Append(" And RestaurantName='"+RestaurantName+"'");
            

            if(Phone!=null && Phone.Length>0)
                strWhere.Append(" And Phone='"+Phone+"'");
            

            if(Site!=null && Site.Length>0)
                strWhere.Append(" And Site='"+Site+"'");
            

            if(Remark!=null && Remark.Length>0)
                strWhere.Append(" And Remark='"+Remark+"'");
            

            if(Time!=null && Time.Length>0)
                strWhere.Append(" And Time='"+Time+"'");
            
            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From xiuse_restaurant Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From xiuse_restaurant Where");
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
            string strSql="Select "+ Fields +" From xiuse_restaurant";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
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
            string strSql="Select "+ Fields +" From xiuse_restaurant";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From xiuse_restaurant";
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
            string strSql="Select * From xiuse_restaurant ";
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
            string strSql="Select * From xiuse_restaurant ";
            string countSql="Select Count(*) From xiuse_restaurant ";
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
            string sql = "update xiuse_restaurant set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

