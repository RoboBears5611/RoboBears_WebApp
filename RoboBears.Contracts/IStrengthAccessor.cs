﻿using RoboBears.DataContracts;

namespace RoboBears.Contracts
{
    public interface IStrengthAccessor
    {
        Strength GetStrengthById(int strengthId);

        Strength[] GetStrengths();

        Strength CreateStrength(Strength strength);

        Strength ModifyStrength(Strength newStrength);
    }
}
