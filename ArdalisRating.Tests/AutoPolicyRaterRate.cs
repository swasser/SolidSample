using System.Linq;
using Xunit;

namespace ArdalisRating.Tests
{
    public class AutoPolicyRaterRate
    {
        [Fact]
        public void Log_Missing_Make_Message()
        {
            var logger = new FakeLogger();

            var policy = new Policy { Type = "Auto" };

            var rater = new AutoPolicyRater(logger);

            rater.Rate(policy);

            Assert.Equal("Auto policy must specify Make", logger.LoggedMessages.Last());
        }

        [Fact]
        public void Update_Auto_Rater_Rating()
        {
            var policy = new Policy { Type = "Auto", Make = "BMW", Deductible = 200 };

            var logger = new FakeLogger();

            var rater = new AutoPolicyRater(logger);

            var rate = rater.Rate(policy);

            Assert.Equal(1000m, rate);

        }

    }
}
