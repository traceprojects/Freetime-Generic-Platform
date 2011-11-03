
namespace Freetime.Base.Framework.Caching
{
    public interface ICache
    {
        void Put(string key, object value);

        object Get(string key);

        object this[string key] { get; set; }

        bool ContainsKey(string key);
    }
}
