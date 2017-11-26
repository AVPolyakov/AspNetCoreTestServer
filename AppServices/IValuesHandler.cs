using System.Threading.Tasks;

namespace AppServices
{
    public interface IValuesHandler
    {
        Task<string> Get(string x);
        Task<string> M2(string x);
    }

    public class ValuesHandler : IValuesHandler
    {
        private readonly IXxxProvider xxxProvider;

        public ValuesHandler(IXxxProvider xxxProvider)
        {
            this.xxxProvider = xxxProvider;
        }

        public Task<string> Get(string x)
        {
            return Task.FromResult($"M1_{xxxProvider.Value}_{x}");
        }

        public Task<string> M2(string x)
        {
            return Task.FromResult($"M2_{xxxProvider.Value}_{x}");
        }
    }
}