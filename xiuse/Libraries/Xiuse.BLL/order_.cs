using System;
using System.Collections.Generic;
using System.Data;
using Xiuse.Model;
using DotNet.Utilities;
using Xiuse.Model.ViewModel;

namespace Xiuse.BLL
{
    /// <summary>
    /// [order_] 业务逻辑处理
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
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.order_ model)
        {
            return dal.Insert(model);
        }





        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.order_ model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 订单换桌
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="TableId"></param>
        /// <returns></returns>
        public bool DeskChanged(string orderId, string newTableId,string oldTableId)
        {
            return dal.DeskChanged(orderId, newTableId,oldTableId);
        }
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="OrderId">OrderId</param>
        public bool Delete(string OrderId)
        {
            return dal.Delete(OrderId);
        }
        
        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <param name="OrderId">OrderId</param>
        public bool Exists(string OrderId)
        {
            return dal.Exists(OrderId);
        }
        
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="OrderId">OrderId</param>
        public Xiuse.Model.order_ GetModel(string OrderId)
        {
            return dal.GetModel(OrderId);
        }
        /// <summary>
        /// 获取实体，餐桌当天未完成支付的订单
        /// </summary>
        /// <param name="DeskId"></param>
        /// <returns></returns>
        public Xiuse.Model.order_ GetDefaultModel(string DeskId)
        {
            return dal.GetDefaultModel(DeskId);
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
        public DataSet Search(string DeskId,decimal BillAmount,decimal AccountsPayable,decimal Refunds,byte DishCount,byte OrderState,decimal Cash,decimal BankCard,decimal WeiXin,decimal Alipay,decimal MembersCard,string OrderbeginTime,string OrderEndTime, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(DeskId,BillAmount,AccountsPayable,Refunds,DishCount,OrderState,Cash,BankCard,WeiXin,Alipay,MembersCard,OrderbeginTime,OrderEndTime,StartIndex,PageSize,out count);
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
        ///获取某一餐厅的所有未结账餐桌的金额
        /// 

        public List<Xiuse.Model.order_> GetUnpaidDesks(string RestaurantId)
        {
            return DataSetTransModelListNoExpand(dal.GetUnpaidDesks(RestaurantId));
        }


        ///获取某一餐厅最近一笔已支付的金额
        public List<Xiuse.Model.order_> GetPaidLatest(string RestaurantId)
        {
            return DataSetTransModelListNoExpand(dal.GetPaidLatest(RestaurantId));
        }
        /// <summary>
        /// 获取数据[用于分页]
        /// </summary>
        /// <param name="Fields">字段字符串[全部为*]</param>
        /// <param name="Wheres">条件[可为空]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet GetData(string Fields, string Wheres,int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.GetData(Fields,Wheres,StartIndex,PageSize,out count);
            RecordCount=count;
            return ds;
        }
        
        /// <summary>
        /// 获取全部数据
        /// </summary>
        public DataSet GetAll()
        {
            return dal.GetAll();
        }
       
        /// <summary>
        /// 获取全部数据[用于分页]
        /// </summary>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet GetAll(int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;                              //记录总数
            DataSet ds=dal.GetAll(StartIndex,PageSize,out count);
            RecordCount=count;
            return ds;
        }   

        /// <summary>
        /// 执行更新SQL语句
        /// </summary>
        /// <param name="filed">要更新的字段，例：["name='"+name+"',pwd='"+pwd+"'"]</param>
        /// <param name="wheres">更新条件，例：["id="+id]</param>
        public int ExecuteUpdate(string updatefield, string wheres)
        {
           return dal.ExecuteUpdate(updatefield,wheres);
        }

        //<summary>
        /// 退单操作
        /// </summary>
        /// 
        public bool BackOrder(Xiuse.Model.order_ Order)
        {
            return dal.BackOrder(Order);
        }

        

        /// <summary>
        /// 获取当天餐厅的特定餐桌的所有未清台的账单
        /// </summary>
        /// <param name="DeskId">餐桌Id</param>
        public List<OrderBill> GetUncleanedDesksbyId(string DeskId)
        {
            return dal.GetUncleanedDesksbyId(DeskId);
        }

        /// <summary>
        /// 获取当天餐厅的餐桌的所有未清台的账单
        /// </summary>
        /// <param name="RestaurantId">餐厅Id</param>
        /// <returns></returns>
        public List<OrderBill> GetAllUncleanedDesks(string RestaurantId)
        {
            return dal.GetAllUncleanedDesks(RestaurantId);
        }


        ///
        ///获取订单详情
        ///参数：订单id
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
            #region 检查账单
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
                state.Add("{'Code':1,'Info':'账单总额有误！'}");
            }
            if(EntireDiscount>BillAmount - sigalDiscount)
            {
                EntireDiscount = 0;
                state.Add("{'Code':2,'Info':'整单折扣有误！'}");
            }
            if(bill.Order.Tip < 0)
            {
                bill.Order.Tip = 0;
                state.Add("{'Code':3,'Info':小费计算有误！'}");
            }
            if(bill.Order.SameChange<0|| bill.Order.SameChange>(BillAmount - sigalDiscount - EntireDiscount))
            {
                bill.Order.SameChange = 0;
                state.Add("{'Code':4,'Info':抹零计算有误！'}");
            }
            if(bill.Order.AccountsPayable != (BillAmount - sigalDiscount -EntireDiscount -bill.Order.SameChange+bill.Order.Tip))
            {
                bill.Order.AccountsPayable = (BillAmount - sigalDiscount - EntireDiscount);
                state.Add("{'Code':5,'Info':应付款计算有误！'}");
            }
            if(bill.Order.CurrentPay != (bill.Order.Cash + bill.Order.BankCard + bill.Order.MembersCard + bill.Order.WeiXin + bill.Order.Alipay))
            {
                bill.Order.ChangePay = (bill.Order.Cash + bill.Order.BankCard + bill.Order.MembersCard + bill.Order.WeiXin + bill.Order.Alipay);
                state.Add("{'Code':6,'Info':总付款的金额计算有误！'}");
            }
            if(bill.Order.ChangePay != (bill.Order.CurrentPay -bill.Order.AccountsPayable))
            {
                bill.Order.ChangePay = (bill.Order.CurrentPay - bill.Order.AccountsPayable);
                state.Add("{'Code':7,'Info':找零计算有误！'}");
            }
            bill.Order.OrderState = 1;
            bill.Order.OrderEndTime = DateTime.Now;
            #endregion

            #region 更新数据
            //添加整单折扣
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
            
            //更新订单中的菜单
            foreach (Model.ordermenu_ item in bill.Ordermenu)
                orderMenuDal.Update(item);
            ///更新订单
            dal.Update(bill.Order);
            //更新餐桌的状态
            deskDal.UpdateDesk(bill.Order.DeskId);
            #endregion
            return state;
        }

        #region 工具类
        /// <summary>
        /// 把DataSet转成List泛型集合(expand无关联实体)
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
        /// 把DataSet转成泛型(expand无关联实体)
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
        /// 工具类DataSet转换为List
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
