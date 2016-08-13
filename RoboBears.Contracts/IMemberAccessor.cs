using RoboBears.DataContracts;

namespace RoboBears.Contracts
{
    public interface IMemberAccessor
    {
        Member GetMemberById(int memberId);

        Member[] GetMembers();

        Member CreateMember(Member member);

        Member ModifyMember(Member newMember);
    }
}
