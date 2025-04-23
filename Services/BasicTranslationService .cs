// Services/FileTranslationService.cs
using System.Text.Json;
using Trasnlator.Interfaces;

public class BasicTranslationService : ITranslationService
{
    private readonly Dictionary<string, Dictionary<string, string>> _translations = new();
    private readonly ILogger<BasicTranslationService> _logger;

    public BasicTranslationService(ILogger<BasicTranslationService> logger)
    {
        _logger = logger;
        LoadTranslations();
    }

    private void LoadTranslations()
    {
        try
        {
            // Load JSON translations
            var enEfJson = File.ReadAllText("Resources/Translations/en-fr.json");
            var enArJson = File.ReadAllText("Resources/Translations/en-ar.json");
            _translations["en-fr"] = JsonSerializer.Deserialize<Dictionary<string, string>>(enEfJson);
            _translations["en-ar"] = JsonSerializer.Deserialize<Dictionary<string, string>>(enArJson);
            Console.WriteLine(_translations.ToArray());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to load translations");
        }
    }

    public Task<string> TranslateAsync(string text, string sourceLang, string targetLang)
    {
        var langPair = $"{sourceLang}-{targetLang}";

        if (!_translations.TryGetValue(langPair, out var translations))
        {
            return Task.FromResult($"[LANG PAIR {langPair} NOT SUPPORTED]");
        }

        if (translations.TryGetValue(text.ToLower(), out var translated))
        {
            return Task.FromResult(translated);
        }

        return Task.FromResult($"[TRANSLATION NOT FOUND FOR: {text}]");
    }
}