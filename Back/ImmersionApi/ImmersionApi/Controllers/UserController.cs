using ImmersionApi.Data;
using ImmersionApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Services;

namespace ImmersionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserFakeDB _db;
        private readonly UploadService _uploadService;
        private readonly UserProfilFakeDB _dbUserProfil;

        public UserController(UserFakeDB db, UploadService uploadService,UserProfilFakeDB dbUserProfil )
        {
            _db = db;
            _uploadService = uploadService;
            _dbUserProfil = dbUserProfil;
        }

        [HttpGet("/user")]
        public IActionResult GetAllUsers()
        {
            var users = _db.GetAll();

            if (users.Count == 0) return NotFound(new
            {
                Message = "Il n'y a aucun utilisateur "
            });

            return Ok(new
            {
                Message = "Voicie la liste des utilisateurs",
                users = users
            });
        }

        [HttpGet("/user/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _db.GetById(id);

            if (user == null) return NotFound(new
            {
                Message = "Aucun utilisateur ne correspond a cet ID"
            });

            else return Ok(new
            {
                Message = "user trouvé ! Voici votre user",
                user = user
            });
        }


        [HttpPost("/user")]
        public IActionResult Add(IFormFile? img, [FromForm] User newuser)
        {
            string path;

            if (img is null)
                path = "https://e7.pngegg.com/pngimages/981/645/png-clipart-default-profile-united-states-computer-icons-desktop-free-high-quality-person-icon-miscellaneous-silhouette-thumbnail.png";

            else
                path = _uploadService.UploadPicture(img, "Avatars");

            newuser.Avatar = path;

            // Creation vierge du profil utilisateur
            var userProfile = new UserProfil();
            _dbUserProfil.Add(userProfile);

            var user = _db.Add(new User() { Email = newuser.Email, FirstName = newuser.FirstName, LastName = newuser.LastName, Avatar = path, IsAdmin = newuser.IsAdmin, Password = newuser.Password, UserProfilID = userProfile.ID  });

            if (user != null) return Ok(new
            {
                Message = "L'utilisateur a été ajouté ;)"
            });

            else return BadRequest(new
            {
                Message = "Oups ... Un problème est survenue"
            });
        }

        [HttpDelete("/user/{id}")]
        public IActionResult Remove(int id)
        {
            var user = _db.RemoveById(id);

            if (user) return Ok(new
            {
                Message = "user supprimé :/",
                user = user
            });

            else return NotFound(new
            {
                Message = "Aucun utilisateur ne possède cet id"
            });

        }

        [HttpPatch("/user/{id}")]
        public IActionResult EditUser(int id, [FromForm] User newuser, IFormFile? img)
        {
            var found = _db.GetById(id);

            if (found == null) return NotFound(new
            {
                Message = "Aucun utilisateur n'existe avec cet id"
            });

            if (_db.Edit(img, newuser, id) != null) return Ok(new
            {
                Message = "Utilisateur Modifier avec succes"
            });

            return BadRequest(new
            {
                Message = "Oups .. Un Problème est survenue"
            });
        }
    }
}
