using AxDBInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace AxDBInventory.Controllers
{
    public class ServerController : Controller
    {
        public List<ServerModel> listServers(string servername = null)
        {
            var lista = new List<ServerModel>();
            var serverDB = new DAL.Server();

            foreach (DataRow row in serverDB.ListAll(servername).Rows)
            {
                ServerModel server = new ServerModel();
                server.ServerName = Convert.IsDBNull(row["ServerName"]) ? "" : Convert.ToString(row["ServerName"]);
                server.IPAddress = Convert.IsDBNull(row["IPAddress"]) ? "" : Convert.ToString(row["IPAddress"]);
                server.Domain = Convert.IsDBNull(row["Domain"]) ? "" : Convert.ToString(row["Domain"]);
                server.Active = Convert.IsDBNull(row["Active"]) ? false : Convert.ToBoolean(row["Active"]);
                server.CPUCores = Convert.IsDBNull(row["CPUCores"]) ? 0 : Convert.ToInt32(row["CPUCores"]);
                server.RAM_GB = Convert.IsDBNull(row["RAM_GB"]) ? 0 : Convert.ToInt32(row["RAM_GB"]);
                server.OperatingSystem = Convert.IsDBNull(row["OperatingSystem"]) ? "" : Convert.ToString(row["OperatingSystem"]);
                server.ServicePack = Convert.IsDBNull(row["ServicePack"]) ? "" : Convert.ToString(row["ServicePack"]);
                server.LastReboot = Convert.IsDBNull(row["LastReboot"]) ? "" : Convert.ToString(row["LastReboot"]);
                server.FQDN = Convert.IsDBNull(row["FQDN"]) ? "" : Convert.ToString(row["FQDN"]);
                server.ComputerName = Convert.IsDBNull(row["ComputerName"]) ? "" : Convert.ToString(row["ComputerName"]);
                server.WMIAvailable = Convert.IsDBNull(row["WMIAvailable"]) ? false : Convert.ToBoolean(row["WMIAvailable"]);
                server.WMILastAttempt = Convert.IsDBNull(row["WMILastAttempt"]) ? DateTime.MinValue : Convert.ToDateTime(row["WMILastAttempt"]);
                server.Manufacturer = Convert.IsDBNull(row["Manufacturer"]) ? "" : Convert.ToString(row["Manufacturer"]);
                server.Description = Convert.IsDBNull(row["Description"]) ? "" : Convert.ToString(row["Description"]);
                server.Environment = Convert.IsDBNull(row["Environment"]) ? "" : Convert.ToString(row["Environment"]);
                server.Application = Convert.IsDBNull(row["Application"]) ? "" : Convert.ToString(row["Application"]);
                server.BusinessOwners = Convert.IsDBNull(row["BusinessOwners"]) ? "" : Convert.ToString(row["BusinessOwners"]);
                server.BusinessImpact = Convert.IsDBNull(row["BusinessImpact"]) ? "" : Convert.ToString(row["BusinessImpact"]);
                server.RDPSuccessful = Convert.IsDBNull(row["RDPSuccessful"]) ? false : Convert.ToBoolean(row["RDPSuccessful"]);
                server.RDPComments = Convert.IsDBNull(row["RDPComments"]) ? "" : Convert.ToString(row["RDPComments"]);
                server.DontUseDefaultCreds = Convert.IsDBNull(row["DontUseDefaultCreds"]) ? false : Convert.ToBoolean(row["DontUseDefaultCreds"]);
                server.SystemLogin = Convert.IsDBNull(row["SystemLogin"]) ? "" : Convert.ToString(row["SystemLogin"]);
                server.SystemPassword = Convert.IsDBNull(row["SystemPassword"]) ? "" : Convert.ToString(row["SystemPassword"]);
                server.isHostMonitored = Convert.IsDBNull(row["isHostMonitored"]) ? 0 : Convert.ToInt32(row["isHostMonitored"]);
                lista.Add(server);
            }
            return lista;

        }
        [HttpPost]
        [Authorize]
        public ActionResult GetServerByServerName(string Servername)
        {
            var Retorno = Json(listServers(Servername));

            return Retorno;
        }
        [HttpPost]
        [Authorize]
        public ActionResult DeleteServerByName(string Servername)
        {
             
            var serverDB = new DAL.Server();
            var Retorno = serverDB.DeleteOne(Servername);

            return Json(Retorno);
        }
        [Authorize]
        public ActionResult ListGrid()
        {

            return View(listServers());
        }
        [Authorize]
        public ActionResult ViewDashBoard()
        {
            return View();
        }
        [Authorize]
        public ActionResult ListDatabase()
        {
            return View();
        }
        [Authorize]
        public ActionResult ListDatabasesJob()
        {
            return View();
        }
        [Authorize]
        public ActionResult ListDatabaseBackup()
        {
            return View();
        }
        [Authorize]
        public ActionResult ListDatabaseAG()
        {
            return View();
        }
    }
}