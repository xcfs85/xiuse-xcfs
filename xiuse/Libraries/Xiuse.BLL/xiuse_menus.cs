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
    /// [xiuse_menus] ҵ���߼�����
    /// </summary>
    public class xiuse_menus 
    {
       
        private readonly Xiuse.DAL.xiuse_menus dal=new Xiuse.DAL.xiuse_menus();

        public xiuse_menus(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_menus model)
        {
            return dal.Insert(model);
        }
        /// <summary>
        /// ���³���menu��˳��
        /// </summary>
        /// <param name="rest"></param>
        /// <param name="ClassifyId"></param>
        /// <returns></returns>
        public List<Model.xiuse_menus> GetAllMenusWithoutUpdate(string rest, string classifyId,string menuId)
        {
            return DataSetTransModelListNoExpand(dal.GetAllMenusWithoutUpdate(rest, classifyId,menuId));
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_menus model)
        {
            return dal.Update(model);
        }

        public bool UpdateList(List<Model.xiuse_menus> lst, Model.xiuse_menus menuModel)
        {
            return dal.UpdateList(lst,menuModel);
        }
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <param name="MenuId">MenuId</param>
        public bool Delete(string MenuId)
        {
            return dal.Delete(MenuId);
        }
        /// <summary>
        /// ɾ���������¶������
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public bool DeleteList(string MenuId, List<Xiuse.Model.xiuse_menus> lst)
        {
            return dal.DeleteList(MenuId, lst);
        }


        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <param name="MenuId">MenuId</param>
        public bool Exists(string MenuId)
        {
            return dal.Exists(MenuId);
        }
        
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="MenuId">MenuId</param>
        public Xiuse.Model.xiuse_menus GetModel(string MenuId)
        {
            return dal.GetModel(MenuId);
        }
        

		/// <summary>
        /// ��������
        /// </summary>
        /// <param name="">[RestaurantId]</param>
        /// <param name="">��Ʒ����[ClassifyId]</param>
        /// <param name="">��Ʒ����[MenuName]</param>
        /// <param name="">(����)��Ʒʣ������[MenuQuantity]</param>
        /// <param name="">��Ʒ�۸�[MenuPrice]</param>
        /// <param name="">�����[MenuShortcut]</param>
        /// <param name="">��Ʒ��ǩ������,΢΢��,΢��,��,����,��̬��,���ǣ�[MenuTag]</param>
        /// <param name="">��ƷͼƬ��·��[MenuImage]</param>
        /// <param name="">��Ʒ����[MenuNo]</param>
        /// <param name="">��Ʒ����[MenuInstruction]</param>
        /// <param name="">��Ʒ����״̬��1�������ۣ�0���������ۣ�[SaleState]</param>
        /// <param name="">��Ʒ״̬��0��������1��ͣ�á�2����ɾ������[MenuState]</param>
        /// <param name="">����ʱ��[MenuTime]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string RestaurantId,string ClassifyId,string MenuName,int MenuQuantity,decimal MenuPrice,string MenuShortcut,string MenuTag,string MenuImage,int MenuNo,string MenuInstruction,int SaleState,int MenuState,string MenuTime, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(RestaurantId,ClassifyId,MenuName,MenuQuantity,MenuPrice,MenuShortcut,MenuTag,MenuImage,MenuNo,MenuInstruction,SaleState,MenuState,MenuTime,StartIndex,PageSize,out count);
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


        ///
        ///��ȡĳһ��������Ʒ�����µ����в�Ʒ��Ϣ
        /// 
        public List<Xiuse.Model.xiuse_menus> GetMenuInfo(string RestaurantId, string MenuClassify)
        {
            return DataSetTransModelListNoExpand(GetData("*"," RestaurantId ='"+RestaurantId+ "' and MenuState<>2 and MenuState<>1  and ClassifyId ='" + MenuClassify+"'"));

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
        public List<Xiuse.Model.xiuse_menus> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_menus> list = new List<Xiuse.Model.xiuse_menus>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_menus>(dataSet, 0));
                return list;
            }
            return list;
        }
        /// <summary>
        /// ��DataSetת�ɷ���(expand�޹���ʵ��)
        /// Author:xcf Date:2015.01.26
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        private Xiuse.Model.xiuse_menus DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_menus>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// ������DataSetת��ΪList
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_menus> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_menus> Tmp = new List<Model.xiuse_menus>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_menus model = new Xiuse.Model.xiuse_menus();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.MenuId = (string)dr["MenuId"];
                    model.RestaurantId = (string)dr["RestaurantId"];
                    model.ClassifyId = (string)dr["ClassifyId"];
                    model.MenuName = dr["MenuName"].ToString();
                    model.MenuQuantity = (int)dr["MenuQuantity"];
                    model.MenuPrice = (decimal)dr["MenuPrice"];
                    model.MenuShortcut = dr["MenuShortcut"].ToString();
                    model.MenuTag = dr["MenuTag"].ToString();
                    model.MenuImage = dr["MenuImage"].ToString();
                    model.MenuNo = (int)dr["MenuNo"];
                    model.MenuInstruction = dr["MenuInstruction"].ToString();
                    model.SaleState = (short)dr["SaleState"];
                    model.MenuState = (short)dr["MenuState"];
                    model.MenuTime = (DateTime)dr["MenuTime"];
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
