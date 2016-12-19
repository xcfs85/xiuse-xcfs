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
    /// [xiuse_restaurant] ҵ���߼�����
    /// </summary>
    public class xiuse_restaurant 
    {
       
        private readonly Xiuse.DAL.xiuse_restaurant dal=new Xiuse.DAL.xiuse_restaurant();

        public xiuse_restaurant(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_restaurant model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_restaurant model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="RestaurantId">RestaurantId</param>
        public bool Delete(string RestaurantId)
        {
            return dal.Delete(RestaurantId);
        }
        
        /// <summary>
        ///  �жϲ����Ƿ����
        /// </summary>
        /// <param name="RestaurantId">RestaurantId</param>
        public bool Exists(string RestaurantId)
        {
            return dal.Exists(RestaurantId);
        }
        
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="RestaurantId">RestaurantId</param>
        public Xiuse.Model.xiuse_restaurant GetModel(string RestaurantId)
        {
            return dal.GetModel(RestaurantId);
        }
        

		/// <summary>
        /// ��������
        /// </summary>
        /// <param name="">��������[RestaurantName]</param>
        /// <param name="">�����ĵ绰[Phone]</param>
        /// <param name="">�����ĵ�ַ[Site]</param>
        /// <param name="">������˵��[Remark]</param>
        /// <param name="">����ʱ��[Time]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string RestaurantName,string Phone,string Site,string Remark,string Time, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(RestaurantName,Phone,Site,Remark,Time,StartIndex,PageSize,out count);
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
        private List<Xiuse.Model.xiuse_restaurant> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_restaurant> list = new List<Xiuse.Model.xiuse_restaurant>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_restaurant>(dataSet, 0));
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
        private Xiuse.Model.xiuse_restaurant DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_restaurant>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// ������DataSetת��ΪList
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_restaurant> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_restaurant> Tmp = new List<Model.xiuse_restaurant>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_restaurant model = new Xiuse.Model.xiuse_restaurant();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.RestaurantId = (string)dr["RestaurantId"];
                    model.RestaurantName = dr["RestaurantName"].ToString();
                    model.Phone = dr["Phone"].ToString();
                    model.Site = dr["Site"].ToString();
                    model.Remark = dr["Remark"].ToString();
                    model.Time = dr["Time"].ToString();
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
