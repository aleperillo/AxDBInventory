using System;
using System.Data;
using System.Data.SqlClient;



namespace DataAccess
{
    public class DataAccessSql
    {
        private SqlConnection CriarConexao()
        {
            if (string.IsNullOrEmpty(sConnectionString.Valor))
            {
                // se nao tem conexion string definida, vamos usar a default.
                sConnectionString.Valor = Helper.Security.Decrypt(Helper.Security.GetSetting("SqlConn"));
            }
            return new SqlConnection(sConnectionString.Valor);
        }

        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }
        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }
        public void AdicionarConnectionString(string sFullConnection)
        {
            sConnectionString.Valor = sFullConnection;
        }
        public void AdicionarConnectionString(string dbServer, string dbName, string dbUser, string dbPass)
        {
            sConnectionString.Valor = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=False;User ID={2};Password={3};Application Name=DBInventory 2.0", dbServer, dbName, dbUser, dbPass);

        }
        public static class sConnectionString
        {
            public static string Valor { get; set; }
        }
        public object ExecutarManipulacao(CommandType commandType, string nomeStoreProcedureOuTextoSql)
        {
            SqlTransaction trasaction;
            return ExecutarManipulacao(commandType, nomeStoreProcedureOuTextoSql, false, out trasaction);
        }
        public object ExecutarManipulacao(CommandType commandType, string nomeStoreProcedureOuTextoSql, bool bWithTransaction, out SqlTransaction transaction)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                if (bWithTransaction)
                {
                    transaction = sqlConnection.BeginTransaction("SampleTransaction");
                }
                else
                    transaction = null;
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoreProcedureOuTextoSql;

                //sqlCommand.CommandTimeout = Properties.Settings.Default.commandTimeout;


                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }
                return sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public SqlTransaction CriarTransacao()
        {
            SqlTransaction sqltransacao = null;
            return sqltransacao;
        }
        

        public DataTable ExecutarConsulta(CommandType commandType, string nomeStoreProcedureOuTextoSql)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoreProcedureOuTextoSql;

                // sqlCommand.CommandTimeout = Properties.Settings.Default.commandTimeout;


                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public SqlDataReader ExecutarConsulta(CommandType commandType, string nomeStoreProcedureOuTextoSql, bool DataAdapter)
        {

            try
            {
                SqlConnection sqlConnection = CriarConexao();
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoreProcedureOuTextoSql;

                // sqlCommand.CommandTimeout = Properties.Settings.Default.commandTimeout;


                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }
                SqlDataReader dr = sqlCommand.ExecuteReader();


                return dr;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}