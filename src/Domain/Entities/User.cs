using Scrumble.Domain.Exceptions;

namespace Scrumble.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; } = null!;
    public string DisplayName { get; private set; } = null!;

    private User()
    {
    }

    public User(string email, string displayName)
    {
        Id = Guid.NewGuid();
        ArgumentNullException.ThrowIfNull(email);
        ArgumentNullException.ThrowIfNull(displayName);
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new DomainException("Email cannot be empty.");
        }
        if (string.IsNullOrWhiteSpace(displayName))
        {
            throw new DomainException("Display name cannot be empty.");
        }
        Email = email;
        DisplayName = displayName;
    }

    public void UpdateDisplayName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new DomainException("Display name cannot be empty.");
        }
        DisplayName = newName;
    }
}
