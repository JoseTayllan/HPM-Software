using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPM_Software
{
    public static class GoogleAuthentication
    {
        public static UserCredential Login(string googleClientId, string googleSecret, string[] scopes)
        {
            ClientSecrets secrets = new ClientSecrets()
            {
                ClientId = googleClientId,
                ClientSecret = googleSecret
            };
            return GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, scopes, "user", CancellationToken.None).Result;
        }
        public static async Task<UserCredential> LoginAsync(string googleClientId, string googleSecret, string[] scopes)
        {
            ClientSecrets secrets = new ClientSecrets()
            {
                ClientId = googleClientId,
                ClientSecret = googleSecret
            };
            return await GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, scopes, "user", CancellationToken.None);
        }

    }
}
