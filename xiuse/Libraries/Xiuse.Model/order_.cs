/**���ߣ�zy    ��������

*��Ӷ���
*��Ӳ�Ʒ
*�޸Ķ���
*ɾ����Ʒ
*�˵�����
*�趨���ϲ�Ʒ
*��Ӷ����ۿۡ�
*�޸Ķ������ۿۡ�
*���С�ѡ�
*����Ĩ���ۿۡ�
*/


using System;
namespace Xiuse.Model
{
    /// <summary>
    /// [order_] ʵ����
    /// </summary>
    public class order_
    {
        public order_() { }
        #region ��Ա����...
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
        #region ��Ա����...
        /// <summary>
        /// ������[OrderId]
        /// </summary>
        public string OrderId
        {
            get { return _OrderId; }
            set { _OrderId = value; }
        }



        /// <summary>
        /// ����Id[DeskId]
        /// </summary>
        public string DeskId
        {
            get { return _DeskId; }
            set { _DeskId = value; }
        }



        /// <summary>
        /// �˵�[BillAmount]
        /// </summary>
        public decimal BillAmount
        {
            get { return _BillAmount; }
            set { _BillAmount = value; }
        }



        /// <summary>
        /// Ӧ����[AccountsPayable]
        /// </summary>
        public decimal AccountsPayable
        {
            get { return _AccountsPayable; }
            set { _AccountsPayable = value; }
        }



        /// <summary>
        /// �˿�[Refunds]
        /// </summary>
        public decimal Refunds
        {
            get { return _Refunds; }
            set { _Refunds = value; }
        }



        /// <summary>
        /// ��Ʒ����[DishCount]
        /// </summary>
        public int DishCount
        {
            get { return _DishCount; }
            set { _DishCount = value; }
        }



        /// <summary>
        /// ����״̬��0��δ֧����1����֧����[OrderState]
        /// </summary>
        public short OrderState
        {
            get { return _OrderState; }
            set { _OrderState = value; }
        }



        /// <summary>
        /// �ֽ𸶿�[Cash]
        /// </summary>
        public decimal Cash
        {
            get { return _Cash; }
            set { _Cash = value; }
        }



        /// <summary>
        /// ���п�����[BankCard]
        /// </summary>
        public decimal BankCard
        {
            get { return _BankCard; }
            set { _BankCard = value; }
        }



        /// <summary>
        /// ΢�Ÿ���[WeiXin]
        /// </summary>
        public decimal WeiXin
        {
            get { return _WeiXin; }
            set { _WeiXin = value; }
        }



        /// <summary>
        /// ֧��������[Alipay]
        /// </summary>
        public decimal Alipay
        {
            get { return _Alipay; }
            set { _Alipay = value; }
        }



        /// <summary>
        /// ��Ա������[MembersCard]
        /// </summary>
        public decimal MembersCard
        {
            get { return _MembersCard; }
            set { _MembersCard = value; }
        }



        /// <summary>
        /// �µ�ʱ��[OrderbeginTime]
        /// </summary>
        public DateTime OrderbeginTime
        {
            get { return _OrderbeginTime; }
            set { _OrderbeginTime = value; }
        }



        /// <summary>
        /// �òͽ���ʱ��[OrderEndTime]
        /// </summary>
        public DateTime OrderEndTime
        {
            get { return _OrderEndTime; }
            set { _OrderEndTime = value; }
        }
        /// <summary>
        /// 0,û����̨��1���Ѿ���̨��
        /// </summary>
        public Int16 ClearDeskState
        {
            get { return _ClearDeskState; }
            set { _ClearDeskState = value; }
        }
        /// <summary>
        /// �˿�����
        /// </summary>
        public int CustomerNum
        {
            get { return _CustomerNum; }
            set { _CustomerNum = value; }
        }
        /// <summary>
        /// ����Ա��Id
        /// </summary>
        public string ServiceUserId
        {
            get { return _ServiceUserId; }
            set { _ServiceUserId = value; }
        }
        #endregion
    }
}