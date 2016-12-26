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
    /// [xiuse_discount] 数据操作类
    /// </summary>
    public class xiuse_discount
    {
        public xiuse_discount(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_discount model)
        {
            string strSql=String.Format(@"Insert Into xiuse_discount(RestaurantId,DiscountName,DiscountType,DiscountContent,DiscountMenus,DiscountSection,DiscountState,DiscountVerification,DiscountTime) 
                                        values({0},'{1}',{2},{3},'{4}',{5},{6},{7},'{8}')",
                                        model.RestaurantId,model.DiscountName,model.DiscountType,model.DiscountContent,model.DiscountMenus,model.DiscountSection,model.DiscountState,model.DiscountVerification,model.DiscountTime);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_discount model)
        {
            string strSql=String.Format(@"Update xiuse_discount Set 
            RestaurantId={0},DiscountName='{1}',DiscountType={2},DiscountContent={3},DiscountMenus='{4}',DiscountSection={5},DiscountState={6},DiscountVerification={7},DiscountTime='{8}' 
            Where DiscountId={9}",
            model.RestaurantId,model.DiscountName,model.DiscountType,model.DiscountContent,model.DiscountMenus,model.DiscountSection,model.DiscountState,model.DiscountVerification,model.DiscountTime,model.DiscountId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <parame name="DiscountId">DiscountId</param>
        public bool Delete(string DiscountId)
        {
            string strSql=String.Format("Delete From xiuse_discount Where DiscountId={0}",DiscountId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <parame name="DiscountId">DiscountId</param>
        public bool Exists(string DiscountId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_discount Where DiscountId={0}",DiscountId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }
        


        /// <summary>
        /// 获取实体
        /// </summary>
         /// <parame name="DiscountId">DiscountId</param>
        public Xiuse.Model.xiuse_discount GetModel(string DiscountId)
        {
             string strSql=String.Format(@"Select * From xiuse_discount Where DiscountId={0}",DiscountId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.xiuse_discount  model=new Xiuse.Model.xiuse_discount();
                DataRow dr=ds.Tables[0].Rows[0];
				model.DiscountId=(string)dr["DiscountId"];
				model.RestaurantId=(string)dr["RestaurantId"];
				model.DiscountName=dr["DiscountName"].ToString();
				model.DiscountType=(byte)dr["DiscountType"];
				model.DiscountContent=(decimal)dr["DiscountContent"];
				model.DiscountMenus=dr["DiscountMenus"].ToString();
				model.DiscountSection=(byte)dr["DiscountSection"];
				model.DiscountState=(bool)dr["DiscountState"];
				model.DiscountVerification=(int)dr["DiscountVerification"];
				model.DiscountTime=dr["DiscountTime"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        #region 作者xcf  时间2016/12/19
        /// <summary>
        /// 获取餐厅所有的折扣信息
        /// </summary>
        /// <param name="RestaurantId">餐厅的Id</param>
        /// <returns></returns>
        public DataSet GetDiscountData(string RestaurantId)
        {
            string strSql = string.Format("Select * From xiuse_discount Where RestaurantId={0}", RestaurantId);
            return AosyMySql.ExecuteforDataSet(strSql);
        }
        /// <summary>
        /// 设置折扣的状态（1,启用；0，禁用;2,删除；）
        /// </summary>
        /// <param name="DiscountId">折扣的ID</param>
        /// <param name="State">折扣的状态（1,启用；0，禁用;2,删除；）</param>
        /// <returns></returns>
        public bool SetDiscountState(string DiscountId,int State)
        {
            string strSql = string.Format("update xiuse_discount set DiscountState={0} where DiscountId={1}", DiscountId,State);
            return AosyMySql.ExecuteforBool(strSql);
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
            #region 条件语句...
            StringBuilder strWhere=new StringBuilder();

            if(RestaurantId.ToString().Length>0)
                strWhere.Append(" And RestaurantId="+RestaurantId);
            

            if(DiscountName!=null && DiscountName.Length>0)
                strWhere.Append(" And DiscountName='"+DiscountName+"'");
            

            if(DiscountType.ToString().Length>0)
                strWhere.Append(" And DiscountType="+DiscountType);
            

            if(DiscountContent.ToString().Length>0)
                strWhere.Append(" And DiscountContent="+DiscountContent);
            

            if(DiscountMenus!=null && DiscountMenus.Length>0)
                strWhere.Append(" And DiscountMenus='"+DiscountMenus+"'");
            

            if(DiscountSection.ToString().Length>0)
                strWhere.Append(" And DiscountSection="+DiscountSection);
            

            if(DiscountState.ToString().Length>0)
                strWhere.Append(" And DiscountState="+DiscountState);
            

            if(DiscountVerification.ToString().Length>0)
                strWhere.Append(" And DiscountVerification="+DiscountVerification);
            

            if(DiscountTime!=null && DiscountTime.Length>0)
                strWhere.Append(" And DiscountTime='"+DiscountTime+"'");
            
            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From xiuse_discount Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From xiuse_discount Where");
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
            string strSql="Select "+ Fields +" From xiuse_discount";
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
            string strSql="Select "+ Fields +" From xiuse_discount";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From xiuse_discount";
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
            string strSql="Select * From xiuse_discount ";
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
            string strSql="Select * From xiuse_discount ";
            string countSql="Select Count(*) From xiuse_discount ";
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
            string sql = "update xiuse_discount set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

