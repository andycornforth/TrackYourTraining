using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApi.Wrapper
{
    public interface IApiWrapper
    {
        IEnumerable<Muscle> GetMuscles();
        Muscle GetMuscle(int muscleId);
        IEnumerable<Movement> GetMovements();
        Movement GetMovement(int movementId);
        int PostMovement(Movement movement);
        Set GetSet(int setId);
        int PostSet(Set set);
        Day GetDayName(int dayId);
        IEnumerable<Set> GetSetsForDay(int dayId);
        int PostDay(Day day);
        IEnumerable<Program> GetPrograms();
        Program GetProgram(int ProgramId);
        IEnumerable<Day> GetProgramDays(int programId);
        int PostProgram(Program program);
    }
}
