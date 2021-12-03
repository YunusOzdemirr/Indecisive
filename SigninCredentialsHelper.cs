using System;
using Microsoft.IdentityModel.Tokens;

namespace Shared.Utilities.Security.Encryption
{
    public class SigninCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
