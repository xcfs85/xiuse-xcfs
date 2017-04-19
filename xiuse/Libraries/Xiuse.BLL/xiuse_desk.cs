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
    /// [xiuse_desk] 业务逻辑处理
    /// </summary>
    public class xiuse_desk
    {

        private readonly Xiuse.DAL.xiuse_desk dal = new Xiuse.DAL.xiuse_desk();
        private readonly Xiuse.DAL.xiuse_restaurant Restdal = new Xiuse.DAL.xiuse_restaurant();

        public xiuse_desk() { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_desk model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_desk model)
        {
            return dal.Update(model);
        }


        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="DeskId">DeskId</param>
        public bool Delete(string DeskId)
        {
            return dal.Delete(DeskId);
        }
        public bool DeleteState(string DeskId)
        {
            return dal.DeleteState(DeskId);
        }
        

        /// <summary>
        ///  判断餐桌是否存在
        /// </summary>
        /// <param name="DeskId">DeskId</param>
        public bool Exists(string DeskId)
        {
            return dal.Exists(DeskId);
        }



        /// <summary>
        ///  判断餐厅是否存在
        /// </summary>
        /// <param name="RestaurantId">RestaurantId</param>
        public bool RestaurantExists(string RestaurantId)
        {
            return Restdal.Exists(RestaurantId);
        }





        ///
        ///获取某一餐厅的所有餐桌信息
        /// 
        public List<Xiuse.Model.xiuse_desk> GetAllDesk(string RestaurantId)
        {
            return DataSetTransModelListNoExpand(GetData("*", "DeskDel=1 and RestaurantId=" + RestaurantId));

        }

        /// <summary>
        /// 获取某一餐厅所有餐桌信息（包含餐桌费用）
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        public DataSet GetAllDesksWithAccount(string RestaurantId)
        {

            return dal.GetAllDesksWithAccount(RestaurantId);
        }


        ///清理已付款的桌子
        /// 
        ///餐桌的状态：0，空桌；1，未支付；2，已支付；
        /// orderstate: 0,没有清台；1，已经清台；
        public bool ClearDesk(string DeskId)
        {
            return dal.ClearDesk(DeskId);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="DeskId">DeskId</param>
        public Xiuse.Model.xiuse_desk GetModel(string DeskId)
        {
            return dal.GetModel(DeskId);
        }


        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">餐厅ID[RestaurantId]</param>
        /// <param name="">餐桌名称[DeskName]</param>
        /// <param name="">是否接受外卖（0，不接受外卖。1接受外卖）[TakeOut]</param>
        /// <param name="">0,已删除。1正常[DeskDel]</param>
        /// <param name="">餐桌的状态：0，空桌；1，未支付；2，已支付；[DeskState]</param>
        /// <param name="">更新时间[DeskTime]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string RestaurantId, string DeskName, int TakeOut, int DeskDel, byte DeskState, string DeskTime, int StartIndex, int PageSize, out int RecordCount)
        {
            int count = 0;
            DataSet ds = dal.Search(RestaurantId, DeskName, TakeOut, DeskDel, DeskState, DeskTime, StartIndex, PageSize, out count);
            RecordCount = count;
            return ds;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="Fields">字段字符串[全部为*]</param>
        /// <param name="Wheres">条件[可为空]</param>
        public DataSet GetData(string Fields, string Wheres)
        {
            return dal.GetData(Fields, Wheres);
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
        private  List<Xiuse.Model.xiuse_desk> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_desk> list = new List<Xiuse.Model.xiuse_desk>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_desk>(dataSet, 0));
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
        private  Xiuse.Model.xiuse_desk DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_desk>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// 工具类DataSet转换为List
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_desk> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_desk> Tmp = new List<Model.xiuse_desk>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Xiuse.Model.xiuse_desk model = new Xiuse.Model.xiuse_desk();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.DeskId = (string)dr["DeskId"];
                    model.RestaurantId = dr["RestaurantId"].ToString();
                    model.DeskName = dr["DeskName"].ToString();
                    model.TakeOut = (short)dr["TakeOut"];
                    model.DeskDel = (short)dr["DeskDel"];
                    model.DeskState = (short)dr["DeskState"];
                    model.DeskTime = (DateTime)dr["DeskTime"];
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
