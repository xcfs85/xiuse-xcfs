using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiuse.DbUtility;
using System.Data;
namespace Xiuse.DAL
{
    public class SysLog
    {
        //增加一个操作日志记录
        public bool Insert(Xiuse.Model.SysLog model)
        {
            string strSql = String.Format(@"Insert Into log(LogId,UserId,LogContent,LogType,LogTime) 
                                        values({0,{1},{2},{3},'{4}','{5}')",
                                        model.LogId, model.UserId, model.LogContent, model.LogType, model.LogTime);
            return AosyMySql.ExecuteforBool(strSql);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <parame name="DeskId">DeskId</param>
        public Xiuse.Model.SysLog GetModel(string LogId)
        {
            string strSql = String.Format(@"Select * From log Where LogId={0}", LogId);
            DataSet ds = AosyMySql.ExecuteforDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Xiuse.Model.SysLog model = new Xiuse.Model.SysLog();
                DataRow dr = ds.Tables[0].Rows[0];
                model.LogId = (string)dr["LogId"];
                model.UserId = (string)dr["UserId"];
                model.LogContent = (string)dr["LogContent"];
                model.LogType = (int)dr["LogType"];
                model.LogTime = (DateTime)dr["LogTime"];
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}