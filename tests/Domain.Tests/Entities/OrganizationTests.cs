using Scrumble.Domain.Entities;
using Scrumble.Domain.Exceptions;
using Xunit;

namespace Scrumble.Domain.Tests.Entities;

public class OrganizationTests
{
    [Fact]
    public void CreateOrganization_Should_GenerateId_And_InitializeProperties()
    {
        // Arrange
        var name = "Acme Corp";
        var tenantId = "acme-001";
        // Act
        var org = new Organization(name, tenantId);
        // Assert
        Assert.NotEqual(Guid.Empty, org.Id);
        Assert.Equal(name, org.Name);
        Assert.Equal(tenantId, org.TenantId);
        Assert.True(org.CreatedAt <= DateTime.UtcNow);
        Assert.Empty(org.Members);
    }

    [Fact]
    public void CreateOrganization_WithNullName_Should_ThrowArgumentNullException()
    {
        // Arrange/Act/Assert
        Assert.Throws<ArgumentNullException>(() => new Organization(null!, "tenant-001"));
    }

    [Fact]
    public void AddMember_Should_AddMember_ToCollection()
    {
        // Arrange
        var org = new Organization("Acme Corp", "acme-001");
        var user = new User("alice@example.com", "Alice");
        // Act
        org.AddMember(user, OrganizationRole.Admin);
        // Assert
        var member = Assert.Single(org.Members);
        Assert.Equal(user.Id, member.UserId);
        Assert.Equal(OrganizationRole.Admin, member.Role);
    }

    [Fact]
    public void AddMember_WithDuplicateUser_Should_ThrowDomainException()
    {
        // Arrange
        var org = new Organization("Acme Corp", "acme-001");
        var user = new User("alice@example.com", "Alice");
        org.AddMember(user, OrganizationRole.Admin);
        // Act/Assert
        Assert.Throws<DomainException>(() => org.AddMember(user, OrganizationRole.Member));
    }

    [Fact]
    public void RemoveMember_Should_RemoveMember_FromCollection()
    {
        // Arrange
        var org = new Organization("Acme Corp", "acme-001");
        var user = new User("alice@example.com", "Alice");
        org.AddMember(user, OrganizationRole.Admin);
        // Act
        org.RemoveMember(user.Id);
        // Assert
        Assert.Empty(org.Members);
    }

    [Fact]
    public void RemoveMember_WithNonExistentUser_Should_ThrowDomainException()
    {
        // Arrange
        var org = new Organization("Acme Corp", "acme-001");
        var userId = Guid.NewGuid();
        // Act/Assert
        Assert.Throws<DomainException>(() => org.RemoveMember(userId));
    }

    // Extended coverage requested in Section 1.5.6: whitespace values, invalid roles, empty user IDs, and null users
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void CreateOrganization_WithWhitespaceName_Should_ThrowDomainException(string invalidName)
    {
        Assert.Throws<DomainException>(() => new Organization(invalidName, "tenant-001"));
    }

    [Fact]
    public void CreateOrganization_WithNullTenantId_Should_ThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new Organization("Acme Corp", null!));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void CreateOrganization_WithWhitespaceTenantId_Should_ThrowDomainException(string invalidTenantId)
    {
        Assert.Throws<DomainException>(() => new Organization("Acme Corp", invalidTenantId));
    }

    [Fact]
    public void AddMember_WithNullUser_Should_ThrowArgumentNullException()
    {
        var org = new Organization("Acme Corp", "acme-001");
        Assert.Throws<ArgumentNullException>(() => org.AddMember(null!, OrganizationRole.Member));
    }

    [Fact]
    public void AddMember_WithInvalidRole_Should_ThrowDomainException()
    {
        var org = new Organization("Acme Corp", "acme-001");
        var user = new User("alice@example.com", "Alice");
        Assert.Throws<DomainException>(() => org.AddMember(user, (OrganizationRole)999));
    }

    [Fact]
    public void OrganizationMember_WithEmptyUserId_Should_ThrowDomainException()
    {
        Assert.Throws<DomainException>(() => new OrganizationMember(Guid.Empty, OrganizationRole.Member));
    }

    [Fact]
    public void OrganizationMember_WithInvalidRole_Should_ThrowDomainException()
    {
        Assert.Throws<DomainException>(() => new OrganizationMember(Guid.NewGuid(), (OrganizationRole)999));
    }

    [Fact]
    public void OrganizationMember_ChangeRole_WithInvalidRole_Should_ThrowDomainException()
    {
        var member = new OrganizationMember(Guid.NewGuid(), OrganizationRole.Member);
        Assert.Throws<DomainException>(() => member.ChangeRole((OrganizationRole)999));
    }

    [Fact]
    public void OrganizationMember_ChangeRole_Should_UpdateRole()
    {
        var member = new OrganizationMember(Guid.NewGuid(), OrganizationRole.Member);
        member.ChangeRole(OrganizationRole.Admin);
        Assert.Equal(OrganizationRole.Admin, member.Role);
    }

    [Fact]
    public void User_Create_WithValidData_Should_Initialize()
    {
        var user = new User("bob@example.com", "Bob");
        Assert.NotEqual(Guid.Empty, user.Id);
        Assert.Equal("bob@example.com", user.Email);
        Assert.Equal("Bob", user.DisplayName);
    }

    [Fact]
    public void User_UpdateDisplayName_WithValidName_Should_Update()
    {
        var user = new User("bob@example.com", "Bob");
        user.UpdateDisplayName("Robert");
        Assert.Equal("Robert", user.DisplayName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void User_UpdateDisplayName_WithWhitespace_Should_ThrowDomainException(string newName)
    {
        var user = new User("bob@example.com", "Bob");
        Assert.Throws<DomainException>(() => user.UpdateDisplayName(newName));
    }
}
