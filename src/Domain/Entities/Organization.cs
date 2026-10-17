using Scrumble.Domain.Common;
using Scrumble.Domain.Exceptions;

namespace Scrumble.Domain.Entities;

public class Organization : IAggregateRoot
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string TenantId { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
    private readonly List<OrganizationMember> _members = new();
    public IReadOnlyCollection<OrganizationMember> Members => _members.AsReadOnly();

    // Private constructor for EF Core
    private Organization()
    {
    }

    public Organization(string name, string tenantId)
    {
        Id = Guid.NewGuid();
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(tenantId);
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("Organization name cannot be empty.");
        }
        if (string.IsNullOrWhiteSpace(tenantId))
        {
            throw new DomainException("Tenant ID cannot be empty.");
        }
        Name = name;
        TenantId = tenantId;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddMember(User user, OrganizationRole role)
    {
        ArgumentNullException.ThrowIfNull(user);
        if (!Enum.IsDefined(role))
        {
            throw new DomainException("Organization role is invalid.");
        }
        if (_members.Any(m => m.UserId == user.Id))
        {
            throw new DomainException($"User {user.Id} is already a member.");
        }
        var member = new OrganizationMember(user.Id, role);
        _members.Add(member);
        // Domain event will be raised in Chapter 3
    }

    public void RemoveMember(Guid userId)
    {
        var member = _members.FirstOrDefault(m => m.UserId == userId);
        if (member is null)
        {
            throw new DomainException($"User {userId} is not a member.");
        }
        _members.Remove(member);
    }
}

public enum OrganizationRole
{
    Owner,
    Admin,
    Member
}
