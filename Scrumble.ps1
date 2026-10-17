# Create the solution file
dotnet new sln -n Scrumble
# .NET 10 uses .slnx by default. Use --format sln if you need a .sln file.

# Create the core projects
dotnet new classlib -n Scrumble.Domain -o src/Domain
dotnet new classlib -n Scrumble.Application -o src/Application
dotnet new classlib -n Scrumble.Infrastructure -o src/Infrastructure
dotnet new webapi -n Scrumble.Web -o src/Web -f net10.0
dotnet new classlib -n Scrumble.Contracts -o src/Contracts

# Create test projects
dotnet new xunit -n Scrumble.Domain.Tests -o tests/Domain.Tests
dotnet new xunit -n Scrumble.Application.Tests -o tests/Application.Tests
dotnet new xunit -n Scrumble.Integration.Tests -o tests/Integration.Tests

# Add projects to the solution
dotnet sln add src/Domain src/Application src/Infrastructure src/Web src/Contracts
dotnet sln add tests/Domain.Tests tests/Application.Tests tests/Integration.Tests

# Set up project references (Dependency Rule)
dotnet add src/Application reference src/Domain src/Contracts
dotnet add src/Infrastructure reference src/Application src/Domain
dotnet add src/Web reference src/Application src/Infrastructure src/Contracts

# Test projects reference their targets
dotnet add tests/Domain.Tests reference src/Domain
dotnet add tests/Application.Tests reference src/Application src/Domain
dotnet add tests/Integration.Tests reference src/Infrastructure src/Web
