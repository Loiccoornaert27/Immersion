using ImmersionApi.Data;
using ImmersionApi.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImmersionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegularProfilController : ControllerBase
    {
        private readonly RegularProfilFakeDB _db;
        private readonly SoftSkillFakeDb _dbSoftSkill;
        private readonly HardSkillFakeDB _dbHardSkill;
        private readonly DiplomaFakeDB _dbDiploma;

        public RegularProfilController(RegularProfilFakeDB db, SoftSkillFakeDb dbSoftSkill, HardSkillFakeDB dbHardSkill, DiplomaFakeDB dbDiploma)
        {
            _db = db;
            _dbSoftSkill = dbSoftSkill;
            _dbHardSkill = dbHardSkill;
            _dbDiploma = dbDiploma;
        }

        [HttpGet("/regularProfil")]
        public IActionResult GetAllRegularProfils()
        {
            var regularProfils = _db.GetAll();

            if (regularProfils.Count == 0) return NotFound(new
            {
                Message = "Il n'y a aucun profil type enregistré"
            });

            return Ok(new
            {
                Message = "Voici la liste des profils type",
                regularProfils = regularProfils
            });
        }

        [HttpGet("/regularProfil/{id}")]
        public IActionResult GetAUserProfil(int id)
        {
            var regularProfil = _db.GetById(id);

            if (regularProfil == null) return NotFound(new
            {
                Message = "Aucun profil type ne correspond a cet ID"
            });

            else return Ok(new
            {
                Message = "profil type trouvé !",
                regularProfil = regularProfil
            });
        }

        [HttpPost("/regularProfil")]
        public IActionResult AddRegularProfil([FromForm] RegularProfil newRegularProfil, [FromForm] List<int> hardSkillIDNeeded, [FromForm] List<int> softSkillIDNeeded, [FromForm] List<int> diplomaIDNeeded,[FromForm] List<int> hardSkillID, [FromForm] List<int> softSkillID, [FromForm] List<int> diplomaID)
        {
            var listSoftNeeded = _dbSoftSkill.GetSoftSkillById(softSkillIDNeeded);
            var listHardNeeded = _dbHardSkill.GetHardSkillById(hardSkillIDNeeded);
            var listDiplomaNeeded = _dbDiploma.GetDiplomaById(diplomaIDNeeded);
            var listSoft = _dbSoftSkill.GetSoftSkillById(softSkillID);
            var listHard = _dbHardSkill.GetHardSkillById(hardSkillID);
            var listDiploma = _dbDiploma.GetDiplomaById(diplomaID);

            var regularProfil = _db.Add(new RegularProfil()
            {
                Job = newRegularProfil.Job,
                SoftSkillsNeeded = listSoftNeeded,
                HardSkillsNeeded = listHardNeeded,
                DiplomasNeeded = listDiplomaNeeded,
                SoftSkills = listSoft,
                HardSkills = listHard,
                Diplomas = listDiploma
            });

            if (regularProfil != null) return Ok(new
            {
                Message = "Le profil type à bien été créer ;)"
            });

            else return BadRequest(new
            {
                Message = "Oups ... Un problème est survenu"
            });
        }

        [HttpDelete("/regularProfil/{id}")]
        public IActionResult RemoveRegularProfil(int id)
        {
            var regularProfil = _db.RemoveById(id);

            if (regularProfil) return Ok(new
            {
                Message = "Profil type supprimé :/",
            });

            else return NotFound(new
            {
                Message = "Aucun poste ne possède cet id"
            });

        }

        [HttpPatch("/regularProfil/{id}")]
        public IActionResult EditRegularProfil(int id, [FromForm] RegularProfil regularProfil)
        {
            var found = _db.GetById(id);

            var editRegularProfil = new RegularProfil()
            {
                Diplomas = regularProfil.Diplomas ?? found.Diplomas,
                HardSkills = regularProfil.HardSkills ?? found.HardSkills,
                SoftSkills = regularProfil.SoftSkills ?? found.SoftSkills,
                Job = regularProfil.Job ?? found.Job,
            };

            if (found == null) return NotFound(new
            {
                Message = "Aucun profil type n'existe avec cet id"
            });

            if (_db.Edit(editRegularProfil, id) != null) return Ok(new
            {
                Message = "Profil type modifié avec succes"
            });

            return BadRequest(new
            {
                Message = "Oups .. Un Problème est survenu"
            });
        }
    }
}
