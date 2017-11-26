using System;
using Microsoft.AspNetCore.TestHost;

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