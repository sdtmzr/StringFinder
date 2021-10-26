using System.IO;

namespace LineCalculatorLibrary
{
    public class DataReceiver : IDataReceiver
    {
        public string PathToDataFile { get; set; }

        public DataReceiver(string path)
        {
            PathToDataFile = path;
        }

        public string[] Receive()
        {
            if (File.Exists(PathToDataFile) == false)
            {
                throw new FileNotFoundException();
            }
            string[] inputData = File.ReadAllLines(PathToDataFile);
            return inputData;
        }
    }
}
