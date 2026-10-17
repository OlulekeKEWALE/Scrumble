# Chapter 1 Non-Executable and Illustrative Snippets

This document records the illustrative, conceptual, and non-executable code snippets from Chapter 1 of *Modern Software Engineering with Enterprise .NET 10*. In accordance with engineering standards, these snippets are preserved in their original context with explicit **NOT EXECUTABLE** labels.

---

### Listing 1.4: Constructor Injection (C#)
- **Status:** `NOT EXECUTABLE` (Pedagogical illustration / partial snippet)
- **Manuscript Section:** 1.5.4 Dependency Injection
- **Context:** Demonstrates good dependency injection practice by decoupling the creator from the repository implementation.
```csharp
// NOT EXECUTABLE: Pedagogical snippet illustrating constructor injection
public class OrganizationCreator
{
    private readonly IOrganizationRepository _repo;

    // Dependency is injected through constructor
    public OrganizationCreator(IOrganizationRepository repo)
    {
        _repo = repo;
    }

    public async Task<Organization> CreateAsync(CreateOrganizationCommand command)
    {
        // ...
    }
}
```

---

### Listing 1.5: Hard-Coded Repository Dependency (C#)
- **Status:** `NOT EXECUTABLE` (Pedagogical anti-pattern illustration)
- **Manuscript Section:** 1.5.4 Dependency Injection
- **Context:** Illustrates the negative anti-pattern of tightly coupling a domain/application service directly to an infrastructure implementation.
```csharp
// NOT EXECUTABLE: Anti-pattern illustration
public class OrganizationCreator
{
    // Hard-coded implementation—can't test, can't swap, tightly coupled
    private readonly SqlOrganizationRepository _repo = new();

    public async Task<Organization> CreateAsync(CreateOrganizationCommand command)
    {
        // ...
    }
}
```

---

### Listing 1.13: Conceptual Branch Protection Policy (YAML)
- **Status:** `ILLUSTRATIVE CONFIGURATION` (Conceptual GitHub branch protection specification)
- **Manuscript Section:** 1.6.1 Git Strategy
- **Context:** Describes the intended branch protection rules for the `main` branch. GitHub branch protection is configured via repository settings/rulesets rather than automatically parsed from this file.
```yaml
# .github/branch-protection.yml (conceptual)
main:
  requires_approval: true
  required_approvals: 1
  requires_status_checks: true
  required_status_checks:
    - Build and Test
    # Formatting and dependency audit run inside Build and Test.
    # Add other required checks only when those checks actually exist.
```

---

### Listing 1.15: Conventional Commit Format (Text)
- **Status:** `SPECIFICATION / NON-CODE`
- **Manuscript Section:** 1.6.2 Commit Standards
- **Context:** Defines the structure of commit messages enforced by the Git hook.
```text
<type>(<scope>): <description>

[optional body]

[optional footer(s)]
```

---

### Listing 1.16: Feature Commit Example (Text)
- **Status:** `SPECIFICATION / EXAMPLE`
- **Manuscript Section:** 1.6.2 Commit Standards
- **Context:** Example of a conventional commit introducing the Organization aggregate root.
```text
feat(domain): add Organization aggregate root

Introduces the Organization entity with member management.
Includes domain events for member addition/removal.

Closes #12
```

---

### Listing 1.17: Fix Commit Example (Text)
- **Status:** `SPECIFICATION / EXAMPLE`
- **Manuscript Section:** 1.6.2 Commit Standards
- **Context:** Example of a conventional commit fixing tenant authorization.
```text
fix(api): authorize requested tenant

Reject a requested tenant when the authenticated user has no active membership.

Fixes #45
```

---

### Listing 1.23: Architecture Evolution (Text)
- **Status:** `SPECIFICATION / ARCHITECTURE ROADMAP`
- **Manuscript Section:** 1.7.3 Architect's Corner
- **Context:** Strategic roadmap for the evolution of the modular monolith.
```text
Step 1: Modular monolith (now)
Step 2: Extract bounded context to separate service (later)
Step 3: Multiple services with event-driven communication
```

---

### Listing 1.24: AI Prompt for a Domain Entity (Text)
- **Status:** `PROMPT / NON-CODE`
- **Manuscript Section:** 1.7.5 AI Companion
```text
You are a .NET 10 expert building an enterprise project management SaaS called Scrumble. We use Clean Architecture and Domain-Driven Design.

Create a domain entity for a "Project" that:
- Has an Id (Guid)
- Has a Name (string, required, max 200 chars)
- Has a Key (value object, must be 3-4 uppercase letters)
- Belongs to an Organization (by OrganizationId)
- Contains a collection of WorkItems

Use C# 14 features: records for value objects, primary constructors where appropriate.
```

---

### Listing 1.25: AI Prompt for Unit Tests (Text)
- **Status:** `PROMPT / NON-CODE`
- **Manuscript Section:** 1.7.5 AI Companion
```text
Given this Organization entity, generate xUnit unit tests for:
1. Creating an organization (success case)
2. Creating an organization with invalid data (failure cases)
3. Adding a member (success)
4. Adding a duplicate member (failure)
5. Removing a member (success)
6. Removing a non-existent member (failure)

Use the test structure from Chapter 1 of the book.
```

---

### Listing 1.26: AI Prompt for a Container Diagram (Text)
- **Status:** `PROMPT / NON-CODE`
- **Manuscript Section:** 1.7.5 AI Companion
```text
Create a C4 Container diagram (using Mermaid) for a modular monolith called Scrumble.

Containers:
- Web API (ASP.NET Core 10)
- Background Worker (.NET 10)
- SQL Server
- Redis
- RabbitMQ
- Blob Storage

Show interactions between containers.
```

---

### Listing 1.27: AI Prompt for an Architecture Decision (Text)
- **Status:** `PROMPT / NON-CODE`
- **Manuscript Section:** 1.7.5 AI Companion
```text
Write an Architecture Decision Record (ADR) for choosing Clean Architecture over N-tier for a new enterprise SaaS application.

Include:
- Context
- Decision
- Options considered (with pros/cons)
- Consequences
- Related decisions
- References
```

---

### Listing 1.28: Testcontainers Exercise Scaffold (C#)
- **Status:** `NOT EXECUTABLE` (Pedagogical exercise scaffold)
- **Manuscript Section:** 1.7.6 Exercises
- **Context:** Exercise scaffold illustrating how integration tests will initialize Testcontainers in future chapters.
```csharp
// Exercise scaffold, not a complete implementation.
// Add Testcontainers.MsSql and Testcontainers.Redis packages and imports.
// Use xUnit v2 IAsyncLifetime Task methods, or adapt for xUnit v3.
public class IntegrationTestBase : IAsyncLifetime
{
    protected readonly MsSqlContainer SqlContainer;
    protected readonly RedisContainer RedisContainer;

    // Initialize and dispose containers
}
```
