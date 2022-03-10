using ImmersionApi.Data;
using ImmersionApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImmersionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly JobFakeDB _db;

        public JobController(JobFakeDB db)
        {
            _db = db;
        }

        [HttpGet("/jobs")]
        public IActionResult GetAlljobs()
        {
            var jobs = _db.GetAll();

            if (jobs.Count == 0) return NotFound(new
            {
                Message = "Il n'y a aucun poste enregistré"
            });

            return Ok(new
            {
                Message = "Voicie la liste des postes",
                jobs = jobs
            });
        }

        [HttpGet("/job/{id}")]
        public IActionResult GetAJob(int id)
        {
            var job = _db.GetById(id);

            if (job == null) return NotFound(new
            {
                Message = "Aucun poste ne correspond a cet ID"
            });

            else return Ok(new
            {
                Message = "poste trouvé !",
                job = job
            });
        }

        [HttpPost("/job")]
        public IActionResult AddAJob([FromForm] Job newjob)
        {
            var job = _db.Add(new Job() { Name = newjob.Name, BeginDate = newjob.BeginDate, Category = newjob.Category, Description = newjob.Description });

            if (job != null) return Ok(new
            {
                Message = "Le poste à bien été créer ;)"
            });

            else return BadRequest(new
            {
                Message = "Oups ... Un problème est survenue"
            });
        }

        [HttpDelete("/job/{id}")]
        public IActionResult RemoveJob(int id)
        {
            var job = _db.RemoveById(id);

            if (job) return Ok(new
            {
                Message = "Poste supprimé :/",
            });

            else return NotFound(new
            {
                Message = "Aucun poste ne possède cet id"
            });

        }

        [HttpPatch("/job/{id}")]
        public IActionResult Editjob(int id, [FromForm] Job newJob)
        {
            // TODO !!!!!!!!!!!!!!!!!!!!!!!
            // Creer un nouveau Job et y affecter les champs null par rapport au données inseré par l'utilisateur 
            // Ensuite, envoyer ce nouveau Job a la BDD

            var found = _db.GetById(id);

            if (found == null) return NotFound(new
            {
                Message = "Aucun Poste n'existe avec cet id"
            });

            if (_db.Edit(newJob, id) != null) return Ok(new
            {
                Message = "Poste modifié avec succes"
            });

            return BadRequest(new
            {
                Message = "Oups .. Un Problème est survenue"
            });
        }
    }
}
