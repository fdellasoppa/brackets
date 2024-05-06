using Brackets.Domain.Matches;

namespace Brackets.Domain.Users;

public record AppUser : IStringIdentifiable
{
	public AppUser() { }

	public string Id { get; init; } = null!;
	public string Login { get; init; } = string.Empty;
	public string? Password { get; set; }
	public string FirstName { get; init; } = string.Empty;
	public string LastName { get; init; } = string.Empty;
	public int PasswordAttempts { get; set; }
	public DateTime ModifiedDate { get; set; }

	public virtual Country? Country { get; init; }

}
