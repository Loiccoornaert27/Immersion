using ImmersionApi.Models;

namespace ImmersionApi.Data
{
    public class SoftSkillFakeDb
    {
        private List<SoftSkill> Name;

        public SoftSkillFakeDb()
        {
            Name = new();
        }

        public List<SoftSkill> GetAllSoftSkill()
        {
            return Name;
        }

        public SoftSkill GetSoftSkillById(int id)
        {
            return Name.FirstOrDefault(x => x.Id == id);
        }

        public SoftSkill AddSoftSkill(SoftSkill newSoftSkill)
        {
            Name.Add(newSoftSkill);
            return newSoftSkill;
        }

        public bool RemoveSoftSkill(int id)
        {
            SoftSkill found = GetSoftSkillById(id);

            if (found == null) return false;
            return Name.Remove(found);         
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
    }
}
