## 4. Project Responsibilities

### 4.1 Server.UI

- Implements the Blazor Server UI.
- Contains UI components, pages, and UI logic.
- Consumes services exposed by `Application.Services` and interfaces from `Application`.
- Should not depend directly on `Infrastructure`.

### 4.2 Application

- Contains use cases, command/query handlers, interfaces, and DTO abstractions.
- Orchestrates business workflows and mediates communication between UI and domain layers.
- Holds interfaces for repositories and service abstractions.
- Follows the CQRS pattern where applicable.

### 4.3 Infrastructure

- Implements persistence with Entity Framework Core.
- Provides implementations for repositories and other service interfaces declared in `Application`.
- Integrates external services (e.g., email, file storage).
- Contains database migrations.

### 4.4 Domain

- Contains domain-level interfaces (e.g., marker interfaces like `IAggregateRoot`).
- Shared domain enums and constants.
- Defines the core domain logic that is independent of infrastructure.

### 4.5 Application.Core

- **All custom domain code (DTOs, Entities, Value Objects, Mapping Profiles) should reside here.**
- Holds core business entities, Data Transfer Objects (DTOs), and Value Objects.
- Defines mapping profiles (e.g., AutoMapper configurations).
- Contains domain events and specifications.
- Acts as the domain model project, encapsulating business rules and logic.
- This project is designed to be application-agnostic and reusable across multiple solutions.

### 4.6 Application.Services

- **All custom business logic, domain services, and service implementations should reside here.**
- Implements domain services encapsulating complex business logic that does not naturally fit inside entities or value objects.
- Services here can be independently tested and reused.
- These services depend on abstractions from the `Application` project and may depend on infrastructure implementations for persistence.
