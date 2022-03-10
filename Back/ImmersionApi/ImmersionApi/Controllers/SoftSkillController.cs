using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ImmersionApi.Data;
using ImmersionApi.Models;

namespace ImmersionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftSkillController : ControllerBase
    {
        private readonly SoftSkillFakeDb _db;

        public SoftSkillController(SoftSkillFakeDb db)
        {
            _db = db;
        }

        [HttpGet("/softskill")]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                SoftSkill = _db.GetAllSoftSkill()
            });
        }

        [HttpGet("/softskill/{id}")]
        public IActionResult GetById(int id)
        {
           SoftSkill found = _db.GetSoftSkillById(id);
           
            if (found == null) return NotFound(new
            {
                Message = "Il n'y a pas de softskill à cet Id"
            });
            return Ok(new
            {
                Message = "La softskill a été trouvée",
                SoftSkill = found
            });
        }

        [HttpPost("/softskill")]
        public IActionResult AddSoftSkill([FromForm] SoftSkill newSoftSkill)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            if (_db.AddSoftSkill(newSoftSkill) != null)
            {
                return Ok(new
                {
                    Message = "SoftSkill ajoutée"
                });
            }
            else
            {
                return BadRequest("Quelque chose s'est mal passé");
            }
        }

        [HttpDelete("/softskill/{id}")]

        public IActionResult Remove(int id)
        {
            SoftSkill found = _db.GetSoftSkillById(id);

            if (found == null) return NotFound(new
            {
                Message = "Il n'y a pas de softskill à cette Id"
            });

            if (_db.RemoveSoftSkill(id)) return Ok(new
            {
                Message = "La softskill a été supprimée"
            });
            else
            {
                return BadRequest("Quelque chose s'est mal passé");
            }
        }

        [HttpPatch("/softskill/{id}")]
        public IActionResult Edit(int id, [FromForm] SoftSkill newSoftSkill)
        {
            SoftSkill found = _db.GetSoftSkillById(id);

            if (found == null) return NotFound(new
            {
                Message = "Il n'y a pas de softskill a cette Id."
            });

            if (_db.EditSoftSkill(id, newSoftSkill) != null)
            {
                return Ok(new
                {
                    Message = "Softskill modifiée dans la database",
                    SoftSkill = _db.GetSoftSkillById(id)
                });
            }
            else
            {
                return BadRequest("Quelque chose s'est mal passé");
            }
        }

    }
}
