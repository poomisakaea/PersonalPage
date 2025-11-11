# PersonalPage

A simple, responsive single-page personal website built with ASP.NET Core that displays the owner's name and email contact information.

---

## สำหรับผู้อ่านภาษาไทย

นี่คือเว็บไซต์บุคคลแบบเดียวสร้างด้วย ASP.NET Core แสดงเฉพาะชื่อและอีเมลติดต่อของเจ้าของ

---

## Features

- **Name & Email**: Clean display of contact information
- **Mobile-First Design**: Fully responsive layout
- **Accessibility**: Semantic HTML, keyboard navigation, screen reader friendly
- **Performance**: Optimized assets, fast load times
- **Privacy-First**: No tracking or analytics by default
- **Thai Language Support**: Full support for Thai characters and fonts

---

## Quick Start

### Prerequisites

- **.NET 8.0 SDK** or later ([download](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))
- **Visual Studio Code** or **Visual Studio 2022** (recommended)
- **Git**

### Local Development

1. **Clone the repository**:
   ```bash
   git clone https://github.com/poomisakaea/PersonalPage.git
   cd PersonalPage
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Run locally**:
   ```bash
   dotnet run --project src/PersonalPage/PersonalPage.csproj
   ```
   The application will be available at `https://localhost:5001` (or `http://localhost:5000`).

4. **Build for release**:
   ```bash
   dotnet build --configuration Release
   ```

5. **Publish**:
   ```bash
   dotnet publish --configuration Release --output ./publish src/PersonalPage/PersonalPage.csproj
   ```

---

## Project Structure

```
PersonalPage/
├── src/
│   └── PersonalPage/           # Main ASP.NET Core web app
│       ├── Controllers/        # MVC Controllers
│       ├── Models/             # Data models (Owner, etc.)
│       ├── Views/              # Razor views (_Layout, Index, etc.)
│       ├── wwwroot/            # Static assets (CSS, JS, images)
│       │   ├── css/
│       │   ├── js/
│       │   └── assets/
│       ├── Program.cs          # Application startup
│       └── PersonalPage.csproj # Project file
├── tests/
│   └── PersonalPage.Tests/     # Unit and integration tests
├── specs/
│   └── 1-create-personal-page/ # Feature specification and tasks
├── PersonalPage.sln            # Solution file
├── README.md                   # This file
└── .gitignore                  # Git ignore rules
```

---

## Configuration

### Owner Information

To customize the owner's name and email, update the configuration in `src/PersonalPage/appsettings.json` or use environment variables:

```json
{
  "Owner": {
    "Name": "Your Name",
    "Email": "your.email@example.com"
  }
}
```

Or set via environment variables:
```bash
export OwnerName="Your Name"
export OwnerEmail="your.email@example.com"
```

---

## Testing

### Unit Tests

Run unit tests with xUnit:
```bash
dotnet test tests/PersonalPage.Tests/PersonalPage.Tests.csproj
```

### Integration Tests

Integration tests use `TestServer` to verify the `/` endpoint returns the correct content:
```bash
dotnet test tests/PersonalPage.Tests/PersonalPage.Tests.csproj --filter "Integration"
```

### Manual Testing

1. Open the application in your browser
2. Verify:
   - Name is clearly visible
   - Email link works (opens mail client)
   - Copy-to-clipboard button works
   - Layout is responsive on mobile and desktop
   - All keyboard navigation works

---

## Deployment to Azure

### Quick Start (ZIP Deploy)

The fastest way to deploy to Azure App Service:

```bash
# 1. Publish locally
dotnet publish --configuration Release --output ./publish

# 2. Create ZIP
Compress-Archive -Path ./publish/* -DestinationPath deploy.zip

# 3. Login to Azure
az login

# 4. Create resources (one-time)
az group create --name personal-page-rg --location eastasia
az appservice plan create --name personal-page-plan --resource-group personal-page-rg --sku B1 --is-linux
az webapp create --resource-group personal-page-rg --plan personal-page-plan --name personal-page-app --runtime "DOTNETCORE|9.0"

# 5. Deploy
az webapp deployment source config-zip \
  --resource-group personal-page-rg \
  --name personal-page-app \
  --src deploy.zip

# 6. Verify
curl https://personal-page-app.azurewebsites.net
```

### Complete Deployment Guide

For detailed instructions including Docker deployment, GitHub Actions setup, and configuration management, see [Azure Deployment Guide](docs/deploy-azure.md).

**Key Topics Covered**:
- ZIP Deploy (recommended for MVP)
- Docker Container deployment
- GitHub Actions automated pipeline
- Environment variables and secrets management
- Monitoring and logging with Application Insights
- Rollback and recovery procedures
- Cost optimization (~$12-17/month for B1 SKU)

### Option 1: Azure App Service (ZIP Deploy) - Recommended

1. **Publish the application**:
   ```bash
   dotnet publish --configuration Release --output ./publish src/PersonalPage/PersonalPage.csproj
   ```

2. **Create Azure resources** (using Azure CLI):
   ```bash
   az group create --name PersonalPageRG --location eastus
   az appservice plan create --name PersonalPagePlan --resource-group PersonalPageRG --sku B1 --is-linux
   az webapp create --resource-group PersonalPageRG --plan PersonalPagePlan --name personalpage-<unique-suffix> --runtime "DOTNETCORE|9.0"
   ```

