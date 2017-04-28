/*******************************************************************************
             ���ݿ���� (OleDb)                                    
             ������Ҫʵ�ֶ����ݿ�����ĸ��ַ���              
             ������Aosy.net�����������Զ�����  
             2016/12/11                 
 * *****************************************************************************/
using System;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Configuration;
using System.Web;

namespace Xiuse.DbUtility
{
    /// <summary>
    /// ����ͨ����[OleDb]
    /// </summary>
    public sealed class AosyOleDb
    {
        #region ���ݿ������ַ���
        /// <summary>
        /// ��ȡ���ݿ������ַ���
        /// </summary>
        private static string Connstr = ConfigurationManager.AppSettings["OleDbConnStr"].ToString() + HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["OleDbPath"].ToString());
        #endregion

        #region ִ��SQL���
        /// <summary>
        /// ִ��SQL���,����Ӱ������
        /// </summary>
        /// <param name="strSql">OleDb���</param>
        /// <returns>Ӱ������</returns>
        static public int ExecuteNonQuery(string strSql)
        {
            using (OleDbConnection conn = new OleDbConnection(Connstr))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(strSql, conn))
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch(OleDbException exp)
                {
                    conn.Close();
                    throw new Exception(exp.Message);
                }
            }
        }

        /// <summary>
        /// ִ��SQL��䣬����ִ�н���ĵ�һ�еĵ�һ��
        /// </summary>
        /// <param name="strSql">SQL���</param>
        /// <returns>����ִ�н���ĵ�һ�еĵ�һ��</returns>
        static public object ExecuteScalar(string strSql)
        {
            using (OleDbConnection conn = new OleDbConnection(Connstr))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(strSql, conn))
                    {
                        return cmd.ExecuteScalar();
                    }
                }
                catch (OleDbException exp)
                {
                    conn.Close();
                    throw new Exception(exp.Message);
                }
            }
        }

        /// <summary>
        /// ִ��SQL��䣬����ִ�н��[OleDbDataReader]
        /// </summary>
        /// <param name="OleDbStr">SQL���</param>
        /// <returns></returns>
        static public OleDbDataReader ExecuteReader(string strSql)
        {
            using (OleDbConnection conn = new OleDbConnection(Connstr))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(strSql, conn))
                    {
                        return cmd.ExecuteReader();
                    }
                }
                catch (OleDbException exp)
                {
                    conn.Close();
                    throw new Exception(exp.Message);
                }
            }
        }


        /// <summary>
        /// ����ִ��SQL���[��������]
        /// </summary>
        /// <param name="listSQL">SQL��伯��</param>
        /// <returns>ִ�гɹ���SQL�������</returns>
        static public int ExecuteListSQL(List<string> listSQL)
        {
            using (OleDbConnection conn = new OleDbConnection(Connstr))
            {
                conn.Open();
                OleDbTransaction tran = conn.BeginTransaction();
                try
                {
                    int icount=0;
                    foreach (string strSql in listSQL)
                    {
                        using (OleDbCommand cmd = new OleDbCommand(strSql, conn))
                        {
                            cmd.Transaction = tran;
                            cmd.ExecuteNonQuery();
                            icount+=1;//��������1
                        }
                    }
                    tran.Commit();
                    return icount;
                }
                catch (OleDbException exp)
                {
                    tran.Rollback();
                    conn.Close();
                    throw new Exception(exp.Message);
                }
            }
        }
       #endregion

        #region ����DataSet
        /// <summary>
        /// ִ��SQL���,����DataSet
        /// </summary>
        /// <param name="strSql">OleDb���</param>
        /// <returns>�����</returns>
        static public DataSet ExecuteforDataSet(string strSql)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter(strSql, Connstr))
            {
                try
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                catch (OleDbException exp)
                {
                    da.Dispose();
                    throw new Exception(exp.Message);
                }
            }
        }

        /// <summary>
        /// ִ��SQL���,����DataSet[�����ڷ�ҳʹ��]
        /// </summary>
        /// <param name="startRecord">��ʼ��¼��</param>
        /// <param name="maxRecord">����¼��</param>
        /// <param name="RecordCount">�ܼ�¼��</param>
        /// <param name="strSql">SQL���</param>
        /// <returns></returns>
        static public DataSet ExecuteforDataSet(int startRecord, int maxRecord, out int RecordCount, string strSql,string countSql)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter(strSql, Connstr))
            {
                try
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds,startRecord,maxRecord,"ds");
                    RecordCount = GetCount(countSql);
                    return ds;
                }
                catch (OleDbException exp)
                {
                    da.Dispose();
                    throw new Exception(exp.Message);
                }
            }
        }
        /// <summary>
        /// ִ��Sql���,����DataSet
        /// </summary>
        /// <param name="strSql">SQL���</param>
        /// <param name="cmdType">CommandType����</param>
        /// <param name="param">����</param>
        /// <returns></returns>
        static public DataSet ExecuteforDataSet(string strSql, CommandType cmdType, params OleDbParameter[] param)
        {
            using (OleDbConnection conn = new OleDbConnection(Connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    DataSet ds = new DataSet();
                    PrepareCommand(cmd, conn, null, CommandType.Text, strSql, param);
                    try
                    {
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            da.Dispose();
                            conn.Close();
                        }
                        return ds;
                    }
                    catch (OleDbException exp)
                    {
                        throw new Exception(exp.Message);
                    }
                }
            }
        }

        /// <summary>
        /// ִ��Sql���,����DataSet
        /// </summary>
        /// <param name="strSql">SQL���</param>
        /// <param name="reccountSql">������¼��SQL���</param>
        /// <param name="startRecord">��ʼ��¼��</param>
        /// <param name="maxRecord">����¼��</param>
        /// <param name="recordCount">�ܼ�¼��</param>
        /// <param name="cmdType">CommandType����</param>
        /// <param name="param">����</param>
        /// <returns></returns>
        static public DataSet ExecuteforDataSet(string strSql,string reccountSql,int startRecord,int maxRecord,out int recordCount, CommandType cmdType, params OleDbParameter[] param)
        {
            using (OleDbConnection conn = new OleDbConnection(Connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    DataSet ds = new DataSet();
                    PrepareCommand(cmd, conn, null, CommandType.Text, strSql, param);
                    try
                    {
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
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
                    catch (OleDbException exp)
                    {
                        throw new Exception(exp.Message);
                    }
                }
            }
        }
        #endregion

        #region ������SQL���ִ��
        /// <summary>
        /// ִ��SQL���,����Ӱ������
        /// </summary>
        /// <param name="strSql">OleDb���</param>
        /// <param name="cmdType">ָ��ΪSQL��䣬�洢�������ƣ��ı�</param>
        /// <param name="param">��������</param>
        /// <returns>Ӱ������</returns>
        static public int ExecuteNonQuery(string strSql, CommandType cmdType, params OleDbParameter[] param)
        {
            using (OleDbConnection conn = new OleDbConnection(Connstr))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        PrepareCommand(cmd, conn, null, cmdType, strSql, param);
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (OleDbException exp)
                {
                    conn.Close();
                    throw new Exception(exp.Message);
                }
            }
        }

        /// <summary>
        /// ִ��SQL��䣬����ִ�н���ĵ�һ�еĵ�һ��
        /// </summary>
        /// <param name="strSql">SQL���</param>
        /// <param name="cmdType">ָ��ΪSQL��䣬�洢�������ƣ��ı�</param>
        /// <param name="param">��������</param>
        /// <returns>����ִ�н���ĵ�һ�еĵ�һ��</returns>
        static public object ExecuteScalar(string strSql, CommandType cmdType, params OleDbParameter[] param)
        {
            using (OleDbConnection conn = new OleDbConnection(Connstr))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        PrepareCommand(cmd, conn, null, cmdType, strSql, param);
                        return cmd.ExecuteScalar();
                    }
                }
                catch (OleDbException exp)
                {
                    conn.Close();
                    throw new Exception(exp.Message);
                }
            }
        }

        /// <summary>
        /// ִ��SQL��䣬����ִ�н��[OleDbDataReader]
        /// </summary>
        /// <param name="OleDbStr">SQL���</param>
        /// <param name="cmdType">ָ��ΪSQL��䣬�洢�������ƣ��ı�</param>
        /// <param name="param">��������</param>
        /// <returns></returns>
        static public OleDbDataReader ExecuteReader(string OleDbStr, CommandType cmdType, params OleDbParameter[] param)
        {
            using (OleDbConnection conn = new OleDbConnection(Connstr))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        PrepareCommand(cmd, conn, null, cmdType, OleDbStr, param);
                        return cmd.ExecuteReader();
                    }
                }
                catch (OleDbException exp)
                {
                    conn.Close();
                    throw new Exception(exp.Message);
                }
            }
        }
        #endregion

        #region ִ�д洢����

        /// <summary>
        /// ִ�д洢���̣���ȡ����ֵ
        /// </summary>
        /// <param name="procedureName">�洢��������</param>
        /// <param name="param">�洢���̲���</param>
        /// <returns></returns>
        static public int ExecuteProcedure(string procedureName,params OleDbParameter[] param)
         {
             using (OleDbConnection conn = new OleDbConnection(Connstr))
             {
                 int rowCount=0;
                 conn.Open();
                 using (OleDbCommand cmd = new OleDbCommand())
                 {
                     PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, procedureName, param);
                     rowCount = cmd.ExecuteNonQuery();
                     conn.Close();
                     return rowCount;
                 }
             }
         }

         /// <summary>
         /// ִ�д洢���̣���ȡ����ֵ
         /// </summary>
         /// <param name="procedureName">�洢��������</param>
         /// <param name="returnParamName">������ֵ����������</param>
         /// <param name="param">�洢���̲���</param>
         /// <returns></returns>
         static public object ExecuteProcedure(string procedureName, string returnParamName, params OleDbParameter[] param)
         {
             using (OleDbConnection conn = new OleDbConnection(Connstr))
             {
                 object result;
                 conn.Open();
                 using (OleDbCommand cmd = new OleDbCommand())
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
        /// ִ�д洢����,����OleDbDataReader
        /// </summary>
        /// <param name="procedureName">�洢��������</param>
        /// <param name="param">�洢���̲���</param>
        /// <returns></returns>
        static public OleDbDataReader ExecuteProcedureDataReader(string procedureName,params OleDbParameter[] param)
        {
            using (OleDbConnection conn = new OleDbConnection(Connstr))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, procedureName, param);
                    return cmd.ExecuteReader();
                }
            }
        }


        /// <summary>
        /// ִ�д洢����,����DataSet
        /// </summary>
        /// <param name="procedureName">�洢��������</param>
        /// <param name="param">�洢���̲���</param>
        /// <returns></returns>
        static public DataSet ExecuteProcedureDataset(string procedureName,params OleDbParameter[] param)
        {
            using (OleDbConnection conn = new OleDbConnection(Connstr))
            {
                conn.Open();
                using (OleDbDataAdapter da = new OleDbDataAdapter())
                {
                    using (OleDbCommand cmd = new OleDbCommand())
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
        /// ִ�д洢����,����DataSet 
        /// </summary>
        /// <param name="procedureName">�洢��������</param>
        /// <param name="startRecord">��ʼ��¼��</param>
        /// <param name="maxRecord">����¼��</param>
        /// <param name="param">�洢���̲���</param>
        /// <returns></returns>
        static public DataSet ExecuteProcedureDataset(string procedureName,int startRecord,int maxRecord,params OleDbParameter[] param)
        {
            using (OleDbConnection conn = new OleDbConnection(Connstr))
            {
                conn.Open();
                using (OleDbDataAdapter da = new OleDbDataAdapter())
                {
                    using (OleDbCommand cmd = new OleDbCommand())
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
        /// ִ�д洢����,����DataSet 
        /// </summary>
        /// <param name="procedureName">�洢��������</param>
        /// <param name="startRecord">��ʼ��¼��</param>
        /// <param name="maxRecord">����¼��</param>
        /// <param name="recordcount">�ܼ�¼��</param>
        /// <param name="param">�洢���̲���</param>
        /// <returns></returns>
        static public DataSet ExecuteProcedureDataset(string procedureName,int startRecord,int maxRecord,out int recordcount,params OleDbParameter[] param)
        {
            using (OleDbConnection conn = new OleDbConnection(Connstr))
            {
                conn.Open();
                using (OleDbDataAdapter da = new OleDbDataAdapter())
                {
                    using (OleDbCommand cmd = new OleDbCommand())
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

        #region ��ҳ�洢����
        /// <summary>
        /// ִ�з�ҳ�洢����
        /// </summary>
        /// <param name="tablename">������</param>
        /// <param name="tablefields">Ҫ��ѯ���ֶ�</param>
        /// <param name="orderfields">�����ֶ�[����]</param>
        /// <param name="ordertype">����ʽ 0 asc, 1 desc</param>
        /// <param name="strwhere">��ѯ����</param>
        /// <param name="pagesize">��ҳ��С</param>
        /// <param name="pageindex">��ǰҳ</param>
        /// <param name="totalcount">�ܼ�¼��</param>
        /// <returns></returns>
        static public DataSet ExecuteProcedurePage(string tablename, string tablefields, string orderfields, int ordertype, string strwhere, int pagesize, int pageindex, out int totalcount)
        {
            OleDbParameter[] param ={
                    new OleDbParameter("@tbName",OleDbType.VarChar,255),
                    new OleDbParameter("@tbFields",OleDbType.VarChar,1000),
                    new OleDbParameter("@OrderField",OleDbType.VarChar,255),
                    new OleDbParameter("@PageSize",OleDbType.Integer),
                    new OleDbParameter("@PageIndex",OleDbType.Integer),
                    new OleDbParameter("@OrderType",OleDbType.Integer),
                    new OleDbParameter("@strWhere",OleDbType.Integer),
                    new OleDbParameter("@Total",OleDbType.Integer)};
            param[0].Value = tablename;
            param[1].Value = tablefields;
            param[2].Value = orderfields;
            param[3].Value = pagesize;
            param[4].Value = pageindex;
            param[5].Value = ordertype;
            param[6].Value = strwhere;
            param[7].Direction = ParameterDirection.Output;
            DataSet ds = ExecuteProcedureDataset("SqlPage", param);
            totalcount = int.Parse(param[7].Value.ToString());
            return ds;
        }
        #endregion

        #region ��������ģ��

        /// <summary>
        /// ��ȡ�ֶ����ID
        /// </summary>
        /// <param name="filedName">������</param>
        /// <param name="tableName">������</param>
        /// <returns>���ID</returns>
        static public int GetMaxId(string filedName,string tableName)
        {
            string strSql = "select max(" + filedName + ") as MaxID from " + tableName;
            return int.Parse(ExecuteScalar(strSql).ToString());
        }

        /// <summary>
        /// �����ֶ������ۺ�
        /// </summary>
        /// <param name="filedName">�ֶ�����</param>
        /// <param name="tableName">������</param>
        /// <returns></returns>
        static public int GetCount(string filedName, string tableName)
        {
            string strSql = "select count(" + filedName + ") as MaxID from " + tableName;
            return int.Parse(ExecuteScalar(strSql).ToString());
        }

        /// <summary>
        /// �����ֶ������ۺ�
        /// </summary>
        ///<param name="countOleDb">��ѯCount�ܺ����</param>
        /// <returns></returns>
        static public int GetCount(string countOleDb)
        {
            return int.Parse(ExecuteScalar(countOleDb).ToString());
        }

        /// <summary>
        /// ִ��SQL���,����bool��������
        /// </summary>
        /// <param name="strSql">SQL���</param>
        /// <returns></returns>
        static public bool ExecuteforBool(string strSql)
        {
            return ExecuteNonQuery(strSql) > 0;
        }

        /// <summary>
        /// ִ��SQL���,����bool��������
        /// </summary>
        /// <param name="strSql">Sql���</param>
        /// <param name="cmdType">CommandType����</param>
        /// <param name="param">����</param>
        /// <returns></returns>
        static public bool ExecuteforBool(string strSql,CommandType cmdType,params OleDbParameter[] param)
        {
            return ExecuteNonQuery(strSql,cmdType,param)>0;
        }
        #endregion

        #region ��������
        /// <summary>
        /// ��OleDbParameter��������(����ֵ)�����OleDbCommand����.
        /// ������������κ�һ����������DBNull.Value;
        /// �ò�������ֹĬ��ֵ��ʹ��.
        /// </summary>
        /// <param name="command">������</param>
        /// <param name="commandParameters">OleDbParameters����</param>
        private static void AttachParameters(OleDbCommand command, OleDbParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (OleDbParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // ���δ����ֵ���������,���������DBNull.Value.
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
        /// ��DataRow���͵���ֵ���䵽OleDbParameter��������.
        /// </summary>
        /// <param name="commandParameters">Ҫ����ֵ��OleDbParameter��������</param>
        /// <param name="dataRow">��Ҫ������洢���̲�����DataRow</param>
        public static void AssignParameterValues(OleDbParameter[] commandParameters, DataRow dataRow)
        {
            if ((commandParameters == null) || (dataRow == null))
            {
                return;
            }

            int i = 0;
            // ���ò���ֵ
            foreach (OleDbParameter commandParameter in commandParameters)
            {
                // ������������,���������,ֻ�׳�һ���쳣.
                if (commandParameter.ParameterName == null ||
                    commandParameter.ParameterName.Length <= 1)
                    throw new Exception(
                        string.Format("���ṩ����{0}һ����Ч������{1}.", i, commandParameter.ParameterName));
                // ��dataRow�ı��л�ȡΪ�����������������Ƶ��е�����.
                // ������ںͲ���������ͬ����,����ֵ������ǰ���ƵĲ���.
                if (dataRow.Table.Columns.IndexOf(commandParameter.ParameterName.Substring(1)) != -1)
                    commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];
                i++;
            }
        }

        /// <summary>
        /// ��һ��������������OleDbParameter��������.
        /// </summary>
        /// <param name="commandParameters">Ҫ����ֵ��OleDbParameter��������</param>
        /// <param name="parameterValues">��Ҫ������洢���̲����Ķ�������</param>
        public static void AssignParameterValues(OleDbParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                return;
            }

            // ȷ����������������������ƥ��,�����ƥ��,�׳�һ���쳣.
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("����ֵ�����������ƥ��.");
            }

            // ��������ֵ
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
        /// Ԥ�����û��ṩ������,���ݿ�����/����/��������/����
        /// </summary>
        /// <param name="command">Ҫ�����OleDbCommand</param>
        /// <param name="connection">���ݿ�����</param>
        /// <param name="transaction">һ����Ч�����������nullֵ</param>
        /// <param name="commandType">�������� (�洢����,�����ı�, ����.)</param>
        /// <param name="commandText">�洢��������T-SQL�����ı�</param>
        /// <param name="commandParameters">�������������OleDbParameter��������,���û�в���Ϊ'null'</param>
        private static void PrepareCommand(OleDbCommand command, OleDbConnection connection, OleDbTransaction transaction, CommandType commandType, string commandText, OleDbParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            // ���������һ�����ݿ�����.
            command.Connection = connection;

            // ���������ı�(�洢��������SQL���)
            command.CommandText = commandText;

            // ��������
            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }

            // ������������.
            command.CommandType = commandType;

            // �����������
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }

        #endregion
    }
}
