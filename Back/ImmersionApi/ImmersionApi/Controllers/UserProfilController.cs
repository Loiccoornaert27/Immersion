using ImmersionApi.Data;
using ImmersionApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImmersionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilController : ControllerBase
    {
        private readonly UserProfilFakeDB _db;

        public UserProfilController(UserProfilFakeDB db)
        {
            _db = db;
        }

        [HttpGet("/userProfil")]
        public IActionResult GetAllUserProfils()
        {
            var userProfils = _db.GetAll();

            if (userProfils.Count == 0) return NotFound(new
            {
                Message = "Il n'y a aucun profil utilisateur enregistré"
            });

            return Ok(new
            {
                Message = "Voicie la liste des profils utilisateur",
                userProfils = userProfils
            });
        }

        [HttpGet("/userProfil/{id}")]
        public IActionResult GetAUserProfil(int id)
        {
            var userProfil = _db.GetById(id);

            if (userProfil == null) return NotFound(new
            {
                Message = "Aucun profil utilisateur ne correspond a cet ID"
            });

            else return Ok(new
            {
                Message = "profil utilisateur trouvé !",
                userProfil = userProfil
            });
        }

        [HttpPost("/userProfil")]
        public IActionResult AddAUserProfil([FromForm] UserProfil newUserProfil, List<int> hardSkillID, List<int> softSkillID, List<int> diplomaID)
        {
            var userProfil = _db.Add(new UserProfil() { Diplomas = newUserProfil.Diplomas, HardSkills = newUserProfil.HardSkills, Job = newUserProfil.Job, SoftSkills = newUserProfil.SoftSkills });

            if (userProfil != null) return Ok(new
            {
                Message = "Le profile utilisateur à bien été créer ;)"
            });

            else return BadRequest(new
            {
                Message = "Oups ... Un problème est survenue"
            });
        }

        [HttpDelete("/userProfil/{id}")]
        public IActionResult RemoveUserProfil(int id)
        {
            var userProfil = _db.RemoveById(id);

            if (userProfil) return Ok(new
            {
                Message = "Profil utilisateur supprimé :/",
            });

            else return NotFound(new
            {
                Message = "Aucun poste ne possède cet id"
            });

        }

        [HttpPatch("/userProfil/{id}")]
        public IActionResult EditUserProfil(int id, [FromForm] UserProfil userProfil)
        {
            var found = _db.GetById(id);

            var editUserProfil = new UserProfil()
            {
                Diplomas = userProfil.Diplomas ?? found.Diplomas,
                HardSkills = userProfil.HardSkills ?? found.HardSkills,
                SoftSkills = userProfil.SoftSkills ?? found.SoftSkills,
                Job = userProfil.Job ?? found.Job,
            };

            if (found == null) return NotFound(new
            {
                Message = "Aucun profil utilisateur n'existe avec cet id"
            });

            if (_db.Edit(editUserProfil, id) != null) return Ok(new
            {
                Message = "Profil utilisateur modifié avec succes"
            });

            return BadRequest(new
            {
                Message = "Oups .. Un Problème est survenue"
            });
        }
    }
}
