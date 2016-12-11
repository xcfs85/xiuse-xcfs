using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DAL;
namespace Xiuse.BLL
{
    /// <summary>
    /// [xiuse_recharge] 业务逻辑处理
    /// </summary>
    public class xiuse_recharge 
    {
       
        private readonly Xiuse.DAL.xiuse_recharge dal=new Xiuse.DAL.xiuse_recharge();

        public xiuse_recharge(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_recharge model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_recharge model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="RechargeId">RechargeId</param>
        public bool Delete(string RechargeId)
        {
            return dal.Delete(RechargeId);
        }
        
        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <param name="RechargeId">RechargeId</param>
        public bool Exists(string RechargeId)
        {
            return dal.Exists(RechargeId);
        }
        
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="RechargeId">RechargeId</param>
        public Xiuse.Model.xiuse_recharge GetModel(string RechargeId)
        {
            return dal.GetModel(RechargeId);
        }
        

		/// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">会员的Id[MemberId]</param>
        /// <param name="">充值类型[RechargeType]</param>
        /// <param name="">充值金额[RechargeAmount]</param>
        /// <param name="">可用余额[Balance]</param>
        /// <param name="">会员的卡号[MemberCardNo]</param>
        /// <param name="">[RechargeTime]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string MemberId,byte RechargeType,decimal RechargeAmount,decimal Balance,string MemberCardNo,string RechargeTime, int StartIndex, int PageSize, out int RecordCount)
        {
            int count=0;
            DataSet ds=dal.Search(MemberId,RechargeType,RechargeAmount,Balance,MemberCardNo,RechargeTime,StartIndex,PageSize,out count);
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
    }
}
