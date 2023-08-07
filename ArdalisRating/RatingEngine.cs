﻿namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private readonly ConsoleLogger _logger;
        private readonly PolicyReader _policyReader;
        private readonly PolicyDeserializer _policyDeserializer = new();
        public decimal? Rating { get; set; }

        public RatingEngine (PolicyReader reader, ConsoleLogger logger)
        {
            _logger = logger;
            _policyReader = reader;
        }

        public void Rate()
        {
            _logger.Log("Starting rate.");

            _logger.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = _policyReader.ReadPolicy("policy");

            var policy = _policyDeserializer.GetPolicyFromJson(policyJson);

            var rater = new RaterFactoryWithReflection(_logger).Create(policy);

            Rating = rater.Rate(policy);

            _logger.Log("Rating completed.");
        }
    }
}
