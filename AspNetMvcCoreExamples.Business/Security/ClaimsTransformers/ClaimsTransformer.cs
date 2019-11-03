using Microsoft.AspNetCore.Authentication;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetMvcCoreExamples.Business.Security.ClaimsTransformers
{
    /// <summary>
    /// https://github.com/aspnet/AspNetCore/blob/master/src/Security/samples/ClaimsTransformation/ClaimsTransformer.cs
    /// </summary>
    public class ClaimsTransformer : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // This will run every time Authenticate is called so its better to create a new Principal
            var transformed = new ClaimsPrincipal();
            transformed.AddIdentities(principal.Identities);
            transformed.AddIdentity(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.DateOfBirth, new DateTime(1990, 1, 1).ToShortDateString())
            }));
            return Task.FromResult(transformed);
        }
    }
}
