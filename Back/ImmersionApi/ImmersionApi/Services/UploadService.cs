namespace WebAPI.Controllers.Services
{
    public class UploadService
    {
        public string UploadPicture(IFormFile picture, string folderName)
        {
            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, folderName));

            string alteredName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);

            string path = Path.Combine(Environment.CurrentDirectory, folderName, alteredName);
            Stream stream = File.Create(path);
            picture.CopyTo(stream);
            stream.Close();

            return folderName + "/" + alteredName;
        }
    }
}
