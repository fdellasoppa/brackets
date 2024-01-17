using Brackets.Domain.Brackets;

namespace Brackets.Domain.Contact;

public record UserContact : IIdentifiable
{
	public UserContact() { }

    public long? Id { get; init; }
	public BracketUser? UserId { get; init; }
	public string UserName { get; init; } = string.Empty;
	public string Email { get; init; } = string.Empty;
	public DateTime SentDate { get; init; }
	public string Subject { get; init; } = string.Empty;
	public string Comments { get; init; } = string.Empty;
}
