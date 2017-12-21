using System;
using Autofac;

namespace WebApplication3
{
    public class StartupSettings
    {
        public Module1Settings Module1 = new Module1Settings();
        public Func<IContainer, IComponentContext> ComponentContextFunc = _ => _;
    }
}