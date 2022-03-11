using ImmersionApi.Models;

namespace ImmersionApi.Data
{
    public class JobFakeDB
    {
        private List<Job> _jobs;

        public JobFakeDB()
        {
            _jobs = new List<Job>();
            Seed();
        }

        private void Seed()
        {
            _jobs = new List<Job>()
            {
                new Job() { BeginDate = DateTime.Now, Category = Enums.Category.System, Description = "Description d'un poste dans le syteme", Name = "Admin réseau" },
                new Job() { BeginDate = new DateTime(11, 10, 1996), Category = Enums.Category.Developper, Description = "Description d'un poste dans dev", Name = "Dev C#" },
                new Job() { BeginDate = new DateTime(11, 10, 2020), Category = Enums.Category.Manager, Description = "Description d'un poste de manager", Name = "manager" },
            };
        }

        public List<Job> GetAll()
        {
            return _jobs;
        }

        public Job GetById(int id)
        {
            return _jobs.FirstOrDefault((x) => x.ID == id);
        }

        public Job Add(Job job)
        {
            _jobs.Add(job);

            return job;
        }

        public Job Edit(Job newJob, int id)
        {
            Job toEdit = GetById(id);

            if (toEdit == null) return null;

            toEdit.Description = newJob.Description ?? toEdit.Description;
            toEdit.Category = newJob.Category;
            toEdit.BeginDate = newJob.BeginDate;
            toEdit.Name = newJob.Name ?? toEdit.Name;

            return toEdit;
        }

        public bool RemoveById(int id)
        {
            var job = GetById(id);

            if (job == null) return false;

            return _jobs.Remove(job);
        }
    }
}
