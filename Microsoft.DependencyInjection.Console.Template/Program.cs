using System.Threading.Tasks;
using Microsoft.DependencyInjection.Console.Template.Providers;
using Microsoft.DependencyInjection.Console.Template.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Microsoft.DependencyInjection.Console.Template
{
    public class Program
    {
        public static ServiceProvider Services { get; private set; }
        public static IConfiguration Configuration { get; private set; }

        public static async Task Main(string[] args)
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection = ConfigureServices(serviceCollection);
            Services = serviceCollection.BuildServiceProvider();

            await RunAsync();
        }

        private static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure =>
            {
                configure.AddConfiguration(Configuration).AddConsole(c =>
                {
                    c.TimestampFormat = "[yyyy-MM-ddTHH:mm:ss.fff] ";
                });
            });

            // Add your services here
            services.AddSingleton<IFooProvider, FooProvider>();
            services.AddSingleton<IFooService, FooService>();

            return services;
        }

        public static async Task RunAsync()
        {
            ILogger<Program> logger = Services.GetService<ILogger<Program>>();

            logger.LogInformation("App is running ...");

            IFooService fooService = Services.GetService<IFooService>();

            var foo = await fooService.GetFooAsync();

            System.Console.WriteLine($"FooService returned: {foo}");
        }
    }
}
