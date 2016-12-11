using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DAL;
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
        /// 获取实体
        /// </summary>
        /// <param name="MemberId">MemberId</param>
        public Xiuse.Model.xiuse_member GetModel(string MemberId)
        {
            return dal.GetModel(MemberId);
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
