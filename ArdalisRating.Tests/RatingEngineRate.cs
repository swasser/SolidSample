using Newtonsoft.Json;
using Xunit;

namespace ArdalisRating.Tests
{
    public class RatingEngineRate
    {
        private FakeLogger _logger = new FakeLogger();
        private FakePolicySource _policySource = new FakePolicySource();
        private FakePolicySerializer _policySerializer = new FakePolicySerializer();
        
        [Fact]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            var policy = new Policy
            {
                Type = "Land",
                BondAmount = 200000,
                Valuation = 200000
            };
            string json = JsonConvert.SerializeObject(policy);
            _policySource.PolicyString = json;

            var engine = new RatingEngine(_logger, _policySource, _policySerializer, new RaterFactory());
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(10000, result);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy
            {
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);
            _policySource.PolicyString = json;

            var engine = new RatingEngine(_logger, _policySource, _policySerializer, new RaterFactory());
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(0, result);
        }

        [Fact]
        public void LogStartingAndCompleting()
        {
            var policy = new Policy
            {
                Type = "Land",
                BondAmount = 200000,
                Valuation = 200000
            };
            string json = JsonConvert.SerializeObject(policy);
            _policySource.PolicyString = json;

            var engine = new RatingEngine(_logger, _policySource, _policySerializer, new RaterFactory());
            engine.Rate();
            
            Assert.Equal("Starting rate.", _logger.loggedMessages[0]);
            Assert.Equal("Loading policy.", _logger.loggedMessages[1]);
            Assert.Equal("Rating LAND policy...", _logger.loggedMessages[2]);
            Assert.Equal("Validating policy.", _logger.loggedMessages[3]);
            Assert.Equal("Rating completed.", _logger.loggedMessages[4]);
        }
    }
}
