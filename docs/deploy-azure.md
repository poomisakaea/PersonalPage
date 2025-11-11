# Azure Deployment Guide | คู่มือการปรับใช้ Azure

**Feature**: Personal Page (Name + Email)  
**Deployment Target**: Azure App Service  
**Environment**: Production  
**Date**: 2025

---

## Table of Contents | สารบัญ

1. [Prerequisites | ข้อกำหนดเบื้องต้น](#prerequisites)
2. [Local Build & Publish | การสร้างและเผยแพร่ในเครื่อง](#local-build--publish)
3. [Deployment Methods | วิธีการปรับใช้](#deployment-methods)
4. [GitHub Actions Setup | ตั้งค่า GitHub Actions](#github-actions-setup)
5. [Configuration & Secrets | การกำหนดค่าและลับ](#configuration--secrets)
6. [Monitoring & Logging | การติดตามและบันทึก](#monitoring--logging)
7. [Troubleshooting | การแก้ไขปัญหา](#troubleshooting)
8. [Rollback & Recovery | การย้อนกลับและการกู้คืน](#rollback--recovery)

---

## Prerequisites | ข้อกำหนดเบื้องต้น

### Required Tools | เครื่องมือที่จำเป็น

```bash
# .NET SDK 9.0+
dotnet --version

# Azure CLI (https://aka.ms/azure-cli)
az --version

# Git
git --version

# Docker (optional, for container deployment)
docker --version
```

### Azure Subscription | การสมัครสมาชิก Azure

✅ **Required**:
- Active Azure subscription (Free tier or higher)
- Resource Group (will create: `personal-page-rg`)
- Storage account (will create automatically)
- Log Analytics workspace (optional, recommended)

✅ **Cost Estimate** (monthly):
```
App Service Plan (B1): $12-17 / month
  - 1 core, 1.75 GB RAM
  - 165 total compute hours
  - Suitable for low-traffic MVP

Optional (if added later):
  - Application Insights: ~$5 / month
  - Custom domain: ~$0.75-15 / month
  - CDN: ~$0.079 / GB transferred

Total (MVP): ~$12-17 / month
```

---

## Local Build & Publish | การสร้างและเผยแพร่ในเครื่อง

### 1. Build Locally

**EN**:
```bash
cd d:\SynologyDrive\0.CodecademyProjects\PersonalPage

# Restore dependencies
dotnet restore

# Build
dotnet build --configuration Release

# Run tests
dotnet test --configuration Release

# Publish to folder
dotnet publish --configuration Release --output ./publish
```

**TH**:
```bash
# ขั้นตอนการสร้างในเครื่อง
dotnet publish --configuration Release --output ./publish
```

### 2. Verify Published App

```bash
# Navigate to publish folder
cd publish

# Check contents (should contain PersonalPage.dll and assets)
ls -la

# Run locally (for testing)
dotnet PersonalPage.dll
# App runs on http://localhost:5000
```

### 3. Create ZIP for Deployment

**EN**: If deploying via ZIP Deploy (method 1):

```bash
# From project root
Compress-Archive -Path ./publish/* -DestinationPath ./deploy.zip

# Verify zip
$items = [System.IO.Compression.ZipFile]::OpenRead('./deploy.zip')
$items.Entries | Select-Object FullName, Length
$items.Dispose()
```

**TH**: สำหรับการปรับใช้ ZIP Deploy

---

## Deployment Methods | วิธีการปรับใช้

### Method 1: ZIP Deploy (Recommended for MVP)

✅ **Fastest**: ~30 seconds  
✅ **Simplest**: No Docker required  
✅ **Best for**: Quick iterations

**Steps**:

```bash
# 1. Login to Azure
az login

# 2. Create resource group
az group create \
  --name personal-page-rg \
  --location eastasia

# 3. Create App Service Plan
az appservice plan create \
  --name personal-page-plan \
  --resource-group personal-page-rg \
  --sku B1 \
  --is-linux

# 4. Create web app
az webapp create \
  --resource-group personal-page-rg \
  --plan personal-page-plan \
  --name personal-page-app-abc123 \
  --runtime "DOTNETCORE|9.0"

# 5. Deploy ZIP
az webapp deployment source config-zip \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123 \
  --src ./deploy.zip

# 6. Set configuration
az webapp config appsettings set \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123 \
  --settings \
    Owner__Name="Your Name" \
    Owner__Email="your.email@example.com" \
    ASPNETCORE_ENVIRONMENT=Production

# 7. Verify deployment
curl https://personal-page-app-abc123.azurewebsites.net
# Should return HTML with name and email
```

### Method 2: Docker Container (Optional, for Advanced Users)

✅ **Scalable**: Easy to scale with containers  
✅ **Reproducible**: Same image everywhere  
❌ **Slower**: ~2 minutes to build and push

**Steps**:

```bash
# 1. Create Azure Container Registry
az acr create \
  --resource-group personal-page-rg \
  --name personalpageacr \
  --sku Basic

# 2. Build and push Docker image
az acr build \
  --registry personalpageacr \
  --image personal-page:latest \
  --file src/PersonalPage/Dockerfile .

# 3. Create Container Instances (or use App Service for Containers)
az webapp create \
  --resource-group personal-page-rg \
  --plan personal-page-plan \
  --name personal-page-container \
  --deployment-container-image-name personal-page:latest \
  --registry-url https://personalpageacr.azurecr.io \
  --registry-username <username> \
  --registry-password <password>

# 4. Configure webhook for auto-deploy on image push (optional)
az acr webhook create \
  --registry personalpageacr \
  --name personalpage \
  --actions push \
  --uri https://personal-page-container.scm.azurewebsites.net/docker/hook \
  --scope personal-page:*
```

### Method 3: GitHub Actions (Fully Automated)

✅ **Automatic**: Deploys on every push to main  
✅ **Tested**: Runs tests before deploying  
✅ **Best for**: Production pipelines

**Setup**: See [GitHub Actions Setup](#github-actions-setup) section below.

---

## GitHub Actions Setup | ตั้งค่า GitHub Actions

### 1. Create Service Principal

```bash
# Generate Azure credentials
az ad sp create-for-rbac \
  --name personal-page-github \
  --role Contributor \
  --scopes /subscriptions/<subscription-id>/resourceGroups/personal-page-rg \
  --json-auth

# Output:
# {
#   "clientId": "...",
#   "clientSecret": "...",
#   "subscriptionId": "...",
#   "tenantId": "...",
#   "activeDirectoryEndpointUrl": "https://login.microsoftonline.com",
#   "resourceManagerEndpointUrl": "https://management.azure.com/",
#   "activeDirectoryGraphResourceId": "https://graph.microsoft.com/",
#   "sqlManagementEndpointUrl": "https://management.core.windows.net:8443/",
#   "galleryEndpointUrl": "https://gallery.azure.com/",
#   "managementEndpointUrl": "https://management.core.windows.net/"
# }
```

### 2. Add GitHub Secrets

**Navigate to**:
```
GitHub → Settings → Secrets and variables → Actions → New repository secret
```

**Add these secrets**:

| Secret Name | Value | Example |
|-------------|-------|---------|
| `AZURE_CREDENTIALS` | Full output from step 1 | JSON object (copy-paste entire output) |
| `AZURE_RESOURCE_GROUP` | Resource group name | `personal-page-rg` |
| `AZURE_APP_NAME` | Web app name | `personal-page-app-abc123` |
| `AZURE_LOCATION` | Azure region | `eastasia` or `westus` |
| `OWNER_NAME` | Your name (for config) | `John Doe` |
| `OWNER_EMAIL` | Your email (for config) | `john@example.com` |
| `SLACK_WEBHOOK` | (Optional) Slack notification | From Slack app integration |

**Example GitHub UI**:
```
Repository → Settings → Secrets and variables → Actions
  → New repository secret

Name: AZURE_CREDENTIALS
Value: { "clientId": "...", ... } (paste full JSON)
  → Add secret

Name: OWNER_NAME
Value: Your Name
  → Add secret

Name: OWNER_EMAIL
Value: your.email@example.com
  → Add secret
```

### 3. Update Workflow File

**File**: `.github/workflows/deploy-azure.yml`

```yaml
env:
  AZURE_RESOURCE_GROUP: ${{ secrets.AZURE_RESOURCE_GROUP }}  # From secrets
  AZURE_APP_NAME: ${{ secrets.AZURE_APP_NAME }}              # From secrets
  AZURE_LOCATION: ${{ secrets.AZURE_LOCATION }}              # From secrets
```

### 4. Test Workflow

```bash
# Push to main and watch GitHub Actions
git add .
git commit -m "Setup Azure deployment"
git push origin main

# Monitor in GitHub
GitHub → Actions → Workflows
  → Deploy to Azure App Service
  → Watch build progress
```

---

## Configuration & Secrets | การกำหนดค่าและลับ

### Environment Variables | ตัวแปรสภาพแวดล้อม

**File**: `src/PersonalPage/appsettings.json` (local development)

```json
{
  "Owner": {
    "Name": "Your Name",
    "Email": "your.email@example.com"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning"
    }
  }
}
```

**Azure Production**: Set via `az webapp config appsettings set`

```bash
az webapp config appsettings set \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123 \
  --settings \
    Owner__Name="John Doe" \
    Owner__Email="john@example.com" \
    ASPNETCORE_ENVIRONMENT=Production \
    WEBSITE_RUN_FROM_PACKAGE=1 \
    WEBSITE_HEALTHCHECK_MAXPINGFAILURES=10
```

**Why `__` (double underscore)?**: ASP.NET Core configuration provider converts `:` to `__` in environment variables.

```
appsettings.json:     { "Owner": { "Name": "..." } }
Environment variable: Owner__Name=...
```

### Secure Secrets Management | การจัดการลับอย่างปลอดภัย

✅ **Best Practice**: Never commit secrets to Git

**Use Azure Key Vault** (advanced):

```bash
# 1. Create Key Vault
az keyvault create \
  --resource-group personal-page-rg \
  --name personal-page-kv

# 2. Store secrets
az keyvault secret set \
  --vault-name personal-page-kv \
  --name OwnerEmail \
  --value john@example.com

# 3. Grant app access
az webapp identity assign \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123

# 4. Add access policy
az keyvault set-policy \
  --name personal-page-kv \
  --object-id <managed-identity-object-id> \
  --secret-permissions get list
```

---

## Monitoring & Logging | การติดตามและบันทึก

### View Logs in Azure Portal

```bash
# Stream logs to terminal
az webapp log tail \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123

# Example output:
# 2025-01-15T10:30:42.123Z   INFO  Application started
# 2025-01-15T10:30:43.456Z   INFO  Listening on http://+:8080
```

### Setup Application Insights (Optional)

```bash
# 1. Create Application Insights
az monitor app-insights component create \
  --app myapp \
  --location eastasia \
  --resource-group personal-page-rg

# 2. Link to web app
az webapp config appsettings set \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123 \
  --settings \
    APPINSIGHTS_INSTRUMENTATIONKEY=<instrumentation-key>

# 3. View metrics in Azure Portal
# App Service → Monitoring → Application Insights
```

### Health Checks

```bash
# Add health check endpoint to Program.cs (future)
app.MapHealthChecks("/health");

# Configure in Azure
az webapp config set \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123 \
  --generic-configurations '{"healthCheckPath": "/health"}'
```

---

## Troubleshooting | การแก้ไขปัญหา

### App Returns 500 Error | แอปพลิเคชันคืนค่า 500

```bash
# 1. Check logs
az webapp log tail \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123

# 2. Verify configuration
az webapp config appsettings list \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123

# 3. Restart app
az webapp restart \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123

# 4. Check runtime version
az webapp show \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123 \
  | grep -A5 linuxFxVersion
```

### Slow Performance | ประสิทธิภาพช้า

```bash
# 1. Check CPU/Memory usage
az monitor metrics list \
  --resource /subscriptions/<subscription>/resourceGroups/personal-page-rg/providers/Microsoft.Web/sites/personal-page-app-abc123 \
  --metric "CpuTime,MemoryWorkingSet" \
  --start-time 2025-01-15T00:00:00 \
  --end-time 2025-01-15T01:00:00

# 2. Scale up if needed
az appservice plan update \
  --name personal-page-plan \
  --resource-group personal-page-rg \
  --sku S1  # Upgrade from B1 to S1

# 3. Check metrics in Application Insights
# Portal → Application Insights → Performance
```

### Deployment Fails in GitHub Actions

```bash
# 1. Check workflow logs
GitHub → Actions → Deploy to Azure App Service
  → View raw logs

# 2. Common issues:
#    - AZURE_CREDENTIALS invalid or expired
#    - App name not found
#    - Secrets not set

# 3. Re-generate credentials
az ad sp create-for-rbac \
  --name personal-page-github \
  --role Contributor \
  --scopes /subscriptions/<subscription-id>/resourceGroups/personal-page-rg \
  --json-auth

# 4. Update AZURE_CREDENTIALS secret in GitHub
```

---

## Rollback & Recovery | การย้อนกลับและการกู้คืน

### View Deployment History

```bash
# List recent deployments
az webapp deployment list \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123 \
  --query '[].{Time:time, Status:status, Message:message}' \
  --output table
```

### Rollback to Previous Version

```bash
# 1. List deployment slots
az webapp deployment slot list \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123

# 2. Deploy to staging slot first
az webapp deployment source config-zip \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123 \
  --slot staging \
  --src ./deploy.zip

# 3. Test in staging
curl https://personal-page-app-abc123-staging.azurewebsites.net

# 4. Swap with production if successful
az webapp deployment slot swap \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123 \
  --slot staging

# 5. If issues occur, swap back
az webapp deployment slot swap \
  --resource-group personal-page-rg \
  --name personal-page-app-abc123 \
  --slot staging
```

---

## Cleanup & Cost Optimization | การล้างข้อมูลและการปรับปรุงต้นทุน

### Delete Resources (if no longer needed)

```bash
# Delete resource group (deletes all resources)
az group delete \
  --name personal-page-rg \
  --yes --no-wait

# This deletes:
# - Web app
# - App Service plan
# - Storage account
# - All other resources in the group
```

### Optimize Costs

✅ **Best Practices**:
1. **Use appropriate SKU**: B1 ($12/month) for low traffic
2. **Setup auto-shutdown** (if not 24/7):
   ```bash
   # (Azure does not have built-in auto-shutdown for App Service)
   # Consider using Functions or Containers for true serverless
   ```
3. **Monitor usage**: Set up budget alerts
   ```bash
   az billing budget create \
     --budget-name PersonalPageBudget \
     --amount 50 \
     --time-period Monthly
   ```

---

## Useful Links & Resources | ลิงก์และแหล่งข้อมูล

- **Azure App Service**: https://docs.microsoft.com/azure/app-service/
- **Azure CLI Reference**: https://docs.microsoft.com/cli/azure/
- **GitHub Actions for Azure**: https://github.com/marketplace/actions/deploy-to-azure-app-service
- **Application Insights**: https://docs.microsoft.com/azure/azure-monitor/app/app-insights-overview
- **Azure Pricing**: https://azure.microsoft.com/pricing/details/app-service/
- **Azure DevOps**: https://azure.microsoft.com/services/devops/

---

## Deployment Checklist | รายการตรวจสอบการปรับใช้

**EN**: Before production deployment:

- [ ] All tests pass locally (`dotnet test`)
- [ ] Environment variables configured (Owner__Name, Owner__Email)
- [ ] Application Insights enabled (optional)
- [ ] Azure resources created (resource group, App Service plan, web app)
- [ ] GitHub secrets configured (AZURE_CREDENTIALS, etc.)
- [ ] Workflow file `.github/workflows/deploy-azure.yml` is valid
- [ ] Deployment verified with `curl`
- [ ] Monitoring and logging configured
- [ ] Custom domain configured (optional)
- [ ] SSL/TLS certificate setup (HTTPS enabled by default on *.azurewebsites.net)

**TH**: ตรวจสอบก่อนปรับใช้บน Azure

---

## Sign-Off | ลงนาม

**Deployment Guide**: ✅ Complete  
**Tested Methods**: ZIP Deploy, GitHub Actions  
**Cost Estimate**: ~$12-17 / month (B1 SKU)  
**Date**: 2025  

---

Generated by speckit.implement on behalf of the feature `specs/1-create-personal-page` (T023).
