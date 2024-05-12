# Create resource group
```
az group create --name rg-kv-library --location eastus2
```

```
az keyvault create --name kv-library --resource-group rg-kv-library --location eastus2
```