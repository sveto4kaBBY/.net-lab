
using System.Reflection;
using FitnessClub.FitnessClub.BL.Mapper;

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