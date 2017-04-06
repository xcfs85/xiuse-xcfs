using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DAL;
using DotNet.Utilities;
using System.Linq;

namespace Xiuse.BLL
{
    /// <summary>
    /// [ordermenu_] ҵ���߼�����
    /// </summary>
    public class ordermenu_ 
    {
       
        private readonly Xiuse.DAL.ordermenu_ dal=new Xiuse.DAL.ordermenu_();

        public ordermenu_(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.ordermenu_ model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.ordermenu_ model)
        {
            return dal.Update(model);
        }



        public bool UpdateMenuState(Xiuse.Model.ordermenu_ model)
        {
            return dal.UpdateMenuState(model);
        }
   
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="OrderMenuId">OrderMenuId</param>
        public bool Delete(string OrderMenuId)
        {
            return dal.Delete(OrderMenuId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="OrderMenuId">OrderMenuId</param>
        public bool Exists(string OrderMenuId)
        {
            return dal.Exists(OrderMenuId);
        }
        
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="OrderMenuId">OrderMenuId</param>
        public Xiuse.Model.ordermenu_ GetModel(string OrderMenuId)
        {
            return dal.GetModel(OrderMenuId);
        }





        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="">[OrderId]</param>
        /// <param name="">��Ʒ����[MenuName]</param>
        /// <param name="">��Ʒ�۸�[MenuPrice]</param>
        /// <param name="">��Ʒ��ǩ[MenuTag]</param>
        /// <param name="">��ƷͼƬ[MenuImage]</param>
        /// <param name="">��Ʒ����[MenuInstruction]</param>
        /// <param name="">�Ƿ����ۿۣ�0,1��[DiscoutFlag]</param>
        /// <param name="">�ۿ�����[DiscountName]</param>
        /// <param name="">�ۿ۽��[DiscountContent]</param>
        /// <param name="">�ۿ�����(0:�ٷֱ� 1���̶����)[DiscountType]</param>
        /// <param name="">�Ƿ��ϲ�[MenuServing]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string OrderId,string MenuName,decimal MenuPrice,string MenuTag,string MenuImage,string MenuInstruction,bool DiscoutFlag,string DiscountName,decimal DiscountContent,byte DiscountType,bool MenuServing, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(OrderId,MenuName,MenuPrice,MenuTag,MenuImage,MenuInstruction,DiscoutFlag,DiscountName,DiscountContent,DiscountType,MenuServing,StartIndex,PageSize,out count);
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
        #region ������
        /// <summary>
        /// ��DataSetת��List���ͼ���(expand�޹���ʵ��)
        /// Author:xcf Date:2015.01.26
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        private  List<Xiuse.Model.ordermenu_> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.ordermenu_> list = new List<Xiuse.Model.ordermenu_>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.ordermenu_>(dataSet, 0));
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
        private  Xiuse.Model.ordermenu_ DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.ordermenu_>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// ������DataSetת��ΪList
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.ordermenu_> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.ordermenu_> Tmp = new List<Model.ordermenu_>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.ordermenu_ model = new Xiuse.Model.ordermenu_();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.OrderMenuId = (string)dr["OrderMenuId"];
                    model.OrderId = (string)dr["OrderId"];
                    model.MenuName = dr["MenuName"].ToString();
                    model.MenuPrice = (decimal)dr["MenuPrice"];
                    model.MenuTag = dr["MenuTag"].ToString();
                    model.MenuImage = dr["MenuImage"].ToString();
                    model.MenuInstruction = dr["MenuInstruction"].ToString();
                    model.DiscoutFlag = (short)dr["DiscoutFlag"];
                    model.DiscountName = dr["DiscountName"].ToString();
                    model.DiscountContent = (decimal)dr["DiscountContent"];
                    model.DiscountType = (short)dr["DiscountType"];
                    model.MenuServing = (short)dr["MenuServing"];
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
