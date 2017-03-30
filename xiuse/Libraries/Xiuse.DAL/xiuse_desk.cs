using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [xiuse_desk] ���ݲ�����
    /// </summary>
    public class xiuse_desk
    {
        public xiuse_desk(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_desk model)
        {
            string strSql=String.Format(@"Insert Into xiuse_desk(RestaurantId,DeskName,TakeOut,DeskDel,DeskState,DeskTime) 
                                        values('{0}','{1}',{2},{3},{4},'{5}')",
                                        model.RestaurantId,model.DeskName,model.TakeOut,model.DeskDel,model.DeskState,model.DeskTime);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_desk model)
        {
            string strSql=String.Format(@"Update xiuse_desk Set 
            RestaurantId='{0}',DeskName='{1}',TakeOut='{2}',DeskDel='{3}',DeskState='{4}',DeskTime='{5}' 
            Where DeskId='{6}'",
            model.RestaurantId,model.DeskName,model.TakeOut,model.DeskDel,model.DeskState,model.DeskTime,model.DeskId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <parame name="DeskId">DeskId</param>
        public bool Delete(string DeskId)
        {
            string strSql=String.Format("Delete From xiuse_desk Where DeskId='{0}'",DeskId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <parame name="DeskId">DeskId</param>
        public bool Exists(string DeskId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_desk Where DeskId='{0}'",DeskId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }



        /// <summary>
        /// ��ȡĳһ�������в�����Ϣ�������������ã�
        ///��ѯ��ǰ���������ж���
        //����״̬��0��δ֧����1����֧��;2,�˵���;
        //������״̬��0��������1��δ֧����2����֧��;
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        public DataSet GetAllDesksWithAccount(string RestaurantId)
        {
            string strSql = String.Format(@"select * from xiuse_desk where RestaurantId='{0}' and DeskDel=1", RestaurantId);
            DataSet a = new DataSet();
            a = AosyMySql.ExecuteforDataSet(strSql);
            if (a == null)
                return null;
            a.Tables[0].Columns.Add("AccountPayable");
            
            for (int i = 0; i < a.Tables[0].Rows.Count; i++)
            {
                //ȡͬһ����δ��̨�Ķ���
                string strSql2 = String.Format(@"select * from order_ where DeskId='{0}' and ClearDeskState=0", a.Tables[0].Rows[i]["DeskId"]);
                decimal accountPayable = 0;
                decimal alreadyPayable = 0;
                DataSet b = new DataSet();
                bool isAllPaid = true;
                b = AosyMySql.ExecuteforDataSet(strSql2);
                for (int j = 0; j < b.Tables[0].Rows.Count; j++)
                {
                    DataRow dr = b.Tables[0].Rows[j];
                    if ((short)dr["OrderState"] == 0)
                    {
                        accountPayable += (decimal)dr["AccountsPayable"];
                        isAllPaid = false;     
                    }else
                        alreadyPayable+= (decimal)dr["AccountsPayable"];
                }
                if (isAllPaid)
                {
                    a.Tables[0].Rows[i]["AccountPayable"] = alreadyPayable;
                }
                else
                a.Tables[0].Rows[i]["AccountPayable"] = accountPayable;
            }

            return a;
        }


        ///
        ///��������
        ///������״̬��0��������1��δ֧����2����֧����
        /// orderstate: 0,û����̨��1���Ѿ���̨��
        public bool ClearDesk(string DeskId)
        {
            string strSql = string.Format("Select OrderState from order_ where  DeskId='{0}'", DeskId);
            DataSet OrderState = AosyMySql.ExecuteforDataSet(strSql);
            if (OrderState.Tables[0].Rows[0].ToString() == "0")
                return false;
            else
            {
                string sql = string.Format("update order_ set CleanDeskState=1 where  DeskId='{0}'", DeskId);
                string sql2=string.Format("update xiuse.desk set DeskState=0 where  DeskId='{0}'", DeskId);

                AosyMySql.ExecuteNonQuery(sql);
                AosyMySql.ExecuteNonQuery(sql2);
                return true;
            }
                

        }

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <parame name="DeskId">DeskId</param>
        public Xiuse.Model.xiuse_desk GetModel(string DeskId)
        {
             string strSql=String.Format(@"Select * From xiuse_desk Where DeskId='{0}'",DeskId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.xiuse_desk  model=new Xiuse.Model.xiuse_desk();
                DataRow dr=ds.Tables[0].Rows[0];
				model.DeskId=(string)dr["DeskId"];
				model.RestaurantId=dr["RestaurantId"].ToString();
				model.DeskName=dr["DeskName"].ToString();
				model.TakeOut=(short)dr["TakeOut"];
				model.DeskDel=(short)dr["DeskDel"];
                model.DeskState=(byte)dr["DeskState"];
				model.DeskTime=(DateTime)dr["DeskTime"];
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
        /// <param name="">����ID[RestaurantId]</param>
        /// <param name="">��������[DeskName]</param>
        /// <param name="">�Ƿ����������0��������������1����������[TakeOut]</param>
        /// <param name="">0,��ɾ����1����[DeskDel]</param>
        /// <param name="">������״̬��0��������1��δ֧����2����֧����[DeskState]</param>
        /// <param name="">����ʱ��[DeskTime]</param>
        /// <param name="StartIndex">��ʼ��¼��</param>
        /// <param name="PageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="RecordCount">��¼����</param>
        public DataSet Search(string RestaurantId,string DeskName,int TakeOut,int DeskDel,byte DeskState,string DeskTime, int StartIndex, int PageSize, out int RecordCount)
        {
            #region �������...
            StringBuilder strWhere=new StringBuilder();

            if(RestaurantId!=null && RestaurantId.Length>0)
                strWhere.Append(" And RestaurantId='"+RestaurantId+"'");
            

            if(DeskName!=null && DeskName.Length>0)
                strWhere.Append(" And DeskName='"+DeskName+"'");
            

            if(TakeOut.ToString().Length>0)
                strWhere.Append(" And TakeOut="+TakeOut);
            

            if(DeskDel.ToString().Length>0)
                strWhere.Append(" And DeskDel="+DeskDel);
            

            if(DeskState.ToString().Length>0)
                strWhere.Append(" And DeskState="+DeskState);
            

            if(DeskTime!=null && DeskTime.Length>0)
                strWhere.Append(" And DeskTime='"+DeskTime+"'");
            
            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From xiuse_desk Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From xiuse_desk Where");
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
            string strSql="Select "+ Fields +" From xiuse_desk";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            return AosyMySql.ExecuteforDataSet(strSql);
        }

        public DataSet test(string RestaurantId)
        {
            string strSql = string.Format(@"Select * from xiuse_desk where RestaurantId='{0}'", RestaurantId);
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
            string strSql="Select "+ Fields +" From xiuse_desk";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From xiuse_desk";
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
            string strSql="Select * From xiuse_desk ";
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
            string strSql="Select * From xiuse_desk ";
            string countSql="Select Count(*) From xiuse_desk ";
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
            string sql = "update xiuse_desk set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

