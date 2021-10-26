using System;
using System.IO;
using CommandLine;
using StringFinder.Resourses;
using LineCalculatorLibrary;

namespace StringFinder
{
    class StringFinder
    {
        public class Options
        {
            [Option('o', "open", Required = false, HelpText = "Set path to source file")]
            public string PathToFile { get; set; }
        }

        static void Main(string[] args)
        {
            try
            {
                string pathToFile = "";
                Console.WriteLine(Messages.WelcomeMessage);
                Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o =>
                {
                    if (string.IsNullOrEmpty(o.PathToFile) == false && File.Exists(o.PathToFile))
                    {
                        pathToFile = o.PathToFile;
                    }
                    else
                    {
                        pathToFile = new InteractionsWithUser().GetPathToFileFromUser();
                    }
                });
                new Renderer().RenderBestAndBadLines(new LineCalculator(new Converter(), new DataReceiver(pathToFile), new BestAndBadLinesFinder()).CalculateLines());
            }
            catch (Exception ex)
            {
                string message = ex is FileNotFoundException || ex is ArgumentNullException ? ex.Message : Messages.UnexpectedError;
                Console.Write(message);
            }
        }
    }
}
