using Microsoft.AspNetCore.Authorization;

namespace AspNetMvcCoreExamples.Business.Security.Requirements
{
    // TODO MinimumAgeRequirement is part of .NET core source code
    // https://github.com/aspnet/AspNetCore/tree/master/src/Security/samples/CustomPolicyProvider
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get; }

        public MinimumAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }
}
