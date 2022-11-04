namespace NewsSite.Services.AdminServices.IAdminServices.IFileMovieServices
{
    public interface IFileMovieAddServices
    {
        public Task FileMovieAdd(HttpContext context,IFormFile uploadedFile);
    }
}
