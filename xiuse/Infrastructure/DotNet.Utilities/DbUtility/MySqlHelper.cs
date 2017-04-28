/*******************************************************************************
             数据库基类 (MySql)                                    
             本类主要实现对数据库操作的各种方法              
             本类由Aosy.net代码生成器自动生成  
             2016/12/11                 
 * *****************************************************************************/

using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;

namespace Xiuse.DbUtility
{
	/// <summary>
	/// Helper class that makes it easier to work with the provider.
	/// </summary>
	public sealed class MySqlHelper
	{
        private static Hashtable parmCache = Hashtable.Synchronized( new Hashtable() );
		// this class provides only static methods
		private MySqlHelper(){}        

        #region private utility methods & constructors     
       

        /// <summary>
        /// This method is used to attach array of SqlParameters to a SqlCommand.
        /// 
        /// This method will assign a value of DbNull to any parameter with a direction of
        /// InputOutput and a value of null.  
        /// 
        /// This behavior will prevent default values from being used, but
        /// this will be the less common case than an intended pure output parameter (derived as InputOutput)
        /// where the user provided no input value.
        /// </summary>
        /// <param name="command">The command to which the parameters will be added</param>
        /// <param name="commandParameters">An array of SqlParameters to be added to command</param>
        private static void AttachParameters( MySqlCommand command, MySqlParameter[] commandParameters )
        {
            if( command == null ) throw new ArgumentNullException( "command" );
            if( commandParameters != null )
            {
                foreach ( MySqlParameter p in commandParameters )
                {
                    if( p != null )
                    {
                        // Check for derived output value with no value assigned
                        if ( ( p.Direction == ParameterDirection.InputOutput || 
                            p.Direction == ParameterDirection.Input ) && 
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        /// <summary>
        /// This method assigns dataRow column values to an array of SqlParameters
        /// </summary>
        /// <param name="commandParameters">Array of SqlParameters to be assigned values</param>
        /// <param name="dataRow">The dataRow used to hold the stored procedure's parameter values</param>
        private static void AssignParameterValues( MySqlParameter[] commandParameters, DataRow dataRow )
        {
            if ( ( commandParameters == null ) || ( dataRow == null ) ) 
            {
                // Do nothing if we get no data
                return;
            }

            int i = 0;
            // Set the parameters values
            foreach( MySqlParameter commandParameter in commandParameters )
            {
                // Check the parameter name
                if( commandParameter.ParameterName == null || 
                    commandParameter.ParameterName.Length <= 1 )
                    throw new Exception( 
                        string.Format( 
                        "Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: '{1}'.", 
                        i, commandParameter.ParameterName ) );
                if (dataRow.Table.Columns.IndexOf(commandParameter.ParameterName.Substring(1)) != -1)
                    commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];
                i++;
            }
        }

        /// <summary>
        /// This method assigns an array of values to an array of SqlParameters
        /// </summary>
        /// <param name="commandParameters">Array of SqlParameters to be assigned values</param>
        /// <param name="parameterValues">Array of objects holding the values to be assigned</param>
        public static void AssignParameterValues( MySqlParameter[] commandParameters, params object[] parameterValues )
        {
            if ( ( commandParameters == null ) || ( parameterValues == null ) ) 
            {
                // Do nothing if we get no data
                return;
            }

            // We must have the same number of values as we pave parameters to put them in
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }

            // Iterate through the SqlParameters, assigning the values from the corresponding position in the 
            // value array
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                // If the current array value derives from IDbDataParameter, then assign its Value property
                if (parameterValues[i] is IDbDataParameter)
                {
                    IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
                    if( paramInstance.Value == null )
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
        /// This method assigns an array of values to an array of SqlParameters
        /// </summary>
        /// <param name="commandParameter">Array of SqlParameters to be assigned values</param>
        /// <param name="parameterValue">Array of objects holding the values to be assigned</param>
        public static void AssignParameterValues( MySqlParameter commandParameter, object parameterValue )
        {
            if ( ( commandParameter == null ) || ( parameterValue == null ) ) 
            {
                // Do nothing if we get no data
                return;
            }		

            // Iterate through the SqlParameters, assigning the values from the corresponding position in the 
            // value array
			
            // If the current array value derives from IDbDataParameter, then assign its Value property
            if ( parameterValue is IDbDataParameter )
            {
                IDbDataParameter paramInstance = ( IDbDataParameter )parameterValue;
                if( paramInstance.Value == null )
                {
                    commandParameter.Value = DBNull.Value; 
                }
                else
                {
                    commandParameter.Value = paramInstance.Value;
                }
            }
            else if ( parameterValue == null )
            {
                commandParameter.Value = DBNull.Value;
            }
            else
            {
                commandParameter.Value = parameterValue;
            }
        }

        #endregion private utility methods & constructors

        #region ExecuteNonQuery

        /// <summary>
        /// Executes a single command against a MySQL database.  The <see cref="MySqlConnection"/> is assumed to be
		/// open when the method is called and remains open after the method completes.
		/// </summary>
		/// <param name="connection"><see cref="MySqlConnection"/> object to use</param>
		/// <param name="commandText">SQL command to be executed</param>
		/// <param name="commandParameters">Array of <see cref="MySqlParameter"/> objects to use with the command.</param>
		/// <returns></returns>
		public static int ExecuteNonQuery( MySqlConnection connection, string commandText, params MySqlParameter[] commandParameters )
		{
			//create a command and prepare it for execution
			MySqlCommand cmd = new MySqlCommand();
			cmd.Connection = connection;
			cmd.CommandText = commandText;
			cmd.CommandType = CommandType.Text;

			if (commandParameters != null)
				foreach (MySqlParameter p in commandParameters)
					cmd.Parameters.Add( p );

			int result = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			return result;
		}

		/// <summary>
		/// Executes a single command against a MySQL database.  A new <see cref="MySqlConnection"/> is created
		/// using the <see cref="MySqlConnection.ConnectionString"/> given.
		/// </summary>
		/// <param name="connectionString"><see cref="MySqlConnection.ConnectionString"/> to use</param>
		/// <param name="commandText">SQL command to be executed</param>
		/// <param name="parms">Array of <see cref="MySqlParameter"/> objects to use with the command.</param>
		/// <returns></returns>
		public static int ExecuteNonQuery( string connectionString, string commandText, params MySqlParameter[] parms )
		{
			//create & open a SqlConnection, and dispose of it after we are done.
			using (MySqlConnection cn = new MySqlConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteNonQuery(cn, commandText, parms );
			}
		}

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset and takes no parameters) against the provided SqlTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders");
        /// </remarks>
        /// <param name="transaction">A valid SqlTransaction</param>    
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery( MySqlTransaction transaction, string commandText )
        {
            // Pass through the call providing null for the set of SqlParameters
            return ExecuteNonQuery( transaction, commandText, ( MySqlParameter[] ) null );
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against the specified SqlTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid SqlTransaction</param>    
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery( MySqlTransaction transaction, string commandText, params MySqlParameter[] commandParameters )
        {
            if( transaction == null ) throw new ArgumentNullException( "transaction" );
            if( transaction != null && transaction.Connection == null ) throw new ArgumentException( "The transaction was rollbacked or commited, please provide an open transaction.", "transaction" );

            // Create a command and prepare it for execution
            MySqlCommand cmd = new MySqlCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandText, commandParameters, out mustCloseConnection );
    			
            // Finally, execute the command
            int retval = cmd.ExecuteNonQuery();
    			
            // Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            return retval;
        }       
		#endregion

		#region ExecuteDataSet
		/// <summary>
		/// Executes a single SQL command and returns the first row of the resultset.  A new MySqlConnection object
		/// is created, opened, and closed during this method.
		/// </summary>
		/// <param name="connectionString">Settings to be used for the connection</param>
		/// <param name="commandText">Command to execute</param>
		/// <param name="parms">Parameters to use for the command</param>
		/// <returns>DataRow containing the first row of the resultset</returns>
		public static DataRow ExecuteDataRow( string connectionString, string commandText, params MySqlParameter[] parms )
		{
			DataSet ds = ExecuteDataset( connectionString, commandText, parms );
			if (ds == null) return null;
			if (ds.Tables.Count == 0) return null;
			if (ds.Tables[0].Rows.Count == 0) return null;
			return ds.Tables[0].Rows[0];
		}

		/// <summary>
		/// Executes a single SQL command and returns the resultset in a <see cref="DataSet"/>.  
		/// A new MySqlConnection object is created, opened, and closed during this method.
		/// </summary>
		/// <param name="connectionString">Settings to be used for the connection</param>
		/// <param name="commandText">Command to execute</param>
		/// <returns><see cref="DataSet"/> containing the resultset</returns>
		public static DataSet ExecuteDataset(string connectionString, string commandText)
		{
			//pass through the call providing null for the set of SqlParameters
			return ExecuteDataset(connectionString, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Executes a single SQL command and returns the resultset in a <see cref="DataSet"/>.  
		/// A new MySqlConnection object is created, opened, and closed during this method.
		/// </summary>
		/// <param name="connectionString">Settings to be used for the connection</param>
		/// <param name="commandText">Command to execute</param>
		/// <param name="commandParameters">Parameters to use for the command</param>
		/// <returns><see cref="DataSet"/> containing the resultset</returns>
		public static DataSet ExecuteDataset(string connectionString, string commandText, params MySqlParameter[] commandParameters)
		{
			//create & open a SqlConnection, and dispose of it after we are done.
			using (MySqlConnection cn = new MySqlConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteDataset(cn, commandText, commandParameters);
			}
		}

		/// <summary>
		/// Executes a single SQL command and returns the resultset in a <see cref="DataSet"/>.  
		/// The state of the <see cref="MySqlConnection"/> object remains unchanged after execution
		/// of this method.
		/// </summary>
		/// <param name="connection"><see cref="MySqlConnection"/> object to use</param>
		/// <param name="commandText">Command to execute</param>
		/// <returns><see cref="DataSet"/> containing the resultset</returns>
		public static DataSet ExecuteDataset(MySqlConnection connection, string commandText)
		{
			//pass through the call providing null for the set of SqlParameters
			return ExecuteDataset(connection, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Executes a single SQL command and returns the resultset in a <see cref="DataSet"/>.  
		/// The state of the <see cref="MySqlConnection"/> object remains unchanged after execution
		/// of this method.
		/// </summary>
		/// <param name="connection"><see cref="MySqlConnection"/> object to use</param>
		/// <param name="commandText">Command to execute</param>
		/// <param name="commandParameters">Parameters to use for the command</param>
		/// <returns><see cref="DataSet"/> containing the resultset</returns>
		public static DataSet ExecuteDataset( MySqlConnection connection, string commandText, params MySqlParameter[] commandParameters )
		{
			//create a command and prepare it for execution
			MySqlCommand cmd = new MySqlCommand();
			cmd.Connection = connection;
			cmd.CommandText = commandText;
			cmd.CommandType = CommandType.Text;

			if ( commandParameters != null )
				foreach ( MySqlParameter p in commandParameters )
					cmd.Parameters.Add( p );
			
			//create the DataAdapter & DataSet
			MySqlDataAdapter da = new MySqlDataAdapter( cmd );
			DataSet ds = new DataSet();

			//fill the DataSet using default values for DataTable names, etc.
			da.Fill(ds);
			
			// detach the MySqlParameters from the command object, so they can be used again.			
			cmd.Parameters.Clear();
			
			//return the dataset
			return ds;						
		}

        /// <summary>
        /// Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="transaction">A valid SqlTransaction</param>      
        /// <param name="commandText">The T-SQL command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset( MySqlTransaction transaction, string commandText )
        {
            // Pass through the call providing null for the set of SqlParameters
            return ExecuteDataset(transaction, commandText, ( MySqlParameter[] ) null );
        }
		
        /// <summary>
        /// Execute a MySqlCommand (that returns a resultset) against the specified MySqlTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(trans, "GetOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid MySqlTransaction</param>        
        /// <param name="commandText">The T-SQL command</param>
        /// <param name="commandParameters">An array of MySqlParamters used to execute the command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset( MySqlTransaction transaction, string commandText, params MySqlParameter[] commandParameters )
        {
            if( transaction == null ) throw new ArgumentNullException( "transaction" );
            if( transaction != null && transaction.Connection == null ) throw new ArgumentException( "The transaction was rollbacked or commited, please provide an open transaction.", "transaction" );

            // Create a command and prepare it for execution
            MySqlCommand cmd = new MySqlCommand();
            bool mustCloseConnection = false;
            PrepareCommand( cmd, transaction.Connection, transaction, commandText, commandParameters, out mustCloseConnection );
    			
            // Create the DataAdapter & DataSet
            using( MySqlDataAdapter da = new MySqlDataAdapter( cmd ) )
            {
                DataSet ds = new DataSet();

                // Fill the DataSet using default values for DataTable names, etc
                da.Fill( ds );
    			
                // Detach the SqlParameters from the command object, so they can be used again
                cmd.Parameters.Clear();

                // Return the dataset
                return ds;
            }	
        }

		/// <summary>
		/// Updates the given table with data from the given <see cref="DataSet"/>
		/// </summary>
		/// <param name="connectionString">Settings to use for the update</param>
		/// <param name="commandText">Command text to use for the update</param>
		/// <param name="ds"><see cref="DataSet"/> containing the new data to use in the update</param>
		/// <param name="tablename">Tablename in the dataset to update</param>
		public static void UpdateDataSet( string connectionString, string commandText, DataSet ds, string tablename )
		{
			MySqlConnection cn = new MySqlConnection( connectionString );
			cn.Open();
			MySqlDataAdapter da = new MySqlDataAdapter( commandText, cn );
			MySqlCommandBuilder cb = new MySqlCommandBuilder( da );
			da.Update( ds, tablename );
			cn.Close();
		}

                		/// <summary>
        /// 执行指定数据库连接对象的命令,返回DataSet.
        /// </summary>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="startRecord">开始记录数</param>
        /// <param name="maxRecord">最大记录数</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="commandText">查询语句</param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string connectionString,CommandType commandType, int startRecord, int maxRecord, out int recordCount, string commandText)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");

            // 创建并打开数据库连接对象,操作完成释放对象.
            using (MySqlConnection connection= new MySqlConnection(connectionString))
            {
                connection.Open();
                DataSet ds = new DataSet();
                int reccount = 0;
                using(MySqlCommand cmd=new MySqlCommand())
                {
                    cmd.Connection=connection;
                    cmd.CommandType=commandType;
                    cmd.CommandText=commandText;
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(ds, startRecord, maxRecord, "ds");
                    }
                    reccount=int.Parse(cmd.ExecuteNonQuery().ToString());
                }
                recordCount = reccount;
                return ds;
            }
        }

                       /// <summary>
        /// 执行指定数据库连接对象的命令,返回DataSet.
        /// </summary>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="startRecord">开始记录数</param>
        /// <param name="maxRecord">最大记录数</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="commandText">查询语句</param>
        /// <param name="parameters">参数集合</param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string connectionString,CommandType commandType, int startRecord, int maxRecord, out int recordCount, string commandText, params MySqlParameter[] parameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");

            // 创建并打开数据库连接对象,操作完成释放对象.
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                DataSet ds = new DataSet();
                int reccount = 0;
                using (MySqlCommand cmds = new MySqlCommand())
                {
                    cmds.Connection = connection;
                    cmds.CommandText = commandText;
                    cmds.CommandType=commandType;
                    AttachParameters(cmds, parameters);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmds))
                    {
                        da.Fill(ds, startRecord, maxRecord, "ds");
                    }
                     reccount = int.Parse(cmds.ExecuteNonQuery().ToString());
                }
                recordCount = reccount;
                return ds;
            }
        }
		#endregion

		#region ExecuteDataReader        
		/// <summary>
		/// Executes a single command against a MySQL database, possibly inside an existing transaction.
		/// </summary>
		/// <param name="connection"><see cref="MySqlConnection"/> object to use for the command</param>
		/// <param name="transaction"><see cref="MySqlTransaction"/> object to use for the command</param>
		/// <param name="commandText">Command text to use</param>
		/// <param name="commandParameters">Array of <see cref="MySqlParameter"/> objects to use with the command</param>
		/// <param name="ExternalConn">True if the connection should be preserved, false if not</param>
		/// <returns><see cref="MySqlDataReader"/> object ready to read the results of the command</returns>
		private static MySqlDataReader ExecuteReader( MySqlConnection connection, MySqlTransaction transaction, string commandText, MySqlParameter[] commandParameters, bool ExternalConn )
		{	
			//create a command and prepare it for execution
			MySqlCommand cmd = new MySqlCommand();
			cmd.Connection = connection;
			cmd.Transaction = transaction;
			cmd.CommandText = commandText;
			cmd.CommandType = CommandType.Text;
			
			if (commandParameters != null)
				foreach (MySqlParameter p in commandParameters)
					cmd.Parameters.Add( p );

			//create a reader
			MySqlDataReader dr;

			// call ExecuteReader with the appropriate CommandBehavior
			if ( ExternalConn )
			{
				dr = cmd.ExecuteReader();
			}
			else
			{
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
			
			// detach the SqlParameters from the command object, so they can be used again.
			cmd.Parameters.Clear();
			
			return dr;
		}

		/// <summary>
		/// Executes a single command against a MySQL database.
		/// </summary>
		/// <param name="connectionString">Settings to use for this command</param>
		/// <param name="commandText">Command text to use</param>
		/// <returns><see cref="MySqlDataReader"/> object ready to read the results of the command</returns>
		public static MySqlDataReader ExecuteReader(string connectionString, string commandText)
		{
			//pass through the call providing null for the set of SqlParameters
			return ExecuteReader(connectionString, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Executes a single command against a MySQL database.
		/// </summary>
		/// <param name="connectionString">Settings to use for this command</param>
		/// <param name="commandText">Command text to use</param>
		/// <param name="commandParameters">Array of <see cref="MySqlParameter"/> objects to use with the command</param>
		/// <returns><see cref="MySqlDataReader"/> object ready to read the results of the command</returns>
		public static MySqlDataReader ExecuteReader(string connectionString, string commandText, params MySqlParameter[] commandParameters)
		{
			//create & open a SqlConnection
			MySqlConnection cn = new MySqlConnection(connectionString);
			cn.Open();
			try
			{
				//call the private overload that takes an internally owned connection in place of the connection string
				return ExecuteReader( cn, null, commandText, commandParameters, false );
			}
			catch
			{
				//if we fail to return the SqlDatReader, we need to close the connection ourselves
				cn.Close();
				throw;
			}
		}

        /// <summary>
        /// Execute a MySqlCommand (that returns a resultset and takes no parameters) against the provided SqlTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  MySqlDataReader dr = ExecuteReader( trans, "GetOrders");
        /// </remarks>
        /// <param name="transaction">A valid SqlTransaction</param>      
        /// <param name="commandText">The T-SQL command</param>
        /// <returns>A SqlDataReader containing the resultset generated by the command</returns>
        public static MySqlDataReader ExecuteReader( MySqlTransaction transaction, string commandText )
        {
            // Pass through the call providing null for the set of SqlParameters
            return ExecuteReader( transaction, commandText, ( MySqlParameter[] ) null );
        }

        /// <summary>
        /// Execute a SqlCommand (that returns a resultset) against the specified SqlTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///   MySqlDataReader dr = ExecuteReader(trans, "GetOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid SqlTransaction</param>        
        /// <param name="commandText">The T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>A MySqlDataReader containing the resultset generated by the command</returns>
        public static MySqlDataReader ExecuteReader( MySqlTransaction transaction, string commandText, params MySqlParameter[] commandParameters)
        {
            if( transaction == null ) throw new ArgumentNullException( "transaction" );
            if( transaction != null && transaction.Connection == null ) throw new ArgumentException( "The transaction was rollbacked or commited, please provide an open transaction.", "transaction" );

            // Pass through to private overload, indicating that the connection is owned by the caller
            return ExecuteReader( transaction.Connection, transaction, commandText, commandParameters, false );
        }

		#endregion

		#region ExecuteScalar

		/// <summary>
		/// Execute a single command against a MySQL database.
		/// </summary>
		/// <param name="connectionString">Settings to use for the update</param>
		/// <param name="commandText">Command text to use for the update</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		public static object ExecuteScalar(string connectionString, string commandText)
		{
			//pass through the call providing null for the set of MySqlParameters
			return ExecuteScalar(connectionString, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Execute a single command against a MySQL database.
		/// </summary>
		/// <param name="connectionString">Settings to use for the command</param>
		/// <param name="commandText">Command text to use for the command</param>
		/// <param name="commandParameters">Parameters to use for the command</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		public static object ExecuteScalar(string connectionString, string commandText, params MySqlParameter[] commandParameters)
		{
			//create & open a SqlConnection, and dispose of it after we are done.
			using (MySqlConnection cn = new MySqlConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteScalar(cn, commandText, commandParameters);
			}
		}

		/// <summary>
		/// Execute a single command against a MySQL database.
		/// </summary>
		/// <param name="connection"><see cref="MySqlConnection"/> object to use</param>
		/// <param name="commandText">Command text to use for the command</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		public static object ExecuteScalar( MySqlConnection connection, string commandText )
		{
			//pass through the call providing null for the set of MySqlParameters
			return ExecuteScalar( connection, commandText, ( MySqlParameter[] )null );
		}

		/// <summary>
		/// Execute a single command against a MySQL database.
		/// </summary>
		/// <param name="connection"><see cref="MySqlConnection"/> object to use</param>
		/// <param name="commandText">Command text to use for the command</param>
		/// <param name="commandParameters">Parameters to use for the command</param>
		/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
		public static object ExecuteScalar( MySqlConnection connection, string commandText, params MySqlParameter[] commandParameters )
		{
			//create a command and prepare it for execution
			MySqlCommand cmd = new MySqlCommand();
			cmd.Connection = connection;
			cmd.CommandText = commandText;
			cmd.CommandType = CommandType.Text;
			
			if (commandParameters != null)
				foreach (MySqlParameter p in commandParameters)
					cmd.Parameters.Add( p );
			
			//execute the command & return the results
			object retval = cmd.ExecuteScalar();
			
			// detach the SqlParameters from the command object, so they can be used again.
			cmd.Parameters.Clear();
			return retval;
			
		}

        /// <summary>
        /// Execute a MySqlCommand (that returns a 1x1 resultset and takes no parameters) against the provided SqlTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(trans, "GetOrderCount");
        /// </remarks>
        /// <param name="transaction">A valid MySqlTransaction</param>      
        /// <param name="commandText">The T-SQL command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar( MySqlTransaction transaction, string commandText )
        {
            // Pass through the call providing null for the set of SqlParameters
            return ExecuteScalar( transaction, commandText, (MySqlParameter[])null);
        }

        /// <summary>
        /// Execute a SqlCommand (that returns a 1x1 resultset) against the specified SqlTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(trans, "GetOrderCount", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid MySqlTransaction</param>   
        /// <param name="commandText">The T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar( MySqlTransaction transaction, string commandText, params MySqlParameter[] commandParameters )
        {
            if( transaction == null ) throw new ArgumentNullException( "transaction" );
            if( transaction != null && transaction.Connection == null ) throw new ArgumentException( "The transaction was rollbacked or commited, please provide an open transaction.", "transaction" );

            // Create a command and prepare it for execution
            MySqlCommand cmd = new MySqlCommand();
            bool mustCloseConnection = false;
            PrepareCommand( cmd, transaction.Connection, transaction, commandText, commandParameters, out mustCloseConnection );
    			
            // Execute the command & return the results
            object retval = cmd.ExecuteScalar();
    			
            // Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            return retval;
        }

        /// <summary>
        /// This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
        /// to the provided command
        /// </summary>
        /// <param name="command">The SqlCommand to be prepared</param>
        /// <param name="connection">A valid SqlConnection, on which to execute this command</param>
        /// <param name="transaction">A valid SqlTransaction, or 'null'</param>       
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParameters to be associated with the command or 'null' if no parameters are required</param>
        /// <param name="mustCloseConnection"><c>true</c> if the connection was opened by the method, otherwose is false.</param>
        private static void PrepareCommand( MySqlCommand command, MySqlConnection connection, MySqlTransaction transaction, string commandText, MySqlParameter[] commandParameters, out bool mustCloseConnection )
        {
            if( command == null ) throw new ArgumentNullException( "command" );
            if( commandText == null || commandText.Length == 0 ) throw new ArgumentNullException( "commandText" );

            // If the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            // Associate the connection with the command
            command.Connection = connection;

            // Set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;

            // If we were provided a transaction, assign it
            if (transaction != null)
            {
                if( transaction.Connection == null ) throw new ArgumentException( "The transaction was rollbacked or commited, please provide an open transaction.", "transaction" );
                command.Transaction = transaction;
            }          

            // Attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }

		#endregion

        #region Make SqlParameters
        /// <summary>
        /// Make input param.
        /// </summary>
        /// <param name="ParamName">Name of param.</param>
        /// <param name="DbType">Param type.</param>
        /// <param name="Size">Param size.</param>
        /// <param name="Value">Param value.</param>
        /// <returns>New parameter.</returns>
        public static MySqlParameter MakeInParam(string ParamName, MySqlDbType DbType, int Size, object Value) 
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }		

        /// <summary>
        /// Make input param.
        /// </summary>
        /// <param name="ParamName">Name of param.</param>
        /// <param name="DbType">Param type.</param>
        /// <param name="Size">Param size.</param>
        /// <returns>New parameter.</returns>
        public static MySqlParameter MakeOutParam(string ParamName, MySqlDbType DbType, int Size) 
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }		

        /// <summary>
        /// Make stored procedure param.
        /// </summary>
        /// <param name="ParamName">Name of param.</param>
        /// <param name="DbType">Param type.</param>
        /// <param name="Size">Param size.</param>
        /// <param name="Direction">Parm direction.</param>
        /// <param name="Value">Param value.</param>
        /// <returns>New parameter.</returns>
        public static MySqlParameter MakeParam(string ParamName, MySqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value) 
        {
            MySqlParameter param;

            if(Size > 0)
                param = new MySqlParameter( ParamName, DbType, Size );
            else
                param = new MySqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }
        #endregion
	}

    /// <summary>
    /// 用来存取缓存SqlParameter[]
    /// </summary>
    public sealed class ParamsCache
    {
        #region private methods, variables, and constructors

        //Since this class provides only static methods, make the default constructor private to prevent 
        //instances from being created with "new ParamsCache()"
        private ParamsCache() {}

        private static Hashtable paramCache = Hashtable.Synchronized( new Hashtable() );
        

        /// <summary>
        /// Deep copy of cached SqlParameter array
        /// </summary>
        /// <param name="originalParameters"></param>
        /// <returns></returns>
        private static MySqlParameter[] CloneParameters( MySqlParameter[] originalParameters )
        {
            MySqlParameter[] clonedParameters = new MySqlParameter[originalParameters.Length];

            for ( int i = 0, j = originalParameters.Length; i < j; i++ )
            {
                clonedParameters[i] = ( MySqlParameter )( ( ICloneable ) originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        /// <summary>
        /// Deep copy of cached SqlParameter array
        /// </summary>
        /// <param name="originalParameter"></param>
        /// <returns></returns>
        private static MySqlParameter CloneParameters( MySqlParameter originalParameter )
        {
            MySqlParameter clonedParameter = new MySqlParameter();
            clonedParameter = ( MySqlParameter )( (ICloneable) originalParameter).Clone();
            return clonedParameter;
        }

        #endregion private methods, variables, and constructors

        #region caching functions

        /// <summary>
        /// Add parameter array to the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for a SqlConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters to be cached</param>
        public static void CacheParameterSet( string connectionString, string commandText, params MySqlParameter[] commandParameters )
        {
            if( connectionString == null || connectionString.Length == 0 ) throw new ArgumentNullException( "connectionString" );
            if( commandText == null || commandText.Length == 0 ) throw new ArgumentNullException( "commandText" );

            string hashKey = connectionString + ":" + commandText;

            paramCache[hashKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve a parameter array from the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for a SqlConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An array of SqlParamters</returns>
        public static MySqlParameter[] GetCachedParameterSet( string connectionString, string commandText )
        {
            if( connectionString == null || connectionString.Length == 0 ) throw new ArgumentNullException( "connectionString" );
            if( commandText == null || commandText.Length == 0 ) throw new ArgumentNullException( "commandText" );

            string hashKey = connectionString + ":" + commandText;

            MySqlParameter[] cachedParameters = paramCache[hashKey] as MySqlParameter[];
            if ( cachedParameters == null )
            {			
                return null;
            }
            else
            {
                return CloneParameters( cachedParameters );
            }
        }
        /// <summary>
        /// 得到缓存中的存储过程参数。如果能得到，返回true，并out 参数出来，不能得到，则parms = null，返回false;
        /// 作者：肯定是Wintle:)
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="spName"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static bool GetCachedParameterSet( string connectionString, string spName, out MySqlParameter[] parms )
        {
            bool hasCached = false;
            if( connectionString == null || connectionString.Length == 0 ) throw new ArgumentNullException( "connectionString" );
            if( spName == null || spName.Length == 0 ) throw new ArgumentNullException( "spName" );
            string hashKey = connectionString + ":" + spName;

            MySqlParameter[] cachedParameters = paramCache[hashKey] as MySqlParameter[];
			
            if (cachedParameters == null)
            {
                parms = null;
            }
            else
            {
                parms = CloneParameters(cachedParameters);
                hasCached = true;
            }
            return hasCached;
        }

        /// <summary>
        /// 得到缓存中的存储过程参数。如果能得到，返回true，并out 参数出来，不能得到，则parms = null，返回false;
        /// 作者：肯定是Wintle:)
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="spName"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        public static bool GetCachedParameterSet( string connectionString,string spName, out MySqlParameter parm )
        {
            bool hasCached = false;
            if( connectionString == null || connectionString.Length == 0 ) throw new ArgumentNullException( "connectionString" );
            if( spName == null || spName.Length == 0 ) throw new ArgumentNullException( "spName" );
            string hashKey = connectionString + ":" + spName;

            MySqlParameter cachedParameter = paramCache[hashKey] as MySqlParameter;
			
            if ( cachedParameter == null)
            {
                parm = null;
            }
            else
            {
                parm = CloneParameters(cachedParameter);
                hasCached = true;
            }
            return hasCached;
        }

        #endregion caching functions      

    }
}
