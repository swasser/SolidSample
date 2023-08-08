namespace ArdalisRating
{
    public abstract class Rater
    {
        protected readonly ILogger _logger;

        public Rater(ILogger logger)
        {
            _logger = logger;
        }

        public abstract decimal Rate(Policy policy);
    }
}
