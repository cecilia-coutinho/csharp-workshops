namespace EnkelSidan.Models
{
    public class SeedData
    {
        public static List<Member> Members { get; set; } = new List<Member>();

        public static void Initialize()
        {
            var member1 = new Member { Id = 1, Name = "John Lennon", Role = "Singer, songwriter, rhythm guitarist" };
            var member2 = new Member { Id = 2, Name = "Paul McCartney", Role = "Singer, songwriter, bassist" };
            var member3 = new Member { Id = 3, Name = "George Harrison", Role = "Guitarist" };
            var member4 = new Member { Id = 4, Name = "Ringo Starr", Role = "Drummer" };
            Members.AddRange(new[] { member1, member2, member3, member4 });
        }

        public static Member? GetMemberById(int memberId)
        {
            return Members.FirstOrDefault(member => member.Id == memberId);
        }

        public static void AddMember(Member newMember)
        {
            int nextId;

            if (Members.Count > 0)
            {
                int maxId = Members.Max(m => m.Id);
                nextId = maxId + 1;
            }
            else
            {
                nextId = 1;
            }
            newMember.Id = nextId;
            Members.Add(newMember);
        }
    }
}
