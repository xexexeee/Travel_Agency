using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Storage.MS_SQL.Entities
{
    public class Cart
    {
        public Guid CartId { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
