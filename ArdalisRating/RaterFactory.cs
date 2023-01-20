namespace ArdalisRating
{
    internal class RaterFactory
    {
        private ConsoleLogger _logger;

        public RaterFactory(ConsoleLogger logger)
        {
            _logger = logger;
        }

        public AbstractRater Create(Policy policy)
        {
            switch (policy.Type)
            {
                case PolicyType.Auto:
                {
                    return new AutoPolicyRater(_logger);
                }
                case PolicyType.Land:
                {
                    return new LandPolicyRater(_logger);
                }
                case PolicyType.Life:
                {
                    return new LifePolicyRater(_logger);
                }
                default:
                    _logger.Log("Unknown policy type");
                    break;
            }

            return null;
        }
    }
}
