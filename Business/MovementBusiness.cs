using DBModels;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MovementBusiness
    {
        MovementRepository movementRepository = new MovementRepository();

        public List<Movement> GetAllMovements()
        {
            return movementRepository.GetMovements();
        }

        public Movement GetMovementById(int id)
        {
            return movementRepository.GetMovement(id);
        }

        public int InsertNewMovement(Movement movement)
        {
            return movementRepository.InsertNewMovement(movement);
        }
    }
}
