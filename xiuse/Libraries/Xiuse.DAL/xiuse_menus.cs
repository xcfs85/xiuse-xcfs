using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DbUtility;

namespace  Xiuse.DAL
{
    /// <summary>
    /// [xiuse_menus] 数据操作类
    /// </summary>
    public class xiuse_menus
    {
        public xiuse_menus(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_menus model)
        {
            string strSql=String.Format(@"Insert Into xiuse_menus(RestaurantId,ClassifyId,MenuName,MenuQuantity,MenuPrice,MenuShortcut,MenuTag,MenuImage,MenuNo,MenuInstruction,SaleState,MenuState,MenuTime,MenuId) 
                                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}','{12}','{13}')",
                                        model.RestaurantId,model.ClassifyId,model.MenuName,model.MenuQuantity,model.MenuPrice,model.MenuShortcut,model.MenuTag,model.MenuImage,model.MenuNo,model.MenuInstruction,model.SaleState,model.MenuState,model.MenuTime,model.MenuId);

            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_menus model)
        {
            string strSql=String.Format(@"Update xiuse_menus Set 
            RestaurantId='{0}',ClassifyId='{1}',MenuName='{2}',MenuQuantity='{3}',MenuPrice='{4}',MenuShortcut='{5}',MenuTag='{6}',MenuImage='{7}',MenuNo='{8}',MenuInstruction='{9}',SaleState='{10}',MenuState='{11}',MenuTime='{12}' 
            Where MenuId='{13}'",
            model.RestaurantId,model.ClassifyId,model.MenuName,model.MenuQuantity,model.MenuPrice,model.MenuShortcut,model.MenuTag,model.MenuImage,model.MenuNo,model.MenuInstruction,model.SaleState,model.MenuState,model.MenuTime,model.MenuId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        

        
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <parame name="MenuId">MenuId</param>
        public bool Delete(string MenuId)
        {
            string strSql=String.Format("Delete From xiuse_menus Where MenuId='{0}'",MenuId);
            return AosyMySql.ExecuteforBool(strSql);
        }
        


        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <parame name="MenuId">MenuId</param>
        public bool Exists(string MenuId)
        {
            string strSql=String.Format("Select Count(1) From xiuse_menus Where MenuId='{0}'",MenuId);
            return int.Parse(AosyMySql.ExecuteScalar(strSql).ToString())>0;
        }
        


        /// <summary>
        /// 获取实体
        /// </summary>
         /// <parame name="MenuId">MenuId</param>
        public Xiuse.Model.xiuse_menus GetModel(string MenuId)
        {
             string strSql=String.Format(@"Select * From xiuse_menus Where MenuId='{0}'",MenuId); 
            DataSet ds=AosyMySql.ExecuteforDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                Xiuse.Model.xiuse_menus  model=new Xiuse.Model.xiuse_menus();
                DataRow dr=ds.Tables[0].Rows[0];
				model.MenuId=(string)dr["MenuId"];
				model.RestaurantId=(string)dr["RestaurantId"];
				model.ClassifyId=(string)dr["ClassifyId"];
				model.MenuName=dr["MenuName"].ToString();
				model.MenuQuantity=(int)dr["MenuQuantity"];
				model.MenuPrice=(decimal)dr["MenuPrice"];
				model.MenuShortcut=dr["MenuShortcut"].ToString();
				model.MenuTag=dr["MenuTag"].ToString();
				model.MenuImage=dr["MenuImage"].ToString();
				model.MenuNo=(int)dr["MenuNo"];
				model.MenuInstruction=dr["MenuInstruction"].ToString();
				model.SaleState=(short)dr["SaleState"];
				model.MenuState=(short)dr["MenuState"];
				model.MenuTime=(DateTime)dr["MenuTime"];
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
        /// <param name="">[RestaurantId]</param>
        /// <param name="">菜品种类[ClassifyId]</param>
        /// <param name="">餐品名称[MenuName]</param>
        /// <param name="">(当天)菜品剩余数量[MenuQuantity]</param>
        /// <param name="">餐品价格[MenuPrice]</param>
        /// <param name="">快捷码[MenuShortcut]</param>
        /// <param name="">菜品标签（正常,微微辣,微辣,辣,超辣,变态辣,多糖）[MenuTag]</param>
        /// <param name="">餐品图片的路径[MenuImage]</param>
        /// <param name="">菜品排序[MenuNo]</param>
        /// <param name="">餐品介绍[MenuInstruction]</param>
        /// <param name="">菜品销售状态（1限量销售，0不限量销售）[SaleState]</param>
        /// <param name="">餐品状态（0，正常。1，停用。2，已删除。）[MenuState]</param>
        /// <param name="">更新时间[MenuTime]</param>
        /// <param name="StartIndex">开始记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">记录总数</param>
        public DataSet Search(string RestaurantId,string ClassifyId,string MenuName,int MenuQuantity,decimal MenuPrice,string MenuShortcut,string MenuTag,string MenuImage,int MenuNo,string MenuInstruction,int SaleState,int MenuState,string MenuTime, int StartIndex, int PageSize, out int RecordCount)
        {
            #region 条件语句...
            StringBuilder strWhere=new StringBuilder();

            if(RestaurantId.ToString().Length>0)
                strWhere.Append(" And RestaurantId="+RestaurantId);
            

            if(ClassifyId.ToString().Length>0)
                strWhere.Append(" And ClassifyId="+ClassifyId);
            

            if(MenuName!=null && MenuName.Length>0)
                strWhere.Append(" And MenuName='"+MenuName+"'");
            

            if(MenuQuantity.ToString().Length>0)
                strWhere.Append(" And MenuQuantity="+MenuQuantity);
            

            if(MenuPrice.ToString().Length>0)
                strWhere.Append(" And MenuPrice="+MenuPrice);
            

            if(MenuShortcut!=null && MenuShortcut.Length>0)
                strWhere.Append(" And MenuShortcut='"+MenuShortcut+"'");
            

            if(MenuTag!=null && MenuTag.Length>0)
                strWhere.Append(" And MenuTag='"+MenuTag+"'");
            

            if(MenuImage!=null && MenuImage.Length>0)
                strWhere.Append(" And MenuImage='"+MenuImage+"'");
            

            if(MenuNo.ToString().Length>0)
                strWhere.Append(" And MenuNo="+MenuNo);
            

            if(MenuInstruction!=null && MenuInstruction.Length>0)
                strWhere.Append(" And MenuInstruction='"+MenuInstruction+"'");
            

            if(SaleState.ToString().Length>0)
                strWhere.Append(" And SaleState="+SaleState);
            

            if(MenuState.ToString().Length>0)
                strWhere.Append(" And MenuState="+MenuState);
            

            if(MenuTime!=null && MenuTime.Length>0)
                strWhere.Append(" And MenuTime='"+MenuTime+"'");
            
            string where=strWhere.ToString().Substring(4,strWhere.Length-4);
            #endregion

            StringBuilder strSql=new StringBuilder();
            strSql.Append("Select * From xiuse_menus Where");
            strSql.Append(where);

            StringBuilder countSql=new StringBuilder();
            countSql.Append("Select Count(*) From xiuse_menus Where");
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
            string strSql="Select "+ Fields +" From xiuse_menus";
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
            string strSql="Select "+ Fields +" From xiuse_menus";
	    if(Wheres.Length>0)strSql+=" Where "+ Wheres +"";
            string countSql="Select Count(*) From xiuse_menus";
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
            string strSql="Select * From xiuse_menus ";
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
            string strSql="Select * From xiuse_menus ";
            string countSql="Select Count(*) From xiuse_menus ";
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
            string sql = "update xiuse_menus set " + updatefield + " where " + wheres;
            return AosyMySql.ExecuteNonQuery(sql);
        }
    }
}

