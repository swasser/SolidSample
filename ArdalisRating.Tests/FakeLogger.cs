using System.Collections.Generic;

namespace ArdalisRating.Tests
{
    public class FakeLogger : ILogger
    {
        public List<string> loggedMessages = new List<string>();
        public void Log(string message)
        {
            loggedMessages.Add(message);
        }
    }
}
