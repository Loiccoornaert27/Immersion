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

        [HttpGet("/job")]
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
            var found = _db.GetById(id);

            var editJob = new Job()
            {
                Name = newJob.Name ?? found.Name,
                Description = newJob.Description ?? found.Description,
                BeginDate = newJob.BeginDate ?? found.BeginDate,
                Category = newJob.Category ?? found.Category,
            };

            if (found == null) return NotFound(new
            {
                Message = "Aucun Poste n'existe avec cet id"
            });

            if (_db.Edit(editJob, id) != null) return Ok(new
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
