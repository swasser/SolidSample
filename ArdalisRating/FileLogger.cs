using System.IO;

namespace ArdalisRating
{
    internal class FileLogger : ILogger
    {
        public void Log(string message)
        {
            using(var stream = File.AppendText("log.txt"))
            {
                stream.WriteLine(message);
                stream.Flush();
            }
        }
    }
}
