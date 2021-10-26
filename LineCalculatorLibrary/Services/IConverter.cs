using System.Collections.Generic;

namespace LineCalculatorLibrary
{
    public interface IConverter
    {
        public float[][] Convert(IDataReceiver dataReceiver);
    }
}
