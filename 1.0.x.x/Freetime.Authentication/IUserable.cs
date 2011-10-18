namespace Freetime.Authentication
{
    public interface IUserable
    {
        FreetimeUser CurrentUser { get; set; }
    }
}
