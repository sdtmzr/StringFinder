using System;
using System.Collections.ObjectModel;

namespace LineCalculatorLibrary
{
    public class LineCalculator
    {
        public IConverter Converter { get; set; }
        public IDataReceiver DataReceiver { get; set; }
        public BestAndBadLinesFinder BestAndBadLinesFinder { get; set; }

        public LineCalculator (IConverter converter, IDataReceiver receiver, BestAndBadLinesFinder bestAndBadLinesFinder)
        {
            Converter = converter;
            DataReceiver = receiver;
            BestAndBadLinesFinder = bestAndBadLinesFinder;
        }

        public BestAndBadLinesFinder CalculateLines()
        {
            BestAndBadLinesFinder.CalculateBestAndBadLines(Converter.Convert(DataReceiver));
            return BestAndBadLinesFinder;
        }
    }
}
