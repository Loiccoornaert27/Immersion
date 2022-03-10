namespace ImmersionApi.Models
{
    public class SoftSkill
    {
        private int _id;
        private static int _count;
        private List<SoftSkill>? _listSoftSkill;

        public int Id { get => _id; set => _id = value; }
        public static int Count { get => _count; set => _count = value; }
        public List<SoftSkill>? ListSoftSkill { get => _listSoftSkill; set => _listSoftSkill = value; }

        public SoftSkill()
        {
            _id = ++_count;
        }
    }
}
