using System.Threading.Tasks;
using Microsoft.DependencyInjection.Console.Template.Providers;
using Microsoft.Extensions.Logging;

namespace Microsoft.DependencyInjection.Console.Template.Services
{
    public class FooService : IFooService
    {
        private readonly ILogger<FooService> _logger;
        private readonly IFooProvider _fooProvider;

        public FooService(
            ILogger<FooService> logger,
            IFooProvider fooProvider)
        {
            _logger = logger;
            _fooProvider = fooProvider;
        }

        public Task<string> GetFooAsync()
        {
            _logger.LogInformation("Getting Foo ...");
            return _fooProvider.CalculateFooAsync();
        }
    }
}
