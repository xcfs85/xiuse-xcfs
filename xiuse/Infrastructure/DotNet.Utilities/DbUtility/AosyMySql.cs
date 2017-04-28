/*******************************************************************************
             数据库基类 (MySql)                                    
             本类主要实现对数据库操作的各种方法              
             本类由Aosy.net代码生成器自动生成  
             2016/12/11                 
 * *****************************************************************************/
using System;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;

namespace Xiuse.DbUtility
{
    /// <summary>
    /// 数据通用类[MySql]
    /// </summary>
    public sealed class AosyMySql
    {
        #region 数据库连接字符串
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        private static string Connstr = System.Configuration.ConfigurationManager.ConnectionStrings["XiuseMySqlConnection"].ConnectionString;
        #endregion

        #region 执行SQL语句
        /// <summary>
        /// 执行SQL语句,返回影响行数
        /// </summary>
        /// <param name="strSql">MySql语句</param>
        /// <returns>影响行数</returns>
        static public int ExecuteNonQuery(string strSql)
        {
            using (MySqlConnection conn = new MySqlConnection(Connstr))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch(MySqlException exp)
                {
                    conn.Close();
                    throw new Exception(exp.Message);
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回执行结果的第一行的第一列
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>返回执行结果的第一行的第一列</returns>
        static public object ExecuteScalar(string strSql)
        {
            using (MySqlConnection conn = new MySqlConnection(Connstr))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
                    {
                        return cmd.ExecuteScalar();
                    }
                }
                catch (MySqlException exp)
                {
                    conn.Close();
                    throw new Exception(exp.Message);
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回执行结果[MySqlDataReader]
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        static public MySqlDataReader ExecuteReader(string strSql)
        {
            using (MySqlConnection conn = new MySqlConnection(Connstr))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
                    {
                        return cmd.ExecuteReader();
                    }
                }
                catch (MySqlException exp)
                {
                    conn.Close();
                    throw new Exception(exp.Message);
                }
            }
        }


        /// <summary>
        /// 批量执行SQL语句[带事务处理]
        /// </summary>
        /// <param name="listSQL">SQL语句集合</param>
        /// <returns>执行成功的SQL语句数量</returns>
        static public int ExecuteListSQL(List<string> listSQL)
        {
            using (MySqlConnection conn = new MySqlConnection(Connstr))
            {
                conn.Open();
                MySqlTransaction tran = conn.BeginTransaction();
                try
                {
                    int icount=0;
                    foreach (string strSql in listSQL)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
                        {
                            cmd.Transaction = tran;
                            cmd.ExecuteNonQuery();
                            icount+=1;//计数器加1
                        }
                    }
                    tran.Commit();
                    return icount;
                }
                catch (MySqlException exp)
                {
                    tran.Rollback();
                    conn.Close();
                    throw new Exception(exp.Message);
                }
            }
        }
       #endregion

        #region 返回DataSet

        /// <summary>
        /// 执行SQL语句,返回DataSet
        /// </summary>
        /// <param name="strSql">MySql语句</param>
        /// <returns>结果集</returns>
        static public DataSet ExecuteforDataSet(string strSql)
        {
            using (MySqlDataAdapter da = new MySqlDataAdapter(strSql, Connstr))
            {
                try
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                catch (MySqlException exp)
                {
                    da.Dispose();
                    throw new Exception(exp.Message);
                }
            }
        }

