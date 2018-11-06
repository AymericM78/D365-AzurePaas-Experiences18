using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureD365DemoWebJob.Models
{
    public class MessageEntityData
    {
        public MessageEntityData()
        {
            Properties = new Dictionary<string, string>();
        }
        
        public string MessageId { get; set; }

        public Guid RecordId { get; set; }
        public Guid RequestId { get; set; }

        public Dictionary<string, string> Properties { get; set; }
    }
}
