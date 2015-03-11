using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using DBModels;

namespace RepositoryTests
{
    [TestClass]
    public class ProgramRepositoryTests
    {
        [TestMethod]
        public void ICanGetAllProgramsFromDB()
        {
            var programRepository = new ProgramRepository();
            var programs = programRepository.GetPrograms();

            Assert.IsTrue(0 < programs.Count);
        }
    }
}
