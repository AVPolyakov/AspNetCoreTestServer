using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace TypedHttpClient
{
    public static class TestServerExtensions
    {
        public static T CreateClient<T>(this TestServer testServer, Type controllerType)
        {
            return Implementation.Create<T>(new HandlerProxy(controllerType, 
                testServer.CreateClient()));
        }
    }
}