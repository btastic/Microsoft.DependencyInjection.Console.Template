using System.Threading.Tasks;

namespace Microsoft.DependencyInjection.Console.Template.Services
{
    public interface IFooService
    {
        Task<string> GetFooAsync();
    }
}
