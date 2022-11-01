namespace NewsSite.Services.AdminServices
{
    public interface IFileMovieAddServices
    {
        public Task FileMovieAdd(HttpContext context,IFormFile uploadedFile);
    }
}
