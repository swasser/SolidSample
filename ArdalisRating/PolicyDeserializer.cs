using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating
{
    public class PolicyDeserializer
    {
        public Policy GetPolicyFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Policy>(json, new StringEnumConverter());
        }
    }
}
