using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [xiuse_recharge] ���ݲ�����
    /// </summary>
    public class xiuse_recharge
    {
        public xiuse_recharge(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_recharge model)
        {
            string strSql=String.Format(@"Insert Into xiuse_recharge(MemberId,RechargeType,RechargeAmount,Balance,MemberCardNo,RechargeTime,RechargeId) 
                                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                                        model.MemberId,model.RechargeType,model.RechargeAmount,model.Balance,model.MemberCardNo,model.RechargeTime,model.RechargeId);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_recharge model)
        {
            string strSql=String.Format(@"Update xiuse_recharge Set 
            MemberId='{0}',RechargeType='{1}',RechargeAmount='{2}',Balance='{3}',MemberCardNo='{4}',RechargeTime='{5}' 
            Where RechargeId='{6}'",
            model.MemberId,model.RechargeType,model.RechargeAmount,model.Balance,model.MemberCardNo,model.RechargeTime,model.RechargeId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <parame name="RechargeId">RechargeId</param>
        public bool Delete(string RechargeId)
        {
            string strSql=String.Format("Delete From xiuse_recharge Where RechargeId='{0}'",RechargeId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <parame name="RechargeId">RechargeId</param>
        public bool Exists(string RechargeId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_recharge Where RechargeId='{0}'",RechargeId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }

        #region ��ȡʵ�壬�����ڵĳ�ֵ��¼���ߣ�xcf  ����ʱ�䣺2016/12/15
        /// <summary>
        /// ��ȡ���̵�ʵ��
        /// </summary>
        /// <param name="RestaurantId">���̵�ID</param>
        /// <returns></returns>
        public DataSet GetModelsAtRestaurant(string RestaurantId)
        {
            string strSql = String.Format(@" select* from xiuse_member left join xiuse_recharge on xiuse_member.MemberId = xiuse_recharge.MemberId where xiuse_member={ 0}", RestaurantId);
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            return ds;
        }
        /// <summary>
        /// �������ڻ�Ա��ֵ��¼
        /// </summary>
        /// <param name="RestaurantId">������ID</param>
        /// <param name="Condition">������������Ա���ơ���Ա�ֻ��š���Ա����</param>
        /// <returns></returns>
        public DataSet Search(string RestaurantId, string Condition)
        {
            string strSql = string.Format(@"SELECT
                        xiuse_recharge.* FROM
                        xiuse_recharge left join xiuse_member on xiuse_recharge.MemberId = xiuse_member.MemberId
                        where xiuse_member.RestaurantId = '{0}' and 
                            (xiuse_member.MemberCardNo like '%{1}%' or 
                             xiuse_member.MemberCell like '%{2}%' or 
                             xiuse_member.MemberName like'%{3}%') ", RestaurantId, Condition, Condition, Condition);
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            return ds;
        }
        #endregion

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <parame name="RechargeId">RechargeId</param>
        public Xiuse.Model.xiuse_recharge GetModel(string RechargeId)
        {
             string strSql=String.Format(@"Select * From xiuse_recharge Where RechargeId='{0}'",RechargeId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.xiuse_recharge  model=new Xiuse.Model.xiuse_recharge();
                DataRow dr=ds.Tables[0].Rows[0];
				model.RechargeId=(string)dr["RechargeId"];
				model.MemberId=(string)dr["MemberId"];
				model.RechargeType=(byte)dr["RechargeType"];
				model.RechargeAmount=(decimal)dr["RechargeAmount"];
				model.Balance=(decimal)dr["Balance"];
				model.MemberCardNo=dr["MemberCardNo"].ToString();
				model.RechargeTime=dr["RechargeTime"].ToString();
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
        /// <param name="">��Ա��Id[MemberId]</param>
        /// <param name="">��ֵ����[RechargeType]</param>
        /// <param name="">��ֵ���[RechargeAmount]</param>
        /// <param name="">�������[Balance]</param>
        /// <param name="">��Ա�Ŀ���[MemberCardNo]</param>
        /// <param name="">[RechargeTime]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string MemberId,byte RechargeType,decimal RechargeAmount,decimal Balance,string MemberCardNo,string RechargeTime, int StartIndex, int PageSize, out int RecordCount)
        {
            #region �������...
            StringBuilder strWhere=new StringBuilder();

            if(MemberId.ToString().Length>0)
                strWhere.Append(" And MemberId="+MemberId);
            

            if(RechargeType.ToString().Length>0)
                strWhere.Append(" And RechargeType="+RechargeType);
            

            if(RechargeAmount.ToString().Length>0)
                strWhere.Append(" And RechargeAmount="+RechargeAmount);
            

            if(Balance.ToString().Length>0)
                strWhere.Append(" And Balance="+Balance);
            

            if(MemberCardNo!=null && MemberCardNo.Length>0)
                strWhere.Append(" And MemberCardNo='"+MemberCardNo+"'");
            

            if(RechargeTime!=null && RechargeTime.Length>0)
                strWhere.Append(" And RechargeTime='"+RechargeTime+"'");
            
            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From xiuse_recharge Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From xiuse_recharge Where");
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
            string strSql="Select "+ Fields +" From xiuse_recharge";
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
            string strSql="Select "+ Fields +" From xiuse_recharge";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From xiuse_recharge";
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
            string strSql="Select * From xiuse_recharge ";
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
            string strSql="Select * From xiuse_recharge ";
            string countSql="Select Count(*) From xiuse_recharge ";
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
            string sql = "update xiuse_recharge set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

