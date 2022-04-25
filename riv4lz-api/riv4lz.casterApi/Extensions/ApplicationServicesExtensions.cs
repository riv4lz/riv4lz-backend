namespace riv4lz.casterApi.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSignalR();

            return services;
        }
    }
}


    
