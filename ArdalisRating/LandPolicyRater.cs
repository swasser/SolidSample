using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class LandPolicyRater
    {
        private ConsoleLogger _logger;

        public LandPolicyRater(ConsoleLogger logger)
        {
            _logger = logger;
        }

        public decimal? Rate(Policy policy)
        {
            if (policy.Type == PolicyType.Land)
            {
                _logger.Log("Rating LAND policy...");
                _logger.Log("Validating policy.");
                if (policy.BondAmount == 0 || policy.Valuation == 0)
                {
                    _logger.Log("Land policy must specify Bond Amount and Valuation.");
                }
                if (policy.BondAmount < 0.8m * policy.Valuation)
                {
                    _logger.Log("Insufficient bond amount.");
                }
                return policy.BondAmount * 0.05m; 
            }

            return null;
        }
    }
}
