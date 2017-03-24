using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [memberconsumption] 数据操作类
    /// </summary>
    public class memberconsumption
    {
        public memberconsumption(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.memberconsumption model)
        {
            string strSql=String.Format(@"Insert Into memberconsumption(MemberId,MemberCardNo,CRecordsType,Amount,Balance,ConsumptionTime,OrderId) 
                                        values({0},{1},{2},{3},{4},'{5}',{6})",
                                        model.MemberId,model.MemberCardNo,model.CRecordsType,model.Amount,model.Balance,model.ConsumptionTime,model.OrderId);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.memberconsumption model)
        {
            string strSql=String.Format(@"Update memberconsumption Set 
            MemberId='{0}',MemberCardNo={1},CRecordsType={2},Amount={3},Balance={4},ConsumptionTime='{5}',OrderId={6} 
            Where ConsumptionRecordsId={7}",
            model.MemberId,model.MemberCardNo,model.CRecordsType,model.Amount,model.Balance,model.ConsumptionTime,model.OrderId,model.ConsumptionRecordsId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <parame name="ConsumptionRecordsId">ConsumptionRecordsId</param>
        public bool Delete(string ConsumptionRecordsId)
        {
            string strSql=String.Format("Delete From memberconsumption Where ConsumptionRecordsId='{0}'",ConsumptionRecordsId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <parame name="ConsumptionRecordsId">ConsumptionRecordsId</param>
        public bool Exists(string ConsumptionRecordsId)
        {
            string strSql=String.Format("Select Count(1) From memberconsumption Where ConsumptionRecordsId='{0}'",ConsumptionRecordsId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }
        


        /// <summary>
        /// 获取实体
        /// </summary>
         /// <parame name="ConsumptionRecordsId">ConsumptionRecordsId</param>
        public Xiuse.Model.memberconsumption GetModel(string ConsumptionRecordsId)
        {
             string strSql=String.Format(@"Select * From memberconsumption Where ConsumptionRecordsId='{0}'",ConsumptionRecordsId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.memberconsumption  model=new Xiuse.Model.memberconsumption();
                DataRow dr=ds.Tables[0].Rows[0];
				model.ConsumptionRecordsId=(string)dr["ConsumptionRecordsId"];
				model.MemberId=(string)dr["MemberId"];
				model.MemberCardNo=(string)dr["MemberCardNo"];
				model.CRecordsType=(byte)dr["CRecordsType"];
				model.Amount=(decimal)dr["Amount"];
				model.Balance=(decimal)dr["Balance"];
				model.ConsumptionTime=dr["ConsumptionTime"].ToString();
				model.OrderId=(string)dr["OrderId"];
                return model;
            }
            else
            {
                return null;
            }
        }
        #region 作者 xcf   时间：2016/12/16
        /// <summary>
        /// 获取餐厅内的会员消费记录
        /// </summary>
        /// <param name="RestaurantId">餐厅ID</param>
        /// <returns></returns>
        public DataSet GetModels(string RestaurantId)
        {
            string strSql = string.Format(@"select memberconsumption.* from 
                            memberconsumption left join xiuse_member on memberconsumption.MemberId = xiuse_member.MemberId
                            where xiuse.xiuse_member.RestaurantId = '{0}'", RestaurantId);
            return AosyMySql.ExecuteforDataSet(strSql);
        }

        /// <summary>
        /// 搜索餐厅内的会员消费记录
        /// </summary>
        /// <param name="RestaurantId">餐厅Id</param>
        /// <param name="Condition">搜索条件：会员名称、会员卡号、会员手机号</param>
        /// <returns></returns>
        public DataSet Search(string RestaurantId,string Condition)
        {
            string strSql = string.Format(@"select memberconsumption.* from 
                            memberconsumption left join xiuse_member on memberconsumption.MemberId = xiuse_member.MemberId
                            where xiuse.xiuse_member.RestaurantId = '{0}' 
                            and (xiuse_member.MemberCardNo like '%{1}%' 
                            or xiuse_member.MemberCell like '%{1}%' 
                            or xiuse_member.MemberName like '%{1}%')"
                            , RestaurantId,Condition);
            return AosyMySql.ExecuteforDataSet(strSql);
        }
        #endregion


        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">会员Id[MemberId]</param>
        /// <param name="">会员卡卡号[MemberCardNo]</param>
        /// <param name="">消费类型[CRecordsType]</param>
        /// <param name="">消费金额[Amount]</param>
        /// <param name="">余额[Balance]</param>
        /// <param name="">消费日期[ConsumptionTime]</param>
        /// <param name="">订单Id[OrderId]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string MemberId,string MemberCardNo,byte CRecordsType,decimal Amount,decimal Balance,string ConsumptionTime,string OrderId, int StartIndex, int PageSize, out int RecordCount)
        {
            #region 条件语句...
            StringBuilder strWhere=new StringBuilder();

            if(MemberId.ToString().Length>0)
                strWhere.Append(" And MemberId="+MemberId);
            

            if(MemberCardNo.ToString().Length>0)
                strWhere.Append(" And MemberCardNo="+MemberCardNo);
            

            if(CRecordsType.ToString().Length>0)
                strWhere.Append(" And CRecordsType="+CRecordsType);
            

            if(Amount.ToString().Length>0)
                strWhere.Append(" And Amount="+Amount);
            

            if(Balance.ToString().Length>0)
                strWhere.Append(" And Balance="+Balance);
            

            if(ConsumptionTime!=null && ConsumptionTime.Length>0)
                strWhere.Append(" And ConsumptionTime='"+ConsumptionTime+"'");
            

            if(OrderId.ToString().Length>0)
                strWhere.Append(" And OrderId="+OrderId);
            
            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From memberconsumption Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From memberconsumption Where");
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
            string strSql="Select "+ Fields +" From memberconsumption";
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
            string strSql="Select "+ Fields +" From memberconsumption";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From memberconsumption";
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
            string strSql="Select * From memberconsumption ";
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
            string strSql="Select * From memberconsumption ";
            string countSql="Select Count(*) From memberconsumption ";
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
            string sql = "update memberconsumption set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

