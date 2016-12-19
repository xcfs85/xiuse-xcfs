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
    /// [order_] ���ݲ�����
    /// </summary>
    public class order_
    {
        public order_(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.order_ model)
        {
            string strSql=String.Format(@"Insert Into order_(DeskId,BillAmount,AccountsPayable,Refunds,DishCount,OrderState,Cash,BankCard,WeiXin,Alipay,MembersCard,OrderbeginTime,OrderEndTime) 
                                        values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},'{11}','{12}')",
                                        model.DeskId,model.BillAmount,model.AccountsPayable,model.Refunds,model.DishCount,model.OrderState,model.Cash,model.BankCard,model.WeiXin,model.Alipay,model.MembersCard,model.OrderbeginTime,model.OrderEndTime);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.order_ model)
        {
            string strSql=String.Format(@"Update order_ Set 
            DeskId={0},BillAmount={1},AccountsPayable={2},Refunds={3},DishCount={4},OrderState={5},Cash={6},BankCard={7},WeiXin={8},Alipay={9},MembersCard={10},OrderbeginTime='{11}',OrderEndTime='{12}', ClearDeskState={13}
            Where OrderId={14}",
            model.DeskId,model.BillAmount,model.AccountsPayable,model.Refunds,model.DishCount,model.OrderState,model.Cash,model.BankCard,model.WeiXin,model.Alipay,model.MembersCard,model.OrderbeginTime,model.OrderEndTime,model.ClearDeskState,model.OrderId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <parame name="OrderId">OrderId</param>
        public bool Delete(string OrderId)
        {
            string strSql=String.Format("Delete From order_ Where OrderId={0}",OrderId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <parame name="OrderId">OrderId</param>
        public bool Exists(string OrderId)
        {
            string strSql=String.Format("Select Count(1) From order_ Where OrderId={0}",OrderId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }
        


        /// <summary>
        /// ��ȡʵ��
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
        /// ��������
        /// </summary>
        /// <param name="">����Id[DeskId]</param>
        /// <param name="">�˵�[BillAmount]</param>
        /// <param name="">Ӧ����[AccountsPayable]</param>
        /// <param name="">�˿�[Refunds]</param>
        /// <param name="">��Ʒ����[DishCount]</param>
        /// <param name="">����״̬��0��δ֧����1����֧����[OrderState]</param>
        /// <param name="">�ֽ𸶿�[Cash]</param>
        /// <param name="">���п�����[BankCard]</param>
        /// <param name="">΢�Ÿ���[WeiXin]</param>
        /// <param name="">֧��������[Alipay]</param>
        /// <param name="">��Ա������[MembersCard]</param>
        /// <param name="">�µ�ʱ��[OrderbeginTime]</param>
        /// <param name="">�òͽ���ʱ��[OrderEndTime]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string DeskId,decimal BillAmount,decimal AccountsPayable,decimal Refunds,byte DishCount,byte OrderState,decimal Cash,decimal BankCard,decimal WeiXin,decimal Alipay,decimal MembersCard,string OrderbeginTime,string OrderEndTime,byte ClearDeskState, int StartIndex, int PageSize, out int RecordCount)
        {
            #region �������...
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
        /// ��ȡ����
        /// </summary>
        /// <param name="Fields">�ֶ��ַ���[ȫ��Ϊ*]</param>
        /// <param name="Wheres">����[��Ϊ��]</param>
        public DataSet GetData(string Fields, string Wheres)
        {
            string strSql="Select "+ Fields +" From order_";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            return AosyMySql.ExecuteforDataSet(strSql);
        }


        /// <summary>
        /// ��ȡ����[���ڷ�ҳ]
        /// </summary>
        /// <param name="Fields">�ֶ��ַ���[ȫ��Ϊ*]</param>
        /// <param name="Wheres">����[��Ϊ��]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
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
        /// ��ȡȫ������
        /// </summary>
        public DataSet GetAll()
        {
            string strSql="Select * From order_ ";
            return AosyMySql.ExecuteforDataSet(strSql);
        }


        /// <summary>
        /// ��ȡȫ������[���ڷ�ҳ]
        /// </summary>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
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
        /// ִ�и���SQL���
        /// </summary>
        /// <param name="filed">Ҫ���µ��ֶΣ�����["name='"+name+"',pwd='"+pwd+"'"]</param>
        /// <param name="wheres">��������������["id="+id]</param>
        /// <returns></returns>
        public int ExecuteUpdate(string updatefield, string wheres)
        {
            string sql = "update order_ set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

