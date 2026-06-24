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

# 🛠 Technologies

### Backend

- ASP.NET Core 9
- C#
- Entity Framework Core
- SQL Server
- Grok AI API

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
- ASP.NET Core Testing

---

# 📂 Project Structure

## Controllers

### TravelController

Handles incoming API requests for:

- Destination suggestions
- Travel plan generation

---

## Services

### TravelService

Business logic layer responsible for:

- Request handling
- Caching
- Database operations
- Communication with AI services

### GrokAIService

Handles communication with Grok AI.

Responsibilities:

- AI prompt generation
- API communication
- Response parsing
- Error handling
- Logging

---

## Models

### TravelRequest

Stores:

- Budget
- Travel days
- Departure date
- Departure location

### TravelResponse

Stores:

- Selected destination
- Estimated cost
- Travel plan
- Quality notes
- Summary
- Trace ID

---

## DTOs

### Requests

Used to receive client input.

Examples:

- DestinationRequestDto
- TravelPlanRequestDto

### Responses

Used to return API responses.

Examples:

- DestinationResponseDto
- TravelPlanResponseDto

---

## Middleware

### GlobalExceptionMiddleware

Centralized exception handling.

Provides:

- Consistent error responses
- Custom status codes
- Cleaner controller logic

---

## Exceptions

### AppException

Custom exception system for:

- Authentication failures
- Rate limits
- Timeouts
- Unexpected errors

---

## Logging

### AIRequestLogger

Tracks:

- Response times
- Success responses
- Failed requests
- Trace IDs

---

## Tests

### ControllerTests

Verifies controller behavior.

### ServiceTests

Verifies TravelService functionality.

### GrokAIServiceTests

Verifies:

- AI response parsing
- Authentication failures
- Error handling

### ValidationTests

Verifies:

- Budget validation
- Travel days validation
- Departure date validation

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

# ⚙️ CI/CD Pipeline

## CI Workflow

Responsible for:

✅ Restore dependencies

✅ Build application

✅ Execute automated tests

✅ Verify code quality

Runs automatically on Pull Requests.

---

## CD Workflow

Responsible for:

✅ Azure authentication

✅ Docker image build

✅ Push image to Azure Container Registry

✅ Deploy latest image to Azure Container Apps

Runs after deployment approval workflow.

---

# 🔐 GitHub Secrets

The following GitHub Secrets are used:

- AZURE_CREDENTIALS

Secrets are never stored in source control.

---

# 📦 Azure Container Registry (ACR)

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

# ☁️ Azure Deployment

The application is deployed to Azure using:

- Azure Container Registry
- Azure Container Apps
- Azure Key Vault
- Managed Identity

This provides a production-like cloud environment.

---

# 📦 Azure Container Apps

Azure Container Apps hosts the API.

Benefits:

- Fully managed service
- Automatic scaling
- Simplified container hosting
- Native integration with Azure services

---

# 🔑 Azure Key Vault

Azure Key Vault stores sensitive configuration values.

Examples:

- API Keys
- Connection strings
- Secrets

Benefits:

- Secure storage
- Centralized secret management
- No secrets inside source code

---

# 🛡 Managed Identity and RBAC

Managed Identity allows Azure services to authenticate securely without storing credentials.

RBAC permissions are assigned to:

- Read secrets from Key Vault
- Access required Azure resources

Benefits:

- No hardcoded credentials
- Principle of least privilege
- Improved security

---

# ✅ Verification Endpoint

The application includes endpoints used to verify:

- API functionality
- AI integration
- Deployment health

These endpoints help validate successful deployments.

---

# 📊 Monitoring and Logging

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

# 📝 Evaluation.md

The project includes an Evaluation.md document.

Contents:

- Project reflection
- Technical decisions
- Challenges encountered
- Lessons learned
- Future improvements

---

# ▶️ How to Run the Project

## Clone Repository

```bash
git clone <repository-url>
```

---

## Restore Dependencies

```bash
dotnet restore
```

---

## Run API

```bash
dotnet run
```

---

## Run Tests

```bash
dotnet test
```

---

## Build Docker Image

```bash
docker build -t travelplanner .
```

---

## Run Docker Container

```bash
docker run -p 8080:8080 travelplanner
```

---

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

# ⭐ Key Features

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

# 📸 Screenshots

The project contains a Screenshots folder showing:

- Validation errors
- User input validation
- Application behavior
- Test results

---

# 👨‍💻 Author

### Abdalle Abdulkadir
### Sepideh ShoghiRabani

K5 Project in Team

Chas Academy

Cloud, DevOps & AI Integration


