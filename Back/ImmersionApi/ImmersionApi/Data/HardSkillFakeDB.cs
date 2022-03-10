using ImmersionApi.Models;

namespace ImmersionApi.Data
{
    public class HardSkillFakeDB
    {
        private static List<HardSkill> _hardSkills;

        public HardSkillFakeDB()
        {
            _hardSkills = new List<HardSkill>();
            Seed();
        }

        public void Seed()
        {
            _hardSkills = new List<HardSkill>()
            {
                new HardSkill() { Name = "Langage C#"},
                new HardSkill() { Name = "Framework Angular"},
                new HardSkill() { Name = "SQL"},
                new HardSkill() { Name = "Html"},
                new HardSkill() { Name = "CSS"},
                new HardSkill() { Name = "JS"},
            };
        }

        public List<HardSkill> GetAll()
        {
            return _hardSkills;
        }

        public HardSkill GetById(int id)
        {
            return _hardSkills.FirstOrDefault((x) => x.ID == id);
        }

        public HardSkill Add(HardSkill hardSkill)
        {
            _hardSkills.Add(hardSkill);

            return hardSkill;
        }

        public HardSkill Edit(HardSkill newHardSkill, int id)
        {
            HardSkill toEdit = GetById(id);

            if (toEdit == null) return null;

            toEdit.Name = newHardSkill.Name ?? toEdit.Name;

            return toEdit;
        }

        public bool RemoveById(int id)
        {
            var hardSkill = GetById(id);

            if (hardSkill == null) return false;

            return _hardSkills.Remove(hardSkill);
        }



    }
}
