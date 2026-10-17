# Chapter 1 Companion Guide: Software Engineering Fundamentals and the .NET Ecosystem

Welcome to the Chapter 1 companion documentation for Scrumble, the reference agile project management SaaS platform from *Modern Software Engineering with Enterprise .NET 10*.

---

## 1. Chapter 1 Overview

Chapter 1 establishes the foundational engineering principles, Clean Architecture structure, DDD building blocks, testing harness, and operational standards for Scrumble:
- **Architecture Style:** Modular Monolith (ADR-001)
- **Framework:** .NET 10 SDK (`net10.0`), C# 14
- **Core Entities:** `Organization`, `OrganizationMember`, `User`
- **Quality & Standards:** `.editorconfig`, Git commit hook, GitHub Actions CI workflow, Docker Compose stack

---

## 2. Prerequisites

- **.NET 10 SDK** (version 10.0.100 or later; verified on SDK 10.0.402)
- **Git** (version 2.40+)
- **Docker Desktop** (v24+ / Compose v2) for local service containers
- **IDE:** Visual Studio 2026, JetBrains Rider, or VS Code with C# Dev Kit

---

## 3. Chapter 1 Folder Tree

```text
Scrumble/
├── src/
│   ├── Domain/
│   │   ├── Common/
│   │   │   └── IAggregateRoot.cs             # Marker interface (Listing 1.9)
│   │   ├── Entities/
│   │   │   ├── Organization.cs               # Aggregate root & OrganizationRole enum (Listing 1.6)
│   │   │   ├── OrganizationMember.cs         # Membership entity (Listing 1.7)
│   │   │   └── User.cs                       # User entity (Listing 1.8)
│   │   ├── Exceptions/
│   │   │   └── DomainException.cs            # Custom domain exception (Listing 1.10)
│   │   └── Scrumble.Domain.csproj
│   ├── Application/
│   │   └── Scrumble.Application.csproj
│   ├── Contracts/
│   │   └── Scrumble.Contracts.csproj
│   ├── Infrastructure/
│   │   └── Scrumble.Infrastructure.csproj
│   └── Web/
│       ├── Program.cs                        # Minimal API host entry point
│       └── Scrumble.Web.csproj
├── tests/
│   ├── Domain.Tests/
│   │   ├── Entities/
│   │   │   └── OrganizationTests.cs          # Unit tests (Listing 1.11 + boundary cases)
│   │   └── Scrumble.Domain.Tests.csproj
│   ├── Application.Tests/
│   │   └── Scrumble.Application.Tests.csproj
│   └── Integration.Tests/
│       └── Scrumble.Integration.Tests.csproj
├── docs/
│   ├── adr/
│   │   └── ADR-001-modular-monolith.md       # Architecture Decision Record (Section 1.4.5)
│   ├── architecture/
│   │   └── adr/
│   │       └── ADR-001-modular-monolith.md   # Architectural mirror
│   └── chapter01/
│       ├── non-executable/
│       │   └── Illustrative-Snippets.md      # Preserved illustrative / non-executable snippets
│       ├── README.md                         # This file
│       ├── Code-Inventory.md                 # Complete catalog of all Chapter 1 artifacts
│       ├── Implementation-Crosswalk.md       # Artifact-to-code traceability crosswalk
│       ├── Manuscript-Corrections.md         # Discrepancies and recommended errata
│       └── Validation-Report.md              # Test execution and verification results
├── tools/
│   └── git-hooks/
│       └── commit-msg                        # Conventional commit enforcement hook (Listing 1.18)
├── .github/
│   ├── workflows/
│   │   └── ci.yml                            # GitHub Actions CI workflow (Listing 1.19)
│   └── branch-protection.yml                 # Conceptual branch protection specification (Listing 1.13)
├── docker-compose.yml                        # SQL Server, Redis, RabbitMQ (Listing 1.20)
├── .editorconfig                             # Code style and formatting rules (Listing 1.22)
├── Scrumble.ps1                              # Solution and project setup script (Listing 1.3)
├── Scrumble.slnx                             # .NET 10 solution file
└── README.md                                 # Root repository documentation
```

---

## 4. Where Chapter 1 Examples Are Found

| Manuscript Reference | Example Description | Source Location |
| :--- | :--- | :--- |
| Section 1.4.5 | ADR-001 Modular Monolith | `docs/adr/ADR-001-modular-monolith.md` |
| Listing 1.3 | Solution Setup Script | `Scrumble.ps1` |
| Listing 1.4 | Constructor Injection (DI) | `docs/chapter01/non-executable/Illustrative-Snippets.md` |
| Listing 1.5 | Hard-Coded Dependency (Anti-pattern) | `docs/chapter01/non-executable/Illustrative-Snippets.md` |
| Listing 1.6 | Organization Aggregate & Role Enum | `src/Domain/Entities/Organization.cs` |
| Listing 1.7 | OrganizationMember Entity | `src/Domain/Entities/OrganizationMember.cs` |
| Listing 1.8 | User Entity | `src/Domain/Entities/User.cs` |
| Listing 1.9 | IAggregateRoot Marker | `src/Domain/Common/IAggregateRoot.cs` |
| Listing 1.10 | DomainException | `src/Domain/Exceptions/DomainException.cs` |
| Listing 1.11 | Organization Unit Tests | `tests/Domain.Tests/Entities/OrganizationTests.cs` |
| Listing 1.13 | Branch Protection Policy | `.github/branch-protection.yml` |
| Listing 1.18 | Git Commit Message Hook | `.git/hooks/commit-msg` & `tools/git-hooks/commit-msg` |
| Listing 1.19 | GitHub Actions Workflow | `.github/workflows/ci.yml` |
| Listing 1.20 | Docker Compose Infrastructure | `docker-compose.yml` |
| Listing 1.22 | Coding Standards | `.editorconfig` |

---

## 5. Safe Setup, Run, and Test Commands

### 5.1 Restoring and Building
```shell
dotnet restore Scrumble.slnx
dotnet build Scrumble.slnx --no-restore
```
*Expected Result:* Build succeeds with 0 errors and 0 warnings.

### 5.2 Running Domain Unit Tests
```shell
dotnet test tests/Domain.Tests
```
*Expected Result:* 21 passed, 0 failed, duration < 1 second.

### 5.3 Verifying Coding Standards
```shell
dotnet format --verify-no-changes
```
*Expected Result:* Exits with code 0 and no formatting violations reported.

### 5.4 Starting Local Dependencies (Docker)
Ensure your environment variables are configured in your shell or local environment:
```shell
# Set local development passwords
$env:SCRUMBLE_SQL_PASSWORD = "YourStrong!Password123"
$env:SCRUMBLE_RABBITMQ_PASSWORD = "YourStrong!RabbitPassword123"

# Start SQL Server, Redis, and RabbitMQ
docker compose up -d
```
To stop the services:
```shell
docker compose down
```

---

## 6. Detailed Chapter 1 Reports

- [Complete Code Inventory](Code-Inventory.md)
- [Implementation Crosswalk](Implementation-Crosswalk.md)
- [Manuscript Corrections and Errata](Manuscript-Corrections.md)
- [Verification and Validation Report](Validation-Report.md)
