using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [ordermenu_] 数据操作类
    /// </summary>
    public class ordermenu_
    {
        public ordermenu_(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.ordermenu_ model)
        {
            string strSql=String.Format(@"Insert Into ordermenu_(OrderId,MenuName,MenuPrice,MenuTag,MenuImage,MenuInstruction,DiscoutFlag,DiscountName,DiscountContent,DiscountType,MenuServing) 
                                        values({0},'{1}',{2},'{3}','{4}','{5}',{6},'{7}',{8},{9},{10})",
                                        model.OrderId,model.MenuName,model.MenuPrice,model.MenuTag,model.MenuImage,model.MenuInstruction,model.DiscoutFlag,model.DiscountName,model.DiscountContent,model.DiscountType,model.MenuServing);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.ordermenu_ model)
        {
            string strSql=String.Format(@"Update ordermenu_ Set 
            OrderId='{0}',MenuName='{1}',MenuPrice={2},MenuTag='{3}',MenuImage='{4}',MenuInstruction='{5}',DiscoutFlag={6},DiscountName='{7}',DiscountContent={8},DiscountType={9},MenuServing={10} 
            Where OrderMenuId={11}",
            model.OrderId,model.MenuName,model.MenuPrice,model.MenuTag,model.MenuImage,model.MenuInstruction,model.DiscoutFlag,model.DiscountName,model.DiscountContent,model.DiscountType,model.MenuServing,model.OrderMenuId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <parame name="OrderMenuId">OrderMenuId</param>
        public bool Delete(string OrderMenuId)
        {
            string strSql=String.Format("Delete From ordermenu_ Where OrderMenuId='{0}'",OrderMenuId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <parame name="OrderMenuId">OrderMenuId</param>
        public bool Exists(string OrderMenuId)
        {
            string strSql=String.Format("Select Count(1) From ordermenu_ Where OrderMenuId='{0}'",OrderMenuId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }
        


        /// <summary>
        /// 获取实体
        /// </summary>
         /// <parame name="OrderMenuId">OrderMenuId</param>
        public Xiuse.Model.ordermenu_ GetModel(string OrderMenuId)
        {
             string strSql=String.Format(@"Select * From ordermenu_ Where OrderMenuId='{0}'",OrderMenuId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.ordermenu_  model=new Xiuse.Model.ordermenu_();
                DataRow dr=ds.Tables[0].Rows[0];
				model.OrderMenuId=(string)dr["OrderMenuId"];
				model.OrderId=(string)dr["OrderId"];
				model.MenuName=dr["MenuName"].ToString();
				model.MenuPrice=(decimal)dr["MenuPrice"];
				model.MenuTag=dr["MenuTag"].ToString();
				model.MenuImage=dr["MenuImage"].ToString();
				model.MenuInstruction=dr["MenuInstruction"].ToString();
				model.DiscoutFlag=(short)dr["DiscoutFlag"];
				model.DiscountName=dr["DiscountName"].ToString();
				model.DiscountContent=(decimal)dr["DiscountContent"];
				model.DiscountType=(byte)dr["DiscountType"];
				model.MenuServing=(short)dr["MenuServing"];
                return model;
            }
            else
            {
                return null;
            }
        }
        


        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="">[OrderId]</param>
        /// <param name="">餐品名称[MenuName]</param>
        /// <param name="">菜品价格[MenuPrice]</param>
        /// <param name="">菜品标签[MenuTag]</param>
        /// <param name="">菜品图片[MenuImage]</param>
        /// <param name="">菜品介绍[MenuInstruction]</param>
        /// <param name="">是否有折扣（0,1）[DiscoutFlag]</param>
        /// <param name="">折扣名称[DiscountName]</param>
        /// <param name="">折扣金额[DiscountContent]</param>
        /// <param name="">折扣类型(0:百分比 1：固定金额)[DiscountType]</param>
        /// <param name="">是否上菜[MenuServing]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string OrderId,string MenuName,decimal MenuPrice,string MenuTag,string MenuImage,string MenuInstruction,bool DiscoutFlag,string DiscountName,decimal DiscountContent,byte DiscountType,bool MenuServing, int StartIndex, int PageSize, out int RecordCount)
        {
            #region 条件语句...
            StringBuilder strWhere=new StringBuilder();

            if(OrderId.ToString().Length>0)
                strWhere.Append(" And OrderId="+OrderId);
            

            if(MenuName!=null && MenuName.Length>0)
                strWhere.Append(" And MenuName='"+MenuName+"'");
            

            if(MenuPrice.ToString().Length>0)
                strWhere.Append(" And MenuPrice="+MenuPrice);
            

            if(MenuTag!=null && MenuTag.Length>0)
                strWhere.Append(" And MenuTag='"+MenuTag+"'");
            

            if(MenuImage!=null && MenuImage.Length>0)
                strWhere.Append(" And MenuImage='"+MenuImage+"'");
            

            if(MenuInstruction!=null && MenuInstruction.Length>0)
                strWhere.Append(" And MenuInstruction='"+MenuInstruction+"'");
            

            if(DiscoutFlag.ToString().Length>0)
                strWhere.Append(" And DiscoutFlag="+DiscoutFlag);
            

            if(DiscountName!=null && DiscountName.Length>0)
                strWhere.Append(" And DiscountName='"+DiscountName+"'");
            

            if(DiscountContent.ToString().Length>0)
                strWhere.Append(" And DiscountContent="+DiscountContent);
            

            if(DiscountType.ToString().Length>0)
                strWhere.Append(" And DiscountType="+DiscountType);
            

            if(MenuServing.ToString().Length>0)
                strWhere.Append(" And MenuServing="+MenuServing);
            
            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From ordermenu_ Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From ordermenu_ Where");
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
            string strSql="Select "+ Fields +" From ordermenu_";
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
            string strSql="Select "+ Fields +" From ordermenu_";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From ordermenu_";
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
            string strSql="Select * From ordermenu_ ";
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
            string strSql="Select * From ordermenu_ ";
            string countSql="Select Count(*) From ordermenu_ ";
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
            string sql = "update ordermenu_ set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

