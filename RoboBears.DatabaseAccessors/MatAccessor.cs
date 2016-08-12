using RoboBears.Contracts;
using System;
using RoboBears.DataContracts;
using RoboBears.DatabaseAccessors.EntityFramework;
using Mat = RoboBears.DataContracts.Mat;
using System.Linq;

namespace RoboBears.DatabaseAccessors
{
    public class MatAccessor : IMatAccessor
    {
        public Mat CreateMat(Mat mat)
        {
            using (var db = new DatabaseContext())
            {
                Mat addedMat = (Mat)db.Mats.Add((EntityFramework.Mat)mat);
                db.SaveChanges();
                return addedMat;
            }
        }

        public Mat GetMatById(int matId)
        {
            using (var db = new DatabaseContext())
            {
                return (Mat)db.Mats.Find(matId);
            }
        }

        public Mat[] GetMats()
        {
            using (var db = new DatabaseContext())
            {
                return db.Mats.Select(mat => (Mat)mat).ToArray();
            }
        }

        public Mat ModifyMat(Mat newMat)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(newMat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (Mat)db.Mats.Find(newMat.MatId);
            }
        }
    }
}
