using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxDBInventory.Models
{
    public class ServerModel
    {
        public string ServerName { get; set; }
        public string IPAddress { get; set; }
        public string Domain { get; set; }
        public Boolean Active { get; set; }
        public Int32 CPUCores { get; set; }
        public Int32 RAM_GB { get; set; }
        public string OperatingSystem { get; set; }
        public string ServicePack { get; set; }
        public string LastReboot { get; set; }
        public string FQDN { get; set; }
        public string ComputerName { get; set; }
        public Boolean WMIAvailable { get; set; }
        public DateTime WMILastAttempt { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string Environment { get; set; }
        public string Application { get; set; }
        public string BusinessOwners { get; set; }
        public string BusinessImpact { get; set; }
        public Boolean RDPSuccessful { get; set; }
        public string RDPComments { get; set; }
        public Boolean DontUseDefaultCreds { get; set; }
        public string SystemLogin { get; set; }
        public string SystemPassword { get; set; }
        public Int32 isHostMonitored { get; set; }
    }
}