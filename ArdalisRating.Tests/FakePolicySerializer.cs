using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating.Tests
{
    public class FakePolicySerializer : IPolicySerializer
    {
        public string SerializedString { get; set; }    

        public Policy GetPolicyFromJsonString(string policyString)
        {
            return JsonConvert.DeserializeObject<Policy>(policyString,
               new StringEnumConverter());
        }
    }
}
