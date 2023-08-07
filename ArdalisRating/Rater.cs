namespace ArdalisRating
{
    public abstract class Rater
    {
        //protected readonly IRatingContext _context;

        protected readonly IRatingUpdater _ratingUpdater;
        //protected readonly ConsoleLogger _logger;
        public ILogger Logger { get; set; } = new ConsoleLogger();

        public Rater(IRatingUpdater ratingUpdater)
        {
            _ratingUpdater = ratingUpdater;
            //_logger = _context.Logger;
        }

        public abstract void Rate(Policy policy);
    }
}
