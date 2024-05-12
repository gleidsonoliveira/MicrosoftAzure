# Log in to the Azure Portal 
```
az login
```
# Create resource group
```
az group create --name rg-kv-library --location eastus2
```

# Create key vault via command line
```
az keyvault create --name kv-library --resource-group rg-kv-library --location eastus2
```