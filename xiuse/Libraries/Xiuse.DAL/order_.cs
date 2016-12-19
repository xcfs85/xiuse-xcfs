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
    /// [order_] 数据操作类
    /// </summary>
    public class order_
    {
        public order_(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.order_ model)
        {
            string strSql=String.Format(@"Insert Into order_(DeskId,BillAmount,AccountsPayable,Refunds,DishCount,OrderState,Cash,BankCard,WeiXin,Alipay,MembersCard,OrderbeginTime,OrderEndTime) 
                                        values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},'{11}','{12}')",
                                        model.DeskId,model.BillAmount,model.AccountsPayable,model.Refunds,model.DishCount,model.OrderState,model.Cash,model.BankCard,model.WeiXin,model.Alipay,model.MembersCard,model.OrderbeginTime,model.OrderEndTime);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.order_ model)
        {
            string strSql=String.Format(@"Update order_ Set 
            DeskId={0},BillAmount={1},AccountsPayable={2},Refunds={3},DishCount={4},OrderState={5},Cash={6},BankCard={7},WeiXin={8},Alipay={9},MembersCard={10},OrderbeginTime='{11}',OrderEndTime='{12}', ClearDeskState={13}
            Where OrderId={14}",
            model.DeskId,model.BillAmount,model.AccountsPayable,model.Refunds,model.DishCount,model.OrderState,model.Cash,model.BankCard,model.WeiXin,model.Alipay,model.MembersCard,model.OrderbeginTime,model.OrderEndTime,model.ClearDeskState,model.OrderId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <parame name="OrderId">OrderId</param>
        public bool Delete(string OrderId)
        {
            string strSql=String.Format("Delete From order_ Where OrderId={0}",OrderId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <parame name="OrderId">OrderId</param>
        public bool Exists(string OrderId)
        {
            string strSql=String.Format("Select Count(1) From order_ Where OrderId={0}",OrderId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }
        


        /// <summary>
        /// 获取实体
        /// </summary>
         /// <parame name="OrderId">OrderId</param>
        public Xiuse.Model.order_ GetModel(string OrderId)
        {
             string strSql=String.Format(@"Select * From order_ Where OrderId={0}",OrderId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.order_  model=new Xiuse.Model.order_();
                DataRow dr=ds.Tables[0].Rows[0];
				model.OrderId=dr["OrderId"].ToString();
				model.DeskId=(string)dr["DeskId"];
				model.BillAmount=(decimal)dr["BillAmount"];
				model.AccountsPayable=(decimal)dr["AccountsPayable"];
				model.Refunds=(decimal)dr["Refunds"];
				model.DishCount=(byte)dr["DishCount"];
				model.OrderState=(byte)dr["OrderState"];
				model.Cash=(decimal)dr["Cash"];
				model.BankCard=(decimal)dr["BankCard"];
				model.WeiXin=(decimal)dr["WeiXin"];
				model.Alipay=(decimal)dr["Alipay"];
				model.MembersCard=(decimal)dr["MembersCard"];
				model.OrderbeginTime=dr["OrderbeginTime"].ToString();
				model.OrderEndTime=dr["OrderEndTime"].ToString();
                model.ClearDeskState = (byte)dr["ClearDeskState"];
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
        /// <param name="">餐桌Id[DeskId]</param>
        /// <param name="">账单[BillAmount]</param>
        /// <param name="">应付款[AccountsPayable]</param>
        /// <param name="">退款[Refunds]</param>
        /// <param name="">菜品数量[DishCount]</param>
        /// <param name="">订单状态（0，未支付；1，已支付）[OrderState]</param>
        /// <param name="">现金付款[Cash]</param>
        /// <param name="">银行卡付款[BankCard]</param>
        /// <param name="">微信付款[WeiXin]</param>
        /// <param name="">支付宝付款[Alipay]</param>
        /// <param name="">会员卡付款[MembersCard]</param>
        /// <param name="">下单时间[OrderbeginTime]</param>
        /// <param name="">用餐结束时间[OrderEndTime]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string DeskId,decimal BillAmount,decimal AccountsPayable,decimal Refunds,byte DishCount,byte OrderState,decimal Cash,decimal BankCard,decimal WeiXin,decimal Alipay,decimal MembersCard,string OrderbeginTime,string OrderEndTime,byte ClearDeskState, int StartIndex, int PageSize, out int RecordCount)
        {
            #region 条件语句...
            StringBuilder strWhere=new StringBuilder();

            if(DeskId.ToString().Length>0)
                strWhere.Append(" And DeskId="+DeskId);
            

            if(BillAmount.ToString().Length>0)
                strWhere.Append(" And BillAmount="+BillAmount);
            

            if(AccountsPayable.ToString().Length>0)
                strWhere.Append(" And AccountsPayable="+AccountsPayable);
            

            if(Refunds.ToString().Length>0)
                strWhere.Append(" And Refunds="+Refunds);
            

            if(DishCount.ToString().Length>0)
                strWhere.Append(" And DishCount="+DishCount);
            

            if(OrderState.ToString().Length>0)
                strWhere.Append(" And OrderState="+OrderState);
            

            if(Cash.ToString().Length>0)
                strWhere.Append(" And Cash="+Cash);
            

            if(BankCard.ToString().Length>0)
                strWhere.Append(" And BankCard="+BankCard);
            

            if(WeiXin.ToString().Length>0)
                strWhere.Append(" And WeiXin="+WeiXin);
            

            if(Alipay.ToString().Length>0)
                strWhere.Append(" And Alipay="+Alipay);
            

            if(MembersCard.ToString().Length>0)
                strWhere.Append(" And MembersCard="+MembersCard);
            

            if(OrderbeginTime!=null && OrderbeginTime.Length>0)
                strWhere.Append(" And OrderbeginTime='"+OrderbeginTime+"'");

            
            if (OrderEndTime!=null && OrderEndTime.Length>0)
                strWhere.Append(" And OrderEndTime='"+OrderEndTime+"'");

            if (ClearDeskState.ToString().Length > 0)
                strWhere.Append(" And ClearDeskState='" + ClearDeskState + "'");

            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From order_ Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From order_ Where");
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
            string strSql="Select "+ Fields +" From order_";
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
            string strSql="Select "+ Fields +" From order_";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From order_";
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
            string strSql="Select * From order_ ";
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
            string strSql="Select * From order_ ";
            string countSql="Select Count(*) From order_ ";
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
            string sql = "update order_ set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

