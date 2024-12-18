using OnlineStore.Logic.Queries.Search;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStore.Storage.MS_SQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Logic.Repositories.Interfaces
{
    public interface IRouteEntityRepository
    {
        public Task<List<RouteVM>> SearchFuncAsyc(IContext context, string searchText, CancellationToken cancellationToken);

    }
}
