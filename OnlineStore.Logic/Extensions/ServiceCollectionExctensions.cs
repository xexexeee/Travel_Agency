using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Logic.Auth.Hasher;
using OnlineStore.Logic.Behaviors;
using OnlineStore.Logic.JWT;
using OnlineStore.Logic.Repositories;
using OnlineStore.Logic.Repositories.Interfaces;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories;
using OnlineStrore.Logic.Repositories.Interfaces;
using System.Reflection;

namespace OnlineStore.Logic.Extensions
{
    public static class ServiceCollectionExctensions
    {
        public static void AddLogicServices(this IServiceCollection service)
        {
            service.AddScoped<IContext, Context>();

            service.AddSingleton<IClientRepository, ClientRepository>();
            service.AddSingleton<IProductRepository, ProductRepository>();
            service.AddSingleton<IProductTypeRepository, ProductTypeRepository>();
            service.AddSingleton<ISaleRepository, SaleRepository>();
            service.AddSingleton<IFeedbackRepository, FeedbackRepository>();
            service.AddSingleton<ICartRepository, CartRepository>();
            service.AddSingleton<IRouteEntityRepository, RouteEntityRepository>();

            service.AddSingleton<IPasswordHasher, PasswordHasher>();
            service.AddSingleton<IJwtPorvider, JwtPorvider>();
            // Регистрируем AutoMapper для текущей сборки
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Регистрируем MediatR для текущей сборки
            service.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            // Регистрируем все валидаторы из текущей сборки
            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Добавляем поведение валидации в конвейер Mediator
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
