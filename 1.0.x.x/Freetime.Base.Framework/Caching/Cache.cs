
namespace Freetime.Base.Framework.Caching
{
    public abstract class Cache : ICache
    {
        public string Name { get; private set; }

        protected Cache(string name)
        {
            Name = name;
        }

        public abstract void Put(string key, object value);

        public abstract object Get(string key);

        public abstract object this[string key] { get; set; }

        public abstract bool ContainsKey(string key);
    }
}
