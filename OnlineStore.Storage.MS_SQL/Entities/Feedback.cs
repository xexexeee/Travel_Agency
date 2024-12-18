using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Storage.MS_SQL.Entities
{
    public class Feedback
    {
        public Guid FeedbackId { get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
    }
}
