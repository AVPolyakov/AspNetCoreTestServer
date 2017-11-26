using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TypedHttpClient
{
    public class HandlerProxy : IImplementation
    {
        private readonly Type controllerType;
        private readonly HttpClient httpClient;

        public HandlerProxy(Type controllerType, HttpClient httpClient)
        {
            this.controllerType = controllerType;
            this.httpClient = httpClient;
        }

        public T Call<T>(string methodName, Args args)
        {
            return (T) typeof(HandlerProxy).GetMethod(nameof(CallAsync))
                .MakeGenericMethod(typeof(T).GetGenericArguments().Single())
                .Invoke(this, new object[] {methodName, args});
        }

        public async Task<T> CallAsync<T>(string methodName, Args args)
        {
            var method = controllerType.GetMethod(methodName);
            var attribute = (HttpGetAttribute) method.GetCustomAttribute(typeof(HttpGetAttribute));
            var controller = controllerType.Name.Substring(0, controllerType.Name.Length - "Controller".Length);
            var parameters = string.Join("&", method.GetParameters().Select((_, i) => $"{_.Name}={args.Value[i]}"));
            var response = await httpClient.GetAsync(
                $"/api/{controller}/{attribute.Template}?{parameters}");
            response.EnsureSuccessStatusCode();
            return (T) (object) await response.Content.ReadAsStringAsync();
        }

        public void CallVoid(string methodName, Args args)
        {
            throw new NotImplementedException();
        }
    }
}