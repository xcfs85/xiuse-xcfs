using System;
using System.Collections.Generic;
using System.Data;
using Xiuse.Model;
using DotNet.Utilities;
using Xiuse.Model.ViewModel;

namespace Xiuse.BLL
{
    /// <summary>
    /// [order_] ҵ���߼�����
    /// </summary>
    public class order_ 
    {
       
        private readonly Xiuse.DAL.order_ dal=new Xiuse.DAL.order_();
        private readonly DAL.ordermenu_ dalOrderMenu = new DAL.ordermenu_();
        public order_(){}


        public string NewOrder(dynamic obj)
        {
            Model.order_ OrderModel = new Model.order_();
            OrderModel.OrderId = Guid.NewGuid().ToString("N");
            OrderModel.DeskId = Convert.ToString(obj.DeskId);
            OrderModel.BillAmount = Convert.ToDecimal(obj.BillAmount);
            OrderModel.AccountsPayable = Convert.ToDecimal(obj.AccountsPayable);
            //OrderModel.BankCard = Convert.ToDecimal(obj.BankCard);
            //OrderModel.Cash = Convert.ToDecimal(obj.Cash);
            OrderModel.ClearDeskState = Convert.ToInt16(obj.ClearDeskState);
            OrderModel.CustomerNum = Convert.ToInt32(obj.CustomerNum);
            OrderModel.DishCount = Convert.ToInt32(obj.DishCount);
            OrderModel.ServiceUserId = Convert.ToString(obj.ServiceUserId);
            OrderModel.OrderbeginTime = DateTime.Now;
            bool OrderFlag = dal.NewOrder(OrderModel);
            bool OrderMenuFlag = true;
           // List<Xiuse.Model.ordermenu_> menus = new List<Model.ordermenu_>();
            Model.ordermenu_ TheMenu = new Model.ordermenu_();
            
            for (int i = 0; i < obj.Menus.Count; i++)
            {
                TheMenu = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.ordermenu_>(Convert.ToString(obj.Menus[i]));
                TheMenu.MenuNum = (int)obj.Menus[i].MenuNo;
                TheMenu.OrderId = OrderModel.OrderId;
                TheMenu.OrderMenuId = Guid.NewGuid().ToString("N");
                if (dalOrderMenu.Insert(TheMenu) == false)
                     OrderMenuFlag=false;
            }

            if (OrderFlag== false||OrderMenuFlag==false)
                return "0";
            else return OrderModel.OrderId;
           
        }



        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.order_ model)
        {
            return dal.Insert(model);
        }





        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.order_ model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="TableId"></param>
        /// <returns></returns>
        public bool DeskChanged(string orderId, string newTableId,string oldTableId)
        {
            return dal.DeskChanged(orderId, newTableId,oldTableId);
        }
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="OrderId">OrderId</param>
        public bool Delete(string OrderId)
        {
            return dal.Delete(OrderId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="OrderId">OrderId</param>
        public bool Exists(string OrderId)
        {
            return dal.Exists(OrderId);
        }
        
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="OrderId">OrderId</param>
        public Xiuse.Model.order_ GetModel(string OrderId)
        {
            return dal.GetModel(OrderId);
        }
        /// <summary>
        /// ��ȡʵ�壬��������δ���֧���Ķ���
        /// </summary>
        /// <param name="DeskId"></param>
        /// <returns></returns>
        public Xiuse.Model.order_ GetDefaultModel(string DeskId)
        {
            return dal.GetDefaultModel(DeskId);
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
        public DataSet Search(string DeskId,decimal BillAmount,decimal AccountsPayable,decimal Refunds,byte DishCount,byte OrderState,decimal Cash,decimal BankCard,decimal WeiXin,decimal Alipay,decimal MembersCard,string OrderbeginTime,string OrderEndTime, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(DeskId,BillAmount,AccountsPayable,Refunds,DishCount,OrderState,Cash,BankCard,WeiXin,Alipay,MembersCard,OrderbeginTime,OrderEndTime,StartIndex,PageSize,out count);
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
            return dal.GetData(Fields,Wheres);
        }
      
        public List<Model.order_> GetDailyBills(string deskId)
        {
            string str = "day(OrderbeginTime)=day(curdate()) and OrderState<>0 and DeskId='" + deskId + "'";

            return DataSetTransModelListNoExpand(GetData("*", str));
        }

        public List<Model.order_> GetDailyRes(string resId)
        {
            return DataSetTransModelListNoExpand(dal.GetDailyRes(resId));
        }




        ///
        ///��ȡĳһ����������δ���˲����Ľ��
        /// 

        public List<Xiuse.Model.order_> GetUnpaidDesks(string RestaurantId)
        {
            return DataSetTransModelListNoExpand(dal.GetUnpaidDesks(RestaurantId));
        }


        ///��ȡĳһ�������һ����֧���Ľ��
        public List<Xiuse.Model.order_> GetPaidLatest(string RestaurantId)
        {
            return DataSetTransModelListNoExpand(dal.GetPaidLatest(RestaurantId));
        }
        /// <summary>
        /// ��ȡ����[���ڷ�ҳ]
        /// </summary>
        /// <param name="Fields">�ֶ��ַ���[ȫ��Ϊ*]</param>
        /// <param name="Wheres">����[��Ϊ��]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet GetData(string Fields, string Wheres,int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.GetData(Fields,Wheres,StartIndex,PageSize,out count);
            RecordCount=count;
            return ds;
        }
        
        /// <summary>
        /// ��ȡȫ������
        /// </summary>
        public DataSet GetAll()
        {
            return dal.GetAll();
        }
       
        /// <summary>
        /// ��ȡȫ������[���ڷ�ҳ]
        /// </summary>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet GetAll(int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;                              //��¼����
            DataSet ds=dal.GetAll(StartIndex,PageSize,out count);
            RecordCount=count;
            return ds;
        }   

        /// <summary>
        /// ִ�и���SQL���
        /// </summary>
        /// <param name="filed">Ҫ���µ��ֶΣ�����["name='"+name+"',pwd='"+pwd+"'"]</param>
        /// <param name="wheres">��������������["id="+id]</param>
        public int ExecuteUpdate(string updatefield, string wheres)
        {
           return dal.ExecuteUpdate(updatefield,wheres);
        }

        //<summary>
        /// �˵�����
        /// </summary>
        /// 
        public bool BackOrder(Xiuse.Model.order_ Order)
        {
            return dal.BackOrder(Order);
        }

        

        /// <summary>
        /// ��ȡ����������ض�����������δ��̨���˵�
        /// </summary>
        /// <param name="DeskId">����Id</param>
        public List<OrderBill> GetUncleanedDesksbyId(string DeskId)
        {
            return dal.GetUncleanedDesksbyId(DeskId);
        }

        /// <summary>
        /// ��ȡ��������Ĳ���������δ��̨���˵�
        /// </summary>
        /// <param name="RestaurantId">����Id</param>
        /// <returns></returns>
        public List<OrderBill> GetAllUncleanedDesks(string RestaurantId)
        {
            return dal.GetAllUncleanedDesks(RestaurantId);
        }


        ///
        ///��ȡ��������
        ///����������id
        /// 
        public OrderBill GetOrderBill(string orderId)
        {
            return dal.GetOrderBill(orderId);
        }

        public List<string> CheckoutBill(Model.ViewModel.OrderBill bill)
        {
            List<string> state = new List<string>();
            DAL.ordermenu_ orderMenuDal = new DAL.ordermenu_();
            DAL.xiuse_desk deskDal = new DAL.xiuse_desk();
            DAL.xiuse_discount discountDal = new DAL.xiuse_discount();
            #region ����˵�
            decimal BillAmount = 0;
            decimal sigalDiscount = 0;
            decimal EntireDiscount = 0;
            foreach (ordermenu_dicount item in  bill.Ordermenu){
                BillAmount += item.MenuPrice;
                if (item.DisState)
                {
                    item.DiscountName = item.MenuDiscount.DiscountName;
                    item.DiscountContent = item.MenuDiscount.DiscountContent;
                    item.DiscountType = item.MenuDiscount.DiscountType;
                    item.DiscoutFlag = item.DisState ? Int16.Parse("1") : Int16.Parse("0");
                    sigalDiscount += item.DiscountType == 0 ? (decimal)item.DiscountContent *(decimal)0.01*item.MenuPrice:item.DiscountContent;
                }
            }
            if (bill.EntireDiscount != null)
            {
                EntireDiscount = bill.EntireDiscount.DiscountType == 0? 
                    (decimal)bill.EntireDiscount.DiscountContent * (decimal)0.01*(BillAmount-sigalDiscount) : bill.EntireDiscount.DiscountContent;
            }
            if (BillAmount != bill.Order.BillAmount)
            {
                bill.Order.BillAmount = BillAmount;
                state.Add("{'Code':1,'Info':'�˵��ܶ�����'}");
            }
            if(EntireDiscount>BillAmount - sigalDiscount)
            {
                EntireDiscount = 0;
                state.Add("{'Code':2,'Info':'�����ۿ�����'}");
            }
            if(bill.Order.Tip < 0)
            {
                bill.Order.Tip = 0;
                state.Add("{'Code':3,'Info':С�Ѽ�������'}");
            }
            if(bill.Order.SameChange<0|| bill.Order.SameChange>(BillAmount - sigalDiscount - EntireDiscount))
            {
                bill.Order.SameChange = 0;
                state.Add("{'Code':4,'Info':Ĩ���������'}");
            }
            if(bill.Order.AccountsPayable != (BillAmount - sigalDiscount -EntireDiscount -bill.Order.SameChange+bill.Order.Tip))
            {
                bill.Order.AccountsPayable = (BillAmount - sigalDiscount - EntireDiscount);
                state.Add("{'Code':5,'Info':Ӧ�����������'}");
            }
            if(bill.Order.CurrentPay != (bill.Order.Cash + bill.Order.BankCard + bill.Order.MembersCard + bill.Order.WeiXin + bill.Order.Alipay))
            {
                bill.Order.ChangePay = (bill.Order.Cash + bill.Order.BankCard + bill.Order.MembersCard + bill.Order.WeiXin + bill.Order.Alipay);
                state.Add("{'Code':6,'Info':�ܸ���Ľ���������'}");
            }
            if(bill.Order.ChangePay != (bill.Order.CurrentPay -bill.Order.AccountsPayable))
            {
                bill.Order.ChangePay = (bill.Order.CurrentPay - bill.Order.AccountsPayable);
                state.Add("{'Code':7,'Info':�����������'}");
            }
            bill.Order.OrderState = 1;
            bill.Order.OrderEndTime = DateTime.Now;
            #endregion

            #region ��������
            //��������ۿ�
            if(bill.EntireDiscount != null)
            {
                Model.ordermenu_ entier = new Model.ordermenu_();
                entier.OrderId = bill.Order.OrderId;

                entier.DiscoutFlag = 2;
                entier.DiscountName = bill.EntireDiscount.DiscountName;
                entier.DiscountContent = bill.EntireDiscount.DiscountContent;
                entier.DiscountType = bill.EntireDiscount.DiscountType;
                entier.OrderMenuId = Guid.NewGuid().ToString("N");
                if (orderMenuDal.IsExitEntier(entier.OrderId))
                    orderMenuDal.DeleteEntityDiscount(entier.OrderId);
                orderMenuDal.Insert(entier);
            }
            
            //���¶����еĲ˵�
            foreach (Model.ordermenu_ item in bill.Ordermenu)
                orderMenuDal.Update(item);
            ///���¶���
            dal.Update(bill.Order);
            //���²�����״̬
            deskDal.UpdateDesk(bill.Order.DeskId);
            #endregion
            return state;
        }

        #region ������
        /// <summary>
        /// ��DataSetת��List���ͼ���(expand�޹���ʵ��)
        /// Author:xcf Date:2015.01.26
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        private  List<Xiuse.Model.order_> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.order_> list = new List<Xiuse.Model.order_>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.order_>(dataSet, 0));
                return list;
            }
            return null;
        }
        /// <summary>
        /// ��DataSetת�ɷ���(expand�޹���ʵ��)
        /// Author:xcf Date:2015.01.26
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        private  Xiuse.Model.order_ DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.order_>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// ������DataSetת��ΪList
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.order_> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.order_> Tmp = new List<Model.order_>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.order_ model = new Xiuse.Model.order_();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.OrderId = dr["OrderId"].ToString();
                    model.DeskId = (string)dr["DeskId"];
                    model.BillAmount = (decimal)dr["BillAmount"];
                    model.AccountsPayable = (decimal)dr["AccountsPayable"];
                    model.Refunds = (decimal)dr["Refunds"];
                    model.DishCount = (int)dr["DishCount"];
                    model.OrderState = (short)dr["OrderState"];
                    model.Cash = (decimal)dr["Cash"];
                    model.BankCard = (decimal)dr["BankCard"];
                    model.WeiXin = (decimal)dr["WeiXin"];
                    model.Alipay = (decimal)dr["Alipay"];
                    model.MembersCard = (decimal)dr["MembersCard"];
                    model.OrderbeginTime = (DateTime)dr["OrderbeginTime"];
                    model.OrderEndTime = (DateTime)dr["OrderEndTime"];
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
