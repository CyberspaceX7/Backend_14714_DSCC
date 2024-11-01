using DSCC.CW1.Backend._14714.DBContexts;
using DSCC.CW1.Backend._14714.Model;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1.Backend._14714.Repository
{
    public class MembershipPlanRepository : IMembershipRepository
    {
        private readonly GymContext _planContext;
        public MembershipPlanRepository(GymContext planContext)
        {
            _planContext = planContext;
        }


        public void DeleteMembershipPlan(int MembershipPlanId)
        {
            var plan = _planContext.MembershipPlans.Find(MembershipPlanId);
            _planContext.MembershipPlans.Remove(plan);
            Save();
        }

        public MembershipPlan GetMembershipPlanId(int Id)
        {
            var m = _planContext.MembershipPlans.Find(Id);
            return m;
        }

        public IEnumerable<MembershipPlan> GetMembershipPlans()
        {
            return _planContext.MembershipPlans.ToList();
        }

        public void InsertMembershipPlan(MembershipPlan membershipPlan)
        {
            _planContext.MembershipPlans.Add(membershipPlan);
            Save();
        }

        public void UpdateMembershipPlan(MembershipPlan membershipPlan)
        {
            // Retrieve the existing MembershipPlan from the database
            var existingPlan = _planContext.MembershipPlans.Find(membershipPlan.PlanId);
            if (existingPlan != null)
            {
                // Update properties of the existing plan
                existingPlan.PlanName = membershipPlan.PlanName;
                existingPlan.Cost = membershipPlan.Cost;

                // Save changes
                _planContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Membership plan not found.");
            }
        }

        public void Save()
        {
            _planContext.SaveChanges();
        }
    }
}
