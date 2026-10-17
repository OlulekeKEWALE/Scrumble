using Scrumble.Domain.Exceptions;

namespace Scrumble.Domain.Entities;

public class OrganizationMember
{
    public Guid UserId { get; private set; }
    public OrganizationRole Role { get; private set; }

    // Private constructor for EF Core
    private OrganizationMember()
    {
    }

    public OrganizationMember(Guid userId, OrganizationRole role)
    {
        if (userId == Guid.Empty)
        {
            throw new DomainException("User ID cannot be empty.");
        }
        if (!Enum.IsDefined(role))
        {
            throw new DomainException("Organization role is invalid.");
        }
        UserId = userId;
        Role = role;
    }

    public void ChangeRole(OrganizationRole newRole)
    {
        if (!Enum.IsDefined(newRole))
        {
            throw new DomainException("Organization role is invalid.");
        }
        Role = newRole;
    }
}
