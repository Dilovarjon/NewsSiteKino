namespace NewsSite.Interfaces
{
    public interface ILoginServices
    {
        public Task<string> PersonLogin(HttpContext context);
    }
}
