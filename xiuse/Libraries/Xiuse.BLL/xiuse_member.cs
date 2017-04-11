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
    /// [xiuse_member] ҵ���߼�����
    /// </summary>
    public class xiuse_member 
    {
       
        private readonly Xiuse.DAL.xiuse_member dal=new Xiuse.DAL.xiuse_member();

        public xiuse_member(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_member model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_member model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// �������/��������
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdatePassword(Model.xiuse_member model)
        {
            return dal.UpdatePassword(model);
        }

        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="MemberId">MemberId</param>
        public bool Delete(string MemberId)
        {
            return dal.Delete(MemberId);
        }
        
        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="MemberId">MemberId</param>
        public bool Exists(string MemberId)
        {
            return dal.Exists(MemberId);
        }
        /// <summary>
        ///  �жϿ��ż���ز����Ƿ��쳣
        /// </summary>
        /// <param name="MemberId">MemberId</param>
        public bool ExistsMember(Model.xiuse_member member)
        {
            return dal.ExistsMember(member);
        }

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="MemberId">MemberId</param>
        public Xiuse.Model.xiuse_member GetModel(string MemberId)
        {
            return dal.GetModel(MemberId);
        }
        /*
         * ���ݲ���ID��ѯ��Ա��Ϣ
         * ������xcf  2016/12/13
         */
        /// <summary>
        /// ��ȡʵ��,���ݲ���ID��ѯʵ��
        /// </summary>
        /// <param name="RestaurantId">����ID</param>
        /// <returns></returns>List<Xiuse.Model.xiuse_member>
        public DataSet GetModels_RestaurantId(string RestaurantId)
        {
            return dal.GetModels_Rest(RestaurantId);
            //return DataSetTransModelListNoExpand(dal.GetModels_Rest(RestaurantId));
        }
        /*
        * ���ݻ�Ա��ID�趨��Ա������״̬
        * ������xcf  2016/12/13
        */
        /// <summary>
        /// �趨��Ա����״̬
        /// </summary>
        /// <param name="MemberId">��Ա��ID</param>
        /// <param name="flag">����״̬</param>
        /// <returns></returns>
        public bool SetMemberState(string MemberId,int flag)
        {
            if (dal.Exists(MemberId))
            {
                if (dal.ExecuteUpdate(String.Format("MemberState={0}", flag), String.Format("MemberId='{0}'", MemberId)) > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        /*
       * ���ݻ�Ա���ֻ��ż���Ա�ֻ��Ƿ��ظ�
       * ������xcf  2016/12/15
       */
        /// <summary>
        /// ���ĳ�����Ա�ֻ��Ƿ��ظ�
        /// </summary>
        /// <param name="Cell">�ֻ�����</param>
        /// <returns>true�����ظ���false:���ظ���</returns>
        public bool CheckCellExist(string cell,string rest)
        {
            if (dal.GetData("1", string.Format("MemberCell='{0}' and RestaurantId='{1}'", cell,rest)).Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="">��Ա����ID[MemberClassifyId]</param>
        /// <param name="">��Ա����[MemberCardNo]</param>
        /// <param name="">��Ա����[MemberName]</param>
        /// <param name="">�������[MemberAmount]</param>
        /// <param name="">�ֻ���[MemberCell]</param>
        /// <param name="">�Ƽ���[MemberReference]</param>
        /// <param name="">[MemberPassword]</param>
        /// <param name="">��Ա״̬��0�����ã�1�����ã���[MemberState]</param>
        /// <param name="">��Ա����ʱ��[MemberTime]</param>
        /// <param name="">[RestaurantId]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string MemberClassifyId,string MemberCardNo,string MemberName,decimal MemberAmount,string MemberCell,string MemberReference,string MemberPassword,bool MemberState,string MemberTime,string RestaurantId, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(MemberClassifyId,MemberCardNo,MemberName,MemberAmount,MemberCell,MemberReference,MemberPassword,MemberState,MemberTime,RestaurantId,StartIndex,PageSize,out count);
            RecordCount=count;
            return ds;
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="">��Ա����[MemberCardNo]</param>
        /// <param name="">��Ա����[MemberName]</param>
        /// <param name="">�ֻ���[MemberCell]</param>
        public List<Model.xiuse_member> Search( string MemberCardNo, string MemberName, string MemberCell)
        {
            return DataSetTransModelListNoExpand( dal.Search( MemberCardNo, MemberName, MemberCell));
            
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
        private  List<Xiuse.Model.xiuse_member> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_member> list = new List<Xiuse.Model.xiuse_member>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_member>(dataSet, 0));
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
        private  Xiuse.Model.xiuse_member DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_member>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// ������DataSetת��ΪList
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_member> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_member> Tmp = new List<Model.xiuse_member>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_member model = new Xiuse.Model.xiuse_member();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.MemberId = (string)dr["MemberId"];
                    model.MemberClassifyId = (string)dr["MemberClassifyId"];
                    model.MemberCardNo = (string)dr["MemberCardNo"];
                    model.MemberName = dr["MemberName"].ToString();
                    model.MemberAmount = (decimal)dr["MemberAmount"];
                    model.MemberCell = dr["MemberCell"].ToString();
                    model.MemberReference = dr["MemberReference"].ToString();
                    model.MemberPassword = dr["MemberPassword"].ToString();
                    model.MemberState = (short)dr["MemberState"];
                    model.MemberTime = (DateTime)dr["MemberTime"];
                    model.RestaurantId = (string)dr["RestaurantId"];
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
