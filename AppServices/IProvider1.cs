using System;
using System.Globalization;

namespace AppServices
{
    public interface IProvider1
    {
        string Value { get; }
    }

    public class Provider1 : IProvider1
    {
        public string Value => DateTime.Now.ToString(CultureInfo.InvariantCulture);
    }
}