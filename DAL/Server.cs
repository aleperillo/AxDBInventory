using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Helper;
using Microsoft.SqlServer.Server;

namespace DAL
{
    public class Server
    {
        private string sqlConn()
        {
            return Helper.Security.Decrypt(ConfigurationManager.AppSettings["SqlConn"]);

        }
        public DataTable ListAll(string servername = null)
        {
            DataAccess.DataAccessSql dataAccessSql = new DataAccess.DataAccessSql();
            DataTable table = new DataTable();
            string command = "select * from DatabaseServers where Active = 1";
            if (!String.IsNullOrEmpty(servername))
                command += string.Format(" and Servername='{0}'", servername);

            table = dataAccessSql.ExecutarConsulta(CommandType.Text, command);
            
            return table;

        }
        public object DeleteOne(string servername)
        {
            
            DataAccess.DataAccessSql dataAccessSql = new DataAccess.DataAccessSql();
            string command = string.Format(@"
                                    update i 
                                    set i.isInstanceMonitored = 0
                                    from DatabaseServerInstances i  inner
                                    join DatabaseServers d on i.ServerName = d.ServerName
                                    where i.servername = '{0}';", servername);


            var Retorno = dataAccessSql.ExecutarManipulacao(CommandType.Text, command);
            
            command = string.Format(@"
                                update d 
                                set Active=0, isHostMonitored=0
                                from DatabaseServers d  
                                where d.servername= '{0}';", servername);
            
            Retorno = dataAccessSql.ExecutarManipulacao(CommandType.Text, command);

            return Retorno;

        }
    }
}
