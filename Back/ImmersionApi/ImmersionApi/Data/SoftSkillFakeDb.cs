using ImmersionApi.Models;

namespace ImmersionApi.Data
{
    public class SoftSkillFakeDb
    {
        private List<SoftSkill> SoftSkillName;

        public SoftSkillFakeDb()
        {
            SoftSkillName = new();
        }

        public List<SoftSkill> GetAllSoftSkill()
        {
            return SoftSkillName;
        }

        public SoftSkill GetSoftSkillById(int id)
        {
            return SoftSkillName.FirstOrDefault(x => x.Id == id);
        }

        public SoftSkill AddSoftSkill(SoftSkill newSoftSkill)
        {
            SoftSkillName.Add(newSoftSkill);
            return newSoftSkill;
        }

        public bool RemoveSoftSkill(int id)
        {
            SoftSkill found = GetSoftSkillById(id);

            if (found == null) return false;
            return SoftSkillName.Remove(found);         
        }

        public SoftSkill EditSoftSkill(int id, SoftSkill newSoftSkill)
        {
            SoftSkill found = GetSoftSkillById(id);

            if (found == null) return null;
            else
            {
                found.SoftSkillName = newSoftSkill.SoftSkillName;
                return found;
            }
        }
    }
}
