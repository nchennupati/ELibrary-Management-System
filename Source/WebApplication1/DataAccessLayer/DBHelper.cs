using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;
using System.Data;
namespace DataAccessLayer
{
    static class DBHelper
    {
        static DbProviderFactory factory;

        static DBHelper()
        {
            factory = DbProviderFactories.GetFactory(ELibConfigurations.ProviderName);
        }

        public static DbCommand CreateCommand(string text, CommandType type, params DbParameter[] parameters)
        {
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = ELibConfigurations.ConnectionString;

            DbCommand command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = text;
            command.CommandType = type;
            if (parameters.Length > 0)
                command.Parameters.AddRange(parameters);
            return command;
        }

        public static int ExecuteNonQuery(DbCommand command)
        {
            int rowsAffected = -1;
            try
            {
                command.Connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (DbException ex)
            {
                throw ex;
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }
            return rowsAffected;
        }
        public static object ExecuteScalar(DbCommand command)
        {
            object result = null;
            try
            {
                command.Connection.Open();
                result = command.ExecuteScalar();
            }
            catch (DbException ex)
            {
                throw ex;
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }
            return result;
        }
        public static DataTable ExecuteReader(DbCommand command)
        {
            DataTable dataTable = new DataTable();
            DbDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                dataTable.Load(reader);
            }
            catch (DbException ex)
            {
                throw ex;
            }
            finally
            {
                if (reader.IsClosed == false)
                    reader.Close();
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }
            return dataTable;
        }

        public static DbParameter CreateParameter(string paramName, object value = null)
        {
            DbParameter parameter = factory.CreateParameter();
            parameter.ParameterName = paramName;
            parameter.Value = value;
            return parameter;
        }
    }
}
