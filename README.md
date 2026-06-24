# ✈️ K5 Project in Team – Travel Planner

## 📖 Project Overview

Travel Planner is a cloud-native ASP.NET Core Web API that helps users discover travel destinations and generate AI-powered travel plans based on their budget, travel duration, and departure date.

The application integrates with Grok AI to:

- Suggest travel destinations
- Generate complete travel plans
- Provide estimated travel costs
- Return quality notes and recommendations

The project follows modern cloud development practices including Docker, CI/CD, Azure deployment, Key Vault integration, automated testing, monitoring, and secure secret management.

---

## 🛠 Technologies

### Backend

- ASP.NET Core 9
- C#
- Entity Framework Core
- SQL Server
- Grok AI API

### 🗄️ Database Implementation

- SQL Server was used as the database
- Database First approach was used
- Save operations are currently commented out
- Test data is not stored during development
- Can be fully enabled and extended in future versions

### Cloud & DevOps

- Docker
- GitHub Actions
- Azure Container Registry (ACR)
- Azure Container Apps
- Azure Key Vault
- Managed Identity
- RBAC

### Testing

- xUnit

---

## 📂 Project Structure

The project follows a clean and simple structure:

- `Controllers/` → Handles HTTP requests and API endpoints.
- `Services/TravelService/` → Handles business logic, caching, and travel request processing.
- `Services/GrokAIService/` → Handles communication with Grok AI and AI-generated travel plans.
- `Models/` → Domain entities used to store travel requests and travel responses.
- `DTOs/Requests/` → Receives and validates incoming client data.
- `DTOs/Responses/` → Returns structured data back to the client.
- `Data/` → Database context and Entity Framework configuration.
- `Middleware/` → Provides centralized exception handling.
- `Exceptions/` → Contains custom application exceptions.
- `Logging/` → Logs AI requests, failures, response times, and trace IDs.
- `TravelPlanner.Tests/` → Automated unit and validation tests.
- `.github/workflows/ci.yml` → Runs automated tests and build checks.
- `.github/workflows/cd.yml` → Handles Docker build, Azure login, ACR push, and Azure deployment.
.- `Evaluation.md` → Documents project reflections, challenges, lessons learned, and future improvements.
- `Screenshots/` → Validation and application demonstration screenshots.


---

## 🐳 Dockerization

The API was containerized using a multi-stage Dockerfile.

### 🔒 Security

The container runs as a non-root user (`USER app`) following container security best practices.

### 🌐 Port Configuration

The application exposes port `8080`, which is the recommended default port for .NET 9 rootless containers.

### 🧪 Local Verification

Docker image:

```bash
docker build -t travelplanner-api .
```

Run container:

```bash
docker run --name travelplanner-container -p 8080:8080 travelplanner-api
```

Test endpoint:

```text
http://localhost:8080/api/travel/health
```

Expected response:

```json
{
  "status": "Healthy"
}
```

> The health endpoint is used for testing because it is a simple GET endpoint that can be accessed directly from a browser. Other endpoints require request bodies and are tested using Scalar.

### ✅ Verification

- Docker image builds successfully
- Container starts successfully
- API listens on port 8080
- Health endpoint returns HTTP 200 OK

---

## ⚙️ CI/CD pipeline

The project uses GitHub Actions to automate testing, containerization, and cloud deployment. Both pipelines run automatically on pull requests and updates to the `dev` and `main` branches.

### CI (Continuous Integration)

Ensures that new code is validated before being merged.

- `Pull Request Validation` → Runs automatically on pull requests targeting `dev` and `main`.
- `Restore` → Restores all project dependencies and NuGet packages.
- `Build` → Compiles the solution to verify that the application builds successfully.
- `Test` → Runs automated tests to verify application functionality.

### CD (Continuous Deployment)

Automates the deployment process to Azure.

- `Pull Request & Branch Trigger` → Runs on updates and pull requests for `dev` and `main`.
- `Azure Login` → Authenticates GitHub Actions with Azure.
- `ACR Login` → Connects to Azure Container Registry.
- `Docker Build` → Builds a Docker image of the application.
- `Docker Push` → Pushes the image to Azure Container Registry.
- `Azure Deployment` → Deploys the latest container image to Azure Container Apps.

---

## 🌿 Git Workflow

- `main` → Protected production branch.
- `dev` → Protected default development branch.
- `Feature Branches` → Created from `dev` for all development work.
- `Pull Requests` → Required before merging changes into `dev`.
- `Code Review` → Changes are reviewed before being merged.
- `Final Release` → Completed work is merged from `dev` into `main`.

