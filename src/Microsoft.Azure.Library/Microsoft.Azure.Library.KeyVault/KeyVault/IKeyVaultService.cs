using Microsoft.Azure.Library.KeyVault.KeyVault.Entity;
namespace Microsoft.Azure.Library.KeyVault.KeyVault
{
    public interface IkeyVaultService
    {
        Task CreateOrUpdateSecretAsync(string secretName, string secretValue);
        Task<SecretModel> GetSecretAsync(string secretName);
        Task UpdateSecretAsync(string secretName, string newSecretValue);
        Task DeleteSecretAsync(string secretName);
    }
}
