using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;
using MySql.Data.MySqlClient;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [xiuse_desk] 数据操作类
    /// </summary>
    public class xiuse_desk
    {
        public xiuse_desk(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_desk model)
        {
            string strSql=String.Format(@"Insert Into xiuse_desk(RestaurantId,DeskName,TakeOut,DeskDel,DeskState,DeskTime) 
                                        values('{0}','{1}',{2},{3},{4},'{5}')",
                                        model.RestaurantId,model.DeskName,model.TakeOut,model.DeskDel,model.DeskState,model.DeskTime);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_desk model)
        {
            string strSql=String.Format(@"Update xiuse_desk Set 
            RestaurantId='{0}',DeskName='{1}',TakeOut={2},DeskDel={3},DeskState={4},DeskTime='{5}' 
            Where DeskId={6}",
            model.RestaurantId,model.DeskName,model.TakeOut,model.DeskDel,model.DeskState,model.DeskTime,model.DeskId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <parame name="DeskId">DeskId</param>
        public bool Delete(string DeskId)
        {
            string strSql=String.Format("Delete From xiuse_desk Where DeskId={0}",DeskId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <parame name="DeskId">DeskId</param>
        public bool Exists(string DeskId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_desk Where DeskId={0}",DeskId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }
        


        /// <summary>
        /// 获取实体
        /// </summary>
         /// <parame name="DeskId">DeskId</param>
        public Xiuse.Model.xiuse_desk GetModel(string DeskId)
        {
             string strSql=String.Format(@"Select * From xiuse_desk Where DeskId={0}",DeskId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.xiuse_desk  model=new Xiuse.Model.xiuse_desk();
                DataRow dr=ds.Tables[0].Rows[0];
				model.DeskId=(string)dr["DeskId"];
				model.RestaurantId=dr["RestaurantId"].ToString();
				model.DeskName=dr["DeskName"].ToString();
				model.TakeOut=(bool)dr["TakeOut"];
				model.DeskDel=(bool)dr["DeskDel"];
				model.DeskState=(byte)dr["DeskState"];
				model.DeskTime=dr["DeskTime"].ToString();
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
        /// <param name="">餐厅ID[RestaurantId]</param>
        /// <param name="">餐桌名称[DeskName]</param>
        /// <param name="">是否接受外卖（0，不接受外卖。1接受外卖）[TakeOut]</param>
        /// <param name="">0,已删除。1正常[DeskDel]</param>
        /// <param name="">餐桌的状态：0，空桌；1，未支付；2，已支付；[DeskState]</param>
        /// <param name="">更新时间[DeskTime]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string RestaurantId,string DeskName,bool TakeOut,bool DeskDel,byte DeskState,string DeskTime, int StartIndex, int PageSize, out int RecordCount)
        {
            #region 条件语句...
            StringBuilder strWhere=new StringBuilder();

            if(RestaurantId!=null && RestaurantId.Length>0)
                strWhere.Append(" And RestaurantId='"+RestaurantId+"'");
            

            if(DeskName!=null && DeskName.Length>0)
                strWhere.Append(" And DeskName='"+DeskName+"'");
            

            if(TakeOut.ToString().Length>0)
                strWhere.Append(" And TakeOut="+TakeOut);
            

            if(DeskDel.ToString().Length>0)
                strWhere.Append(" And DeskDel="+DeskDel);
            

            if(DeskState.ToString().Length>0)
                strWhere.Append(" And DeskState="+DeskState);
            

            if(DeskTime!=null && DeskTime.Length>0)
                strWhere.Append(" And DeskTime='"+DeskTime+"'");
            
            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From xiuse_desk Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From xiuse_desk Where");
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
            string strSql="Select "+ Fields +" From xiuse_desk";
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
            string strSql="Select "+ Fields +" From xiuse_desk";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From xiuse_desk";
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
            string strSql="Select * From xiuse_desk ";
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
            string strSql="Select * From xiuse_desk ";
            string countSql="Select Count(*) From xiuse_desk ";
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
            string sql = "update xiuse_desk set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