3. **Deploy**:
   ```bash
   cd publish
   zip -r ../deploy.zip .
   cd ..
   az webapp deployment source config-zip --resource-group PersonalPageRG --name personalpage-<unique-suffix> --src deploy.zip
   ```

### Option 2: Azure App Service for Containers (Docker)

1. **Build Docker image**:
   ```bash
   docker build -t personalpage:latest .
   ```

2. **Tag and push to Azure Container Registry**:
   ```bash
   az acr create --resource-group PersonalPageRG --name personalpage<uniquename> --sku Basic
   az acr build --registry personalpage<uniquename> --image personalpage:latest .
   ```

3. **Create App Service for Containers**:
   ```bash
   az appservice plan create --name PersonalPagePlan --resource-group PersonalPageRG --sku B1 --is-linux
   az webapp create --resource-group PersonalPageRG --plan PersonalPagePlan --name personalpage-<unique-suffix> --deployment-container-image-name personalpage<uniquename>.azurecr.io/personalpage:latest
   ```

For more detailed deployment instructions, see `docs/deploy-azure.md`.

---

## GitHub Actions CI/CD

The repository includes a GitHub Actions workflow (`.github/workflows/dotnet-ci.yml`) that:
- Builds the solution on every push
- Runs unit and integration tests
- Optionally publishes to Azure App Service (requires secrets)

To enable automated deployment:
1. Set GitHub secrets: `AZURE_RESOURCE_GROUP`, `AZURE_APP_SERVICE_NAME`, `AZURE_PUBLISH_PROFILE`
2. Push to the main branch or create a pull request

---

## Documentation

Comprehensive guides for different aspects of the project:

- **[Accessibility Notes](specs/1-create-personal-page/accessibility-notes.md)**: WCAG 2.1 Level AA compliance, keyboard navigation, screen reader support
- **[Performance Report](specs/1-create-personal-page/performance-report.md)**: Optimization metrics, asset sizes, Lighthouse scores
- **[Azure Deployment Guide](docs/deploy-azure.md)**: Step-by-step guide for deploying to Azure App Service (ZIP Deploy or Docker)
- **[GitHub Actions Workflow](docs/deploy-azure.md#github-actions-setup)**: Automated CI/CD pipeline for tests and deployment
- **[Acceptance Checklist](specs/1-create-personal-page/acceptance-checklist.md)**: Manual and automated test criteria

---

## Performance & Accessibility

### Performance Goals ✅
- Page load time: < 1.5s on typical 4G networks
- Time to Interactive: < 2s
- Total page size: < 50KB (gzipped: < 10KB)
- Lighthouse score: 95+

**Current Metrics**:
- FCP (First Contentful Paint): ~800ms
- LCP (Largest Contentful Paint): ~1.2s
- CLS (Cumulative Layout Shift): 0.0
- Bundle: HTML 2KB + CSS 8KB + JS 2KB = 12KB total

See [Performance Report](specs/1-create-personal-page/performance-report.md) for details.

### Accessibility Checklist ✅
- ✅ Semantic HTML structure
- ✅ ARIA labels and roles
- ✅ Keyboard navigation (Tab, Enter)
- ✅ Focus indicators visible (3px outline)
- ✅ Color contrast WCAG AA compliant (7:1 ratio)
- ✅ Screen reader friendly
- ✅ Respects prefers-reduced-motion
- ✅ Support for high-contrast mode

See [Accessibility Notes](specs/1-create-personal-page/accessibility-notes.md) for detailed implementation.

**Run accessibility audits**:
```bash
# Using Lighthouse (requires Chrome/Chromium)
# Open the app in Chrome DevTools → Lighthouse → Audit

# Using axe DevTools browser extension
# Install from https://www.deque.com/axe/devtools/

# Expected Lighthouse scores:
# - Performance: 95+
# - Accessibility: 97+
# - Best Practices: 100
# - SEO: 100
```

---

## Development Stack

| Layer | Technology |
|-------|-----------|
| **Runtime** | .NET 8.0 |
| **Framework** | ASP.NET Core MVC |
| **Frontend** | HTML5, CSS3 (BEM), JavaScript (ES2022) |
| **Testing** | xUnit, TestServer (integration) |
| **Build** | dotnet CLI |
| **Deployment** | Azure App Service |
| **CI/CD** | GitHub Actions |

---

## Code Style & Standards

- **Language**: C# 12, HTML5, CSS3, ES2022
- **CSS Methodology**: BEM (Block Element Modifier)
- **Testing**: TDD where applicable, xUnit framework
- **Documentation**: Inline comments for complex logic, README for setup

---

## License

This project is open source. See `LICENSE` file (if applicable) for details.

---

## Contributing

To contribute:
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/your-feature`)
3. Commit your changes (`git commit -m 'Add your feature'`)
4. Push to the branch (`git push origin feature/your-feature`)
5. Create a Pull Request

Please ensure all tests pass before submitting a PR.

---

## Support

For questions or issues, please create an issue on GitHub or contact the maintainer.

---

**Last Updated**: November 2025  
**Version**: 1.0.0-MVP
