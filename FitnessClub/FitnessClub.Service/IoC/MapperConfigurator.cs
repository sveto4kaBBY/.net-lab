
using System.Reflection;
using FitnessClub.FitnessClub.BL.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessClub.FitnessClub.Service.IoC
{
    public class MapperConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<UsersBLProfile>();
            }, Assembly.GetExecutingAssembly());
        }
    }
}