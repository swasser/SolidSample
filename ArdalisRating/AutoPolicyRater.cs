using System;

namespace ArdalisRating
{
    internal class AutoPolicyRater
    {
        private ConsoleLogger _logger;

        public AutoPolicyRater(ConsoleLogger logger)
        {
            _logger = logger;
        }

        public decimal? Rate(Policy policy)
        {
            if (policy.Type == PolicyType.Auto)
            {
                _logger.Log("Rating AUTO policy...");
                _logger.Log("Validating policy.");
                if (String.IsNullOrEmpty(policy.Make))
                {
                    _logger.Log("Auto policy must specify Make");
                }
                if (policy.Make == "BMW")
                {
                    if (policy.Deductible < 500)
                    {
                        return 1000m;
                    }
                    return 900m;
                } 
            }

            return null;
        }
    }
}
