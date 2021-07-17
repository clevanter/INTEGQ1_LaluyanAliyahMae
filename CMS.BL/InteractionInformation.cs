using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL
{
    public class InteractionInformation
    {
        public int InteractionNumber { get; set; }
        public string ContactName { get; set; }
        public string Type { get; set; }
        public long UsedNumber { get; set; }
        public string UsedEmail { get; set; }
        public DateTime DateAndDuration { get; set; }
    }
}
