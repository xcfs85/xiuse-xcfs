using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [xiuse_rebates] 数据操作类
    /// </summary>
    public class xiuse_rebates
    {
        public xiuse_rebates(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_rebates model)
        {
            string strSql=String.Format(@"Insert Into xiuse_rebates(MemberId,MemberCardNo,RebatesType,RebatesAmount,DateTime,RebatesId) 
                                        values('{0}','{1}','{2}',{3},'{4}','{5}')",
                                        model.MemberId,model.MemberCardNo,model.RebatesType,model.RebatesAmount,model.DateTime,model.RebatesId);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_rebates model)
        {
            string strSql=String.Format(@"Update xiuse_rebates Set 
            MemberId='{0}',MemberCardNo='{1}',RebatesType='{2}',RebatesAmount='{3}',DateTime='{4}' 
            Where RebatesId={5}",
            model.MemberId,model.MemberCardNo,model.RebatesType,model.RebatesAmount,model.DateTime,model.RebatesId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <parame name="RebatesId">RebatesId</param>
        public bool Delete(string RebatesId)
        {
            string strSql=String.Format("Delete From xiuse_rebates Where RebatesId='{0}'",RebatesId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <parame name="RebatesId">RebatesId</param>
        public bool Exists(string RebatesId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_rebates Where RebatesId='{0}'",RebatesId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }
        


        /// <summary>
        /// 获取实体
        /// </summary>
         /// <parame name="RebatesId">RebatesId</param>
        public Xiuse.Model.xiuse_rebates GetModel(string RebatesId)
        {
             string strSql=String.Format(@"Select * From xiuse_rebates Where RebatesId='{0}'",RebatesId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.xiuse_rebates  model=new Xiuse.Model.xiuse_rebates();
                DataRow dr=ds.Tables[0].Rows[0];
				model.RebatesId=dr["RebatesId"].ToString();
				model.MemberId=dr["MemberId"].ToString();
				model.MemberCardNo=dr["MemberCardNo"].ToString();
				model.RebatesType=dr["RebatesType"].ToString();
				model.RebatesAmount=(decimal)dr["RebatesAmount"];
				model.DateTime= (DateTime)dr["DateTime"];
                return model;
            }
            else
            {
                return null;
            }
        }
        #region 作者 xcf 时间 2016/12/17
        /// <summary>
        /// 获取餐厅的的所有的会员的返现记录
        /// </summary>
        /// <param name="RestaurantId">餐厅的Id</param>
        /// <returns></returns>
        public DataSet GetModelAt(string RestaurantId)
        {
            string strSql = string.Format(@"SELECT xiuse.xiuse_rebates.* FROM
                                    xiuse.xiuse_rebates LEFT JOIN xiuse.xiuse_member on
                                    xiuse_rebates.MemberId = xiuse_member.MemberId
                                    where xiuse_member.RestaurantId='{0}'", RestaurantId);
            return AosyMySql.ExecuteforDataSet(strSql);
        }
        /// <summary>
        /// 搜索餐厅内会员的的返现记录
        /// </summary>
        /// <param name="RestaurantId">餐厅ID</param>
        /// <param name="Condition">搜索条件</param>
        /// <returns></returns>
        public DataSet Search(string RestaurantId,string Condition)
        {
            string strSql = string.Format(@"SELECT xiuse.xiuse_rebates.* FROM
                                 xiuse.xiuse_rebates LEFT JOIN xiuse.xiuse_member on 
                                 xiuse_rebates.MemberId = xiuse_member.MemberId 
                                 where xiuse_member.RestaurantId='{0}'  
                                 and (xiuse_member.MemberCell LIKE '%{1}%'  
                                 OR xiuse_member.MemberCardNo like '%{1}%' 
                                 OR xiuse_member.MemberName LIKE '%{1}%')", RestaurantId,Condition);
            return AosyMySql.ExecuteforDataSet(strSql);
        }
        #endregion

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">会员Id[MemberId]</param>
        /// <param name="">会员卡号[MemberCardNo]</param>
        /// <param name="">返现类型[RebatesType]</param>
        /// <param name="">返现金额[RebatesAmount]</param>
        /// <param name="">日期[DateTime]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string MemberId,string MemberCardNo,string RebatesType,decimal RebatesAmount,string DateTime, int StartIndex, int PageSize, out int RecordCount)
        {
            #region 条件语句...
            StringBuilder strWhere=new StringBuilder();

            if(MemberId!=null && MemberId.Length>0)
                strWhere.Append(" And MemberId='"+MemberId+"'");
            

            if(MemberCardNo!=null && MemberCardNo.Length>0)
                strWhere.Append(" And MemberCardNo='"+MemberCardNo+"'");
            

            if(RebatesType!=null && RebatesType.Length>0)
                strWhere.Append(" And RebatesType='"+RebatesType+"'");
            

            if(RebatesAmount.ToString().Length>0)
                strWhere.Append(" And RebatesAmount="+RebatesAmount);
            

            if(DateTime!=null && DateTime.Length>0)
                strWhere.Append(" And DateTime='"+DateTime+"'");
            
            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From xiuse_rebates Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From xiuse_rebates Where");
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
            string strSql="Select "+ Fields +" From xiuse_rebates";
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
            string strSql="Select "+ Fields +" From xiuse_rebates";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From xiuse_rebates";
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
            string strSql="Select * From xiuse_rebates ";
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
            string strSql="Select * From xiuse_rebates ";
            string countSql="Select Count(*) From xiuse_rebates ";
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
            string sql = "update xiuse_rebates set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

