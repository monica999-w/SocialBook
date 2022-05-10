using SocialBook.Models;

namespace SocialBook.Service
{
    public class PostImageProcessorService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostImageProcessorService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task CopyFile(Post post)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(post.ImageFile.FileName);
            string extension = Path.GetExtension(post.ImageFile.FileName);
            post.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/image", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await post.ImageFile.CopyToAsync(fileStream);
            }
        }
    }
}