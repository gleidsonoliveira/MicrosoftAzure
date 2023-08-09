using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
                      Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((context, config) =>
                      {
                          var buildConfiguration = config.Build();

                          var KvUrl = "";
                          var KeyVaultTenantId = "";
                          var KeyVaultClientId = "";
                          var KeyVaultClientSecret = "";

                          var vClientSecretCredential = new ClientSecretCredential(KeyVaultTenantId, KeyVaultClientId, KeyVaultClientSecret);

                          var client = new SecretClient(new Uri(KvUrl), vClientSecretCredential);
                          config.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());
                      });

}