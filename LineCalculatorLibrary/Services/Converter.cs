using System;
using System.Globalization;
using LineCalculatorLibrary.Extensions;

namespace LineCalculatorLibrary
{
    public class Converter : IConverter
    {
        public string Separator { get; set; } = ",";
        public string FractionalSeparator { get; set; } = ".";

        public float[][] Convert(IDataReceiver dataReceiver)
        {
            var inputData = dataReceiver.Receive().CheckNull(nameof(dataReceiver));
            float[][] result = new float[inputData.Length][];
            for (int i = 0; i < inputData.Length; i++)
            {
                string[] elements = inputData[i].Split(Separator);
                float[] numbers = GetNumbers(elements);
                result[i] = numbers;
                continue;
            }
            return result;
        }

        private float[] GetNumbers(string[] elements)
        {
            IFormatProvider provider = new NumberFormatInfo() { NumberDecimalSeparator = FractionalSeparator };
            float[] numbers = new float[elements.Length];
            for (int i = 0; i < elements.Length; i++)
            {
                if (!float.TryParse(elements[i], NumberStyles.Float, provider, out float number))
                {
                    numbers = null;
                    break;
                }
                numbers[i] = number;
            }
            return numbers;
        }
    }
}
