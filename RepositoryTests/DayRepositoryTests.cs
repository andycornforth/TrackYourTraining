using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using DBModels;

namespace RepositoryTests
{
    [TestClass]
    public class DayRepositoryTests
    {
        [TestMethod]
        public void ICanAddANewDayToDB()
        {
            var dayRepository = new DayRepository();
            dayRepository.CreateNewDay(new Day("Leg Day"));
        }

        public void ICanGetAllTheSetsForADay()
        {
            var dayRepository = new DayRepository();
        }
    }
}
