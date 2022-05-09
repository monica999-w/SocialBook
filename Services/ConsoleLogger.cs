using SocialBook.Services.Interfaces;

namespace SocialBook.Service
{
    public class ConsoleLogger : ILog
    {
        public void Info(string textToLog)
        {
            Console.WriteLine(textToLog);
        }
    }
}