using System;

namespace OLO.API.Models
{
    public class ServiceStatus
    {
        public string ServiceName { get; set; }
        public string Version { get; set; }
        public bool Healthy { get; set; }
        public string Message { get; set; }
        public DateTime StateAsOf { get; set; }
        public DateTime TimeOfStatusCheck { get; set; }
        public string Node { get; set; }
    }
}
