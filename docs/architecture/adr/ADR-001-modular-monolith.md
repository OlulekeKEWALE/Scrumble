# ADR-001: Modular Monolith

**Status:** Accepted  
**Date:** 2025-03-10  
*(Note: This is an illustrative project decision date, not the release date of .NET 10.)*

## Context
Scrumble is a new SaaS platform for agile project management. We need to choose an architecture that balances development speed, operational complexity, and long-term maintainability. The business expects:
- Rapid feature delivery (multiple releases per week)
- Multi-tenancy and enterprise security
- Long-term design ambition of 100,000+ tenants and multiple development teams, subject to capacity validation

Alternative architectures considered:
- Traditional N-tier monolith
- Microservices
- Serverless
- Modular monolith

## Decision
We will build Scrumble as a modular monolith: one cohesive application composed of well-defined business modules aligned with bounded contexts and domain capabilities. Each module may contain multiple aggregates, application use cases, infrastructure adapters, and integration contracts. Modules communicate through defined interfaces and events. Infrastructure remains behind ports to preserve testability. The Web/API host and future worker host can run as separate processes under coordinated releases; they are not independently owned business services.

## Options Considered
- **N-tier monolith**: Familiar and straightforward; disciplined implementations can remain maintainable, but layering alone does not establish business-module boundaries.
- **Microservices**: Independent deployment and scaling are valuable, but their operational and data-consistency costs are not justified for Scrumble’s initial team and uncertain boundaries.
- **Serverless**: Can support stateful workflows through external stores and orchestration; execution constraints and provider-specific integration add trade-offs for this project.
- **Modular monolith**: Fits our initial delivery and operational needs while preserving an option for later extraction.

## Consequences

### Positive
- Faster development velocity in early stages
- Simpler operations through coordinated releases and fewer independently managed services
- Defined interfaces and module events support future extraction but do not guarantee an easy migration
- Ports and inward dependencies make isolated testing practical; useful tests still need deliberate design
- Lower operational complexity and cost initially

### Negative
- Modules share application-host releases and cannot be deployed or scaled independently without extraction; Web/API and worker processes can be scaled separately
- A bug in one module could affect others
- Database schema changes require coordination
- We must be disciplined about enforcing module boundaries

## Related Decisions
- ADR-002: Adopt Domain-Driven Design tactical patterns
- ADR-003: Evaluate MassTransit and RabbitMQ for durable asynchronous messaging; in-process module interactions need not use a broker
- ADR-004: Adopt CQRS-style request handling and Vertical Slice Architecture

## References
- Fowler, M. "MonolithFirst." martinfowler.com
- Newman, S. "Building Microservices." O'Reilly, 2015.
