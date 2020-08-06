using System.Threading.Tasks;

namespace Microsoft.DependencyInjection.Console.Template.Providers
{
    public interface IFooProvider
    {
        Task<string> CalculateFooAsync();
    }
}
