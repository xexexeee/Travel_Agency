using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Storage.MS_SQL.Entities
{
    public class RouteEntity
    {
        public Guid RouteEntityId {get; set;}
        public string searchText {  get; set; }
        public string controllerName { get; set; }
        public string route { get; set; }
    }
}
