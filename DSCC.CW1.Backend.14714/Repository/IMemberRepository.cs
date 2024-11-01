using DSCC.CW1.Backend._14714.Model;

namespace DSCC.CW1.Backend._14714.Repository
{
    public interface IMemberRepository
    {
        void InsertMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int memberId);
        Member GetMemberById(int Id);
        IEnumerable<Member> GetMembers();
    }
}
