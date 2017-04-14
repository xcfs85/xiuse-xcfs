using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [xiuse_menuclassify] ���ݲ�����
    /// </summary>
    public class xiuse_menuclassify
    {
        public xiuse_menuclassify(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_menuclassify model)
        {
            string strSql=String.Format(@"Insert Into xiuse_menuclassify(ClassifyInstruction,ClassifyNo,ClassifyNet,ClassifyTag,ClassifyTime,ClassifyId,RestaurantId) 
                                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                                        model.ClassifyInstruction,model.ClassifyNo,model.ClassifyNet,model.ClassifyTag,model.ClassifyTime,model.ClassifyId,model.RestaurantId);

            return AosyMySql.ExecuteforBool(strSql);
        }



        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_menuclassify model)
        {
            string strSql=String.Format(@"Update xiuse_menuclassify Set 
            ClassifyInstruction='{0}',ClassifyNo='{1}',ClassifyNet='{2}',ClassifyTag='{3}',ClassifyTime='{4}' 
            Where ClassifyId='{5}'",
            model.ClassifyInstruction,model.ClassifyNo,model.ClassifyNet,model.ClassifyTag,model.ClassifyTime,model.ClassifyId);
            return AosyMySql.ExecuteforBool(strSql);
        }


        public bool UpdateList(List<Xiuse.Model.xiuse_menuclassify> lst, Model.xiuse_menuclassify MenuModel)
        {
            List<string> newList = new List<string>();
            foreach (Model.xiuse_menuclassify model in lst)
            {
                string strSql = String.Format(@"update xiuse_menuclassify set ClassifyNo='{0}' where ClassifyId='{1}'",model.ClassifyNo,model.ClassifyId);
                newList.Add(strSql);
            }
            string strSql2 = String.Format(@"update xiuse_menuclassify set ClassifyInstruction ='{0}',ClassifyTag='{1}', ClassifyTime='{2}' where ClassifyId='{3}'", MenuModel.ClassifyInstruction, MenuModel.ClassifyTag, MenuModel.ClassifyTime,MenuModel.ClassifyId);
            newList.Add(strSql2);
            return AosyMySql.ExecuteListSQL(newList)==lst.Count+1;
        }


        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <parame name="ClassifyId">ClassifyId</param>
        public bool Delete(string ClassifyId)
        {
            string strSql=String.Format("Delete From xiuse_menuclassify Where ClassifyId='{0}'",ClassifyId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        /// <summary>
        /// ɾ���������¶�����¼
        /// </summary>
        /// <param name="ClassifyId"></param>
        /// <param name="lst"></param>
        /// <returns></returns>
        public bool DeleteList(string ClassifyId, List<Xiuse.Model.xiuse_menuclassify> lst)
        {
            List<string> newList = new List<string>();
            string strSql= String.Format("Delete From xiuse_menuclassify Where ClassifyId='{0}'", ClassifyId);
            newList.Add(strSql);
            foreach (Model.xiuse_menuclassify model in lst)
            {
                strSql = String.Format(@"update xiuse_menuclassify set ClassifyNo='{0}' where ClassifyId='{1}'", model.ClassifyNo, model.ClassifyId);
                newList.Add(strSql);
            }
            return AosyMySql.ExecuteListSQL(newList) == (lst.Count+1);
        }

        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <parame name="ClassifyId">ClassifyId</param>
        public bool Exists(string ClassifyId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_menuclassify Where ClassifyId='{0}'",ClassifyId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }


        /// <summary>
        ///  �ж���������Ƿ����
        /// </summary>
        /// <parame name="ClassifyId">ClassifyId</param>
        public bool ExistsRestaurant(string RestaurantId)
        {
            string strSql = String.Format("Select Count(1) From xiuse_menuclassify Where Restaurant='{0}'", RestaurantId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString()) > 0;
        }


        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <parame name="ClassifyId">ClassifyId</param>
        public Xiuse.Model.xiuse_menuclassify GetModel(string ClassifyId)
        {
             string strSql=String.Format(@"Select * From xiuse_menuclassify Where ClassifyId='{0}'",ClassifyId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.xiuse_menuclassify  model=new Xiuse.Model.xiuse_menuclassify();
                DataRow dr=ds.Tables[0].Rows[0];
				model.ClassifyId=(string)dr["ClassifyId"];
				model.ClassifyInstruction=dr["ClassifyInstruction"].ToString();
				model.ClassifyNo=(int)dr["ClassifyNo"];
				model.ClassifyNet=(short)dr["ClassifyNet"];
				model.ClassifyTag=dr["ClassifyTag"].ToString();
				model.ClassifyTime=(DateTime)dr["ClassifyTime"];
                model.RestaurantId = dr["RestaurantId"].ToString();
                return model;
            }
            else
            {
                return null;
            }
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
        public DataSet Search(string ClassifyInstruction,int ClassifyNo,short ClassifyNet,string ClassifyTag,string ClassifyTime, int StartIndex, int PageSize, out int RecordCount)
        {
            #region �������...
            StringBuilder strWhere=new StringBuilder();

            if(ClassifyInstruction!=null && ClassifyInstruction.Length>0)
                strWhere.Append(" And ClassifyInstruction='"+ClassifyInstruction+"'");
            

            if(ClassifyNo.ToString().Length>0)
                strWhere.Append(" And ClassifyNo="+ClassifyNo);
            

            if(ClassifyNet.ToString().Length>0)
                strWhere.Append(" And ClassifyNet="+ClassifyNet);
            

            if(ClassifyTag!=null && ClassifyTag.Length>0)
                strWhere.Append(" And ClassifyTag='"+ClassifyTag+"'");
            

            if(ClassifyTime!=null && ClassifyTime.Length>0)
                strWhere.Append(" And ClassifyTime='"+ClassifyTime+"'");
            
            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From xiuse_menuclassify Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From xiuse_menuclassify Where");
            countSql.Append(where);

            int count=0;
            DataSet ds=AosyMySql.ExecuteforDataSet(StartIndex,PageSize,out count,strSql.ToString(),countSql.ToString());
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
            string strSql="Select "+ Fields +" From xiuse_menuclassify";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            return AosyMySql.ExecuteforDataSet(strSql);
        }
        /// <summary>
        /// ���²�Ʒ����
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataSet GetClassifies(string RestaurantId,string ClassifyId)
        {
            string strSql = String.Format(@"select * from xiuse_menuclassify where RestaurantId='{0}'and ClassifyId<>'{1}' order by ClassifyNo asc ",RestaurantId, ClassifyId);
            return AosyMySql.ExecuteforDataSet(strSql);
        }

        /// <summary>
        /// ��ȡ����[���ڷ�ҳ]
        /// </summary>
        /// <param name="Fields">�ֶ��ַ���[ȫ��Ϊ*]</param>
        /// <param name="Wheres">����[��Ϊ��]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet GetData(string Fields, string Wheres, int StartIndex, int PageSize, out int RecordCount)
        {
            string strSql="Select "+ Fields +" From xiuse_menuclassify";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From xiuse_menuclassify";
	    if(Wheres.Length>0)countSql+=" Where "+ Wheres +"";
            int count=0;
            DataSet ds=AosyMySql.ExecuteforDataSet(StartIndex,PageSize,out count,strSql,countSql);
            RecordCount=count;
            return ds;
        }
        

    
        /// <summary>
        /// ��ȡȫ������
        /// </summary>
        public DataSet GetAll()
        {
            string strSql="Select * From xiuse_menuclassify ";
            return AosyMySql.ExecuteforDataSet(strSql);
        }


        /// <summary>
        /// ��ȡȫ������[���ڷ�ҳ]
        /// </summary>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet GetAll(int StartIndex, int PageSize, out int RecordCount)
        {
            string strSql="Select * From xiuse_menuclassify ";
            string countSql="Select Count(*) From xiuse_menuclassify ";
            int count=0;
            DataSet ds=AosyMySql.ExecuteforDataSet(StartIndex,PageSize,out count,strSql,countSql);
            RecordCount=count;
            return ds;
        }

        /// <summary>
        /// ִ�и���SQL���
        /// </summary>
        /// <param name="filed">Ҫ���µ��ֶΣ�����["name='"+name+"',pwd='"+pwd+"'"]</param>
        /// <param name="wheres">��������������["id="+id]</param>
        /// <returns></returns>
        public int ExecuteUpdate(string updatefield, string wheres)
        {
            string sql = "update xiuse_menuclassify set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

