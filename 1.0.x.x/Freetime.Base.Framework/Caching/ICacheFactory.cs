
namespace Freetime.Base.Framework.Caching
{
    public interface ICacheFactory
    {
        ICache GetCache(string name);

        ICache GetCache();
    }
}
