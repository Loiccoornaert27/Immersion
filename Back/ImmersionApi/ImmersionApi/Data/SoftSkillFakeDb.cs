using ImmersionApi.Models;

namespace ImmersionApi.Data
{
    public class SoftSkillFakeDb
    {
        private List<SoftSkill> _listSoftSkill { get; set; }

        public SoftSkillFakeDb()
        {
            _listSoftSkill = new();
        }

        public List<SoftSkill> GetAllSoftSkill()
        {
            return _listSoftSkill;
        }

        public SoftSkill GetSoftSkillById(int id)
        {
            return _listSoftSkill.FirstOrDefault(x => x.Id == id);
        }

        public SoftSkill AddSoftSkill(SoftSkill newSoftSkill)
        {
            _listSoftSkill.Add(newSoftSkill);
            return newSoftSkill;
        }

        public bool RemoveSoftSkill(int id)
        {
            SoftSkill found = GetSoftSkillById(id);

            if (found == null) return false;
            return _listSoftSkill.Remove(found);         
        }

        public SoftSkill EditSoftSkill(int id, SoftSkill newSoftSkill)
        {
            SoftSkill found = GetSoftSkillById(id);

            if (found == null) return null;
            else
            {
                found.ListSoftSkill = newSoftSkill.ListSoftSkill;
                return found;
            }
        }
    }
}
