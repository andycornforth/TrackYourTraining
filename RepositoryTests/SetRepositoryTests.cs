using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using DBModels;

namespace RepositoryTests
{
    [TestClass]
    public class SetRepositoryTests
    {
        [TestMethod]
        public void ICanAddASetToDB()
        {
            var setRepository = new SetRepository();
            setRepository.CreateNewSet(new Set()
            {
                Movement = new Movement(){Id = 1},
                SetNumber = 1,
                Reps = 8,
                Weight = 120,
                Tempo = new Tempo(){Id=1}
            });
        }

        [TestMethod]
        public void ICanGetASetFromTheDB()
        {
            var setRepository = new SetRepository();
            var set = setRepository.GetSet(1);

            Assert.AreEqual("High Bar Squat", set.Movement.Name.TrimEnd());
            Assert.AreEqual(82.5, set.Weight);
            Assert.AreEqual(8, set.Reps);
            Assert.AreEqual(1, set.SetNumber);
        }
    }
}
