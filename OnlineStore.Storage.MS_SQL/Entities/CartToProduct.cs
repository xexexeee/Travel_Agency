using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Storage.MS_SQL.Entities
{
    public class CartToProduct
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
