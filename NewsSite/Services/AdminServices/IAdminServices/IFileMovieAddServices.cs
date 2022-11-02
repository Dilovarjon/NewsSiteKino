namespace NewsSite.Services.AdminServices.IAdminServices
{
    public interface IFileMovieAddServices
    {
        public Task FileMovieAdd(HttpContext context,IFormFile uploadedFile);
    }
}
