using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [xiuse_memberclassify] ���ݲ�����
    /// </summary>
    public class xiuse_memberclassify
    {
        public xiuse_memberclassify(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_memberclassify model)
        {
            string strSql=String.Format(@"Insert Into xiuse_memberclassify(DiscountId,ClassifyName,ClassRemark,ClassifyMemberNum,ClassifyTime,DelTag,RestaurantId) 
                                        values({0},'{1}','{2}',{3},'{4}',{5},{6})",
                                        model.DiscountId,model.ClassifyName,model.ClassRemark,model.ClassifyMemberNum,model.ClassifyTime,model.DelTag,model.RestaurantId);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_memberclassify model)
        {
            string strSql=String.Format(@"Update xiuse_memberclassify Set 
            DiscountId={0},ClassifyName='{1}',ClassRemark='{2}',ClassifyMemberNum={3},ClassifyTime='{4}',DelTag={5},RestaurantId={6} 
            Where MemberClassifyId={7}",
            model.DiscountId,model.ClassifyName,model.ClassRemark,model.ClassifyMemberNum,model.ClassifyTime,model.DelTag,model.RestaurantId,model.MemberClassifyId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <parame name="MemberClassifyId">MemberClassifyId</param>
        public bool Delete(string MemberClassifyId)
        {
            string strSql=String.Format("Delete From xiuse_memberclassify Where MemberClassifyId={0}",MemberClassifyId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <parame name="MemberClassifyId">MemberClassifyId</param>
        public bool Exists(string MemberClassifyId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_memberclassify Where MemberClassifyId={0}",MemberClassifyId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }
        


        /// <summary>
        /// ��ȡʵ��
        /// </summary>
         /// <parame name="MemberClassifyId">MemberClassifyId</param>
        public Xiuse.Model.xiuse_memberclassify GetModel(string MemberClassifyId)
        {
             string strSql=String.Format(@"Select * From xiuse_memberclassify Where MemberClassifyId={0}",MemberClassifyId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.xiuse_memberclassify  model=new Xiuse.Model.xiuse_memberclassify();
                DataRow dr=ds.Tables[0].Rows[0];
				model.MemberClassifyId=(string)dr["MemberClassifyId"];
				model.DiscountId=(string)dr["DiscountId"];
				model.ClassifyName=dr["ClassifyName"].ToString();
				model.ClassRemark=dr["ClassRemark"].ToString();
				model.ClassifyMemberNum=(int)dr["ClassifyMemberNum"];
				model.ClassifyTime=dr["ClassifyTime"].ToString();
				model.DelTag=(byte)dr["DelTag"];
                model.RestaurantId = (string)dr["RestaurantId"];
                return model;
            }
            else
            {
                return null;
            }
        }
        #region ����xcf  �޸�ʱ�� 2016/12/18

        /// <summary>
        /// ��ȡ���������еĻ�Ա����
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        public DataSet GetDatas(string RestaurantId)
        {
            string strSql = String.Format(@"Select * From xiuse_memberclassify Where RestaurantId={0}", RestaurantId);
            return AosyMySql.ExecuteforDataSet(strSql);
        }




        /// <summary>
        /// ���û�Ա���͵�״̬��0,���ã�1��ͣ�ã�2��ɾ������
        /// </summary>
        /// <param name="State">��0,���ã�1��ͣ�ã�2��ɾ������</param>
        /// <param name="MemberClassifyId">��Ա���Id</param>
        /// <returns></returns>
        public bool SetMemberClassify(int State,string MemberClassifyId)
        {
            string strSql = string.Format("update xiuse_memberclassify set DelTag={0} where MemberClassifyId={1}", State, MemberClassifyId);
            if (AosyMySql.ExecuteNonQuery(strSql) > 0)
                return true;
            else
                return false;
        }
        #endregion



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
        public DataSet Search(string DiscountId,string ClassifyName,string ClassRemark,int ClassifyMemberNum,string ClassifyTime,byte DelTag,string RestaurantId, int StartIndex, int PageSize, out int RecordCount)
        {
            #region �������...
            StringBuilder strWhere=new StringBuilder();

            if(DiscountId.ToString().Length>0)
                strWhere.Append(" And DiscountId="+DiscountId);
            

            if(ClassifyName!=null && ClassifyName.Length>0)
                strWhere.Append(" And ClassifyName='"+ClassifyName+"'");
            

            if(ClassRemark!=null && ClassRemark.Length>0)
                strWhere.Append(" And ClassRemark='"+ClassRemark+"'");
            

            if(ClassifyMemberNum.ToString().Length>0)
                strWhere.Append(" And ClassifyMemberNum="+ClassifyMemberNum);
            

            if(ClassifyTime!=null && ClassifyTime.Length>0)
                strWhere.Append(" And ClassifyTime='"+ClassifyTime+"'");
            

            if(DelTag.ToString().Length>0)
                strWhere.Append(" And DelTag="+DelTag);

            if (RestaurantId.ToString().Length > 0)
                strWhere.Append(" And RestaurantId=" + RestaurantId);

            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From xiuse_memberclassify Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From xiuse_memberclassify Where");
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
            string strSql="Select "+ Fields +" From xiuse_memberclassify";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
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
            string strSql="Select "+ Fields +" From xiuse_memberclassify";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From xiuse_memberclassify";
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
            string strSql="Select * From xiuse_memberclassify ";
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
            string strSql="Select * From xiuse_memberclassify ";
            string countSql="Select Count(*) From xiuse_memberclassify ";
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
            string sql = "update xiuse_memberclassify set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

