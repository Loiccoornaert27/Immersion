using ImmersionApi.Models;

namespace ImmersionApi.Data
{
    public class SoftSkillFakeDb
    {
        private List<SoftSkill> _softSkills;

        public SoftSkillFakeDb()
        {
            _softSkills = new();
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
