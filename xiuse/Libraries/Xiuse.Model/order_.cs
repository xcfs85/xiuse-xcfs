/**作者：zy    订单操作

*添加订单
*添加菜品
*修改订单
*删除菜品
*退单操作
*设定已上菜品
*添加订单折扣。
*修改订单的折扣。
*添加小费。
*增加抹零折扣。
*/


using System;
namespace Xiuse.Model
{
    /// <summary>
    /// [order_] 实体类
    /// </summary>
    public class order_
    {
        public order_() { }
        #region 成员变量...
        private string _OrderId;
        private string _DeskId;
        private decimal _BillAmount;
        private decimal _AccountsPayable;
        private decimal _Refunds;
        private int _DishCount;
        private short _OrderState;
        private decimal _Cash;
        private decimal _BankCard;
        private decimal _WeiXin;
        private decimal _Alipay;
        private decimal _MembersCard;
        private DateTime _OrderbeginTime;
        private DateTime _OrderEndTime;
        private Int16 _ClearDeskState;
        private string _ServiceUserId;
        private int _CustomerNum;
        #endregion
        #region 成员属性...
        /// <summary>
        /// 订单号[OrderId]
        /// </summary>
        public string OrderId
        {
            get { return _OrderId; }
            set { _OrderId = value; }
        }



        /// <summary>
        /// 餐桌Id[DeskId]
        /// </summary>
        public string DeskId
        {
            get { return _DeskId; }
            set { _DeskId = value; }
        }



        /// <summary>
        /// 账单[BillAmount]
        /// </summary>
        public decimal BillAmount
        {
            get { return _BillAmount; }
            set { _BillAmount = value; }
        }



        /// <summary>
        /// 应付款[AccountsPayable]
        /// </summary>
        public decimal AccountsPayable
        {
            get { return _AccountsPayable; }
            set { _AccountsPayable = value; }
        }



        /// <summary>
        /// 退款[Refunds]
        /// </summary>
        public decimal Refunds
        {
            get { return _Refunds; }
            set { _Refunds = value; }
        }



        /// <summary>
        /// 菜品数量[DishCount]
        /// </summary>
        public int DishCount
        {
            get { return _DishCount; }
            set { _DishCount = value; }
        }



        /// <summary>
        /// 订单状态（0，未支付；1，已支付）[OrderState]
        /// </summary>
        public short OrderState
        {
            get { return _OrderState; }
            set { _OrderState = value; }
        }



        /// <summary>
        /// 现金付款[Cash]
        /// </summary>
        public decimal Cash
        {
            get { return _Cash; }
            set { _Cash = value; }
        }



        /// <summary>
        /// 银行卡付款[BankCard]
        /// </summary>
        public decimal BankCard
        {
            get { return _BankCard; }
            set { _BankCard = value; }
        }



        /// <summary>
        /// 微信付款[WeiXin]
        /// </summary>
        public decimal WeiXin
        {
            get { return _WeiXin; }
            set { _WeiXin = value; }
        }



        /// <summary>
        /// 支付宝付款[Alipay]
        /// </summary>
        public decimal Alipay
        {
            get { return _Alipay; }
            set { _Alipay = value; }
        }



        /// <summary>
        /// 会员卡付款[MembersCard]
        /// </summary>
        public decimal MembersCard
        {
            get { return _MembersCard; }
            set { _MembersCard = value; }
        }



        /// <summary>
        /// 下单时间[OrderbeginTime]
        /// </summary>
        public DateTime OrderbeginTime
        {
            get { return _OrderbeginTime; }
            set { _OrderbeginTime = value; }
        }



        /// <summary>
        /// 用餐结束时间[OrderEndTime]
        /// </summary>
        public DateTime OrderEndTime
        {
            get { return _OrderEndTime; }
            set { _OrderEndTime = value; }
        }
        /// <summary>
        /// 0,没有清台；1，已经清台；
        /// </summary>
        public Int16 ClearDeskState
        {
            get { return _ClearDeskState; }
            set { _ClearDeskState = value; }
        }
        /// <summary>
        /// 顾客数量
        /// </summary>
        public int CustomerNum
        {
            get { return _CustomerNum; }
            set { _CustomerNum = value; }
        }
        /// <summary>
        /// 服务员的Id
        /// </summary>
        public string ServiceUserId
        {
            get { return _ServiceUserId; }
            set { _ServiceUserId = value; }
        }
        #endregion
    }
}