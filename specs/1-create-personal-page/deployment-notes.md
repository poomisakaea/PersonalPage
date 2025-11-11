# Deployment Notes | หมายเหตุการปรับใช้

**Feature**: Single Personal Page (Name + Email)
**Target Platform**: Azure App Service  
**Updated**: November 2025

---

## Overview | ภาพรวม

This document outlines the deployment strategy and procedures for the PersonalPage application to Azure App Service.

TH: เอกสารนี้อธิบายกลยุทธ์การปรับใช้และขั้นตอนสำหรับแอปพลิเคชัน PersonalPage ไปยัง Azure App Service

---

## Build & Publish | การ Build และ Publish

### Local Development

```bash
# Restore dependencies
dotnet restore

# Build in Debug configuration
dotnet build

# Run locally
dotnet run --project src/PersonalPage/PersonalPage.csproj
```

### Production Build

```bash
# Publish Release configuration
dotnet publish --configuration Release --output ./publish src/PersonalPage/PersonalPage.csproj
```

---

## Deployment Options | ตัวเลือกการปรับใช้

### Option 1: ZIP Deploy (Recommended for Small Apps)

**Pros**:
- Simplest approach
- No Docker required
- Direct .NET 8 runtime from Azure

**Steps**:

1. **Publish the app**:
   ```bash
   dotnet publish --configuration Release --output ./publish src/PersonalPage/PersonalPage.csproj
   cd publish
   zip -r ../deploy.zip .
   cd ..
   ```

2. **Create resource group** (first time only):
   ```bash
   az group create \
     --name PersonalPageRG \
     --location eastus
   ```

3. **Create App Service Plan**:
   ```bash
   az appservice plan create \
     --name PersonalPagePlan \
     --resource-group PersonalPageRG \
     --sku B1 \
     --is-linux
   ```

4. **Create Web App**:
   ```bash
   az webapp create \
     --resource-group PersonalPageRG \
     --plan PersonalPagePlan \
     --name personalpage-<unique-suffix> \
     --runtime "DOTNETCORE|8.0"
   ```

5. **Deploy ZIP**:
   ```bash
   az webapp deployment source config-zip \
     --resource-group PersonalPageRG \
     --name personalpage-<unique-suffix> \
     --src deploy.zip
   ```

### Option 2: Docker Deploy (App Service for Containers)

**Pros**:
- Consistent environment (dev → prod)
- Easier scaling and maintenance
- Container registry for versioning

**Prerequisites**:
- Docker installed locally
- Azure Container Registry (ACR) or Docker Hub

**Steps**:

1. **Build Docker image**:
   ```bash
   docker build -t personalpage:latest .
   ```

2. **Tag image for ACR**:
   ```bash
   docker tag personalpage:latest <acr-name>.azurecr.io/personalpage:latest
   ```

3. **Push to ACR**:
   ```bash
   az acr login --name <acr-name>
   docker push <acr-name>.azurecr.io/personalpage:latest
   ```

4. **Create App Service for Containers**:
   ```bash
   az appservice plan create \
     --name PersonalPagePlan \
     --resource-group PersonalPageRG \
     --sku B1 \
     --is-linux

   az webapp create \
     --resource-group PersonalPageRG \
     --plan PersonalPagePlan \
     --name personalpage-<unique-suffix> \
     --deployment-container-image-name <acr-name>.azurecr.io/personalpage:latest \
     --docker-custom-image-name <acr-name>.azurecr.io/personalpage:latest \
     --docker-registry-server-url https://<acr-name>.azurecr.io
   ```

---

## Configuration | การตั้งค่า

### Environment Variables

Set in Azure App Service → Configuration → Application Settings:

```
ASPNETCORE_ENVIRONMENT = Production
Owner__Name = Your Name
Owner__Email = your.email@example.com
```

**In code (appsettings.json)**:
```json
{
  "Owner": {
    "Name": "Default Name",
    "Email": "default@example.com"
  }
}
```

### Custom Domain (Optional)

```bash
# Bind custom domain
az webapp config hostname add \
  --resource-group PersonalPageRG \
  --webapp-name personalpage-<unique-suffix> \
  --hostname yourdomain.com
```

### HTTPS/SSL (Auto with Azure)

Azure provides automatic HTTPS with managed certificates. No additional setup needed.

