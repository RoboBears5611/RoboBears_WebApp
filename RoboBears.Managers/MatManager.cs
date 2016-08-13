using RoboBears.Contracts;
using RoboBears.DataContracts;
using RoboBears.Utilities;

namespace RoboBears.Managers
{

    public class MatManager : IMatManager
    {
        private IMatAccessor _matAccessor;
        public IMatAccessor MatAccessor
        {
            get
            {
                return _matAccessor ?? ClassFactory.CreateClass<IMatAccessor>();
            }
            set
            {
                _matAccessor = value;
            }
        }
        public Mat CreateMat(Mat mat)
        {
            return MatAccessor.CreateMat(mat);
        }

        public Mat GetMatById(int matId)
        {
            return MatAccessor.GetMatById(matId);
        }

        public Mat[]
        GetMats()
        {
            return MatAccessor.GetMats();
        }

        public Mat ModifyMat(Mat newMat)
        {
            return MatAccessor.ModifyMat(newMat);
        }
    }
}
