using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Xiuse.Model;
using Xiuse.DAL;
namespace Xiuse.BLL
{
    /// <summary>
    /// [xiuse_menus] 业务逻辑处理
    /// </summary>
    public class xiuse_menus 
    {
       
        private readonly Xiuse.DAL.xiuse_menus dal=new Xiuse.DAL.xiuse_menus();

        public xiuse_menus(){}
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.xiuse_menus model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Update(Xiuse.Model.xiuse_menus model)
        {
            return dal.Update(model);
        }
        
   
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="MenuId">MenuId</param>
        public bool Delete(string MenuId)
        {
            return dal.Delete(MenuId);
        }
        
        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <param name="MenuId">MenuId</param>
        public bool Exists(string MenuId)
        {
            return dal.Exists(MenuId);
        }
        
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="MenuId">MenuId</param>
        public Xiuse.Model.xiuse_menus GetModel(string MenuId)
        {
            return dal.GetModel(MenuId);
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
            int count=0;
            DataSet ds=dal.Search(RestaurantId,ClassifyId,MenuName,MenuQuantity,MenuPrice,MenuShortcut,MenuTag,MenuImage,MenuNo,MenuInstruction,SaleState,MenuState,MenuTime,StartIndex,PageSize,out count);
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
