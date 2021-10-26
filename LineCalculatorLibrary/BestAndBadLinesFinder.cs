using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LineCalculatorLibrary.Extensions;

namespace LineCalculatorLibrary
{
    public class BestAndBadLinesFinder
    {
        private float _bestLinesValue;
        public float BestLinesValue
        {
            get => _bestLinesValue;
        }
        public ReadOnlyCollection<int> BestLines { get; set; }
        public ReadOnlyCollection<int> BadLines { get; set; }

        public void CalculateBestAndBadLines(float[][] lines)
        {
            lines.CheckNull(nameof(lines));
            if (lines.Length == 0)
            {
                throw new ArgumentNullException();
            }
            Dictionary<int, float> allGoodLines = new Dictionary<int, float>();
            Collection<int> allBadLines = new Collection<int>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != null)
                {
                    allGoodLines.Add(i + 1, GetSumOfNumbers(lines[i]));
                    continue;
                }
                allBadLines.Add(i + 1);
            }
            BestLines = new ReadOnlyCollection<int>(GetBestLines(allGoodLines));
            BadLines = new ReadOnlyCollection<int>(allBadLines);
        }

        private float GetSumOfNumbers(float[] numbers)
        {
            float result = 0;
            foreach (var number in numbers)
            {
                result += number;
            }
            return result;
        }

        private Collection<int> GetBestLines(Dictionary<int, float> allGoodLines)
        {
            Collection<int> allBestLines = new Collection<int>();
            if (allGoodLines.Count != 0)
            {
                _bestLinesValue = allGoodLines.Max(v => v.Value);
                foreach (var item in allGoodLines)
                {
                    if (item.Value == _bestLinesValue)
                    {
                        allBestLines.Add(item.Key);
                    }
                }
            }
            return allBestLines;
        }
    }
}