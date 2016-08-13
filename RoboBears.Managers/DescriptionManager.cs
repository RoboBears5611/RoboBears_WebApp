using RoboBears.Contracts;
using RoboBears.DataContracts;
using RoboBears.Utilities;

namespace RoboBears.Managers
{

    public class DescriptionManager : IDescriptionManager
    {
        private IDescriptionAccessor _descriptionAccessor;
        public IDescriptionAccessor DescriptionAccessor
        {
            get
            {
                return _descriptionAccessor ?? ClassFactory.CreateClass<IDescriptionAccessor>();
            }
            set
            {
                _descriptionAccessor = value;
            }
        }
        public Description CreateDescription(Description description)
        {
            return DescriptionAccessor.CreateDescription(description);
        }

        public Description GetDescriptionById(int descriptionId)
        {
            return DescriptionAccessor.GetDescriptionById(descriptionId);
        }

        public Description[]
        GetDescriptions()
        {
            return DescriptionAccessor.GetDescriptions();
        }

        public Description ModifyDescription(Description newDescription)
        {
            return DescriptionAccessor.ModifyDescription(newDescription);
        }
    }
}
