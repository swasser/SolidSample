using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

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

    public class FakeRatingUpdater : IRatingUpdater
    {
        public decimal? NewRating { get; private set; } 
        
        public void UpdateRating(decimal rating)
        {
            NewRating = rating;
        }
    }

    public class AutoPolicyRaterTest
    {
        [Fact]
        public void LogsProperMessageWhenMakeIsMissing()
        {
            var logger = new FakeLogger();
            var policy = new Policy
            {
                Type = PolicyType.Auto.ToString(),
                Model = "300i",
                Year = 2000,
                Miles = 1000,
                Deductible = 100
            };

            var sut = new AutoPolicyRater(null);
            sut.Logger = logger;

            sut.Rate(policy);

            Assert.Equal("Auto policy must specify Make", logger.loggedMessages.Last());
        }

        [Fact]
        public void RatingIs1000WhenDeductableLessThan500()
        {
            var ratingUpdater = new FakeRatingUpdater();
            var policy = new Policy
            {
                Type = PolicyType.Auto.ToString(),
                Make = "BMW",
                Model = "300i",
                Year = 2000,
                Miles = 1000,
                Deductible = 100
            };

            var sut = new AutoPolicyRater(ratingUpdater);

            sut.Rate(policy);

            Assert.Equal(1000m, ratingUpdater.NewRating);
        }
    }
}
