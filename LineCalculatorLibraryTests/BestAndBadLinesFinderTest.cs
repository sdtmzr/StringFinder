using System;
using Xunit;
using LineCalculatorLibrary;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LineCalculatorLibraryTests
{
    public class BestAndBadLinesFinderTest
    {
        BestAndBadLinesFinder finder = new BestAndBadLinesFinder();

        [Fact]
        public void EmptyInputArray()
        {
            float[][] emptyInputData = new float[0][];
            ArgumentNullException exception = new ArgumentNullException();

            var ex = Assert.Throws<ArgumentNullException>(() => finder.CalculateBestAndBadLines(emptyInputData));

            Assert.Equal(exception.Message, ex.Message);
        }

        [Fact]
        public void NullInputArray()
        {
            float[][] emptyInputData = null;
            ArgumentNullException exception = new ArgumentNullException("lines");

            var ex = Assert.Throws<ArgumentNullException>(() => finder.CalculateBestAndBadLines(emptyInputData));

            Assert.Equal(exception.Message, ex.Message);
        }

        [Fact]
        public void GetBestLinesInMixedData()
        {
            float[][] inputData = new float[][]
            { null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            new float[] { 43 },
            new float[] { 50,50,50 },
            new float[] { (float)55.5 },
            new float[] { (float)0.55 },
            null,
            new float[] { 50,25,25,50 },
            null,
            null,
            new float[] { 1,2,(float)0.3 },
            null,
            null,
            new float[] { 1,22,55,(float)23.4 } };
            Collection<int> allBestLines = new Collection<int>() { { 10 }, { 14 } };
            ReadOnlyCollection<int> expectedResult = new ReadOnlyCollection<int>(allBestLines);

            finder.CalculateBestAndBadLines(inputData);

            Assert.Equal(expectedResult, finder.BestLines);
        }

        [Fact]
        public void GetBestLinesValue()
        {
            float[][] inputData = new float[][]
            { null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            new float[] { 43 },
            new float[] { 50,50,50 },
            new float[] { (float)55.5 },
            new float[] { (float)0.55 },
            null,
            new float[] { 50,25,25,50 },
            null,
            null,
            new float[] { 1,2,(float)0.3 },
            null,
            null,
            new float[] { 1,22,55,(float)23.4 } };
            float expectedResult = 150;

            finder.CalculateBestAndBadLines(inputData);

            Assert.Equal(expectedResult, finder.BestLinesValue);
        }

        [Fact]
        public void GetBadLinesInMixedData()
        {
            float[][] inputData = new float[][]
            { null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            new float[] { 43 },
            new float[] { 50,50,50 },
            new float[] { (float)55.5 },
            new float[] { (float)0.55 },
            null,
            new float[] { 50,25,25,50 },
            null,
            null,
            new float[] { 1,2,(float)0.3 },
            null,
            null,
            new float[] { 1,22,55,(float)23.4 } };
            Collection<int> allBadLines = new Collection<int>() { { 1}, { 2}, { 3}, { 4}, { 5}, { 6}, { 7}, { 8}, { 13}, { 15}, { 16 }, { 18 }, { 19 } };
            ReadOnlyCollection<int> expectedResult = new ReadOnlyCollection<int>(allBadLines);

            finder.CalculateBestAndBadLines(inputData);

            Assert.Equal(expectedResult, finder.BadLines);
        }

        [Fact]
        public void GetBestLinesInBadData()
        {
            float[][] inputData = new float[5][];
            Collection<int> allBestLines = new Collection<int>();
            ReadOnlyCollection<int> expectedResult = new ReadOnlyCollection<int>(allBestLines);

            finder.CalculateBestAndBadLines(inputData);

            Assert.Equal(expectedResult, finder.BestLines);
        }

        [Fact]
        public void GetBadLinesInBadData()
        {
            float[][] inputData = new float[5][];
            Collection<int> allBadLines = new Collection<int>() { { 1 }, { 2 }, { 3 }, { 4 }, { 5 } };
            ReadOnlyCollection<int> expectedResult = new ReadOnlyCollection<int>(allBadLines);

            finder.CalculateBestAndBadLines(inputData);

            Assert.Equal(expectedResult, finder.BadLines);
        }

        [Fact]
        public void GetBestLinesInCorrectData()
        {
            float[][] inputData = new float[][]
            { new float[] { 1,2,3 },
            new float[] { -1,-5,10 },
            new float[] { (float)5.5,25,(float)11.5 },
            new float[] { (float)-12.5,5,10 } };
            Collection<int> allBestLines = new Collection<int>() { { 3 } };
            ReadOnlyCollection<int> expectedResult = new ReadOnlyCollection<int>(allBestLines);

            finder.CalculateBestAndBadLines(inputData);

            Assert.Equal(expectedResult, finder.BestLines);
        }

        [Fact]
        public void GetBadLinesInCorrectData()
        {
            float[][] inputData = new float[][]
               { new float[] { 1,2,3 },
            new float[] { -1,-5,10 },
            new float[] { (float)5.5,25,(float)11.5 },
            new float[] { (float)-12.5,5,10 } };
            Collection<int> allBadLines = new Collection<int>();
            ReadOnlyCollection<int> expectedResult = new ReadOnlyCollection<int>(allBadLines);

            finder.CalculateBestAndBadLines(inputData);

            Assert.Equal(expectedResult, finder.BadLines);
        }
    }
}
