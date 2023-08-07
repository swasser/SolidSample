using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating
{
    public class PolicyDeserializer
    {
        public Policy GetPolicyFromJson(string json)
        {
			try
			{
				return JsonConvert.DeserializeObject<Policy>(json, new StringEnumConverter());
			}
			catch (JsonSerializationException)
			{
				return new Policy { Type = PolicyType.Unknown };
			}
        }
    }
}
