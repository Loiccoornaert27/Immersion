using ImmersionApi.Data;
using ImmersionApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImmersionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiplomaController : ControllerBase
    {
        private readonly DiplomaFakeDB _db;

        public DiplomaController(DiplomaFakeDB db)
        {
            _db = db;
        }

        [HttpGet("/diploma")]
        public IActionResult GetAllDiplomas()
        {
            var diplomas = _db.GetAll();

            if (diplomas.Count == 0) return NotFound(new
            {
                Message = "Il n'y a aucun diplome/certification enregistré"
            });

            return Ok(new
            {
                Message = "Voicie la liste des diplomes",
                diplomas = diplomas
            });
        }

        [HttpGet("/diploma/{id}")]
        public IActionResult GetAContact(int id)
        {
            var diploma = _db.GetById(id);

            if (diploma == null) return NotFound(new
            {
                Message = "Aucun diplome ne correspond a cet ID"
            });

            else return Ok(new
            {
                Message = "diplome trouvé !",
                Diploma = diploma
            });
        }

        [HttpPost("/diploma")]
        public IActionResult AddAContact([FromForm] Diploma newDiploma)
        {
            var Diploma = _db.Add(new Diploma() { Name = newDiploma.Name });

            if (Diploma != null) return Ok(new
            {
                Message = "Le diplome à bien été créer ;)"
            });

            else return BadRequest(new
            {
                Message = "Oups ... Un problème est survenue"
            });
        }

        [HttpDelete("/diploma/{id}")]
        public IActionResult RemoveDiploma(int id)
        {
            var Diploma = _db.RemoveById(id);

            if (Diploma) return Ok(new
            {
                Message = "Diplome supprimé :/",
            });

            else return NotFound(new
            {
                Message = "Aucun diplome ne possède cet id"
            });

        }

        [HttpPatch("/diploma/{id}")]
        public IActionResult EditDiploma(int id, [FromForm] Diploma newDiploma)
        {
            var found = _db.GetById(id);

            if (found == null) return NotFound(new
            {
                Message = "Aucun diplome n'existe avec cet id"
            });

            if (_db.Edit(newDiploma, id) != null) return Ok(new
            {
                Message = "Diplome modifié avec succes"
            });

            return BadRequest(new
            {
                Message = "Oups .. Un Problème est survenue"
            });
        }
    }
}
