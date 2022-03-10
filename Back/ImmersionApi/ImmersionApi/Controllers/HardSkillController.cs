using ImmersionApi.Data;
using ImmersionApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImmersionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardSkillController : ControllerBase
    {
        private readonly HardSkillFakeDB _db;

        public HardSkillController(HardSkillFakeDB db)
        {
            _db = db;
        }

        [HttpGet("/hardSkills")]
        public IActionResult GetAllHardSkills()
        {
            var hardSkills = _db.GetAll();

            if (hardSkills.Count == 0) return NotFound(new
            {
                Message = "Il n'y a aucune competence enregistré"
            });

            return Ok(new
            {
                Message = "Voicie la liste des competence",
                hardSkills = hardSkills
            });
        }

        [HttpGet("/hardSkill/{id}")]
        public IActionResult GetAHardskill(int id)
        {
            var hardSkill = _db.GetById(id);

            if (hardSkill == null) return NotFound(new
            {
                Message = "Aucune competence ne correspond a cet ID"
            });

            else return Ok(new
            {
                Message = "HardSkill trouvé !",
                HardSkill = hardSkill
            });
        }

        [HttpPost("/hardSkill")]
        public IActionResult AddAHardSkill([FromForm] HardSkill newHardSkill)
        {
            var hardSkill = _db.Add(new HardSkill() { Name = newHardSkill.Name });

            if (hardSkill != null) return Ok(new
            {
                Message = "La compétence à bien été créer ;)"
            });

            else return BadRequest(new
            {
                Message = "Oups ... Un problème est survenue"
            });
        }

        [HttpDelete("/hardSkill/{id}")]
        public IActionResult RemoveHardSkill(int id)
        {
            var hardSkill = _db.RemoveById(id);

            if (hardSkill) return Ok(new
            {
                Message = "Compétence supprimé :/",
            });

            else return NotFound(new
            {
                Message = "Aucune compétence ne possède cet id"
            });

        }

        [HttpPatch("/hardSkill/{id}")]
        public IActionResult EditHardSkill(int id, [FromForm] HardSkill newHardSkill)
        {
            var found = _db.GetById(id);

            if (found == null) return NotFound(new
            {
                Message = "Aucune compétence n'existe avec cet id"
            });

            if (_db.Edit(newHardSkill, id) != null) return Ok(new
            {
                Message = "Competence modifié avec succes"
            });

            return BadRequest(new
            {
                Message = "Oups .. Un Problème est survenue"
            });
        }
    }
}
