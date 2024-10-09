using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models.Request
{
    public class WorkItemFields
    {
        public string op { get; set; }
        public string path { get; set; }
        public object from { get; set; }
        public string value { get; set; }
    }
}
