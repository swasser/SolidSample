namespace ArdalisRating
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new FileLogger();
            
            logger.Log("Ardalis Insurance Rating System Starting...");

            IPolicySource policySource = new FilePolicySource();

            IPolicySerializer policySerializer = new JsonPolicySerializer();

            RaterFactory raterFactory = new RaterFactory(logger);

            var engine = new RatingEngine(logger, policySource, policySerializer, raterFactory);
            engine.Rate();

            if (engine.Rating > 0)
            {
                logger.Log($"Rating: {engine.Rating}");
            }
            else
            {
                logger.Log("No rating produced.");
            }
        }
    }
}
