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
    /// [xiuse_menuclassify] ҵ���߼�����
    /// </summary>
    public class xiuse_menuclassify 
    {
       
        private readonly Xiuse.DAL.xiuse_menuclassify dal=new Xiuse.DAL.xiuse_menuclassify();

        public xiuse_menuclassify(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_menuclassify model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_menuclassify model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="ClassifyId">ClassifyId</param>
        public bool Delete(string ClassifyId)
        {
            return dal.Delete(ClassifyId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="ClassifyId">ClassifyId</param>
        public bool Exists(string ClassifyId)
        {
            return dal.Exists(ClassifyId);
        }

        /// <summary>
        ///  �жϷ����Ƿ����
        /// </summary>
        public bool ExistsRestaurant(string RestaurantId)
        {
            return dal.Exists(RestaurantId);
        }

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="ClassifyId">ClassifyId</param>
        public Xiuse.Model.xiuse_menuclassify GetModel(string ClassifyId)
        {
            return dal.GetModel(ClassifyId);
        }
        

		/// <summary>
        /// ��������
        /// </summary>
        /// <param name="">Ʒ�ͷ������[ClassifyInstruction]</param>
        /// <param name="">��Ʒ����˳��[ClassifyNo]</param>
        /// <param name="">���ط��� (���ϵ㵥�ͻ��޷�ʹ��) 1,���ط��ࡣ0�����ط��ࡣ[ClassifyNet]</param>
        /// <param name="">[ClassifyTag]</param>
        /// <param name="">�������ʱ��[ClassifyTime]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string ClassifyInstruction,int ClassifyNo,int ClassifyNet,string ClassifyTag,string ClassifyTime, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(ClassifyInstruction,ClassifyNo,ClassifyNet,ClassifyTag,ClassifyTime,StartIndex,PageSize,out count);
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


        ///��ȡ��ǰ���������в�Ʒ���࣬��������ID
        ///��list��ʽ����
        /// 
        public List<Xiuse.Model.xiuse_menuclassify> GetAllMenuClassify(string ResaurantId)
        {
            return DataSetTransModelListNoExpand(GetData("*", "Resaurant=" + ResaurantId));
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
       private List<Xiuse.Model.xiuse_menuclassify> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_menuclassify> list = new List<Xiuse.Model.xiuse_menuclassify>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_menuclassify>(dataSet, 0));
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
       private  Xiuse.Model.xiuse_menuclassify DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_menuclassify>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// ������DataSetת��ΪList
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
      private  List<Xiuse.Model.xiuse_menuclassify> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_menuclassify> Tmp = new List<Model.xiuse_menuclassify>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_menuclassify model = new Xiuse.Model.xiuse_menuclassify();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.ClassifyId = (string)dr["ClassifyId"];
                    model.ClassifyInstruction = dr["ClassifyInstruction"].ToString();
                    model.ClassifyNo = (int)dr["ClassifyNo"];
                    model.ClassifyNet = (int)dr["ClassifyNet"];
                    model.ClassifyTag = dr["ClassifyTag"].ToString();
                    model.ClassifyTime = dr["ClassifyTime"].ToString();
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
