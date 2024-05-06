
namespace Brackets.Domain;

public record StringTranslations(Dictionary<string, string> Translations)
{
	public string GetName(string? langCode)
	{
		var code = langCode ?? "en";
		return Translations.TryGetValue(code, out string? value) ?
			value
			: string.Empty;
	}
};
