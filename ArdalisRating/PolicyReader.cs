using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArdalisRating
{
    public class PolicyReader
    {
        public string ReadPolicy(string policyName)
        {
            var fileName = string.Concat(policyName, ".json");
            return File.ReadAllText(fileName);
        }
    }
}
