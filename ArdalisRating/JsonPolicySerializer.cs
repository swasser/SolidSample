﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromJsonString(string policyString);
    }

    public class JsonPolicySerializer : IPolicySerializer
    {
        public Policy GetPolicyFromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<Policy>(jsonString,
                new StringEnumConverter());
        }
    }
}
