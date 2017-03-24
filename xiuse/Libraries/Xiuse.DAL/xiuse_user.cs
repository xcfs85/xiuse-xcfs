using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [xiuse_user] 数据操作类
    /// </summary>
    public class xiuse_user
    {
        public xiuse_user(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_user model)
        {
            string strSql=String.Format(@"Insert Into xiuse_user(RestaurantId,UserName,Weixin,CellPhone,Email,Password,UserRole,ParentUserId,OwnRestaurant,Time,UserId) 
                                        values('{0}','{1}','{2}',{3},'{4}','{5}',{6},'{7}',{8},'{9}','{10}')",
                                        model.RestaurantId,model.UserName,model.Weixin,model.CellPhone,model.Email,model.Password,model.UserRole,model.ParentUserId,model.OwnRestaurant,model.Time,model.UserId);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_user model)
        {
            string strSql=String.Format(@"Update xiuse_user Set 
            RestaurantId='{0}',UserName='{1}',Weixin='{2}',CellPhone={3},Email='{4}',Password='{5}',UserRole={6},ParentUserId='{7}',OwnRestaurant={8},Time='{9}' 
            Where UserId={10}",
            model.RestaurantId,model.UserName,model.Weixin,model.CellPhone,model.Email,model.Password,model.UserRole,model.ParentUserId,model.OwnRestaurant,model.Time,model.UserId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <parame name="UserId">UserId</param>
        public bool Delete(string UserId)
        {
            string strSql=String.Format("Delete From xiuse_user Where UserId='{0}'",UserId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <parame name="UserId">UserId</param>
        public bool Exists(string UserId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_user Where UserId='{0}'",UserId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }

        /// <summary>
        ///  判断WORKER是否存在
        /// </summary>
        /// <parame name="UserId">UserId</param>
        public bool WorkerExists(string UserId)
        {
            string strSql = String.Format("Select Count(1) From xiuse_user Where UserId='{0}' and UserRole=1", UserId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString()) > 0;
        }
        ///登录判断用户名、密码
        /// 
        public string AffirmUser(string UserName, string Password)
        {
            string strSql = String.Format("Select UserId From xiuse_user Where Username='{0}' and Password='{1}'", UserName,Password);
            return AosyMySql.ExecuteScalar(strSql).ToString();
        }


        /// <summary>
        /// 获取实体
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



        ///修改员工权限

        public bool FixWorker(string WorkerId, int DelTag)
        {
            string strSql = String.Format(@"Update xiuse_user set DelTag='{0}' where Userid={1}",DelTag,WorkerId);

            return AosyMySql.ExecuteforBool(strSql);
        }
        /*
         * 获取全部实体
         * 版本1.00 修改时间2016/12/12 @xcfs85
         */
        /// <summary>
        /// 获取全部实体
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
        /// 获取worker全部实体
        /// worker的UserRole=1
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
        /// 搜索数据
        /// </summary>
        /// <param name="">餐厅ID[RestaurantId]</param>
        /// <param name="">姓名[UserName]</param>
        /// <param name="">微信号[Weixin]</param>
        /// <param name="">手机号[CellPhone]</param>
        /// <param name="">Email[Email]</param>
        /// <param name="">密码[Password]</param>
        /// <param name="">0,是管理员；1，是员工。[UserRole]</param>
        /// <param name="">上级用户Id，顶级为空！[ParentUserId]</param>
        /// <param name="">餐厅所有权（0，无；1，所有；）[OwnRestaurant]</param>
        /// <param name="">修改时间[Time]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string RestaurantId,string UserName,string Weixin,decimal CellPhone,string Email,string Password,int UserRole,string ParentUserId,bool OwnRestaurant,string Time, int StartIndex, int PageSize, out int RecordCount)
        {
            #region 条件语句...
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
        /// 获取数据
        /// </summary>
        /// <param name="Fields">字段字符串[全部为*]</param>
        /// <param name="Wheres">条件[可为空]</param>
        public DataSet GetData(string Fields, string Wheres)
        {
            string strSql="Select "+ Fields +" From xiuse_user";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            return AosyMySql.ExecuteforDataSet(strSql);
        }


        /// <summary>
        /// 获取数据[用于分页]
        /// </summary>
        /// <param name="Fields">字段字符串[全部为*]</param>
        /// <param name="Wheres">条件[可为空]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
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
        /// 获取全部数据
        /// </summary>
        public DataSet GetAll()
        {
            string strSql="Select * From xiuse_user ";
            return AosyMySql.ExecuteforDataSet(strSql);
        }


        /// <summary>
        /// 获取全部数据[用于分页]
        /// </summary>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
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
        /// 执行更新SQL语句
        /// </summary>
        /// <param name="filed">要更新的字段，例：["name='"+name+"',pwd='"+pwd+"'"]</param>
        /// <param name="wheres">更新条件，例：["id="+id]</param>
        /// <returns></returns>
        public int ExecuteUpdate(string updatefield, string wheres)
        {
            string sql = "update xiuse_user set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

