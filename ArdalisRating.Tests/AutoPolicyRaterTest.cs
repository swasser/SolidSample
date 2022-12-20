using System.Linq;
using Xunit;

namespace ArdalisRating.Tests
{
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
            var logger = new FakeLogger();
            var policy = new Policy
            {
                Type = PolicyType.Auto.ToString(),
                Make = "BMW",
                Model = "300i",
                Year = 2000,
                Miles = 1000,
                Deductible = 100
            };

            var sut = new AutoPolicyRater(logger);

            var result = sut.Rate(policy);

            Assert.Equal(1000m, result);
        }
    }
}
