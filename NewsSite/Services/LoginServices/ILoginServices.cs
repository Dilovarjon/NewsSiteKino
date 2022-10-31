namespace NewsSite.Services.LoginServices
{
    public interface ILoginServices
    {
        public Task<string> PersonLogin(HttpContext context);
    }
}
