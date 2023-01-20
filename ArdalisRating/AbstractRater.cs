namespace ArdalisRating
{
    internal abstract class AbstractRater
    {
        protected ConsoleLogger _logger;

        protected AbstractRater(ConsoleLogger logger)
        {
            _logger = logger;
        }

        public abstract decimal? Rate(Policy policy);
    }
}
