using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum.Shared.Models
{
    public class EmailMission
    {
        public string UUID { get; set; }
        public string ID { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
