using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [xiuse_user] ���ݲ�����
    /// </summary>
    public class xiuse_user
    {
        public xiuse_user(){}
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Insert(Xiuse.Model.xiuse_user model)
        {
            string strSql=String.Format(@"Insert Into xiuse_user(RestaurantId,UserName,Weixin,CellPhone,Email,Password,UserRole,ParentUserId,OwnRestaurant,Time,UserId) 
                                        values('{0}','{1}','{2}',{3},'{4}','{5}',{6},'{7}',{8},'{9}','{10}')",
                                        model.RestaurantId,model.UserName,model.Weixin,model.CellPhone,model.Email,model.Password,model.UserRole,model.ParentUserId,model.OwnRestaurant,model.Time,model.UserId);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ��</param>
        public bool Update(Xiuse.Model.xiuse_user model)
        {
            string strSql=String.Format(@"Update xiuse_user Set 
            RestaurantId='{0}',UserName='{1}',Weixin='{2}',CellPhone={3},Email='{4}',Password='{5}',UserRole={6},ParentUserId='{7}',OwnRestaurant={8},Time='{9}' 
            Where UserId={10}",
            model.RestaurantId,model.UserName,model.Weixin,model.CellPhone,model.Email,model.Password,model.UserRole,model.ParentUserId,model.OwnRestaurant,model.Time,model.UserId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  ɾ��һ������
        /// </summary>
        /// <parame name="UserId">UserId</param>
        public bool Delete(string UserId)
        {
            string strSql=String.Format("Delete From xiuse_user Where UserId='{0}'",UserId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  �ж��Ƿ����
        /// </summary>
        /// <parame name="UserId">UserId</param>
        public bool Exists(string UserId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_user Where UserId='{0}'",UserId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }

        /// <summary>
        ///  �ж�WORKER�Ƿ����
        /// </summary>
        /// <parame name="UserId">UserId</param>
        public bool WorkerExists(string UserId)
        {
            string strSql = String.Format("Select Count(1) From xiuse_user Where UserId='{0}' and UserRole=1", UserId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString()) > 0;
        }
        ///��¼�ж��û���������
        /// 
        public string AffirmUser(string UserName, string Password)
        {
            string strSql = String.Format("Select UserId From xiuse_user Where Username='{0}' and Password='{1}'", UserName,Password);
            return AosyMySql.ExecuteScalar(strSql).ToString();
        }


        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <parame name="UserId">UserId</param>
        public Xiuse.Model.xiuse_user GetModel(string UserId)
        {
             string strSql=String.Format(@"Select * From xiuse_user Where UserId='{0}'",UserId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.xiuse_user  model=new Xiuse.Model.xiuse_user();
                DataRow dr=ds.Tables[0].Rows[0];
				model.UserId=(string)dr["UserId"];
				model.RestaurantId=(string)dr["RestaurantId"];
				model.UserName=dr["UserName"].ToString();
				model.Weixin=dr["Weixin"].ToString();
				model.CellPhone=(string)dr["CellPhone"];
				model.Email=dr["Email"].ToString();
				model.Password=dr["Password"].ToString();
				model.UserRole=(short)dr["UserRole"];
				model.ParentUserId=dr["ParentUserId"].ToString();
				model.OwnRestaurant=(short)dr["OwnRestaurant"];
				model.Time=dr["Time"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }



        ///�޸�Ա��Ȩ��

        public bool FixWorker(string WorkerId, int DelTag)
        {
            string strSql = String.Format(@"Update xiuse_user set DelTag='{0}' where Userid={1}",DelTag,WorkerId);

            return AosyMySql.ExecuteforBool(strSql);
        }
        /*
         * ��ȡȫ��ʵ��
         * �汾1.00 �޸�ʱ��2016/12/12 @xcfs85
         */
        /// <summary>
        /// ��ȡȫ��ʵ��
        /// </summary>
        public List <Xiuse.Model.xiuse_user> GetModels()
        {
            string strSql = String.Format(@"Select * From xiuse_user ");
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            List<Xiuse.Model.xiuse_user> models = new List<Model.xiuse_user>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_user model = new Xiuse.Model.xiuse_user();
                    model.UserId = (string)dr["UserId"];
                    model.RestaurantId = (string)dr["RestaurantId"];
                    model.UserName = dr["UserName"].ToString();
                    model.Weixin = dr["Weixin"].ToString();
                    model.CellPhone = (string)dr["CellPhone"];
                    model.Email = dr["Email"].ToString();
                    model.Password = dr["Password"].ToString();
                    model.UserRole = (short)dr["UserRole"];
                    model.ParentUserId = dr["ParentUserId"].ToString();
                    model.OwnRestaurant = (short)dr["OwnRestaurant"];
                    model.Time = dr["Time"].ToString();
                    models.Add(model);
                }
                return models;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ��ȡworkerȫ��ʵ��
        /// worker��UserRole=1
        /// </summary>
        public List<Xiuse.Model.xiuse_user> GetWorkerModels(string restaurantId)
        {
            string strSql = String.Format(@"Select * From xiuse_user where UserRole=1 and RestaurantId='{0}'",restaurantId);
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            List<Xiuse.Model.xiuse_user> models = new List<Model.xiuse_user>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_user model = new Xiuse.Model.xiuse_user();
                    model.UserId = (string)dr["UserId"];
                    model.RestaurantId = (string)dr["RestaurantId"];
                    model.UserName = dr["UserName"].ToString();
                    model.Weixin = dr["Weixin"].ToString();
                    model.CellPhone = (string)dr["CellPhone"];
                    model.Email = dr["Email"].ToString();
                    model.Password = dr["Password"].ToString();
                    model.UserRole = (short)dr["UserRole"];
                    model.ParentUserId = dr["ParentUserId"].ToString();
                    model.OwnRestaurant = (short)dr["OwnRestaurant"];
                    model.Time = dr["Time"].ToString();
                    models.Add(model);
                }
                return models;
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
            #region �������...
            StringBuilder strWhere=new StringBuilder();

            if(RestaurantId.ToString().Length>0)
                strWhere.Append(" And RestaurantId="+RestaurantId);
            

            if(UserName!=null && UserName.Length>0)
                strWhere.Append(" And UserName='"+UserName+"'");
            

            if(Weixin!=null && Weixin.Length>0)
                strWhere.Append(" And Weixin='"+Weixin+"'");
            

            if(CellPhone.ToString().Length>0)
                strWhere.Append(" And CellPhone="+CellPhone);
            

            if(Email!=null && Email.Length>0)
                strWhere.Append(" And Email='"+Email+"'");
            

            if(Password!=null && Password.Length>0)
                strWhere.Append(" And Password='"+Password+"'");
            

            if(UserRole.ToString().Length>0)
                strWhere.Append(" And UserRole="+UserRole);
            

            if(ParentUserId!=null && ParentUserId.Length>0)
                strWhere.Append(" And ParentUserId='"+ParentUserId+"'");
            

            if(OwnRestaurant.ToString().Length>0)
                strWhere.Append(" And OwnRestaurant="+OwnRestaurant);
            

            if(Time!=null && Time.Length>0)
                strWhere.Append(" And Time='"+Time+"'");
            
            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From xiuse_user Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From xiuse_user Where");
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
            string strSql="Select "+ Fields +" From xiuse_user";
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
            string strSql="Select "+ Fields +" From xiuse_user";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From xiuse_user";
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
            string strSql="Select * From xiuse_user ";
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
            string strSql="Select * From xiuse_user ";
            string countSql="Select Count(*) From xiuse_user ";
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
            string sql = "update xiuse_user set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

