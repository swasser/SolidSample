using System;

namespace ArdalisRating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ardalis Insurance Rating System Starting...");

            var logger = new ConsoleLogger();
            var policySource = new FilePolicySource();
            var policySerializer = new JsonPolicySerializer();
            var raterFactory = new RaterFactory();
            var engine = new RatingEngine(logger, policySource, policySerializer, raterFactory);
            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }

        }
    }
}
