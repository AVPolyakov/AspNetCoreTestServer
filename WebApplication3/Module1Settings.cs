using AppServices;

namespace WebApplication3
{
    public class Module1Settings
    {
        public Registration<IProvider1> Provider1 = Registration.Create<IProvider1, Provider1>();        
    }
}