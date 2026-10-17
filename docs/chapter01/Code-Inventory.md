# Chapter 1: Code and Artifact Inventory

This document provides a comprehensive inventory of all code-related artifacts from Chapter 1 ("Software Engineering Fundamentals and the .NET Ecosystem") of *Modern Software Engineering with Enterprise .NET 10*.

**Canonical Manuscript:** `D:\Tech Crafts Studios Ltd\Books & Blogs\Modern Software Engineering with Enterprise .NET 10\Aligned\Chapter_01_Aligned.docx`  
**SHA-256 Hash:** `4A4B13D3EC5F857EB333EC78A82FA1CED47E15A5FBE2CDD7C9782C103DCB334F`

---

## Complete Artifact Listing

| Artifact ID | Section | Title / Description | Artifact Type | Classification | Source Reference |
| :--- | :--- | :--- | :--- | :--- | :--- |
| **CH01-001** | 1.1.1 | 3:17 AM Production Incident: `foreach` loop with `.ToList()` on 2M rows | C# / Inline mention | Illustrative / Anti-pattern | Section 1.1.1 text |
| **CH01-002** | 1.4.5 | Architecture Decision Record #001: Modular Monolith | Markdown / ADR | Architecture Contract | Section 1.4.5 text |
| **CH01-003** | 1.4.6 | Scrumble Repository File Tree | Text / Hierarchy | Architecture Blueprint | Section 1.4.6 figure |
| **CH01-004** | 1.5.1 | .NET SDK version check | Shell / CLI | Command / Diagnostic | Listing 1.1 |
| **CH01-005** | 1.5.1 | GitHub CLI authentication | Shell / CLI | Command / Setup | Listing 1.2 |
| **CH01-006** | 1.5.2 | Solution and project setup script | Shell / PowerShell | Command / Automation | Listing 1.3 / Scrumble.ps1 |
| **CH01-007** | 1.5.4 | Constructor injection example (`OrganizationCreator`) | C# | Illustrative / Fragment | Listing 1.4 |
| **CH01-008** | 1.5.4 | Hard-coded repository dependency anti-pattern | C# | Illustrative / Anti-pattern | Listing 1.5 |
| **CH01-009** | 1.5.5 | Organization aggregate root and `OrganizationRole` enum | C# | Directly Executable | Listing 1.6 (`src/Domain/Entities/Organization.cs`) |
| **CH01-010** | 1.5.5 | Organization membership entity | C# | Directly Executable | Listing 1.7 (`src/Domain/Entities/OrganizationMember.cs`) |
| **CH01-011** | 1.5.5 | User entity | C# | Directly Executable | Listing 1.8 (`src/Domain/Entities/User.cs`) |
| **CH01-012** | 1.5.5 | Aggregate root marker interface (`IAggregateRoot`) | C# | Directly Executable | Listing 1.9 (`src/Domain/Common/IAggregateRoot.cs`) |
| **CH01-013** | 1.5.5 | Domain exception (`DomainException`) | C# | Directly Executable | Listing 1.10 (`src/Domain/Exceptions/DomainException.cs`) |
| **CH01-014** | 1.5.6 | Organization unit tests suite | C# / xUnit | Directly Executable Test | Listing 1.11 (`tests/Domain.Tests/Entities/OrganizationTests.cs`) |
| **CH01-015** | 1.5.6 | Running domain tests command | Shell / CLI | Command / Verification | Listing 1.12 |
| **CH01-016** | 1.6.1 | Conceptual branch protection policy | YAML | Illustrative Configuration | Listing 1.13 (`.github/branch-protection.yml`) |
| **CH01-017** | 1.6.1 | Feature branch workflow commands | Shell / Git CLI | Command / Workflow | Listing 1.14 |
| **CH01-018** | 1.6.2 | Conventional commit format specification | Text | Specification | Listing 1.15 |
| **CH01-019** | 1.6.2 | Feature commit message example | Text | Example / Template | Listing 1.16 |
| **CH01-020** | 1.6.2 | Fix commit message example | Text | Example / Template | Listing 1.17 |
| **CH01-021** | 1.6.2 | Commit message validation hook | Shell / POSIX sh | Executable Script / Hook | Listing 1.18 (`.git/hooks/commit-msg` & `tools/git-hooks/commit-msg`) |
| **CH01-022** | 1.6.4 | GitHub Actions CI build and test workflow | YAML | Executable CI Configuration | Listing 1.19 (`.github/workflows/ci.yml`) |
| **CH01-023** | 1.6.5 | Local Docker Compose infrastructure services | YAML | Executable Orchestration | Listing 1.20 (`docker-compose.yml`) |
| **CH01-024** | 1.6.5 | Starting local Docker Compose stack | Shell / CLI | Command / Orchestration | Listing 1.21 |
| **CH01-025** | 1.6.6 | Coding standards and formatting (.editorconfig) | EditorConfig | Executable Configuration | Listing 1.22 (`.editorconfig`) |
| **CH01-026** | 1.7.3 | Architecture evolution roadmap | Text | Specification / Strategy | Listing 1.23 |
| **CH01-027** | 1.7.5 | AI prompt: Generating domain entities | Text | LLM Prompt Template | Listing 1.24 |
| **CH01-028** | 1.7.5 | AI prompt: Creating unit tests | Text | LLM Prompt Template | Listing 1.25 |
| **CH01-029** | 1.7.5 | AI prompt: Generating architecture diagrams | Text | LLM Prompt Template | Listing 1.26 |
| **CH01-030** | 1.7.5 | AI prompt: Writing an Architecture Decision Record | Text | LLM Prompt Template | Listing 1.27 |
| **CH01-031** | 1.7.6 | Conceptual review questions | Text | Study Material | Section 1.7.6 Review Questions |
| **CH01-032** | 1.7.6 | Hands-on exercise: Project aggregate & ProjectKey | C# Specification | Exercise Specification | Section 1.7.6 Hands-On Exercise |
| **CH01-033** | 1.7.6 | Hands-on exercise: Project entity unit tests | C# Specification | Exercise Specification | Section 1.7.6 Hands-On Exercise |
| **CH01-034** | 1.7.6 | Testcontainers exercise scaffold | C# | Illustrative / Scaffold | Listing 1.28 |
| **CH01-035** | 1.7.6 | Hands-on exercise: Testcontainers CI workflow | YAML Specification | Exercise Specification | Section 1.7.6 Hands-On Exercise |
| **CH01-036** | 1.7.7 | Capstone challenge: Multi-tenancy foundation | C# / Architecture Spec | Capstone Specification | Section 1.7.7 text |

---

## Inventory Summary

- **Directly Executable Code Artifacts:** 12 (Domain Entities, Enums, Interfaces, Exceptions, Unit Tests, Git Hook, CI Workflow, Docker Compose, EditorConfig, Setup Script, ADR-001)
- **Commands / Workflows:** 5 (CLI, Git workflow, test runner, compose runner)
- **Illustrative / Non-Executable Snippets:** 10 (DI fragments, Testcontainers scaffold, Prompt templates, commit specifications, architecture roadmap)
- **Pedagogical Specifications & Exercises:** 9 (Capstone challenge, hands-on exercises, review questions)
- **Total Cataloged Artifacts:** 36
