using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class RaterFactory
    {
        private ConsoleLogger _logger;

        public RaterFactory(ConsoleLogger logger)
        {
            _logger = logger;
        }

        public decimal? Rate(Policy policy)
        {
            switch (policy.Type)
            {
                case PolicyType.Auto:
                {
                    return new AutoPolicyRater(_logger).Rate(policy);
                }
                case PolicyType.Land:
                {
                    return new LandPolicyRater(_logger).Rate(policy);
                }
                case PolicyType.Life:
                {
                    return new LifePolicyRater(_logger).Rate(policy);
                }
                default:
                    _logger.Log("Unknown policy type");
                    break;
            }

            return null;
        }
    }
}
