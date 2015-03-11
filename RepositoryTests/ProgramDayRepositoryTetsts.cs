using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using DBModels;

namespace RepositoryTests
{
    [TestClass]
    public class ProgramDayRepositoryTests
    {
        [TestMethod]
        public void ICanAddADayToAProgram()
        {
            var programDayRepository = new ProgramDayRepository();
            programDayRepository.AddDayToProgram(1, 1);
        }

        [TestMethod]
        public void ICanDaysForAProgramFromDB()
        {
            var programDayRepository = new ProgramDayRepository();
            var days = programDayRepository.GetProgramDaysForProgram(1);

            Assert.IsTrue(0 < days.Count);
        }
    }
}
