using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceManagement.Models
{
    public class UserSubstribedServicesViewModel
    {
        public int service_id { get; set; }
        public string service_title { get; set; }
        public string service_icon { get; set; }
        public bool active { get; set; }
    }

}