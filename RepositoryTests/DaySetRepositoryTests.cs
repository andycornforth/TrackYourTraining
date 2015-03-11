using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using DBModels;

namespace RepositoryTests
{
    [TestClass]
    public class DaySetRepositoryTests
    {
        [TestMethod]
        public void ICanGetAllSetsForADay()
        {
            var daySetRepository = new DaySetRepository();
            var daysets = daySetRepository.GetSetIdsForDay(1);

            Assert.IsTrue(1 < daysets.Count);
        }

        [TestMethod]
        public void ICanAddASetToADay()
        {
            var daySetRepository = new DaySetRepository();
            daySetRepository.AddSetToDay(1, 1);
        }
    }
}
