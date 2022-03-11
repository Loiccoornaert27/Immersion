﻿using ImmersionApi.Data;
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
        private readonly SoftSkillFakeDb _dbSoftSkill;
        private readonly HardSkillFakeDB _dbHardSkill;
        private readonly DiplomaFakeDB _dbDiploma;

        public UserProfilController(UserProfilFakeDB db, SoftSkillFakeDb dbSoftSkill, HardSkillFakeDB dbHardSkill, DiplomaFakeDB dbDiploma)
        {
            _db = db;
            _dbSoftSkill = dbSoftSkill;
            _dbHardSkill = dbHardSkill;
            _dbDiploma = dbDiploma;
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
        public IActionResult AddAUserProfil([FromForm] UserProfil newUserProfil, [FromForm] List<int> hardSkillID, [FromForm] List<int> softSkillID, [FromForm] List<int> diplomaID)
        {
            var listSoft = _dbSoftSkill.GetSoftSkillById(softSkillID);
            var listHard = _dbHardSkill.GetHardSkillById(softSkillID);
            var listDiploma = _dbDiploma.GetDiplomaById(softSkillID);

            var userProfil = _db.Add(new UserProfil() { 
                Job = newUserProfil.Job, 
                SoftSkills = listSoft,
                HardSkills = listHard,
                Diplomas = listDiploma
            });

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
