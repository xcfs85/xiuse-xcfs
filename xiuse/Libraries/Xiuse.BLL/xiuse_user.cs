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
    /// [xiuse_user] ҵ���߼�����
    /// </summary>
    public class xiuse_user 
    {
       
        private readonly Xiuse.DAL.xiuse_user dal=new Xiuse.DAL.xiuse_user();

        public xiuse_user(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_user model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_user model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="UserId">UserId</param>
        public bool Delete(string UserId)
        {
            return dal.Delete(UserId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="UserId">UserId</param>
        public bool Exists(string UserId)
        {
            return dal.Exists(UserId);
        }

        public bool WorkerExists(string UserId)
        {
            return dal.WorkerExists(UserId);
        }
        /// <summary>
        /// ͨ��id��ѯʵ��
        /// </summary>
        /// <param name="UserId">UserId</param>
        public Xiuse.Model.xiuse_user GetModel(string UserId)
        {
            return dal.GetModel(UserId);
        }

        ///�޸�Ա��Ȩ��
        /// 
        public bool FixWorker(string WorkerId, int DelTag)
        {
            return dal.FixWorker(WorkerId,DelTag);
        }
        /*
         * ���ӻ�ȡȫ��ʵ��
         * 
         * �汾1 �޸�ʱ��2016/12/12  �������� @xcfs85  
         * 
         */
        /// <summary>
        /// ��ȡȫ��ʵ��
        /// </summary>
        public List<Xiuse.Model.xiuse_user> GetModels()
        {
            return dal.GetModels();
        }

        /// <summary>
        /// ��ȡȫ��WORKER
        /// </summary>

        public List<Xiuse.Model.xiuse_user> GetWorkerModels()
        {
            return dal.GetWorkerModels();
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="">����ID[RestaurantId]</param>
        /// <param name="">����[UserName]</param>
        /// <param name="">΢�ź�[Weixin]</param>
        /// <param name="">�ֻ���[CellPhone]</param>
        /// <param name="">Email[Email]</param>
        /// <param name="">����[Password]</param>
        /// <param name="">0,�ǹ���Ա��1����Ա����[UserRole]</param>
        /// <param name="">�ϼ��û�Id������Ϊ�գ�[ParentUserId]</param>
        /// <param name="">��������Ȩ��0���ޣ�1�����У���[OwnRestaurant]</param>
        /// <param name="">�޸�ʱ��[Time]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string RestaurantId,string UserName,string Weixin,decimal CellPhone,string Email,string Password,int UserRole,string ParentUserId,bool OwnRestaurant,string Time, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(RestaurantId,UserName,Weixin,CellPhone,Email,Password,UserRole,ParentUserId,OwnRestaurant,Time,StartIndex,PageSize,out count);
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
        private List<Xiuse.Model.xiuse_user> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_user> list = new List<Xiuse.Model.xiuse_user>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_user>(dataSet, 0));
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
        private Xiuse.Model.xiuse_user DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_user>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// ������DataSetת��ΪList
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_user> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_user> Tmp = new List<Model.xiuse_user>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_user model = new Xiuse.Model.xiuse_user();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.UserId = (string)dr["UserId"];
                    model.RestaurantId = (string)dr["RestaurantId"];
                    model.UserName = dr["UserName"].ToString();
                    model.Weixin = dr["Weixin"].ToString();
                    model.CellPhone = (decimal)dr["CellPhone"];
                    model.Email = dr["Email"].ToString();
                    model.Password = dr["Password"].ToString();
                    model.UserRole = (int)dr["UserRole"];
                    model.ParentUserId = dr["ParentUserId"].ToString();
                    model.OwnRestaurant = (int)dr["OwnRestaurant"];
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
