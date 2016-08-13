using RoboBears.Contracts;
using System.Linq;
using RoboBears.DatabaseAccessors.EntityFramework;
using Member = RoboBears.DataContracts.Member;

namespace RoboBears.DatabaseAccessors
{
    public class MemberAccessor : IMemberAccessor
    {
        public Member CreateMember(Member member)
        {
            using (var db = new DatabaseContext())
            {
                Member CreatedMember =(Member)db.Members.Add((EntityFramework.Member)member);
                db.SaveChanges();
                return CreatedMember;

            }
        }

        public Member GetMemberById(int memberId)
        {
            using (var db = new DatabaseContext())
            {
                return (Member)db.Members.Find(memberId);
            }
        }

        public Member[] GetMembers()
        {
            using (var db = new DatabaseContext())
            {
                return db.Members.Select(member => (Member)member).ToArray();
            }
        }

        public Member ModifyMember(Member newMember)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(newMember).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (Member)db.Members.Find(newMember.MemberId);
            }
        }
    }
}
