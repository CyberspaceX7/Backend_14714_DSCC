using DSCC.CW1.Backend._14714.Model;

namespace DSCC.CW1.Backend._14714.Repository
{
    public interface IMembershipRepository
    {
        void InsertMembershipPlan(MembershipPlan membershipPlan);
        void UpdateMembershipPlan(MembershipPlan membershipPlan);
        void DeleteMembershipPlan(int MembershipPlanId);
        MembershipPlan GetMembershipPlanId(int Id);
        IEnumerable<MembershipPlan> GetMembershipPlans();
    }
}
