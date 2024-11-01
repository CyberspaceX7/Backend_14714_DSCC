    using DSCC.CW1.Backend._14714.DBContexts;
    using DSCC.CW1.Backend._14714.Model;
    using Microsoft.EntityFrameworkCore;

    namespace DSCC.CW1.Backend._14714.Repository
    {
        public class MemberRepository : IMemberRepository
        {
            private readonly GymContext _dbContext;

            public MemberRepository(GymContext dbContext)
            {
                _dbContext = dbContext;
            }

            // Method to insert a new member
            public void InsertMember(Member member)
            {
                _dbContext.Members.Add(member);
                Save();
            }

        // Method to update an existing member
        public void UpdateMember(Member member)
        {
            var existingMember = _dbContext.Members.Find(member.MemberId);
            if (existingMember != null)
            {
                // Update properties
                existingMember.FirstName = member.FirstName;
                existingMember.LastName = member.LastName;
                existingMember.JoinDate = member.JoinDate;
                existingMember.PlanId = member.PlanId;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Member not found.");
            }
        }

        // Method to delete a member by ID
        public void DeleteMember(int memberId)
            {
                var member = _dbContext.Members.Find(memberId);
                if (member != null)
                {
                    _dbContext.Members.Remove(member);
                    Save();
                }
            }

            // Method to retrieve a member by ID
            public Member GetMemberById(int memberId)
            {
                var member = _dbContext.Members
                    .Include(m => m.Plan) // Include the MembershipPlan navigation property
                    .FirstOrDefault(m => m.MemberId == memberId);
                return member;
            }

            // Method to retrieve all members
            public IEnumerable<Member> GetMembers()
            {
                return _dbContext.Members.Include(m => m.Plan).ToList();
            }

            // Save changes to the database
            public void Save()
            {
                _dbContext.SaveChanges();
            }
        }
    }
