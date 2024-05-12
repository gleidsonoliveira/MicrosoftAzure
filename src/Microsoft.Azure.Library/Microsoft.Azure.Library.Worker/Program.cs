using Microsoft.Azure.Library.KeyVault.KeyVault;
using Microsoft.Azure.Library.KeyVault.KeyVault.Entity;

class Program
{
    static async Task Main(string[] args)
    {
        string keyVaultName = "kv-library";
        var keyVaultCrud = new KeyVaultService(keyVaultName);

        #region Criar ou atualizar um segredo
        string secretNameCreateOrUpdate = "kv-connection-string-1";
        string secretValueCreateOrUpdate = "Server=localhost;Port=9696;Database=teste;Uid=teste;Pwd=123456789";
        await keyVaultCrud.CreateOrUpdateSecretAsync(secretNameCreateOrUpdate, secretValueCreateOrUpdate);
        Console.WriteLine("Segredo criado com sucesso");
        #endregion

        #region Obter um segredo
        string secretNameGet = "kv-connection-string-1";
        SecretModel secretGet = await keyVaultCrud.GetSecretAsync(secretNameGet);
        Console.WriteLine($"Valor do segredo criado no passo anterior '{secretGet.Name}': {secretGet.Value}");
        #endregion

        #region Atualizar um segredo
        string secretNameUpdate = "kv-connection-string-1";
        string secretValueUpdate = "Server=localhost;Port=9797;Database=teste;Uid=teste;Pwd=123456789";
        await keyVaultCrud.UpdateSecretAsync(secretNameUpdate, secretValueUpdate);
        Console.WriteLine("Segredo atualizado com sucesso!!!");
        #endregion

        #region Obter o segredo atualizado
        string secretNameGetSecretUpdate = "kv-connection-string-1";
        SecretModel secretGetSecretUpdate = await keyVaultCrud.GetSecretAsync(secretNameGetSecretUpdate);
        Console.WriteLine($"Valor do segredo '{secretGetSecretUpdate.Name}': {secretGetSecretUpdate.Value}");
        #endregion

        #region Excluir um segredo
        string secretNameDeleteSecret = "kv-connection-string-1";
        await keyVaultCrud.DeleteSecretAsync(secretNameDeleteSecret);
        Console.WriteLine("Segredo deletado com sucesso!!!");
        #endregion

        Console.ReadKey();
    }
}