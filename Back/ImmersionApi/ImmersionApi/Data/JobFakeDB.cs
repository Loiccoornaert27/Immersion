using ImmersionApi.Models;

namespace ImmersionApi.Data
{
    public class JobFakeDB
    {
        private List<Job> _jobs;

        public JobFakeDB()
        {
            _jobs = new List<Job>();
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