        /// <summary>
        /// 执行SQL语句,返回DataSet[可用于分页使用]
        /// </summary>
        /// <param name="startRecord">开始记录数</param>
        /// <param name="maxRecord">最大记录数</param>
        /// <param name="RecordCount">总记录数</param>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        static public DataSet ExecuteforDataSet(int startRecord, int maxRecord, out int RecordCount, string strSql,string countMySql)
        {
            using (MySqlDataAdapter da = new MySqlDataAdapter(strSql, Connstr))
            {
                try
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds,startRecord,maxRecord,"ds");
                    RecordCount = GetCount(countMySql);
                    return ds;
                }
                catch (MySqlException exp)
                {
                    da.Dispose();
                    throw new Exception(exp.Message);
                }
            }
        }

         /// <summary>
        /// 执行Sql语句,返回DataSet
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="cmdType">CommandType类型</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        static public DataSet ExecuteforDataSet(string strSql, CommandType cmdType, params MySqlParameter[] param)
        {
            using (MySqlConnection conn = new MySqlConnection(Connstr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    DataSet ds = new DataSet();
                    PrepareCommand(cmd, conn, null, CommandType.Text, strSql, param);
                    try
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            da.Dispose();
                            conn.Close();
                        }
                        return ds;
                    }
                    catch (MySqlException exp)
                    {
                        throw new Exception(exp.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行Sql语句,返回DataSet
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="reccountSql">检索记录数SQL语句</param>
        /// <param name="startRecord">开始记录数</param>
        /// <param name="maxRecord">最大记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="cmdType">CommandType类型</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        static public DataSet ExecuteforDataSet(string strSql,string reccountSql,int startRecord,int maxRecord,out int recordCount, CommandType cmdType, params MySqlParameter[] param)
        {
            using (MySqlConnection conn = new MySqlConnection(Connstr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    DataSet ds = new DataSet();
                    PrepareCommand(cmd, conn, null, CommandType.Text, strSql, param);
                    try
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(ds,startRecord,maxRecord,"ds");
                            da.Dispose();
                            conn.Close();
                        }
conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandText = reccountSql;
                        recordCount = int.Parse(cmd.ExecuteScalar().ToString());
                        return ds;
                    }
                    catch (MySqlException exp)
                    {
                        throw new Exception(exp.Message);
                    }
                }
            }
        }
        #endregion

        #region 带参数SQL语句执行
        /// <summary>
        /// 执行SQL语句,返回影响行数
        /// </summary>
        /// <param name="strSql">MySql语句</param>
        /// <param name="cmdType">指定为SQL语句，存储过程名称，文本</param>
        /// <param name="param">参数数组</param>
        /// <returns>影响行数</returns>
        static public int ExecuteNonQuery(string strSql, CommandType cmdType, params MySqlParameter[] param)
        {
            using (MySqlConnection conn = new MySqlConnection(Connstr))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        PrepareCommand(cmd, conn, null, cmdType, strSql, param);
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (MySqlException exp)
                {
                    conn.Close();
                    throw new Exception(exp.Message);
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回执行结果的第一行的第一列
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="cmdType">指定为SQL语句，存储过程名称，文本</param>
        /// <param name="param">参数数组</param>
        /// <returns>返回执行结果的第一行的第一列</returns>
        static public object ExecuteScalar(string strSql, CommandType cmdType, params MySqlParameter[] param)
        {
            using (MySqlConnection conn = new MySqlConnection(Connstr))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        PrepareCommand(cmd, conn, null, cmdType, strSql, param);
                        return cmd.ExecuteScalar();
                    }
                }
                catch (MySqlException exp)
                {
                    conn.Close();
                    throw new Exception(exp.Message);
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回执行结果[MySqlDataReader]
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="cmdType">指定为SQL语句，存储过程名称，文本</param>
        /// <param name="param">参数数组</param>
        /// <returns></returns>
        static public MySqlDataReader ExecuteReader(string strSql, CommandType cmdType, params MySqlParameter[] param)
        {
            using (MySqlConnection conn = new MySqlConnection(Connstr))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        PrepareCommand(cmd, conn, null, cmdType, strSql, param);
                        return cmd.ExecuteReader();
                    }
                }
                catch (MySqlException exp)
                {
                    conn.Close();
                    throw new Exception(exp.Message);
                }
            }
        }
        #endregion

        #region 执行存储过程

        /// <summary>
        /// 执行存储过程，获取返回值
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="param">存储过程参数</param>
        /// <returns></returns>
        static public int ExecuteProcedure(string procedureName, params MySqlParameter[] param)
         {
             using (MySqlConnection conn = new MySqlConnection(Connstr))
             {
                 int rowCount=0;
                 conn.Open();
                 using (MySqlCommand cmd = new MySqlCommand())
                 {
                     PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, procedureName, param);
                     rowCount = cmd.ExecuteNonQuery();
                     conn.Close();
                     return rowCount;
                 }
             }
         }

         /// <summary>
         /// 执行存储过程，获取返回值
         /// </summary>
         /// <param name="procedureName">存储过程名称</param>
         /// <param name="returnParamName">带返回值参数的名称</param>
         /// <param name="param">存储过程参数</param>
         /// <returns></returns>
         static public object ExecuteProcedure(string procedureName, string returnParamName, params MySqlParameter[] param)
         {
             using (MySqlConnection conn = new MySqlConnection(Connstr))
             {
                 object result;
                 conn.Open();
                 using (MySqlCommand cmd = new MySqlCommand())
                 {
                     PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, procedureName, param);
                     cmd.ExecuteNonQuery();
                     result = cmd.Parameters[returnParamName].Value;
                     conn.Close();
                     return result;
                 }
             }
         }

        /// <summary>
        /// 执行存储过程,返回MySqlDataReader
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="param">存储过程参数</param>
        /// <returns></returns>
        static public MySqlDataReader ExecuteProcedureDataReader(string procedureName,params MySqlParameter[] param)
        {
            using (MySqlConnection conn = new MySqlConnection(Connstr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, procedureName, param);
                    return cmd.ExecuteReader();
                }
            }
        }


        /// <summary>
        /// 执行存储过程,返回DataSet
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="param">存储过程参数</param>
        /// <returns></returns>
        static public DataSet ExecuteProcedureDataset(string procedureName,params MySqlParameter[] param)
        {
            using (MySqlConnection conn = new MySqlConnection(Connstr))
            {
                conn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter())
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        DataSet ds=new DataSet();
                        PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, procedureName, param);
                        da.SelectCommand=cmd;
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
        }

                                /// <summary>
        /// 执行存储过程,返回DataSet 
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="startRecord">开始记录数</param>
        /// <param name="maxRecord">最大记录数</param>
        /// <param name="param">存储过程参数</param>
        /// <returns></returns>
        static public DataSet ExecuteProcedureDataset(string procedureName,int startRecord,int maxRecord,params MySqlParameter[] param)
        {
            using (MySqlConnection conn = new MySqlConnection(Connstr))
            {
                conn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter())
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        DataSet ds=new DataSet();
                        PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, procedureName, param);
                        da.SelectCommand=cmd;
                        da.Fill(ds,startRecord,maxRecord,"ds");
                        return ds;
                    }
                }
            }
        }
        /// <summary>
        /// 执行存储过程,返回DataSet 
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="startRecord">开始记录数</param>
        /// <param name="maxRecord">最大记录数</param>
        /// <param name="recordcount">总记录数</param>
        /// <param name="param">存储过程参数</param>
        /// <returns></returns>
        static public DataSet ExecuteProcedureDataset(string procedureName,int startRecord,int maxRecord,out int recordcount,params MySqlParameter[] param)
        {
            using (MySqlConnection conn = new MySqlConnection(Connstr))
            {
                conn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter())
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        DataSet ds=new DataSet();
                        PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, procedureName, param);
                        da.SelectCommand=cmd;
                        da.Fill(ds,startRecord,maxRecord,"ds");
                        recordcount=cmd.ExecuteNonQuery();
                        return ds;
                    }
                }
            }
        }
        #endregion

        #region 分页存储过程
        /// <summary>
        /// 执行分页存储过程
        /// </summary>
        /// <param name="tablename">表名称</param>
        /// <param name="tablefields">要查询的字段</param>
        /// <param name="orderfields">排序字段</param>
        /// <param name="ordertype">排序方式 0 asc, 1 desc</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="pagesize">分页大小</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="totalcount">总记录数</param>
        /// <returns></returns>
        static public DataSet ExecuteProcedurePage(string tablename, string tablefields, string orderfields, int ordertype, string strwhere, int pagesize, int pageindex, out int totalcount)
        {
            MySqlParameter[] param ={
                    new MySqlParameter("?$tbName",MySqlDbType.VarChar,255),
                    new MySqlParameter("?$tbFields",MySqlDbType.VarChar,1000),
                    new MySqlParameter("?$OrderField",MySqlDbType.VarChar,255),
                    new MySqlParameter("?$PageSize",MySqlDbType.Int32),
                    new MySqlParameter("?$PageIndex",MySqlDbType.Int32),
                    new MySqlParameter("?$OrderType",MySqlDbType.Bit),
                    new MySqlParameter("?$strWhere",MySqlDbType.VarChar,1500),
                    new MySqlParameter("?$Total",MySqlDbType.Int32)};
            param[0].Value = tablename;
            param[1].Value = tablefields;
            param[2].Value = orderfields;
            param[3].Value = pagesize;
            param[4].Value = pageindex;
            param[5].Value = ordertype;
            param[6].Value = strwhere;
            param[7].Direction = ParameterDirection.Output;
            DataSet ds= ExecuteProcedureDataset("MySqlPage", param);
            totalcount = int.Parse(param[7].Value.ToString());
            return ds;
        }
        #endregion

        #region 公共调用模块

        /// <summary>
        /// 获取字段最大ID
        /// </summary>
        /// <param name="filedName">列名称</param>
        /// <param name="tableName">表名称</param>
        /// <returns>最大ID</returns>
        static public int GetMaxId(string filedName,string tableName)
        {
            string strSql = "select max(" + filedName + ") as MaxID from " + tableName;
            return int.Parse(ExecuteScalar(strSql).ToString());
        }

        /// <summary>
        /// 返回字段数量综合
        /// </summary>
        /// <param name="filedName">字段名称</param>
        /// <param name="tableName">表名称</param>
        /// <returns></returns>
        static public int GetCount(string filedName, string tableName)
        {
            string strSql = "select count(" + filedName + ") as MaxID from " + tableName;
            return int.Parse(ExecuteScalar(strSql).ToString());
        }

        /// <summary>
        /// 返回字段数量综合
        /// </summary>
        ///<param name="countMySql">查询Count总和语句</param>
        /// <returns></returns>
        static public int GetCount(string countMySql)
        {
            return int.Parse(ExecuteScalar(countMySql).ToString());
        }

        /// <summary>
        /// 执行SQL语句,返回bool数据类型
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        static public bool ExecuteforBool(string strSql)
        {
            return ExecuteNonQuery(strSql) > 0;
        }

        /// <summary>
        /// 执行SQL语句,返回bool数据类型
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <param name="cmdType">CommandType类型</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        static public bool ExecuteforBool(string strSql,CommandType cmdType,params MySqlParameter[] param)
        {
            return ExecuteNonQuery(strSql,cmdType,param)>0;
        }
        #endregion

        #region 参数处理
        /// <summary>
        /// 将MySqlParameter参数数组(参数值)分配给MySqlCommand命令.
        /// 这个方法将给任何一个参数分配DBNull.Value;
        /// 该操作将阻止默认值的使用.
        /// </summary>
        /// <param name="command">命令名</param>
        /// <param name="commandParameters">MySqlParameters数组</param>
        private static void AttachParameters(MySqlCommand command, MySqlParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (MySqlParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // 检查未分配值的输出参数,将其分配以DBNull.Value.
                        if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) &&
                            (p.Value == null|| p.Value.ToString()==""))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        /// <summary>
        /// 将DataRow类型的列值分配到MySqlParameter参数数组.
        /// </summary>
        /// <param name="commandParameters">要分配值的MySqlParameter参数数组</param>
        /// <param name="dataRow">将要分配给存储过程参数的DataRow</param>
        public static void AssignParameterValues(MySqlParameter[] commandParameters, DataRow dataRow)
        {
            if ((commandParameters == null) || (dataRow == null))
            {
                return;
            }

            int i = 0;
            // 设置参数值
            foreach (MySqlParameter commandParameter in commandParameters)
            {
                // 创建参数名称,如果不存在,只抛出一个异常.
                if (commandParameter.ParameterName == null ||
                    commandParameter.ParameterName.Length <= 1)
                    throw new Exception(
                        string.Format("请提供参数{0}一个有效的名称{1}.", i, commandParameter.ParameterName));
                // 从dataRow的表中获取为参数数组中数组名称的列的索引.
                // 如果存在和参数名称相同的列,则将列值赋给当前名称的参数.
                if (dataRow.Table.Columns.IndexOf(commandParameter.ParameterName.Substring(1)) != -1)
                    commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];
                i++;
            }
        }

        /// <summary>
        /// 将一个对象数组分配给MySqlParameter参数数组.
        /// </summary>
        /// <param name="commandParameters">要分配值的MySqlParameter参数数组</param>
        /// <param name="parameterValues">将要分配给存储过程参数的对象数组</param>
        public static void AssignParameterValues(MySqlParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                return;
            }

            // 确保对象数组个数与参数个数匹配,如果不匹配,抛出一个异常.
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("参数值个数与参数不匹配.");
            }

            // 给参数赋值
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                if (parameterValues[i] is IDbDataParameter)
                {
                    IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
                    if (paramInstance.Value == null)
                    {
                        commandParameters[i].Value = DBNull.Value;
                    }
                    else
                    {
                        commandParameters[i].Value = paramInstance.Value;
                    }
                }
                else if (parameterValues[i] == null)
                {
                    commandParameters[i].Value = DBNull.Value;
                }
                else
                {
                    commandParameters[i].Value = parameterValues[i];
                }
            }
        }

        /// <summary>
        /// 预处理用户提供的命令,数据库连接/事务/命令类型/参数
        /// </summary>
        /// <param name="command">要处理的MySqlCommand</param>
        /// <param name="connection">数据库连接</param>
        /// <param name="transaction">一个有效的事务或者是null值</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本, 其它.)</param>
        /// <param name="commandText">存储过程名或都T-SQL命令文本</param>
        /// <param name="commandParameters">和命令相关联的MySqlParameter参数数组,如果没有参数为'null'</param>
        private static void PrepareCommand(MySqlCommand command, MySqlConnection connection, MySqlTransaction transaction, CommandType commandType, string commandText, MySqlParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            // 给命令分配一个数据库连接.
            command.Connection = connection;

            // 设置命令文本(存储过程名或SQL语句)
            command.CommandText = commandText;

            // 分配事务
            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }

            // 设置命令类型.
            command.CommandType = commandType;

            // 分配命令参数
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }

        #endregion
    }
}
