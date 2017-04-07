using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [order_] ���ݲ�����
    /// </summary>
    public class order_
    {
        public order_(){}

        /// <summary>
        /// �½�һ������ + �������
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool NewOrder(Xiuse.Model.order_ model)
        {
           
            string strSql = String.Format(@"Insert Into order_(DeskId,BillAmount,DishCount,CustomerNum,OrderbeginTime,ServiceUserId,OrderId,AccountsPayable) 
                                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7})",
                                      model.DeskId, model.BillAmount, model.DishCount, model.CustomerNum, model.OrderbeginTime, model.ServiceUserId, model.OrderId,model.AccountsPayable);
            string DeskState = String.Format(@"update xiuse_desk set DeskState='1' where DeskId={0}", model.DeskId);
            AosyMySql.ExecuteforBool(DeskState);
            return AosyMySql.ExecuteforBool(strSql);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.order_ model)
        {
            string strSql=String.Format(@"Insert Into order_(DeskId,BillAmount,AccountsPayable,Refunds,DishCount,OrderState,Cash,BankCard,WeiXin,Alipay,MembersCard,OrderbeginTime,OrderEndTime) 
                                        values('{0}',{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},'{11}','{12}','{13}')",
                                        model.DeskId,model.BillAmount,model.AccountsPayable,model.Refunds,model.DishCount,model.OrderState,model.Cash,model.BankCard,model.WeiXin,model.Alipay,model.MembersCard,model.OrderbeginTime,model.OrderEndTime,model.OrderId);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.order_ model)
        {
            string strSql=String.Format(@"Update order_ Set 
            DeskId='{0}',BillAmount={1},AccountsPayable={2},Refunds={3},DishCount={4},OrderState={5},Cash={6},BankCard={7},WeiXin={8},Alipay={9},MembersCard={10},OrderbeginTime='{11}',OrderEndTime='{12}' 
            Where OrderId='{13}'",
            model.DeskId,model.BillAmount,model.AccountsPayable,model.Refunds,model.DishCount,model.OrderState,model.Cash,model.BankCard,model.WeiXin,model.Alipay,model.MembersCard,model.OrderbeginTime,model.OrderEndTime,model.OrderId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="TableId"></param>
        /// <returns></returns>
        public bool DeskChanged(string orderId, string newTableId,string oldTableId)
        {
            List<string> strSql = new List<string>();
            strSql.Add(String.Format(@"Update order_ set DeskId='{0}'Where OrderId='{1}'", newTableId, orderId));
            strSql.Add(String.Format(@"update xiuse_desk set DeskState=(select  CASE count(1) WHEN 0 THEN 0 ELSE  if( sum(OrderState)=count(1),2,1)  END  as deskstate  
                                            from  order_  
                                            where  DeskId = '{0}'  and   ClearDeskState = 0 and OrderState <> 2 and  date(OrderbeginTime) = date(curdate()))
                                             where DeskId = '{0}'", oldTableId));
            strSql.Add(String.Format(@"update xiuse_desk set DeskState=(select  CASE count(1) WHEN 0 THEN 0 ELSE  if( sum(OrderState)=count(1),2,1)  END  as deskstate  
                                            from  order_  
                                            where  DeskId = '{0}'  and   ClearDeskState = 0 and OrderState <> 2 and  date(OrderbeginTime) = date(curdate()))
                                             where DeskId = '{0}'", newTableId));
            return AosyMySql.ExecuteListSQL(strSql) == 3;
           
        }

        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <parame name="OrderId">OrderId</param>
        public bool Delete(string OrderId)
        {
            string strSql=String.Format("Delete From order_ Where OrderId='{0}'",OrderId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <parame name="OrderId">OrderId</param>
        public bool Exists(string OrderId)
        {
            string strSql=String.Format("Select Count(1) From order_ Where OrderId='{0}'",OrderId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }

        ///<summary>
        /// �˵�����
        /// </summary>
        /// 
        public bool BackOrder(Xiuse.Model.order_ Order)
        {
            string strSql = String.Format(@"Update order_ Set 
            Refunds='{0}',OrderState=2,Cash=0,BankCard=0,WeiXin=0,Alipay=0 Where OrderId={1}",
          Order.AccountsPayable,Order.OrderId);
            return AosyMySql.ExecuteforBool(strSql);
        }

        ///
        ///��ȡĳһ����������δ���˲����Ľ��
        /// 
        public DataSet GetUnpaidDesks(string RestauratId)
        {
            string strSql = string.Format("Select order_.DeskId,order_.AccountsPayable from order_ left join xiuse_desk on xiuse_desk.DeskId=order_.DeskId where xiuse_desk.DeskState = 1 xiuse_desk.RestaurantId=" + RestauratId);
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            return ds;
        }

        /// <summary>
        /// ��ȡ��������Ĳ���������δ��̨���˵�
        /// </summary>
        /// <param name="RestaurantId">����Id</param>
        /// <returns></returns>
        public List<OrderBill> GetAllUncleanedDesks(string RestaurantId)
        {
            string strSql = string.Format("select * from order_  left join xiuse_desk on order_.DeskId=xiuse_desk.DeskId where xiuse_desk.RestaurantId='{0}' and date(orderendtime)=date(curdate())and order_.ClearDeskState='0'", RestaurantId);
            //string strSql2=string.Format("select * from ordermenu_ where orderid in (select orderid from order_  left join xiuse_desk on order_.DeskId=xiuse_desk.DeskId where xiuse_desk.RestaurantId='{0}'and order_.ClearDeskState='0'", RestauratId);
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            List<OrderBill> OB = new List<OrderBill>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                OrderBill modelBill = new OrderBill();
                modelBill.Order.OrderId = dr["OrderId"].ToString();
                modelBill.Order.DeskId = (string)dr["DeskId"];
                modelBill.Order.BillAmount = (decimal)dr["BillAmount"];
                modelBill.Order.AccountsPayable = (decimal)dr["AccountsPayable"];
                modelBill.Order.Refunds = (decimal)dr["Refunds"];
                modelBill.Order.DishCount = (int)dr["DishCount"];
                modelBill.Order.OrderState = (short)dr["OrderState"];
                modelBill.Order.Cash = (decimal)dr["Cash"];
                modelBill.Order.BankCard = (decimal)dr["BankCard"];
                modelBill.Order.WeiXin = (decimal)dr["WeiXin"];
                modelBill.Order.Alipay = (decimal)dr["Alipay"];
                modelBill.Order.MembersCard = (decimal)dr["MembersCard"];
                modelBill.Order.OrderbeginTime = (DateTime)dr["OrderbeginTime"];
                modelBill.Order.OrderEndTime = (DateTime)dr["OrderEndTime"];
                string strSql2 = string.Format("select * from ordermenu_ where orderid='{0}'", modelBill.Order.OrderId);
                DataSet ds2 = AosyMySql.ExecuteforDataSet(strSql2);
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    DataRow dr2 = ds2.Tables[0].Rows[j];
                    Xiuse.Model.ordermenu_ modelMenu = new Xiuse.Model.ordermenu_();
                    
                    modelMenu.OrderMenuId= (string)dr["OrderMenuId"];
                    modelMenu.OrderId = (string)dr["OrderId"];
                    modelMenu.MenuName = dr["MenuName"].ToString();
                    modelMenu.MenuPrice = (decimal)dr["MenuPrice"];
                    modelMenu.MenuTag = dr["MenuTag"].ToString();
                    modelMenu.MenuImage = dr["MenuImage"].ToString();
                    modelMenu.MenuInstruction = dr["MenuInstruction"].ToString();
                    modelMenu.DiscoutFlag = (short)dr["DiscoutFlag"];
                    modelMenu.DiscountName = dr["DiscountName"].ToString();
                    modelMenu.DiscountContent = (decimal)dr["DiscountContent"];
                    modelMenu.DiscountType = (byte)dr["DiscountType"];
                    modelMenu.MenuServing = (short)dr["MenuServing"];
                    modelBill.Ordermenu.Add(modelMenu);
                }
                OB.Add(modelBill);
            }
         
            return OB;
        }

        /// <summary>
        /// ��ȡ����������ض�����������δ��̨���˵�
        /// </summary>
        /// <param name="DeskId">����Id</param>
        public List<OrderBill> GetUncleanedDesksbyId(string DeskId)
        {
            string strSql = string.Format("select * from order_  where DeskId='{0}'and ClearDeskState='0'and date(orderbegintime)=date(curdate())", DeskId);
            //string strSql2=string.Format("select * from ordermenu_ where orderid in (select orderid from order_  left join xiuse_desk on order_.DeskId=xiuse_desk.DeskId where xiuse_desk.RestaurantId='{0}'and order_.ClearDeskState='0'", RestauratId);
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            List<OrderBill> OB = new List<OrderBill>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                OrderBill modelBill = new OrderBill();
               
                modelBill.Order.OrderId = dr.ItemArray[0].ToString();
                modelBill.Order.DeskId = dr.ItemArray[1].ToString();
                modelBill.Order.BillAmount = (decimal)dr.ItemArray[2];
                modelBill.Order.AccountsPayable = (decimal)dr.ItemArray[3];
                modelBill.Order.Refunds = (decimal)dr.ItemArray[4];
                modelBill.Order.DishCount = (int)dr.ItemArray[5];
                modelBill.Order.OrderState = (int)dr.ItemArray[6];
                modelBill.Order.Cash = (decimal)dr.ItemArray[7];
                modelBill.Order.BankCard = (decimal)dr.ItemArray[8];
                modelBill.Order.WeiXin = (decimal)dr.ItemArray[9];
                modelBill.Order.Alipay = (decimal)dr.ItemArray[10];
                modelBill.Order.MembersCard = (decimal)dr.ItemArray[11];
                modelBill.Order.OrderbeginTime = (DateTime)dr.ItemArray[13];
                if (!dr.IsNull(14))
                {
                    modelBill.Order.OrderEndTime = (DateTime)dr.ItemArray[14];
                }

                string strSql2 = string.Format("select * from ordermenu_ where orderid='{0}'", modelBill.Order.OrderId);
                DataSet ds2 = AosyMySql.ExecuteforDataSet(strSql2);
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    DataRow dr2 = ds2.Tables[0].Rows[j];
                    Xiuse.Model.ordermenu_ modelMenu = new Xiuse.Model.ordermenu_();

                    modelMenu.OrderMenuId = (string)dr2.ItemArray[0];
                    modelMenu.OrderId = (string)dr2.ItemArray[1];
                    modelMenu.MenuName = dr2.ItemArray[2].ToString();
                    modelMenu.MenuPrice = (decimal)dr2.ItemArray[3];
                    modelMenu.MenuTag = dr2.ItemArray[4].ToString();
                    modelMenu.MenuNum = (int)dr2.ItemArray[5];
                    modelMenu.MenuImage = dr2.ItemArray[6].ToString();
                    
                    modelMenu.MenuInstruction = dr2.ItemArray[7].ToString();
                    modelMenu.DiscoutFlag = (short)dr2.ItemArray[8];
                    modelMenu.DiscountName = dr2.ItemArray[9].ToString();
                    modelMenu.DiscountContent = (decimal)dr2.ItemArray[10];
                    modelMenu.DiscountType = (short)dr2.ItemArray[11];
                    modelMenu.MenuServing = (short)dr2.ItemArray[12];
                    modelBill.Ordermenu.Add(modelMenu);
                }
                OB.Add(modelBill);
            }

            return OB;
        }
        ///
        ///��ȡ��������
        ///����������id
        /// 
        public OrderBill GetOrderBill(string orderId)
        {
            //  string strSql = string.Format("select * from order_  left join ordermenu_ on order_.orderId = ordermenu_.orderId where orderId='{0}'", orderId);

            string strSql = string.Format("select * from order_ where orderId='{0}'",orderId);
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Xiuse.Model.OrderBill modelBill = new Xiuse.Model.OrderBill();
                Xiuse.Model.order_ Order = new Xiuse.Model.order_();
                DataRow dr = ds.Tables[0].Rows[0];
                Order.OrderId = dr["OrderId"].ToString();
                Order.DeskId = (string)dr["DeskId"];
                Order.BillAmount = (decimal)dr["BillAmount"];
                Order.AccountsPayable = (decimal)dr["AccountsPayable"];
                Order.Refunds = (decimal)dr["Refunds"];
                Order.DishCount = (int)dr["DishCount"];
                Order.OrderState = (int)dr["OrderState"];
                Order.Cash = (decimal)dr["Cash"];
                Order.BankCard = (decimal)dr["BankCard"];
                Order.WeiXin = (decimal)dr["WeiXin"];
                Order.Alipay = (decimal)dr["Alipay"];
                Order.MembersCard = (decimal)dr["MembersCard"];
                Order.OrderbeginTime = (DateTime)dr["OrderbeginTime"];
                if(!dr.IsNull("OrderEndTime"))
                    Order.OrderEndTime = (DateTime)dr["OrderEndTime"];
                modelBill.Order = Order;
                string strSql2 = string.Format("select * from ordermenu_ where orderid='{0}'", orderId);
                DataSet ds2 = AosyMySql.ExecuteforDataSet(strSql2);
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    DataRow dr2 = ds2.Tables[0].Rows[j];
                    Xiuse.Model.ordermenu_ modelMenu = new Xiuse.Model.ordermenu_();

                    modelMenu.OrderMenuId = (string)dr2["OrderMenuId"];
                    modelMenu.OrderId = (string)dr2["OrderId"];
                    modelMenu.MenuName = dr2["MenuName"].ToString();
                    modelMenu.MenuPrice = (decimal)dr2["MenuPrice"];
                    modelMenu.MenuTag = dr2["MenuTag"].ToString();
                    modelMenu.MenuImage = dr2["MenuImage"].ToString();
                    modelMenu.MenuInstruction = dr2["MenuInstruction"].ToString();
                    modelMenu.DiscoutFlag = (short)dr2["DiscoutFlag"];
                    modelMenu.DiscountName = dr2["DiscountName"].ToString();
                    modelMenu.DiscountContent = (decimal)dr2["DiscountContent"];
                    modelMenu.DiscountType = (short)dr2["DiscountType"];
                    modelMenu.MenuNum = (int)dr2["MenuNum"];
                    modelMenu.MenuServing = (short)dr2["MenuServing"];
                    modelBill.Ordermenu.Add(modelMenu);
                }
                return modelBill;
            }
            else
            {
                return null;
            }
         
        }


        ///
        ///
        ///��ȡĳһ���������һ�ν��˵Ľ����һ�ε�������κ���������orderbegintime��orderendtime��
        /// order_.OrderState :0��δ֧����1����֧��
        public DataSet GetPaidLatest(string RestauratId)
        {
            string strSql = string.Format("Select order_.DeskId,order_.AccountsPayable from order_ left join xiuse_desk on xiuse_desk.DeskId=order_.DeskId where order_.OrderState = 1 xiuse_desk.RestaurantId=" + RestauratId+" order by order_.orderendtime desc");
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            return ds;
        }



        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <parame name="OrderId">OrderId</param>
        public Xiuse.Model.order_ GetModel(string OrderId)
        {
             string strSql=String.Format(@"Select * From order_ Where OrderId='{0}'",OrderId); 
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
				model.DishCount=(int)dr["DishCount"];
				model.OrderState=(short)dr["OrderState"];
				model.Cash=(decimal)dr["Cash"];
				model.BankCard=(decimal)dr["BankCard"];
				model.WeiXin=(decimal)dr["WeiXin"];
				model.Alipay=(decimal)dr["Alipay"];
				model.MembersCard=(decimal)dr["MembersCard"];
				model.OrderbeginTime=(DateTime)dr["OrderbeginTime"];
				model.OrderEndTime=(DateTime)dr["OrderEndTime"];
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
        public DataSet Search(string DeskId,decimal BillAmount,decimal AccountsPayable,decimal Refunds,byte DishCount,short OrderState,decimal Cash,decimal BankCard,decimal WeiXin,decimal Alipay,decimal MembersCard,string OrderbeginTime,string OrderEndTime, int StartIndex, int PageSize, out int RecordCount)
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
            

            if(OrderEndTime!=null && OrderEndTime.Length>0)
                strWhere.Append(" And OrderEndTime='"+OrderEndTime+"'");
            
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


        public DataSet GetDailyRes(string resId)
        {
            string strSql = String.Format(@"select * from order_ left join xiuse_desk on order_.DeskId=xiuse_desk.DeskId where day(OrderbeginTime)=day(curdate()) and xiuse_desk.RestaurantId='{0}'", resId);
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

