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
    /// [xiuse_memberclassify] ҵ���߼�����
    /// </summary>
    public class xiuse_memberclassify 
    {
       
        private readonly Xiuse.DAL.xiuse_memberclassify dal=new Xiuse.DAL.xiuse_memberclassify();

        public xiuse_memberclassify(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_memberclassify model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_memberclassify model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="MemberClassifyId">MemberClassifyId</param>
        public bool Delete(string MemberClassifyId)
        {
            return dal.Delete(MemberClassifyId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="MemberClassifyId">MemberClassifyId</param>
        public bool Exists(string MemberClassifyId)
        {
            return dal.Exists(MemberClassifyId);
        }
        
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="MemberClassifyId">MemberClassifyId</param>
        public Xiuse.Model.xiuse_memberclassify GetModel(string MemberClassifyId)
        {
            return dal.GetModel(MemberClassifyId);
        }
        

		/// <summary>
        /// ��������
        /// </summary>
        /// <param name="">�ۿ�ID[DiscountId]</param>
        /// <param name="">��������[ClassifyName]</param>
        /// <param name="">˵��[ClassRemark]</param>
        /// <param name="">��Ա����[ClassifyMemberNum]</param>
        /// <param name="">�޸�ʱ��[ClassifyTime]</param>
        /// <param name="">ɾ����־��(0,���ã�1��ͣ�ã�2��ɾ����)[DelTag]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string DiscountId,string ClassifyName,string ClassRemark,int ClassifyMemberNum,string ClassifyTime,byte DelTag, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(DiscountId,ClassifyName,ClassRemark,ClassifyMemberNum,ClassifyTime,DelTag,StartIndex,PageSize,out count);
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
        private List<Xiuse.Model.xiuse_memberclassify> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_memberclassify> list = new List<Xiuse.Model.xiuse_memberclassify>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_memberclassify>(dataSet, 0));
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
        private Xiuse.Model.xiuse_memberclassify DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_memberclassify>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// ������DataSetת��ΪList
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_memberclassify> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_memberclassify> Tmp = new List<Model.xiuse_memberclassify>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_memberclassify model = new Xiuse.Model.xiuse_memberclassify();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.MemberClassifyId = (string)dr["MemberClassifyId"];
                    model.DiscountId = (string)dr["DiscountId"];
                    model.ClassifyName = dr["ClassifyName"].ToString();
                    model.ClassRemark = dr["ClassRemark"].ToString();
                    model.ClassifyMemberNum = (int)dr["ClassifyMemberNum"];
                    model.ClassifyTime = dr["ClassifyTime"].ToString();
                    model.DelTag = (byte)dr["DelTag"];
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
