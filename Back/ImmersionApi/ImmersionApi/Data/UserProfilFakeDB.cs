using ImmersionApi.Models;

namespace ImmersionApi.Data
{
    public class UserProfilFakeDB
    {
        private List<UserProfil> _userProfils;

        public UserProfilFakeDB()
        {
            _userProfils = new List<UserProfil>();
        }

        public List<UserProfil> GetAll()
        {
            return _userProfils;
        }

        public UserProfil GetById(int id)
        {
            return _userProfils.FirstOrDefault((x) => x.ID == id);
        }

        public UserProfil Add(UserProfil userProfil)
        {
            _userProfils.Add(userProfil);

            return userProfil;
        }

        public UserProfil Edit(UserProfil newUserProfil, int id)
        {
            UserProfil toEdit = GetById(id);

            if (toEdit == null) return null;

            toEdit.Job = newUserProfil.Job;
            toEdit.SoftSkills = newUserProfil.SoftSkills;
            toEdit.HardSkills = newUserProfil.HardSkills;
            toEdit.Diplomas = newUserProfil.Diplomas;

            return toEdit;
        }

        public bool RemoveById(int id)
        {
            var userProfil = GetById(id);

            if (userProfil == null) return false;

            return _userProfils.Remove(userProfil);
        }
    }
}
