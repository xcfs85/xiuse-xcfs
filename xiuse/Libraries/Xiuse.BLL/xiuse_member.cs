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
    /// [xiuse_member] 业务逻辑处理
    /// </summary>
    public class xiuse_member 
    {
       
        private readonly Xiuse.DAL.xiuse_member dal=new Xiuse.DAL.xiuse_member();

        public xiuse_member(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_member model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_member model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 添加密码/更新密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdatePassword(Model.xiuse_member model)
        {
            return dal.UpdatePassword(model);
        }

        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="MemberId">MemberId</param>
        public bool Delete(string MemberId)
        {
            return dal.Delete(MemberId);
        }
        
        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <param name="MemberId">MemberId</param>
        public bool Exists(string MemberId)
        {
            return dal.Exists(MemberId);
        }
        /// <summary>
        ///  判断卡号及相关参数是否异常
        /// </summary>
        /// <param name="MemberId">MemberId</param>
        public bool ExistsMember(Model.xiuse_member member)
        {
            return dal.ExistsMember(member);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="MemberId">MemberId</param>
        public Xiuse.Model.xiuse_member GetModel(string MemberId)
        {
            return dal.GetModel(MemberId);
        }
        /*
         * 根据餐厅ID查询会员信息
         * 创建人xcf  2016/12/13
         */
        /// <summary>
        /// 获取实体,根据餐厅ID查询实体
        /// </summary>
        /// <param name="RestaurantId">餐厅ID</param>
        /// <returns></returns>List<Xiuse.Model.xiuse_member>
        public DataSet GetModels_RestaurantId(string RestaurantId)
        {
            return dal.GetModels_Rest(RestaurantId);
            //return DataSetTransModelListNoExpand(dal.GetModels_Rest(RestaurantId));
        }
        /*
        * 根据会员的ID设定会员的启用状态
        * 创建人xcf  2016/12/13
        */
        /// <summary>
        /// 设定会员启用状态
        /// </summary>
        /// <param name="MemberId">会员的ID</param>
        /// <param name="flag">启用状态</param>
        /// <returns></returns>
        public bool SetMemberState(string MemberId,int flag)
        {
            if (dal.Exists(MemberId))
            {
                if (dal.ExecuteUpdate(String.Format("MemberState={0}", flag), String.Format("MemberId='{0}'", MemberId)) > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        /*
       * 根据会员的手机号检测会员手机是否重复
       * 创建人xcf  2016/12/15
       */
        /// <summary>
        /// 检测某饭店会员手机是否重复
        /// </summary>
        /// <param name="Cell">手机号码</param>
        /// <returns>true：有重复；false:无重复；</returns>
        public bool CheckCellExist(string cell,string rest)
        {
            if (dal.GetData("1", string.Format("MemberCell='{0}' and RestaurantId='{1}'", cell,rest)).Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">会员类型ID[MemberClassifyId]</param>
        /// <param name="">会员卡号[MemberCardNo]</param>
        /// <param name="">会员名称[MemberName]</param>
        /// <param name="">卡内余额[MemberAmount]</param>
        /// <param name="">手机号[MemberCell]</param>
        /// <param name="">推荐人[MemberReference]</param>
        /// <param name="">[MemberPassword]</param>
        /// <param name="">会员状态（0，禁用；1，启用；）[MemberState]</param>
        /// <param name="">会员创建时间[MemberTime]</param>
        /// <param name="">[RestaurantId]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string MemberClassifyId,string MemberCardNo,string MemberName,decimal MemberAmount,string MemberCell,string MemberReference,string MemberPassword,bool MemberState,string MemberTime,string RestaurantId, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(MemberClassifyId,MemberCardNo,MemberName,MemberAmount,MemberCell,MemberReference,MemberPassword,MemberState,MemberTime,RestaurantId,StartIndex,PageSize,out count);
            RecordCount=count;
            return ds;
        }
        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">会员卡号[MemberCardNo]</param>
        /// <param name="">会员名称[MemberName]</param>
        /// <param name="">手机号[MemberCell]</param>
        public List<Model.xiuse_member> Search( string MemberCardNo, string MemberName, string MemberCell)
        {
            return DataSetTransModelListNoExpand( dal.Search( MemberCardNo, MemberName, MemberCell));
            
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
        private  List<Xiuse.Model.xiuse_member> DataSetTransModelListNoExpand(DataSet dataSet)
        {
            List<Xiuse.Model.xiuse_member> list = new List<Xiuse.Model.xiuse_member>();
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                list.AddRange(ConvertHelper.DataSetToEntityList<Xiuse.Model.xiuse_member>(dataSet, 0));
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
        private  Xiuse.Model.xiuse_member DataSetTransModelNoExpand(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return ConvertHelper.DataSetToEntity<Xiuse.Model.xiuse_member>(dataSet, 0);
            }
            return null;
        }
        /// <summary>
        /// 工具类DataSet转换为List
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        private List<Xiuse.Model.xiuse_member> ConvertDSToModels(DataSet ds)
        {
            List<Xiuse.Model.xiuse_member> Tmp = new List<Model.xiuse_member>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
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
                    model.MemberState = (short)dr["MemberState"];
                    model.MemberTime = (DateTime)dr["MemberTime"];
                    model.RestaurantId = (string)dr["RestaurantId"];
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
