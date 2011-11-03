using Freetime.Base.Data.Collection;
using Freetime.Base.Data.Entities;

namespace Freetime.Base.Component
{
    public interface ILanguageManager
    {
        LanguageList Languages { get; }

        string GetStringResource(string languageCode, string key);
    }
}
