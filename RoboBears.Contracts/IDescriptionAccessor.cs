using RoboBears.DataContracts;

namespace RoboBears.Contracts
{
    public interface IDescriptionAccessor
    {
        Description GetDescriptionById(int descriptionId);

        Description[] GetDescriptions();

        Description CreateDescription(Description description);

        Description ModifyDescription(Description newDescription);
    }
}
