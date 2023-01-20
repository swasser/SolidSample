using System;

namespace ArdalisRating
{
    internal class RaterFactoryWithReflection
    {
        private readonly ConsoleLogger _logger;

        public RaterFactoryWithReflection(ConsoleLogger logger)
        {
            _logger = logger;
        }

        public AbstractRater Create(Policy policy)
        {
            try
            {
                return (AbstractRater)Activator.CreateInstance(
                        Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),
                        new object[] { _logger });
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
