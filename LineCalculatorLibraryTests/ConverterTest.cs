using System;
using Xunit;
using LineCalculatorLibrary;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LineCalculatorLibraryTests
{
    public class ConverterTest
    {
        IDataReceiver nullDataRecieverMock = new NullDataReceiverMock();
        IDataReceiver mixedDataReceiverMock = new MixedDataReceiverMock();
        IDataReceiver correctDataReceiverMock = new CorrectDataReceiverMock();
        IDataReceiver badDataReceiverMock = new BadDataReceiverMock();
        IConverter converter = new Converter();

        [Fact]
        public void NullDataReceiver()
        {
            ArgumentNullException exception = new ArgumentNullException("dataReceiver");

            var ex = Assert.Throws<ArgumentNullException>(() => converter.Convert(nullDataRecieverMock));

            Assert.Equal(ex.Message, exception.Message);
        }

        [Fact]
        public void ConvertMixedData()
        {
            float[][] expected = new float[][]
            { null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            new float[] { 43 },
            new float[] { 50, 50, 50 },
            new float[] { (float)55.5 },
            new float[] { (float)0.55 },
            null,
            new float[] { 50, 25, 25, 50 },
            null,
            null,
            null,
            new float[] { 1, 2, (float)0.3 },
            null,
            new float[] { 1,22,55,(float)23.4 } };

            var result = converter.Convert(mixedDataReceiverMock);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void ConvertCorrectData()
        {
            float[][] expected = new float[][]
            { new float[] { 1,2,3 },
            new float[] { -1,-5,10 },
            new float[] { (float)5.5,25,(float)11.5 },
            new float[] { (float)-12.5,5,10 } };

            var result = converter.Convert(correctDataReceiverMock);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void ConvertBadData()
        {
            float[][] expected = new float[5][];

            var result = converter.Convert(badDataReceiverMock);

            Assert.Equal(result, expected);
        }
    }
}
