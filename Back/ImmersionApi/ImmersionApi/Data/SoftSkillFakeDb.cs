using ImmersionApi.Models;

namespace ImmersionApi.Data
{
    public class SoftSkillFakeDb
    {
        private List<SoftSkill> _softSkills;

        public SoftSkillFakeDb()
        {
            _softSkills = new();
            Seed();
        }

        public void Seed()
        {
            _softSkills = new List<SoftSkill>()
            {
                new SoftSkill() { Name = "Travail d'equipe"},
                new SoftSkill() { Name = "Sociable"},
                new SoftSkill() { Name = "Extravertie"},
                new SoftSkill() { Name = "Curiosité"},
                new SoftSkill() { Name = "Je sais plus quoi mettre"},
            };
        }

        public List<SoftSkill> GetAllSoftSkill()
        {
            return _softSkills;
        }

        public SoftSkill GetSoftSkillById(int id)
        {
            return _softSkills.FirstOrDefault(x => x.Id == id);
        }

        public SoftSkill AddSoftSkill(SoftSkill newSoftSkill)
        {
            _softSkills.Add(newSoftSkill);
            return newSoftSkill;
        }

        public bool RemoveSoftSkill(int id)
        {
            SoftSkill found = GetSoftSkillById(id);

            if (found == null) return false;
            return _softSkills.Remove(found);         
        }

        public SoftSkill EditSoftSkill(int id, SoftSkill newSoftSkill)
        {
            SoftSkill found = GetSoftSkillById(id);

            if (found == null) return null;
            else
            {
                found.Name = newSoftSkill.Name;
                return found;
            }
        }

        public List<SoftSkill> GetSoftSkillById(List<int> idList)
        {
            List<SoftSkill> list = new List<SoftSkill>();

            foreach (var idSoft in idList)
            {
                list.Add(_softSkills.FirstOrDefault(x => x.Id == idSoft) );
            }

            return list;
        }
    }
}
