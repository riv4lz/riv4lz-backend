using riv4lz.core.IServices;
using riv4lz.dataAccess.Repositories;
using riv4lz.domain.IRepositories;
using riv4lz.domain.Services;


namespace riv4lz.casterApi.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICasterService, CasterService>();
            services.AddScoped<ICasterRepository, CasterRepository>();
            services.AddSignalR();
            
            return services;
        }
    }
}


    
