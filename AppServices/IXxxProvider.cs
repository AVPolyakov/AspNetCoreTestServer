using System;
using System.Globalization;

namespace AppServices
{
    public interface IXxxProvider
    {
        string Value { get; }
    }

    public class XxxProvider : IXxxProvider
    {
        public string Value => DateTime.Now.ToString(CultureInfo.InvariantCulture);
    }
}