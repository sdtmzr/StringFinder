using System;
using Xunit;
using LineCalculatorLibrary;

namespace LineCalculatorLibraryTests
{
    public class NullDataReceiverMock : IDataReceiver
    {
        public string[] Receive()
        {
            return null;
        }
    }

    public class BadDataReceiverMock : IDataReceiver
    {
        public string[] Receive()
        {
            string[] inputData = new string[5] { " .,5", " c", "g.df", "5 5", "a s" };
            return inputData;
        }
    }

    public class CorrectDataReceiverMock : IDataReceiver
    {
        public string[] Receive()
        {
            string[] inputData = new string[4] { "1,2,3", "-1,-5,10", "5.5,25,11.5", "-12.5,5,10"  };
            return inputData;
        }
    }

    public class MixedDataReceiverMock : IDataReceiver
    {
        public string[] Receive()
        {
            string[] inputData = new string[20] { "", " ", ".", ",", " .", " .,5", " c", "g.df", "43", "50,50,50", "55.5", ".55", "5 5", "50,25,25,50", "a s", "a.s", "a,6", "1,2,.3", "1.2.3.4.5", "1,22,55,23.4" };
            return inputData;
        }
    }
}
