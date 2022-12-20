using System;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, ILogger logger)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),
                        new object[] { logger });
            }
            catch
            {
                return new UnknownPolicyRater(logger);
            }
        }
    }
}
