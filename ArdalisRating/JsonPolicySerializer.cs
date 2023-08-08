using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating
{
    public class JsonPolicySerializer : IPolicySerializer
    {
        //TODO : remove after DefaultRatingContext removal
        public Policy GetPolicyFromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<Policy>(jsonString,
                new StringEnumConverter());
        }

        public Policy GetPolicyFromString(string jsonString)
        {
            return JsonConvert.DeserializeObject<Policy>(jsonString,
                new StringEnumConverter());
        }
    }
}
