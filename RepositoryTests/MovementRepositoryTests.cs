using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using DBModels;
using System.Collections.Generic;

namespace RepositoryTests
{
    [TestClass]
    public class MovementRepositoryTests
    {
        [TestMethod]
        public void ICanAddANewMovementToTheDB()
        {
            var movementRepository = new MovementRepository();

            movementRepository.InsertNewMovement(new Movement() 
            { 
                Name = "Squats",
                PrimaryMuscle = new Muscle() { Id=1},
                SecondaryMuscles = new List<string>(){"hamstrings"},
                WeightType = new WeightType(1,""),
                DifficultyLevel = new DifficultyLevel(3,""),
                Description = "squat bitch!!!"
            });
        }

        [TestMethod]
        public void ICanGetAllMovementFromDB()
        {
            var movementRepository = new MovementRepository();
            var movements = movementRepository.GetMovements();

            Assert.AreEqual("High Bar Squat", movements[0].Name.TrimEnd());
        }

        [TestMethod]
        public void ICanGetASpecificMovementFromDB()
        {
            var movementRepository = new MovementRepository();
            var movements = movementRepository.GetMovements();
            var movement = movementRepository.GetMovement(movements[0].Id);

            Assert.AreEqual("High Bar Squat", movement.Name.TrimEnd());
        }
    }
}
