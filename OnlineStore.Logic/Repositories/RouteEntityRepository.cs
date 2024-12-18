using Microsoft.EntityFrameworkCore;
using OnlineStore.Logic.Queries.Search;
using OnlineStore.Logic.Repositories.Interfaces;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStore.Storage.MS_SQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OnlineStore.Logic.Repositories
{
    public class RouteEntityRepository : IRouteEntityRepository
    {
        public async Task<List<RouteVM>> SearchFuncAsyc(IContext context, string SearchText, CancellationToken cancellationToken)
        {
            //var resultOfSearch = await context.RouteEntities.Where(r => r.searchText).ToListAsync(cancellationToken);
            var filterRouters = await context.RouteEntities
       .Where(x => x.searchText != null &&
                   (x.searchText.StartsWith(SearchText) ||
                    x.searchText.Contains(SearchText)))
       .ToListAsync(cancellationToken);

            // Преобразование RouteEntity в RouteVM
            var result = filterRouters.Where(f => f.controllerName != "Home").Select(x => new RouteVM
            {
                searchText = x.searchText,
                linkText = $"/{x.controllerName}/{x.route}"
            }).ToList();

            result.AddRange(filterRouters.Where(f => f.controllerName == "Home" && f.route !="Index").
                Select(x => new RouteVM { searchText = x.searchText, linkText = $"/{x.route}" }).ToList());

            result.AddRange(filterRouters.Where(f => f.controllerName == "Home" && f.route == "Index").
                Select(x => new RouteVM { searchText = x.searchText, linkText = "/" }).ToList());

            return result;
        }
    }
}
