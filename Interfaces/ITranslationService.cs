namespace Trasnlator.Interfaces;

public interface ITranslationService
{
    Task<string> TranslateAsync(string text, string fromLanguage, string toLanguage);
}
