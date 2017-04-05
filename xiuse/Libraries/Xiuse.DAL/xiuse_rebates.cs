using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [xiuse_rebates] ���ݲ�����
    /// </summary>
    public class xiuse_rebates
    {
        public xiuse_rebates(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_rebates model)
        {
            string strSql=String.Format(@"Insert Into xiuse_rebates(MemberId,MemberCardNo,RebatesType,RebatesAmount,DateTime,RebatesId) 
                                        values('{0}','{1}','{2}',{3},'{4}','{5}')",
                                        model.MemberId,model.MemberCardNo,model.RebatesType,model.RebatesAmount,model.DateTime,model.RebatesId);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_rebates model)
        {
            string strSql=String.Format(@"Update xiuse_rebates Set 
            MemberId='{0}',MemberCardNo='{1}',RebatesType='{2}',RebatesAmount='{3}',DateTime='{4}' 
            Where RebatesId={5}",
            model.MemberId,model.MemberCardNo,model.RebatesType,model.RebatesAmount,model.DateTime,model.RebatesId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <parame name="RebatesId">RebatesId</param>
        public bool Delete(string RebatesId)
        {
            string strSql=String.Format("Delete From xiuse_rebates Where RebatesId='{0}'",RebatesId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <parame name="RebatesId">RebatesId</param>
        public bool Exists(string RebatesId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_rebates Where RebatesId='{0}'",RebatesId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }
        


        /// <summary>
        /// ��ȡʵ��
        /// </summary>
         /// <parame name="RebatesId">RebatesId</param>
        public Xiuse.Model.xiuse_rebates GetModel(string RebatesId)
        {
             string strSql=String.Format(@"Select * From xiuse_rebates Where RebatesId='{0}'",RebatesId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.xiuse_rebates  model=new Xiuse.Model.xiuse_rebates();
                DataRow dr=ds.Tables[0].Rows[0];
				model.RebatesId=dr["RebatesId"].ToString();
				model.MemberId=dr["MemberId"].ToString();
				model.MemberCardNo=dr["MemberCardNo"].ToString();
				model.RebatesType=dr["RebatesType"].ToString();
				model.RebatesAmount=(decimal)dr["RebatesAmount"];
				model.DateTime= (DateTime)dr["DateTime"];
                return model;
            }
            else
            {
                return null;
            }
        }
        #region ���� xcf ʱ�� 2016/12/17
        /// <summary>
        /// ��ȡ�����ĵ����еĻ�Ա�ķ��ּ�¼
        /// </summary>
        /// <param name="RestaurantId">������Id</param>
        /// <returns></returns>
        public DataSet GetModelAt(string RestaurantId)
        {
            string strSql = string.Format(@"SELECT xiuse.xiuse_rebates.* FROM
                                    xiuse.xiuse_rebates LEFT JOIN xiuse.xiuse_member on
                                    xiuse_rebates.MemberId = xiuse_member.MemberId
                                    where xiuse_member.RestaurantId='{0}'", RestaurantId);
            return AosyMySql.ExecuteforDataSet(strSql);
        }
        /// <summary>
        /// ���������ڻ�Ա�ĵķ��ּ�¼
        /// </summary>
        /// <param name="RestaurantId">����ID</param>
        /// <param name="Condition">��������</param>
        /// <returns></returns>
        public DataSet Search(string RestaurantId,string Condition)
        {
            string strSql = string.Format(@"SELECT xiuse.xiuse_rebates.* FROM
                                 xiuse.xiuse_rebates LEFT JOIN xiuse.xiuse_member on 
                                 xiuse_rebates.MemberId = xiuse_member.MemberId 
                                 where xiuse_member.RestaurantId='{0}'  
                                 and (xiuse_member.MemberCell LIKE '%{1}%'  
                                 OR xiuse_member.MemberCardNo like '%{1}%' 
                                 OR xiuse_member.MemberName LIKE '%{1}%')", RestaurantId,Condition);
            return AosyMySql.ExecuteforDataSet(strSql);
        }
        #endregion

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="">��ԱId[MemberId]</param>
        /// <param name="">��Ա����[MemberCardNo]</param>
        /// <param name="">��������[RebatesType]</param>
        /// <param name="">���ֽ��[RebatesAmount]</param>
        /// <param name="">����[DateTime]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string MemberId,string MemberCardNo,string RebatesType,decimal RebatesAmount,string DateTime, int StartIndex, int PageSize, out int RecordCount)
        {
            #region �������...
            StringBuilder strWhere=new StringBuilder();

            if(MemberId!=null && MemberId.Length>0)
                strWhere.Append(" And MemberId='"+MemberId+"'");
            

            if(MemberCardNo!=null && MemberCardNo.Length>0)
                strWhere.Append(" And MemberCardNo='"+MemberCardNo+"'");
            

            if(RebatesType!=null && RebatesType.Length>0)
                strWhere.Append(" And RebatesType='"+RebatesType+"'");
            

            if(RebatesAmount.ToString().Length>0)
                strWhere.Append(" And RebatesAmount="+RebatesAmount);
            

            if(DateTime!=null && DateTime.Length>0)
                strWhere.Append(" And DateTime='"+DateTime+"'");
            
            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From xiuse_rebates Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From xiuse_rebates Where");
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
            string strSql="Select "+ Fields +" From xiuse_rebates";
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
            string strSql="Select "+ Fields +" From xiuse_rebates";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From xiuse_rebates";
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
            string strSql="Select * From xiuse_rebates ";
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
            string strSql="Select * From xiuse_rebates ";
            string countSql="Select Count(*) From xiuse_rebates ";
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
            string sql = "update xiuse_rebates set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

