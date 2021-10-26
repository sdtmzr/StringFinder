using System;
using LineCalculatorLibrary;
using StringFinder.Resourses;
using System.Collections.ObjectModel;

namespace StringFinder
{
    public class Renderer
    {
        public string BestLineKeyAndValueSeparator { get; set; } = " - ";
        public string LinesNumberSeparator { get; set; } = ",";

        public void RenderBestAndBadLines(BestAndBadLinesFinder lines)
        {
            RenderLine(lines.BestLines, Messages.NoGoodLines, Messages.BestLine, lines.BestLinesValue);
            RenderLine(lines.BadLines, Messages.NoBadLines, Messages.BadLines);
        }

        private void RenderLine(ReadOnlyCollection<int> lines, string messageIfEmpty, string messageLineType, float value)
        {
            if (lines.Count == 0)
            {
                Console.WriteLine(messageIfEmpty);
                return;
            }
            Console.WriteLine(string.Join(LinesNumberSeparator, lines) + BestLineKeyAndValueSeparator + value + BestLineKeyAndValueSeparator+ messageLineType);
        }

        private void RenderLine(ReadOnlyCollection<int> lines, string messageIfEmpty, string messageLineType)
        {
            if (lines.Count == 0)
            {
                Console.WriteLine(messageIfEmpty);
                return;
            }
            Console.WriteLine(string.Join(LinesNumberSeparator, lines) + BestLineKeyAndValueSeparator + messageLineType);
        }
    }
}