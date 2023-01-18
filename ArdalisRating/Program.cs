﻿using System;

namespace ArdalisRating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ardalis Insurance Rating System Starting...");

            var logger = new ConsoleLogger();
            var reader = new PolicyReader();
            var serializer = new PolicyDeserializer();

            var engine = new RatingEngine(reader, logger, serializer);

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
