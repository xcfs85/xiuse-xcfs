using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [xiuse_memberclassify] 数据操作类
    /// </summary>
    public class xiuse_memberclassify
    {
        public xiuse_memberclassify(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_memberclassify model)
        {
            string strSql=String.Format(@"Insert Into xiuse_memberclassify(DiscountId,ClassifyName,ClassRemark,ClassifyMemberNum,ClassifyTime,DelTag,RestaurantId) 
                                        values({0},'{1}','{2}',{3},'{4}',{5},{6})",
                                        model.DiscountId,model.ClassifyName,model.ClassRemark,model.ClassifyMemberNum,model.ClassifyTime,model.DelTag,model.RestaurantId);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_memberclassify model)
        {
            string strSql=String.Format(@"Update xiuse_memberclassify Set 
            DiscountId={0},ClassifyName='{1}',ClassRemark='{2}',ClassifyMemberNum={3},ClassifyTime='{4}',DelTag={5},RestaurantId={6} 
            Where MemberClassifyId={7}",
            model.DiscountId,model.ClassifyName,model.ClassRemark,model.ClassifyMemberNum,model.ClassifyTime,model.DelTag,model.RestaurantId,model.MemberClassifyId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <parame name="MemberClassifyId">MemberClassifyId</param>
        public bool Delete(string MemberClassifyId)
        {
            string strSql=String.Format("Delete From xiuse_memberclassify Where MemberClassifyId={0}",MemberClassifyId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <parame name="MemberClassifyId">MemberClassifyId</param>
        public bool Exists(string MemberClassifyId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_memberclassify Where MemberClassifyId={0}",MemberClassifyId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }
        


        /// <summary>
        /// 获取实体
        /// </summary>
         /// <parame name="MemberClassifyId">MemberClassifyId</param>
        public Xiuse.Model.xiuse_memberclassify GetModel(string MemberClassifyId)
        {
             string strSql=String.Format(@"Select * From xiuse_memberclassify Where MemberClassifyId={0}",MemberClassifyId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.xiuse_memberclassify  model=new Xiuse.Model.xiuse_memberclassify();
                DataRow dr=ds.Tables[0].Rows[0];
				model.MemberClassifyId=(string)dr["MemberClassifyId"];
				model.DiscountId=(string)dr["DiscountId"];
				model.ClassifyName=dr["ClassifyName"].ToString();
				model.ClassRemark=dr["ClassRemark"].ToString();
				model.ClassifyMemberNum=(int)dr["ClassifyMemberNum"];
				model.ClassifyTime=dr["ClassifyTime"].ToString();
				model.DelTag=(byte)dr["DelTag"];
                model.RestaurantId = (string)dr["RestaurantId"];
                return model;
            }
            else
            {
                return null;
            }
        }
        #region 作者xcf  修改时间 2016/12/18

        /// <summary>
        /// 获取餐厅的所有的会员类型
        /// </summary>
        /// <param name="RestaurantId"></param>
        /// <returns></returns>
        public DataSet GetDatas(string RestaurantId)
        {
            string strSql = String.Format(@"Select * From xiuse_memberclassify Where RestaurantId={0}", RestaurantId);
            return AosyMySql.ExecuteforDataSet(strSql);
        }




        /// <summary>
        /// 设置会员类型的状态（0,启用；1，停用；2，删除。）
        /// </summary>
        /// <param name="State">（0,启用；1，停用；2，删除。）</param>
        /// <param name="MemberClassifyId">会员类别Id</param>
        /// <returns></returns>
        public bool SetMemberClassify(int State,string MemberClassifyId)
        {
            string strSql = string.Format("update xiuse_memberclassify set DelTag={0} where MemberClassifyId={1}", State, MemberClassifyId);
            if (AosyMySql.ExecuteNonQuery(strSql) > 0)
                return true;
            else
                return false;
        }
        #endregion



        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">折扣ID[DiscountId]</param>
        /// <param name="">类型名称[ClassifyName]</param>
        /// <param name="">说明[ClassRemark]</param>
        /// <param name="">会员数量[ClassifyMemberNum]</param>
        /// <param name="">修改时间[ClassifyTime]</param>
        /// <param name="">删除标志，(0,启用；1，停用；2，删除。)[DelTag]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string DiscountId,string ClassifyName,string ClassRemark,int ClassifyMemberNum,string ClassifyTime,byte DelTag,string RestaurantId, int StartIndex, int PageSize, out int RecordCount)
        {
            #region 条件语句...
            StringBuilder strWhere=new StringBuilder();

            if(DiscountId.ToString().Length>0)
                strWhere.Append(" And DiscountId="+DiscountId);
            

            if(ClassifyName!=null && ClassifyName.Length>0)
                strWhere.Append(" And ClassifyName='"+ClassifyName+"'");
            

            if(ClassRemark!=null && ClassRemark.Length>0)
                strWhere.Append(" And ClassRemark='"+ClassRemark+"'");
            

            if(ClassifyMemberNum.ToString().Length>0)
                strWhere.Append(" And ClassifyMemberNum="+ClassifyMemberNum);
            

            if(ClassifyTime!=null && ClassifyTime.Length>0)
                strWhere.Append(" And ClassifyTime='"+ClassifyTime+"'");
            

            if(DelTag.ToString().Length>0)
                strWhere.Append(" And DelTag="+DelTag);

            if (RestaurantId.ToString().Length > 0)
                strWhere.Append(" And RestaurantId=" + RestaurantId);

            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From xiuse_memberclassify Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From xiuse_memberclassify Where");
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
            string strSql="Select "+ Fields +" From xiuse_memberclassify";
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
            string strSql="Select "+ Fields +" From xiuse_memberclassify";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From xiuse_memberclassify";
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
            string strSql="Select * From xiuse_memberclassify ";
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
            string strSql="Select * From xiuse_memberclassify ";
            string countSql="Select Count(*) From xiuse_memberclassify ";
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
            string sql = "update xiuse_memberclassify set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

