using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureD365DemoWebJob
{
    public class KeyVaultManager
    {
        public string KeyVaultUri { get; set; }
        public string AuthClientId { get; set; }
        public string AuthClientSecret { get; set; }

        private KeyVaultClient KeyVaultClient;

        public KeyVaultManager(string keyVaultUri, string authClientId, string authClientSecret)
        {
            this.KeyVaultUri = keyVaultUri;
            this.AuthClientId = authClientId;
            this.AuthClientSecret = authClientSecret;

            // Register authentication call back - this would be executed for any request to Azure key vault.  
            KeyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetAccessToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public string GetSecretValue(string secretKey)
        {
            var secret = KeyVaultClient.GetSecretAsync(KeyVaultUri, secretKey, null).GetAwaiter().GetResult();
            return secret.Value;
        }

        /// <summary>
        /// Get Access Token
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            var clientId = this.AuthClientId;
            var clientSecret = AuthClientSecret;
            ClientCredential clientCredential = new ClientCredential(clientId, clientSecret);

            var context = new AuthenticationContext(authority, TokenCache.DefaultShared);            
            var result = await context.AcquireTokenAsync(resource, clientCredential);
            return result.AccessToken;
        }
    }
}
