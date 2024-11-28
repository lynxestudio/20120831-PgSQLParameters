/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 11/27/2024
 * Time: 11:07 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Npgsql;
using System.Configuration;
using System.Data;

namespace ExecProcedure
{
	/// <summary>
	/// Description of PgConnection.
	/// </summary>
	internal sealed class PgConnection
	{
		static NpgsqlConnection connection = null;
		internal static NpgsqlConnection GetConnection()
		{
			string connectionString  = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
			connection = new NpgsqlConnection(connectionString);
			connection.Open();
			return connection;
		}
		
		internal static void CloseConnection()
		{
			if(connection != null)
			{
				if(connection.State == ConnectionState.Open)
				{
					connection.Close();
					connection = null;
				}
			}
		}
	}
}
