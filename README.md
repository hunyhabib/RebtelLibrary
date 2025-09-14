# RebtelLibrary

## How to Run Library Management

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started)

### Running with Docker Compose

1. Open Visual Studio And Run The Docker Compose.
2. This will start:
	- API service (`rebtel.librarymanagement.api`) on ports 8080 (HTTP) and 8081 (HTTPS)
	- GRPC service (`rebtel.librarymanagement.grpc`) on ports 8088 (HTTP) and 8089 (HTTPS)
	- SQL Server (`sqldata`) on port 1433

## Project Structure & Best Practices

This project follows several modern software engineering best practices:

### Domain-Driven Design (DDD)

- **Aggregates**: Core domain entities like `Book`, `User`, and `BorrowRecord` are modeled as aggregates in the `Domain` layer.
- **Repositories**: Domain repositories abstract data access and enforce aggregate boundaries.

### CQRS (Command Query Responsibility Segregation)

- **Commands & Queries**: The `Application` layer separates commands (write operations) and queries (read operations) using MediatR.
- **Handlers**: Each command/query has a dedicated handler, promoting single responsibility and testability.

### Clean Architecture

- **Layered Structure**:
  - `Domain`: Business logic and domain models
  - `Application`: Use cases, commands, queries, and behaviors
  - `Infrastructure`: Data access, migrations, and external integrations
  - `Api` & `GRPC`: Presentation layers
- **Dependency Inversion**: Core logic does not depend on infrastructure or presentation.

### Other Practices

- **HTTPS**
- **Open Telemetry**: For Metrics and Traces
- **Health Endpoints** : For k8s compliance and health checks.
- **API Versioning**
- **Problem Details** : For Standard Exepction structure
- **Testing**: Unit and integration tests are provided in the `tests` folder, using xUnit and Moq and Test Containers.

## Contact

For questions or support, please contact the project maintainer.