using OnlineStore.Logic.Extensions;

namespace OnlineStrore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWebServices(this IServiceCollection service)
        {
            service.AddLogicServices();
        }

        public static void ConfigureCors(this IServiceCollection service) =>
            service.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://127.0.0.1:5500");
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
                {

                });
    }
}
