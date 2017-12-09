using System;

namespace XUnitTestProject1
{
    public static class Lazy
    {
        public static Lazy<T> Create<T>(Func<T> valueFactory) => new Lazy<T>(valueFactory);
    }
}