---

## 🔐 GitHub Secrets

- `AZURE_CREDENTIALS` → Stores Azure login credentials for the CD pipeline.

Used for:

- Azure authentication
- ACR access
- Automated deployment

No credentials are stored in source code.

---

## 📦 Azure Container Registry (ACR)

ACR is used to:

- Store Docker images
- Version container builds
- Provide deployment source for Azure

Workflow:

```text
GitHub Actions
      ↓
Docker Build
      ↓
Push to ACR
      ↓
Container App Pulls Image
```

---

## ☁️ Azure Deployment

The application is deployed to Azure using:

- Azure Container Registry
- Azure Container Apps
- Azure Key Vault
- Managed Identity

This provides a production-like cloud environment.

---

## 📦 Azure Container Apps

Azure Container Apps hosts the API.

Benefits:

- Fully managed service
- Automatic scaling
- Simplified container hosting
- Native integration with Azure services

---

## 🔑 Azure Key Vault

- `Grok API Key` → Stored securely in Azure Key Vault.

Benefits:

- Secure secret storage
- No secrets stored in source code
- Centralized secret management


---

## 🛡 Managed Identity and RBAC

Managed Identity allows Azure services to authenticate securely without storing credentials.

RBAC permissions are assigned to:

- Read secrets from Key Vault
- Access required Azure resources

Benefits:

- No hardcoded credentials
- Principle of least privilege
- Improved security

---

## ✅ API Endpoints

- `GET /health` → Verifies that the API is running and responding correctly.
- `GET /travel/save` → Reserved for future database persistence functionality.
- `POST /travel/destinations` → Returns destination suggestions based on budget, travel days, and departure date.
- `POST /travel/plan` → Generates a complete AI-powered travel plan for the selected destination.


---

## 📊 Monitoring and Logging

Monitoring is implemented through:

### AIRequestLogger

Tracks:

- Response time
- Success rate
- Failed requests
- Trace IDs

### Azure Monitoring

Used to:

- View application logs
- Troubleshoot issues
- Verify deployments

---

## 📄 Evaluation.md

The project includes a separate evaluation document covering:

- 🤖 AI Quality – Response accuracy
- ⚠️ Limitations and Risks – Known challenges
- 🛡️ Mitigations – Error handling
- 🔐 Security – Secret protection
- 🔄 Fullstack Flow – System communication
- ✅ Conclusion – Final reflection

---

## ▶️ How to Run the Project

### Clone Repository

```bash
git clone https://github.com/Abdalle-Abdulkadir/K5-Project-i-Team-TravelPlanner-Backend.git
```

### Restore Dependencies

```bash
dotnet restore TravelPlanner.Api.slnx
```

### Run Automated Tests

```bash
dotnet test TravelPlanner.Tests
```

### Run the API

```bash
dotnet run --project TravelPlanner.Api
```

### Build Docker Image

```bash
docker build -t travelplanner-api ./TravelPlanner.Api
```

### Run Docker Container

```bash
docker run -p 8080:8080 travelplanner-api
```


## 🧪 Automated Tests

The project includes automated xUnit tests covering validation rules, controllers, services, caching, and AI integration.

### ✅ Test Coverage

- 📋 TravelValidationTests
  - Budget must be greater than 1000 SEK
  - Days must be greater than 0
  - Departure date must be tomorrow or later

- 🎮 ControllerTests
  - Valid requests return HTTP 200 OK
  - Invalid requests return HTTP 400 Bad Request

- 🤖 GrokAIServiceTests
  - Valid AI responses are parsed correctly
  - Invalid API keys are handled properly

- ⚡ ServiceTests
  - TravelService calls the AI service correctly
  - Caching behavior is verified

All tests run automatically in the GitHub Actions CI pipeline.

---

## ⭐ Key Features

- AI-powered destination recommendations
- AI-generated travel plans
- Custom exception handling
- Global error middleware
- Request caching
- Automated testing
- Docker containerization
- Azure deployment
- CI/CD pipelines
- Azure Key Vault integration
- Managed Identity authentication
- Application monitoring and logging

---

## 📸 Screenshots

The project contains screenshots demonstrating error handling.

- `Invalid API Key` → Authentication failure.
- `Rate Limiting` → API rate limit handling.
- `Timeout Test` → Request timeout handling.
- `Wrong Endpoint Path` → Invalid endpoint handling.


---

## 👨‍💻 Author

### Abdalle Abdulkadir
### Sepideh ShoghiRabani





