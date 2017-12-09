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
        private readonly IProvider1 provider1;

        public ValuesHandler(IProvider1 provider1)
        {
            this.provider1 = provider1;
        }

        public Task<string> Get(string x)
        {
            return Task.FromResult($"M1_{provider1.Value}_{x}");
        }

        public Task<string> M2(string x)
        {
            return Task.FromResult($"M2_{provider1.Value}_{x}");
        }
    }
}