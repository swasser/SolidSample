namespace ArdalisRating
{
    public class RatingUpdater : IRatingUpdater
    {
        private RatingEngine _engine;

        public RatingUpdater(RatingEngine engine)
        {
            _engine = engine;
        }

        public void UpdateRating(decimal rating)
        {
            _engine.Rating = rating;
        }
    }
}
