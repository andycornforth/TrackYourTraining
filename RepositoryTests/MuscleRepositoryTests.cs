using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;

namespace RepositoryTests
{
    [TestClass]
    public class MuscleRepositoryTests
    {
        [TestMethod]
        public void ICanGetAllMuscleFromTheDB()
        {
            var muscleRepository = new MuscleRepository();
            var muscles = muscleRepository.GetMuscles();

            Assert.IsNotNull(muscles);
            Assert.AreEqual("Quadriceps", muscles[0].MuscleName);
            Assert.IsTrue(13 < muscles.Count);
        }

        [TestMethod]
        public void ICanGetAMuscleById()
        {
            var muscleRepository = new MuscleRepository();
            var muscle = muscleRepository.GetMuscle(5);

            Assert.AreEqual("Pectorals", muscle.MuscleName);
        }
    }
}
