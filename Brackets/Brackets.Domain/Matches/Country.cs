namespace Brackets.Domain.Matches;

public record Country
{
	public Country() { }

	public long Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string FlagImageCode { get; set; } = string.Empty;
}