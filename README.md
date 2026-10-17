# Scrumble — Chapter 1: Enterprise .NET 10 Foundations

> Companion codebase for **Chapter 1 ("Software Engineering Fundamentals and the .NET Ecosystem")** of *Modern Software Engineering with Enterprise .NET 10*.

Scrumble is a multi-tenant Software-as-a-Service (SaaS) platform for agile project management. This repository branch (`Chapter-1`) establishes the foundational architecture, domain model, coding standards, automated testing baseline, and continuous integration pipeline using modern **.NET 10**.

---

## Scope and Learning Outcomes

In Chapter 1, the foundational solution structure and core engineering standards are put into practice:

- **Clean Architecture & Dependency Rule:** Structuring a modular solution where dependencies strictly flow inward toward the pure domain layer.
- **Domain-Driven Design (DDD) Basics:** Modeling the core `Organization` aggregate root, `OrganizationMember`, and `User` entities while enforcing business invariants and throwing descriptive domain exceptions (`DomainException`).
- **Automated Testing Baseline:** Implementing thorough unit tests for domain invariants using xUnit, establishing a zero-failure regression baseline.
- **Code-Quality & Formatting Gates:** Enforcing unified enterprise styling, file-scoped namespaces, and formatting via [.editorconfig](.editorconfig) and `dotnet format`.
- **Continuous Integration (CI):** Formulating a declarative build, lint, and test pipeline via GitHub Actions ([.github/workflows/ci.yml](.github/workflows/ci.yml)) with strict NuGet audit enforcement.
- **Local Infrastructure Orchestration:** Declarative definitions for containerized local dependencies (SQL Server, Redis, RabbitMQ) using [docker-compose.yml](docker-compose.yml).

---

## Repository Structure

```text
Scrumble/
├── .editorconfig                          # Enterprise coding standards and style rules
├── .github/
│   ├── branch-protection.yml              # Conceptual branch protection specification (Listing 1.13)
│   └── workflows/
│       └── ci.yml                         # GitHub Actions CI build, test, and audit workflow
├── .gitignore                             # Repository exclusion rules (.NET, IDEs, secrets, AI tools)
├── docker-compose.yml                     # Local containerized infrastructure (SQL Server, Redis, RabbitMQ)
├── docs/
│   ├── adr/
│   │   └── ADR-001-modular-monolith.md    # Architectural Decision Record: Modular Monolith
│   ├── architecture/
│   │   └── adr/
│   │       └── ADR-001-modular-monolith.md
│   └── chapter01/
│       ├── Code-Inventory.md              # Catalog of all Chapter 1 artifacts (CH01-001 to CH01-036)
│       ├── Implementation-Crosswalk.md    # Mapping of manuscript listings to repository files
│       ├── Manuscript-Corrections.md      # Audited discrepancies and technical errata
│       ├── README.md                      # Chapter 1 overview and architectural guide
│       ├── Validation-Report.md           # Independent test and build verification report
│       └── non-executable/
│           └── Illustrative-Snippets.md   # Non-executable pedagogical code and prompt templates
├── README.md                              # Branch-specific reader documentation
├── Scrumble.ps1                           # Solution and project automation bootstrap script
├── Scrumble.slnx                          # Modern .NET 10 solution definition
├── src/
│   ├── Application/                       # Use cases, application contracts, and ports
│   │   ├── Class1.cs                      # Application boundary placeholder
│   │   └── Scrumble.Application.csproj
│   ├── Contracts/                         # Shared integration data transfer objects (DTOs)
│   │   ├── Class1.cs                      # Contracts boundary placeholder
│   │   └── Scrumble.Contracts.csproj
│   ├── Domain/                            # Pure domain layer: entities, invariants, and exceptions
│   │   ├── Common/
│   │   │   └── IAggregateRoot.cs          # Aggregate root marker interface
│   │   ├── Entities/
│   │   │   ├── Organization.cs            # Organization aggregate root & OrganizationRole enum
│   │   │   ├── OrganizationMember.cs      # Membership entity with role assignment
│   │   │   └── User.cs                    # User entity with identity and profile rules
│   │   ├── Exceptions/
│   │   │   └── DomainException.cs         # Domain-level violation exception
│   │   └── Scrumble.Domain.csproj
│   ├── Infrastructure/                    # Adapters, persistence implementations, external clients
│   │   ├── Class1.cs                      # Infrastructure boundary placeholder
│   │   └── Scrumble.Infrastructure.csproj
│   └── Web/                               # ASP.NET Core 10 Minimal APIs host & composition root
│       ├── appsettings.Development.json
│       ├── appsettings.json
│       ├── Program.cs                     # Web API entry point and composition root
│       ├── Properties/
│       │   └── launchSettings.json
│       ├── Scrumble.Web.csproj
│       └── Scrumble.Web.http
├── tests/
│   ├── Application.Tests/                 # Application use-case tests
│   │   ├── Scrumble.Application.Tests.csproj
│   │   └── UnitTest1.cs                   # Application test placeholder
│   ├── Domain.Tests/                      # Comprehensive unit tests for domain entities and invariants
│   │   ├── Entities/
│   │   │   └── OrganizationTests.cs       # 21 unit tests covering all core & boundary invariants
│   │   └── Scrumble.Domain.Tests.csproj
│   └── Integration.Tests/                 # Web API and end-to-end integration tests
│       ├── Scrumble.Integration.Tests.csproj
│       └── UnitTest1.cs                   # Integration test placeholder
└── tools/
    └── git-hooks/
        └── commit-msg                     # Conventional Commits format validation hook
```

