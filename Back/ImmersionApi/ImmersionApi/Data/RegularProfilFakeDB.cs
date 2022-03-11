using ImmersionApi.Models;

namespace ImmersionApi.Data
{
    public class RegularProfilFakeDB
    {
        private List<RegularProfil> _regularProfils;

        public RegularProfilFakeDB()
        {
            _regularProfils = new List<RegularProfil>();
        }

        public List<RegularProfil> GetAll()
        {
            return _regularProfils;
        }

        public RegularProfil GetById(int id)
        {
            return _regularProfils.FirstOrDefault((x) => x.ID == id);
        }

        public RegularProfil Add(RegularProfil regularProfil)
        {
            _regularProfils.Add(regularProfil);

            return regularProfil;
        }

        public RegularProfil Edit(RegularProfil newRegularProfil, int id)
        {
            RegularProfil toEdit = GetById(id);

            if (toEdit == null) return null;

            toEdit.Job = newRegularProfil.Job;
            toEdit.SoftSkills = newRegularProfil.SoftSkills;
            toEdit.HardSkills = newRegularProfil.HardSkills;
            toEdit.Diplomas = newRegularProfil.Diplomas;

            return toEdit;
        }

        public bool RemoveById(int id)
        {
            var regularProfil = GetById(id);

            if (regularProfil == null) return false;

            return _regularProfils.Remove(regularProfil);
        }
    }
}