---

## GitHub Actions Integration

The repository includes `.github/workflows/dotnet-ci.yml` for automated CI/CD.

### Setup GitHub Secrets

1. Go to GitHub Repo → Settings → Secrets and variables → Actions
2. Add secrets:
   - `AZURE_RESOURCE_GROUP`: Your resource group name
   - `AZURE_APP_SERVICE_NAME`: Your app service name
   - `AZURE_PUBLISH_PROFILE`: Downloaded from Azure Portal

### Download Publish Profile

1. Go to Azure Portal → App Service → Download publish profile
2. Store in GitHub Secret as `AZURE_PUBLISH_PROFILE`

---

## Monitoring & Logging

### View Logs

```bash
# Stream logs in real-time
az webapp log tail \
  --resource-group PersonalPageRG \
  --name personalpage-<unique-suffix>
```

### Application Insights (Optional)

```bash
# Create Application Insights resource
az monitor app-insights component create \
  --app personalpage \
  --location eastus \
  --resource-group PersonalPageRG

# Link to App Service
az webapp config appsettings set \
  --resource-group PersonalPageRG \
  --name personalpage-<unique-suffix> \
  --settings APPINSIGHTS_INSTRUMENTATIONKEY=<key>
```

---

## Scaling

### Scale Up (Larger VM)

```bash
az appservice plan update \
  --resource-group PersonalPageRG \
  --name PersonalPagePlan \
  --sku S1
```

### Scale Out (Multiple Instances)

```bash
az appservice plan update \
  --resource-group PersonalPageRG \
  --name PersonalPagePlan \
  --number-of-workers 2
```

---

## Health Checks

### Configure Health Endpoint

The app provides a simple health check at `/` (or custom endpoint).

```bash
az webapp config set \
  --resource-group PersonalPageRG \
  --name personalpage-<unique-suffix> \
  --health-check-path "/"
```

---

## Rollback Strategy

### Previous Deployments

```bash
# View deployment history
az webapp deployment list \
  --resource-group PersonalPageRG \
  --name personalpage-<unique-suffix>

# Rollback to previous deployment
az webapp deployment source update-deployment \
  --resource-group PersonalPageRG \
  --name personalpage-<unique-suffix> \
  --deployment-id <previous-deployment-id> \
  --active true
```

---

## Troubleshooting | แก้ไขปัญหา

### Common Issues

1. **502 Bad Gateway**
   - Check logs: `az webapp log tail ...`
   - Ensure ASPNETCORE_ENVIRONMENT is set
   - Verify configuration settings (Owner__Name, Owner__Email)

2. **404 Not Found**
   - Verify routing in HomeController
   - Check Views folder exists and has Index.cshtml

3. **Slow Performance**
   - Review Application Insights metrics
   - Check App Service Plan SKU
   - Verify network latency

### Health Check URL

```bash
curl https://personalpage-<unique-suffix>.azurewebsites.net/
```

---

## Cost Estimation | ประมาณการค่าใช้จ่าย

| Component | SKU | Monthly Cost (USD) |
|-----------|-----|--------------------|
| App Service Plan | B1 (Basic) | ~$12 |
| Data Transfer (outbound) | - | ~$0-5 |
| **Total** | - | **~$12-17** |

*Prices as of November 2025; check Azure Pricing Calculator for current rates.*

---

## Disaster Recovery | การกู้คืนจากภัยพิบัติ

### Backup Strategy

1. **Code**: Stored in Git repository (GitHub)
2. **Configuration**: Exported from App Service settings
3. **Database**: N/A (stateless application)

### Recovery Steps

1. Clone repository
2. Publish new App Service
3. Restore configuration from exported settings
4. Deploy latest code

---

## Maintenance Schedule | ตารางการบำรุงรักษา

- **Weekly**: Monitor logs and performance
- **Monthly**: Review costs and performance metrics
- **Quarterly**: Update .NET runtime and dependencies
- **As needed**: Deploy bug fixes and feature updates

---

## Contact & Support | ติดต่อและสนับสนุน

- **Repository**: https://github.com/poomisakaea/PersonalPage
- **Issues**: GitHub Issues
- **Email**: your.email@example.com

---

**Last Updated**: November 2025  
**Next Review**: February 2026
