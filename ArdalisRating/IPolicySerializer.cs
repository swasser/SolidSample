﻿namespace ArdalisRating
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromString(string policyStrig);
    }
}
