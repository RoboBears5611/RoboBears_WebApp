using RoboBears.Contracts;
using RoboBears.DataContracts;
using RoboBears.Utilities;

namespace RoboBears.Managers
{

    public class StrengthManager : IStrengthManager
    {
        private IStrengthAccessor _strengthAccessor;
        public IStrengthAccessor StrengthAccessor
        {
            get
            {
                return _strengthAccessor ?? ClassFactory.CreateClass<IStrengthAccessor>();
            }
            set
            {
                _strengthAccessor = value;
            }
        }
        public Strength CreateStrength(Strength strength)
        {
            return StrengthAccessor.CreateStrength(strength);
        }

        public Strength GetStrengthById(int strengthId)
        {
            return StrengthAccessor.GetStrengthById(strengthId);
        }

        public Strength[]
        GetStrengths()
        {
            return StrengthAccessor.GetStrengths();
        }

        public Strength ModifyStrength(Strength newStrength)
        {
            return StrengthAccessor.ModifyStrength(newStrength);
        }
    }
}