### Key Documentation Links
- [Chapter 1 Overview & Guide](docs/chapter01/README.md)
- [Chapter 1 Code Inventory](docs/chapter01/Code-Inventory.md)
- [Implementation Crosswalk](docs/chapter01/Implementation-Crosswalk.md)
- [Manuscript Corrections & Errata](docs/chapter01/Manuscript-Corrections.md)
- [Validation Report](docs/chapter01/Validation-Report.md)
- [Illustrative Snippets](docs/chapter01/non-executable/Illustrative-Snippets.md)
- [ADR-001: Modular Monolith](docs/adr/ADR-001-modular-monolith.md)

---

## Prerequisites

Before running or developing against this repository, ensure the following tools are installed:

- **[.NET 10 SDK](https://dotnet.microsoft.com/)**: Version `10.0.100` or later (validated with SDK `10.0.402` on .NET 10.0.13 runtime).
- **[Git](https://git-scm.com/)**: Version `2.40` or later.
- **[Docker Desktop](https://www.docker.com/) / Docker Engine & Compose** *(Optional for Chapter 1)*: Required if starting local infrastructure services.
- **PowerShell / Bash**: PowerShell 7+ on Windows or standard POSIX shells on Linux/macOS.

---

## Quick Start

### 1. Clone & Switch to the Chapter 1 Branch
```powershell
git clone <repository-url>
cd Scrumble
git checkout Chapter-1
```

### 2. Restore Dependencies
Restore all solution project dependencies and execute NuGet security audits:
```powershell
dotnet restore Scrumble.slnx
```

### 3. Build the Solution
Compile the complete solution without re-restoring:
```powershell
dotnet build Scrumble.slnx --no-restore
```

### 4. Execute the Test Suite
Run all unit and placeholder test suites across the solution:
```powershell
dotnet test Scrumble.slnx --no-build
```
Alternatively, run individual test projects:
```powershell
dotnet test tests/Domain.Tests
dotnet test tests/Application.Tests
dotnet test tests/Integration.Tests
```

### 5. Check Code Formatting
Verify compliance with [.editorconfig](.editorconfig) rules without modifying files:
```powershell
dotnet format Scrumble.slnx --verify-no-changes
```

### 6. Solution Bootstrap Script (`Scrumble.ps1`)
The repository includes [Scrumble.ps1](Scrumble.ps1), which corresponds to Listing 1.3 in the manuscript. This script automates the creation of the solution file, class libraries, test projects, and inter-project references from scratch according to the Clean Architecture dependency rule. In an existing clone, you do not need to re-run this script, but it serves as an executable reference for greenfield bootstrapping.

---

## Optional Local Infrastructure

Chapter 1 provides a declarative [docker-compose.yml](docker-compose.yml) specifying three local services:
- **SQL Server 2022** (`mcr.microsoft.com/mssql/server:2022-latest`): Port `1433`.
- **Redis 7** (`redis:7-alpine`): Port `6379`.
- **RabbitMQ 4 with Management UI** (`rabbitmq:4-management-alpine`): Ports `5672` (AMQP) and `15672` (Management Dashboard).

### Configuration
The Compose file employs required environment variable substitutions to prevent startup with default or missing passwords:
```powershell
$env:SCRUMBLE_SQL_PASSWORD="YourStrong(!)Password"
$env:SCRUMBLE_RABBITMQ_PASSWORD="YourRabbitMQ(!)Password"
docker compose up -d
```
> **Notice:** Running containers is completely optional for Chapter 1. The chapter focuses on domain modeling and testing foundations; live database persistence and message brokers are activated in Chapters 3, 4, and 8. Local validation was conducted on the compiled solution without launching background containers.

---

## Testing Status and Limitations

The test harness currently consists of **23 passing tests**:
- **`Domain.Tests` (21 Tests):** Full unit test suite validating the `Organization`, `OrganizationMember`, and `User` domain entities, role assignment transitions, null checks, whitespace boundaries, duplicate member rejections, and domain exceptions.
- **`Application.Tests` (1 Test):** Starter template test (`UnitTest1.cs`). Application services and command handlers will be implemented and tested in Chapter 2.
- **`Integration.Tests` (1 Test):** Starter template test (`UnitTest1.cs`). End-to-end integration tests using WebApplicationFactory and Testcontainers will be implemented in subsequent chapters.

### CI Pipeline vs Hosted Execution
- The CI pipeline defined in [.github/workflows/ci.yml](.github/workflows/ci.yml) has been verified for schema correctness and command parity with local CLI runs.
- Note that hosted execution on GitHub Actions runners will take place upon pushing to a remote repository with GitHub Actions enabled.

---

## Architecture Decisions

The architectural foundation of Scrumble is governed by Architecture Decision Records located in [docs/adr/](docs/adr/):

- **[ADR-001: Modular Monolith](docs/adr/ADR-001-modular-monolith.md):** Adopts a Modular Monolith architecture within a single deployable unit, organizing code around domain boundaries rather than premature distributed microservices.

### Clean Architecture Boundary Rules
The project adheres to the strict Clean Architecture dependency rule:
1. **Domain (`src/Domain`):** Pure enterprise business logic. No dependencies on external frameworks, databases, or transport layers.
2. **Application (`src/Application`):** Use cases, orchestrators, and port definitions. References `Domain` and `Contracts`.
3. **Infrastructure (`src/Infrastructure`):** Adapters for databases, messaging, caching, and external APIs. References `Application` and `Domain`.
4. **Web (`src/Web`):** Composition root and HTTP endpoint hosting. References `Application`, `Infrastructure`, and `Contracts`.
5. **Contracts (`src/Contracts`):** Shared transport DTOs and integration messages. Zero dependencies on internal domain logic.

Dependencies always point inward: `Web` -> `Application` -> `Domain` <- `Infrastructure`.

---

## Traceability and Chapter Mapping

Every code listing and architectural concept from Chapter 1 is cataloged and traceable:
- **[Code Inventory](docs/chapter01/Code-Inventory.md):** Exhaustive inventory of artifacts CH01-001 through CH01-036.
- **[Implementation Crosswalk](docs/chapter01/Implementation-Crosswalk.md):** Section-by-section mapping linking manuscript listings to source files.
- **[Illustrative Snippets](docs/chapter01/non-executable/Illustrative-Snippets.md):** Illustrative and pedagogical code snippets (such as dependency injection anti-patterns, prompt engineering templates, and Testcontainers exercise scaffolds) preserved for study.
- **[Manuscript Corrections](docs/chapter01/Manuscript-Corrections.md):** Technical observations, POSIX hook permissions, and recommendations regarding the manuscript text.

---

## Branch and Contribution Conventions

- **Branch Checkpoint:** The `Chapter-1` branch represents the canonical, frozen milestone for Chapter 1. Subsequent chapters branch from or extend this foundation.
- **Quality Gates:** Any modification must satisfy:
  - Clean build without errors (`dotnet build Scrumble.slnx`).
  - Zero test failures across all test projects (`dotnet test Scrumble.slnx`).
  - Strict compliance with formatting rules (`dotnet format Scrumble.slnx --verify-no-changes`).
- **Commit Message Convention:** All commits follow the [Conventional Commits](https://www.conventionalcommits.org/) specification:
  - Types: `feat`, `fix`, `docs`, `style`, `refactor`, `perf`, `test`, `chore`.
  - Format: `<type>(<scope>): <subject>` (e.g., `feat(chapter-1): publish Scrumble .NET 10 foundation`).
  - A Git validation hook is provided in [tools/git-hooks/commit-msg](tools/git-hooks/commit-msg) and can be activated by copying it to `.git/hooks/commit-msg`.

---

## Known Limitations and Next Steps

As Chapter 1 establishes the baseline architecture, several planned capabilities will be introduced in subsequent chapters:
1. **Application Layer Logic:** Currently contains placeholder types; use case interactors, CQRS commands, and queries will be introduced in Chapter 2.
2. **Persistence and EF Core:** Domain entities are currently in-memory only; Entity Framework Core configurations, migrations, and database seeding occur in Chapter 3.
3. **HTTP Endpoints & API Gateway:** Minimal API endpoints and Swagger/OpenAPI documentation will be expanded in Chapter 2 and Chapter 4.
4. **Integration Testing Harness:** Testcontainers-based integration testing with real SQL Server and RabbitMQ containers will be integrated in subsequent chapters.
