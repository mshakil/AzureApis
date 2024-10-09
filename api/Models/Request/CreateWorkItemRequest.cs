using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models.Request
{
    public class CreateWorkItemRequest
    {
        public WorkItemFields[] wiFields { get; set; }
    }
}
