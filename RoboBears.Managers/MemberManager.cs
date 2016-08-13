using RoboBears.Contracts;
using RoboBears.DataContracts;
using RoboBears.Utilities;

namespace RoboBears.Managers
{

    public class MemberManager : IMemberManager
    {
        private IMemberAccessor _memberAccessor;
        public IMemberAccessor MemberAccessor
        {
            get
            {
                return _memberAccessor ?? ClassFactory.CreateClass<IMemberAccessor>();
            }
            set
            {
                _memberAccessor = value;
            }
        }
        public Member CreateMember(Member member)
        {
            return MemberAccessor.CreateMember(member);
        }

        public Member GetMemberById(int memberId)
        {
            return MemberAccessor.GetMemberById(memberId);
        }

        public Member[]
        GetMembers()
        {
            return MemberAccessor.GetMembers();
        }

        public Member ModifyMember(Member newMember)
        {
            return MemberAccessor.ModifyMember(newMember);
        }
    }
}
