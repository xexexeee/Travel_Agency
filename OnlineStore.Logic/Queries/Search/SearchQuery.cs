using FluentValidation;
using MediatR;
using OnlineStore.Logic.Repositories;
using OnlineStore.Logic.Repositories.Interfaces;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStore.Storage.MS_SQL.Entities;


namespace OnlineStore.Logic.Queries.Search
{
    public class SearchQuery : IRequest<List<RouteVM>>
    {
        public string searchText { get; set; }
    }
    public class SearchQueryValidator : AbstractValidator<SearchQuery>
    {
        public SearchQueryValidator()
        {
            RuleFor(s => s.searchText).NotEmpty();
        }
    }
    public class SearchQueryHandler : IRequestHandler<SearchQuery, List<RouteVM>>
    {
        private readonly IContext context;

        private readonly IRouteEntityRepository routeEntityRepository;

        public SearchQueryHandler(IRouteEntityRepository routeEntityRepository, IContext context)
        {
            this.routeEntityRepository = routeEntityRepository;
            this.context = context;
        }

        public async Task<List<RouteVM>> Handle(SearchQuery query, CancellationToken cancellationToken)
        {
            var result = await routeEntityRepository.SearchFuncAsyc(context, query.searchText, cancellationToken);
            return result;
        }
    }
}
