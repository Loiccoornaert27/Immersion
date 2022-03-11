using ImmersionApi.Data;
using ImmersionApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImmersionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly UserProfilFakeDB _userDb;
        private readonly RegularProfilFakeDB _regularDb;

        public ResultController(UserProfilFakeDB userDb, RegularProfilFakeDB regularDb)
        {
            _userDb = userDb;
            _regularDb = regularDb;
        }

        [HttpPost("/result/{id}")]
        public IActionResult Compare(int idUser, int idProfil)
        {
            var user = _userDb.GetById(idUser);
            if (user == null) return NotFound(new
            {
                Message = "Pas de profil utilisateur avec cet id"
            });
            var profil = _regularDb.GetById(idProfil);
            if (profil == null) return NotFound(new
            {
                Message = "Pas de profil type avec cet id"
            });
            List<SoftSkill> missingSoftNeeded = new();
            List<HardSkill> missingHardNeeded = new();
            List<Diploma> missingDiplomasNeeded = new();
            List<SoftSkill> missingSoft = new();
            List<HardSkill> missingHard = new();
            List<Diploma> missingDiplomas = new();

            for (int i = 0; i < profil.SoftSkillsNeeded.Count; i++)
            {
                bool owned = false;
                for (int j = 0; j < user.SoftSkills.Count; j++)
                {
                    if (user.SoftSkills[j] == profil.SoftSkillsNeeded[i])
                    {
                        owned = true;
                        break;
                    }
                }
                if (!owned) missingSoftNeeded.Add(profil.SoftSkillsNeeded[i]);
            }

            for (int i = 0; i < profil.HardSkillsNeeded.Count; i++)
            {
                bool owned = false;
                for (int j = 0; j < user.HardSkills.Count; j++)
                {
                    if (user.HardSkills[j] == profil.HardSkillsNeeded[i])
                    {
                        owned = true;
                        break;
                    }
                }
                if (!owned) missingHardNeeded.Add(profil.HardSkillsNeeded[i]);
            }

            for (int i = 0; i < profil.DiplomasNeeded.Count; i++)
            {
                bool owned = false;
                for (int j = 0; j < user.Diplomas.Count; j++)
                {
                    if (user.Diplomas[j] == profil.DiplomasNeeded[i])
                    {
                        owned = true;
                        break;
                    }
                }
                if (!owned) missingDiplomasNeeded.Add(profil.DiplomasNeeded[i]);
            }

            for (int i = 0; i < profil.SoftSkills.Count; i++)
            {
                bool owned = false;
                for (int j = 0; j < user.SoftSkills.Count; j++)
                {
                    if (user.SoftSkills[j] == profil.SoftSkills[i])
                    {
                        owned = true;
                        break;
                    }
                }
                if (!owned) missingSoft.Add(profil.SoftSkills[i]);
            }

            for (int i = 0; i < profil.HardSkills.Count; i++)
            {
                bool owned = false;
                for (int j = 0; j < user.HardSkills.Count; j++)
                {
                    if (user.HardSkills[j] == profil.HardSkills[i])
                    {
                        owned = true;
                        break;
                    }
                }
                if (!owned) missingHard.Add(profil.HardSkills[i]);
            }

            for (int i = 0; i < profil.Diplomas.Count; i++)
            {
                bool owned = false;
                for (int j = 0; j < user.Diplomas.Count; j++)
                {
                    if (user.Diplomas[j] == profil.Diplomas[i])
                    {
                        owned = true;
                        break;
                    }
                }
                if (!owned) missingDiplomas.Add(profil.Diplomas[i]);
            }
        }
    }
}
