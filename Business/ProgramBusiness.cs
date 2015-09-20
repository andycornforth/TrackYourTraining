using DBModels;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProgramBusiness
    {
        ProgramRepository programRepository = new ProgramRepository();
        ProgramDayRepository programDayRepository = new ProgramDayRepository();
        DayRepository dayRepoitory = new DayRepository();

        public List<Program> GetAllPrograms()
        {
            return programRepository.GetPrograms();
        }

        public Program GetProgramById(int programId)
        {
            return programRepository.GetProgramById(programId);
        }

        public List<Day> GetProgramDays(int programId)
        {
            var programDays = programDayRepository.GetProgramDaysForProgram(programId);
            var days = new List<Day>();
            foreach (var programDay in programDays)
            {
                days.Add(dayRepoitory.GetDay(programDay.DayId));
            }
            return days;

        }

        public int CreateNewProgram(Program program)
        {
            return programRepository.InsertNewProgram(program);
        }
    }
}
