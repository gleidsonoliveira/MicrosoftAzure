using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.Library.KeyVault.KeyVault.Entity;

namespace Microsoft.Azure.Library.KeyVault.KeyVault
{
    public class KeyVaultService : IkeyVaultService
    {
        private readonly SecretClient _client;
        public KeyVaultService(string keyVaultName)
        {
            _client = new SecretClient(new Uri($"https://{keyVaultName}.vault.azure.net/"), new DefaultAzureCredential());
        }

        public async Task CreateOrUpdateSecretAsync(string secretName, string secretValue)
        {
            await _client.SetSecretAsync(secretName, secretValue);
            Console.WriteLine($"Secret '{secretName}' criado/atualizado com sucesso.");
        }

        public async Task<SecretModel> GetSecretAsync(string secretName)
        {
            KeyVaultSecret secret = await _client.GetSecretAsync(secretName);
            return new SecretModel { Name = secret.Name, Value = secret.Value };
        }

        public async Task UpdateSecretAsync(string secretName, string newSecretValue)
        {
            await _client.SetSecretAsync(secretName, newSecretValue);
            Console.WriteLine($"Secret '{secretName}' atualizado com sucesso.");
        }

        public async Task DeleteSecretAsync(string secretName)
        {
            DeleteSecretOperation operation = await _client.StartDeleteSecretAsync(secretName);
            await operation.WaitForCompletionAsync();
            Console.WriteLine($"Secret '{secretName}' excluído com sucesso.");
        }
    }
}
