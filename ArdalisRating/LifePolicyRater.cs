using System;

namespace ArdalisRating
{
    internal class LifePolicyRater : AbstractRater
    {
        public LifePolicyRater(ConsoleLogger logger) : base(logger){}

        public override decimal? Rate(Policy policy)
        {
            if (policy.Type == PolicyType.Life)
            {
                _logger.Log("Rating LIFE policy...");
                _logger.Log("Validating policy.");
                if (policy.DateOfBirth == DateTime.MinValue)
                {
                    _logger.Log("Life policy must include Date of Birth.");
                }
                if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
                {
                    _logger.Log("Centenarians are not eligible for coverage.");
                }
                if (policy.Amount == 0)
                {
                    _logger.Log("Life policy must include an Amount.");
                }
                int age = DateTime.Today.Year - policy.DateOfBirth.Year;
                if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                    DateTime.Today.Day < policy.DateOfBirth.Day ||
                    DateTime.Today.Month < policy.DateOfBirth.Month)
                {
                    age--;
                }
                decimal baseRate = policy.Amount * age / 200;
                if (policy.IsSmoker)
                {
                    return baseRate * 2;
                }
                return baseRate; 
            }

            return null;
        }
    }
}
