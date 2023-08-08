using Newtonsoft.Json;
using System;
using System.Globalization;
using Xunit;

namespace ArdalisRating.Tests
{
    public class FakePolicySource : IPolicySource
    {
        public string policySource { get; set; } = "";

        public string GetPolicyFromSource()
        {
            return policySource;
        }
    }
    
    public class RatingEngineRate
    {
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

            var policySource = new FakePolicySource();
            policySource.policySource = json;

            var policySerializer = new JsonPolicySerializer();

            var raterFactory = new RaterFactory(new FakeLogger());

            var engine = new RatingEngine(new FakeLogger(), policySource, policySerializer, raterFactory);
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(10000, result);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy
            {
                //Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);

            var policySource = new FakePolicySource();
            policySource.policySource = json;

            var policySerializer = new JsonPolicySerializer();
            var raterFactory = new RaterFactory(new FakeLogger());
            var engine = new RatingEngine(new FakeLogger(), policySource, policySerializer, raterFactory);
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(0, result);
        }

        [Fact]
        public void RatingEngine_Messages_Logged()
        {
            FakeLogger logger = new FakeLogger();
            
            var policy = new Policy
            {
                Type = "Life",
                DateOfBirth = DateTime.ParseExact("1970-05-10", "yyyy-mm-dd", CultureInfo.InvariantCulture),
                Amount = 1000000m
            };

            string json = JsonConvert.SerializeObject(policy);

            var policySource = new FakePolicySource();
            policySource.policySource = json;

            var policySerializer = new JsonPolicySerializer();

            var raterFactory = new RaterFactory(new FakeLogger());
            var engine = new RatingEngine(logger, policySource, policySerializer, raterFactory);
            engine.Rate();

            Assert.Contains("Starting rate.", logger.LoggedMessages);
        }
    }
}
