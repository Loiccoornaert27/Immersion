using ImmersionApi.Models;
using WebAPI.Controllers.Services;

namespace ImmersionApi.Data
{
    public class UserFakeDB
    {
        private static List<User> _users;
        private static UploadService _uploadService;

        public UserFakeDB(UploadService uploadService)
        {
            _uploadService = uploadService;
            _users = new List<User>();
            Seed();
        }

        private void Seed ()
        {
            _users = new List<User>()
            {
                new User { Email = "boucetta.kamel@gmail.com", FirstName = "Kamel", LastName = "Boucetta", IsAdmin = false, Password = "BichonLePlusBeau", Avatar = "https://e7.pngegg.com/pngimages/981/645/png-clipart-default-profile-united-states-computer-icons-desktop-free-high-quality-person-icon-miscellaneous-silhouette-thumbnail.png" }
            };
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault((x) => x.ID == id);
        }

        public User Add(User User)
        {
            _users.Add(User);

            return User;
        }

        public User Edit(IFormFile img, User newUser, int id)
        {
            User toEdit = GetById(id);

            if (toEdit == null) return null;

            toEdit.Email = newUser.Email ?? toEdit.Email;
            toEdit.FirstName = newUser.FirstName ?? toEdit.FirstName;
            toEdit.LastName = newUser.LastName ?? toEdit.LastName;
            toEdit.Password = newUser.Password ?? toEdit.Password;
            toEdit.IsAdmin = newUser.IsAdmin;

            toEdit.Avatar = newUser.Avatar ?? toEdit.Avatar;

            return toEdit;

            if (img != null)
            {
                toEdit.Avatar = _uploadService.UploadPicture(img, "Avatars");
            }

            return toEdit;
        }

        public bool RemoveById(int id)
        {
            var User = GetById(id);

            if (User == null) return false;

            return _users.Remove(User);
        }
    }
}
