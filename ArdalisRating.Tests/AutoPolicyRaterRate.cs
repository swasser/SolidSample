using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ArdalisRating.Tests
{
    public class FakeLogger : ILogger
    {
        public List<string> LoggedMessages { get; } = new List<string>();

        public void Log(string message)
        {
            LoggedMessages.Add(message);
        }
    }

    public class FakeRatingUpdater : IRatingUpdater
    {
        public decimal? Rating { get; private set; }

        public void UpdateRating(decimal rating)
        {
            Rating = rating;
        }
    }
   
    public class AutoPolicyRaterRate
    {
        [Fact]
        public void Log_Missing_Make_Message()
        {
            var logger = new FakeLogger();

            var policy = new Policy { Type = "Auto" };

            var rater = new AutoPolicyRater(null);

            rater.Logger = logger;

            rater.Rate(policy);

            Assert.Equal("Auto policy must specify Make", logger.LoggedMessages.Last());
        }

        [Fact]
        public void Update_Auto_Rater_Rating()
        {
            var policy = new Policy { Type = "Auto", Make = "BMW", Deductible = 200 };

            var ratingUpdater = new FakeRatingUpdater();

            var rater = new AutoPolicyRater(ratingUpdater);

            rater.Rate(policy);

            Assert.Equal(1000m, ratingUpdater.Rating.Value);

        }

    }
}
