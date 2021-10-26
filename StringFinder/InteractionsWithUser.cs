using System;
using StringFinder.Resourses;

namespace StringFinder
{
    public class InteractionsWithUser
    {
        public string GetPathToFileFromUser()
        {
            Console.Write(Messages.GetPathMessage);
            string result = Console.ReadLine();
            return result;
        }
    }
}
