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
    /// [xiuse_user] 业务逻辑处理
    /// </summary>
    public class xiuse_user 
    {
       
        private readonly Xiuse.DAL.xiuse_user dal=new Xiuse.DAL.xiuse_user();

        public xiuse_user(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_user model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_user model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="UserId">UserId</param>
        public bool Delete(string UserId)
        {
            return dal.Delete(UserId);
        }
        
        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <param name="UserId">UserId</param>
        public bool Exists(string UserId)
        {
            return dal.Exists(UserId);
        }

        public bool WorkerExists(string UserId)
        {
            return dal.WorkerExists(UserId);
        }
        /// <summary>
        /// 通过id查询实体
        /// </summary>
        /// <param name="UserId">UserId</param>
        public Xiuse.Model.xiuse_user GetModel(string UserId)
        {
            return dal.GetModel(UserId);
        }

        ///修改员工权限
        /// 
        public bool FixWorker(string WorkerId, int DelTag)
        {
            return dal.FixWorker(WorkerId,DelTag);
        }
        /*
         * 增加获取全部实体
         * 
         * 版本1 修改时间2016/12/12  创建函数 @xcfs85  
         * 
         */
        /// <summary>
        /// 获取全部实体
        /// </summary>
        public List<Xiuse.Model.xiuse_user> GetModels()
        {
            return dal.GetModels();
        }

        /// <summary>
        /// 获取全部WORKER
        /// </summary>

        public List<Xiuse.Model.xiuse_user> GetWorkerModels()
        {
            return dal.GetWorkerModels();
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
            int count=0;
            DataSet ds=dal.Search(RestaurantId,UserName,Weixin,CellPhone,Email,Password,UserRole,ParentUserId,OwnRestaurant,Time,StartIndex,PageSize,out count);
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
            return dal.GetData(Fields,Wheres);
        }


        /// <summary>
        /// 获取数据[用于分页]
        /// </summary>
        /// <param name="Fields">字段字符串[全部为*]</param>
        /// <param name="Wheres">条件[可为空]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet GetData(string Fields, string Wheres,int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.GetData(Fields,Wheres,StartIndex,PageSize,out count);
            RecordCount=count;
            return ds;
        }
        
        /// <summary>
        /// 获取全部数据
        /// </summary>
        public DataSet GetAll()
        {
            return dal.GetAll();
        }
       
        /// <summary>
        /// 获取全部数据[用于分页]
        /// </summary>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet GetAll(int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;                              //记录总数
            DataSet ds=dal.GetAll(StartIndex,PageSize,out count);
            RecordCount=count;
            return ds;
        }   

        /// <summary>
        /// 执行更新SQL语句
        /// </summary>
        /// <param name="filed">要更新的字段，例：["name='"+name+"',pwd='"+pwd+"'"]</param>
        /// <param name="wheres">更新条件，例：["id="+id]</param>
        public int ExecuteUpdate(string updatefield, string wheres)
        {
           return dal.ExecuteUpdate(updatefield,wheres);
        }
        #region 工具类
        /// <summary>
        /// 把DataSet转成List泛型集合(expand无关联实体)
        /// Author:xcf Date:2015.01.26
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_user> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_user> list = new List<Xiuse.Model.xiuse_user>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_user>(dataSet, 0));
                return list;
            }
            return null;
        }
        /// <summary>
        /// 把DataSet转成泛型(expand无关联实体)
        /// Author:xcf Date:2015.01.26
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        private Xiuse.Model.xiuse_user DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_user>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// 工具类DataSet转换为List
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_user> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_user> Tmp = new List<Model.xiuse_user>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_user model = new Xiuse.Model.xiuse_user();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.UserId = (string)dr["UserId"];
                    model.RestaurantId = (string)dr["RestaurantId"];
                    model.UserName = dr["UserName"].ToString();
                    model.Weixin = dr["Weixin"].ToString();
                    model.CellPhone = (decimal)dr["CellPhone"];
                    model.Email = dr["Email"].ToString();
                    model.Password = dr["Password"].ToString();
                    model.UserRole = (int)dr["UserRole"];
                    model.ParentUserId = dr["ParentUserId"].ToString();
                    model.OwnRestaurant = (int)dr["OwnRestaurant"];
                    model.Time = dr["Time"].ToString();
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
