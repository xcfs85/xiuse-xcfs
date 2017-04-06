using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [xiuse_member] ���ݲ�����
    /// </summary>
    public class xiuse_member
    {
        public xiuse_member(){}




        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_member model)
        {
            string strSql = String.Format(@"Insert Into xiuse_member(MemberId,MemberClassifyId,MemberCardNo,MemberName,MemberAmount,MemberCell,MemberReference,MemberPassword,MemberState,MemberTime,RestaurantId,MemberEmail,MemberEnabledPassWord) 
                                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
                                        model.MemberId, model.MemberClassifyId, model.MemberCardNo, model.MemberName, model.MemberAmount, model.MemberCell, model.MemberReference, model.MemberPassword, model.MemberState, model.MemberTime, model.RestaurantId, model.MemberEmail, model.MemberEnabledPassWord);

            return AosyMySql.ExecuteforBool(strSql);
        }



        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_member model)
        {
            string strSql = String.Format(@"Update xiuse_member Set 
            MemberId='{0}',MemberClassifyId='{1}',MemberCardNo='{2}',MemberName='{3}',MemberAmount='{4}',MemberCell='{5}',MemberReference='{6}',MemberPassword='{7}',MemberState={8},MemberTime='{9}',RestaurantId='{10}',MemberEmail='{11}',MemberEnabledPassWord='{12}' 
            Where MemberId='{13}'",
            model.MemberId, model.MemberClassifyId, model.MemberCardNo, model.MemberName, model.MemberAmount, model.MemberCell, model.MemberReference, model.MemberPassword, model.MemberState, model.MemberTime, model.RestaurantId, model.MemberEmail, model.MemberEnabledPassWord, model.MemberId);
            return AosyMySql.ExecuteforBool(strSql);
        }

        
        

        
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <parame name="MemberId">MemberId</param>
        public bool Delete(string MemberId)
        {
            string strSql=String.Format("Delete From xiuse_member Where MemberId='{0}'",MemberId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <parame name="MemberId">MemberId</param>
        public bool Exists(string MemberId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_member Where MemberId='{0}'",MemberId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }
        
        /// <summary>
        ///  �жϻ�Ա�Ƿ����
        ///  ���ߣ�xcf  ʱ�䣺2016/12/13
        ///  
        /// </summary>
        /// <parame name="MemberId">MemberId</param>
        public bool ExistsMember(Model.xiuse_member Member)
        {
            string strSql = String.Format("Select Count(1) From xiuse_member Where MemberCardNo='{0}' or MemberCell='{1}'", Member.MemberCardNo,Member.MemberCell);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString()) > 0;
        }

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <parame name="MemberId">MemberId</param>
        public Xiuse.Model.xiuse_member GetModel(string MemberId)
        {
            string strSql = String.Format(@"Select * From xiuse_member Where MemberId='{0}'", MemberId);
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
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
                model.MemberState = (int)dr["MemberState"];
                model.MemberTime = (DateTime)dr["MemberTime"];
                model.RestaurantId = (string)dr["RestaurantId"];
                model.MemberEmail = dr["MemberEmail"].ToString();
                model.MemberEnabledPassWord = (short)dr["MemberEnabledPassWord"];
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// �������ݣ�����������Ա���š����ơ��ֻ�
        /// ���ߣ�xcf ʱ��2016.12.13
        /// </summary>
        /// <param name="">��Ա����[MemberCardNo]</param>
        /// <param name="">��Ա����[MemberName]</param>
        /// <param name="">�ֻ���[MemberCell]</param>
        public DataSet Search(string MemberCardNo,  string MemberName, string MemberCell)
        {
            #region �������...
            StringBuilder strSql = new StringBuilder();
            
            strSql.Append(string.Format("Select * From xiuse_member Where MemberCell like '%{0}%' or MemberName like '{1}' or MemberCardNo like", MemberCell,MemberName,MemberCardNo));
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql.ToString());
            return ds;
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
            #region �������...
            StringBuilder strWhere=new StringBuilder();

            if(MemberClassifyId.ToString().Length>0)
                strWhere.Append(" And MemberClassifyId="+MemberClassifyId);
            

            if(MemberCardNo.ToString().Length>0)
                strWhere.Append(" And MemberCardNo="+MemberCardNo);
            

            if(MemberName!=null && MemberName.Length>0)
                strWhere.Append(" And MemberName='"+MemberName+"'");
            

            if(MemberAmount.ToString().Length>0)
                strWhere.Append(" And MemberAmount="+MemberAmount);
            

            if(MemberCell!=null && MemberCell.Length>0)
                strWhere.Append(" And MemberCell='"+MemberCell+"'");
            

            if(MemberReference!=null && MemberReference.Length>0)
                strWhere.Append(" And MemberReference='"+MemberReference+"'");
            

            if(MemberPassword!=null && MemberPassword.Length>0)
                strWhere.Append(" And MemberPassword='"+MemberPassword+"'");
            

            if(MemberState.ToString().Length>0)
                strWhere.Append(" And MemberState="+MemberState);
            

            if(MemberTime!=null && MemberTime.Length>0)
                strWhere.Append(" And MemberTime='"+MemberTime+"'");
            

            if(RestaurantId.ToString().Length>0)
                strWhere.Append(" And RestaurantId="+RestaurantId);
            
            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From xiuse_member Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From xiuse_member Where");
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
            string strSql="Select "+ Fields +" From xiuse_member";
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
            string strSql="Select "+ Fields +" From xiuse_member";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From xiuse_member";
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
            string strSql="Select * From xiuse_member ";
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
            string strSql="Select * From xiuse_member ";
            string countSql="Select Count(*) From xiuse_member ";
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
            string sql = "update xiuse_member set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
        #endregion
    }
}

