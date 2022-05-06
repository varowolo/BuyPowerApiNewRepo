using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyPowerApiNew.Models
{
    public class tblRequestAndResponseLog
    {
        public long Id { get; set; }
        public string RequestType { get; set; }
        public string RequestPayload { get; set; }
        public string RequestId { get; set; }
        public string Response { get; set; }
        public DateTime RequestTimestamp { get; set; }
        public DateTime ResponseTimestamp { get; set; }
        public string RequestUrl { get; set; }
        public string Client { get; set; }
    }
}
