using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Microsoft.DependencyInjection.Console.Template.Providers
{
    public class FooProvider : IFooProvider
    {
        private readonly ILogger<FooProvider> _logger;

        public FooProvider(ILogger<FooProvider> logger)
        {
            _logger = logger;
        }

        public async Task<string> CalculateFooAsync()
        {
            _logger.LogInformation("Calculating Foo ...");
            await Task.Delay(1000);

            return "Foo";
        }
    }
}
