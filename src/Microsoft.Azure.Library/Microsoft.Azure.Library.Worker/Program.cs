using Microsoft.Azure.Library.KeyVault.KeyVault;
using Microsoft.Azure.Library.KeyVault.KeyVault.Entity;

class Program
{
    static async Task Main(string[] args)
    {
        string keyVaultName = "kv-library";
        string secretName = "kv-connection-string";

        var keyVaultCrud = new KeyVaultService(keyVaultName);

        // Criar ou atualizar um segredo
        //await keyVaultCrud.CreateOrUpdateSecretAsync(secretName, "secret-value");

        // Obter um segredo
        SecretModel secret = await keyVaultCrud.GetSecretAsync(secretName);
        Console.WriteLine($"Valor do segredo '{secret.Name}': {secret.Value}");

        // Atualizar um segredo
        //await keyVaultCrud.UpdateSecretAsync(secretName, "new-secret-value");

        // Obter o segredo atualizado
        //secret = await keyVaultCrud.GetSecretAsync(secretName);
        //Console.WriteLine($"Valor do segredo '{secret.Name}': {secret.Value}");

        //// Excluir um segredo
        //await keyVaultCrud.DeleteSecretAsync(secretName);

        Console.ReadKey();
    }
}