using System;
namespace Shared.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; } = "https://localhost:3000";
        public string Issuer { get; set; } = "Indecisive@indecisive.com";
        public int AccessTokenExpiration { get; set; } = 30;
        public string SecurityKey { get; set; } = "ZXmP5FSQvf2TmPugnFr5CbXW3GjgcmAULVBzaxk1H";
    }
}

