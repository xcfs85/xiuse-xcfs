using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DAL;
using DotNet.Utilities;

namespace Xiuse.BLL
{
    /// <summary>
    /// [xiuse_discount] ҵ���߼�����
    /// </summary>
    public class xiuse_discount 
    {
       
        private readonly Xiuse.DAL.xiuse_discount dal=new Xiuse.DAL.xiuse_discount();

        public xiuse_discount(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_discount model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_discount model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="DiscountId">DiscountId</param>
        public bool Delete(string DiscountId)
        {
            return dal.Delete(DiscountId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="DiscountId">DiscountId</param>
        public bool Exists(string DiscountId)
        {
            return dal.Exists(DiscountId);
        }
        
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="DiscountId">DiscountId</param>
        public Xiuse.Model.xiuse_discount GetModel(string DiscountId)
        {
            return dal.GetModel(DiscountId);
        }
        

		/// <summary>
        /// ��������
        /// </summary>
        /// <param name="">[RestaurantId]</param>
        /// <param name="">�ۿ�����[DiscountName]</param>
        /// <param name="">�ۿ�����(0:�ٷֱ� 1���̶����)[DiscountType]</param>
        /// <param name="">�ۿ۽��[DiscountContent]</param>
        /// <param name="">�ۿ۲�Ʒ(-1��ȫ����Ʒ������ƷID,��ƷID,��ƷID,��ƷID,��ƷID��,�����ۿ�)[DiscountMenus]</param>
        /// <param name="">0,�����ۿۣ�1����Ʒ�ۿ�[DiscountSection]</param>
        /// <param name="">1,���ã�0������[DiscountState]</param>
        /// <param name="">0,���ù���Ա��֤��1,���ù���Ա��֤��[DiscountVerification]</param>
        /// <param name="">����ʱ��[DiscountTime]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string RestaurantId,string DiscountName,byte DiscountType,decimal DiscountContent,string DiscountMenus,byte DiscountSection,bool DiscountState,int DiscountVerification,string DiscountTime, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(RestaurantId,DiscountName,DiscountType,DiscountContent,DiscountMenus,DiscountSection,DiscountState,DiscountVerification,DiscountTime,StartIndex,PageSize,out count);
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
        private  List<Xiuse.Model.xiuse_discount> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_discount> list = new List<Xiuse.Model.xiuse_discount>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_discount>(dataSet, 0));
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
        private Xiuse.Model.xiuse_discount DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_discount>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// ������DataSetת��ΪList
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_discount> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_discount> Tmp = new List<Model.xiuse_discount>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_discount model = new Xiuse.Model.xiuse_discount();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.DiscountId = (string)dr["DiscountId"];
                    model.RestaurantId = (string)dr["RestaurantId"];
                    model.DiscountName = dr["DiscountName"].ToString();
                    model.DiscountType = (byte)dr["DiscountType"];
                    model.DiscountContent = (decimal)dr["DiscountContent"];
                    model.DiscountMenus = dr["DiscountMenus"].ToString();
                    model.DiscountSection = (byte)dr["DiscountSection"];
                    model.DiscountState = (bool)dr["DiscountState"];
                    model.DiscountVerification = (int)dr["DiscountVerification"];
                    model.DiscountTime = dr["DiscountTime"].ToString();
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
