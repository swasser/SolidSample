namespace ArdalisRating
{
    internal class UnknownPolicyRater : AbstractRater
    {
        public UnknownPolicyRater(ConsoleLogger logger) : base(logger) { }

        public override decimal? Rate(Policy policy)
        {
            _logger.Log("Unknown policy type.");

            return 0;
        }
    }
}
