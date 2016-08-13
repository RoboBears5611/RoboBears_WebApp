using RoboBears.DataContracts;

namespace RoboBears.Contracts
{
    public interface IMatManager
    {
        Mat GetMatById(int matId);

        Mat[] GetMats();

        Mat CreateMat(Mat mat);

        Mat ModifyMat(Mat newMat);
    }
}
