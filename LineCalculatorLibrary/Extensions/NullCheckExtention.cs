using System;

namespace LineCalculatorLibrary.Extensions
{
    public static class NullCheckExtention
    {
        public static T CheckNull<T>(this T argument, string name)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(name);
            }
            return argument;
        }
    }
}
