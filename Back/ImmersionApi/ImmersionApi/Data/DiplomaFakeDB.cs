using ImmersionApi.Models;

namespace ImmersionApi.Data
{
    public class DiplomaFakeDB
    {
        private static List<Diploma> _diplomas;

        public DiplomaFakeDB()
        {
            _diplomas = new List<Diploma>();
            Seed();
        }

        public void Seed()
        {
            _diplomas = new List<Diploma>()
            {
                new Diploma() { Name = "Diplome d'ingenieur"},
                new Diploma() { Name = "Certification Dev Mobile"},
                new Diploma() { Name = "Licence informatique"},
                new Diploma() { Name = "BTS Informatique"},
                new Diploma() { Name = "DUT Informatique"},
                new Diploma() { Name = "Certification Agile"},
            };
        }

        public List<Diploma> GetAll()
        {
            return _diplomas;
        }

        public Diploma GetById(int id)
        {
            return _diplomas.FirstOrDefault((x) => x.ID == id);
        }

        public Diploma Add(Diploma Diploma)
        {
            _diplomas.Add(Diploma);

            return Diploma;
        }

        public Diploma Edit(Diploma newDiploma, int id)
        {
            Diploma toEdit = GetById(id);

            if (toEdit == null) return null;

            toEdit.Name = newDiploma.Name ?? toEdit.Name;

            return toEdit;
        }

        public bool RemoveById(int id)
        {
            var diploma = GetById(id);

            if (diploma == null) return false;

            return _diplomas.Remove(diploma);
        }

        public List<Diploma> GetDiplomaById(List<int> idList)
        {
            List<Diploma> list = new List<Diploma>();

            foreach (var id in idList)
            {
                list.Add(_diplomas.FirstOrDefault(x => x.ID == id));
            }

            return list;
        }
    }
}
