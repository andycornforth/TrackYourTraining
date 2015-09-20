using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApi.Wrapper
{
    public class ApiWrapper : IApiWrapper
    {
        IHttpMessenger apiMessenger;

        public ApiWrapper(string baseAddress)
        {
            apiMessenger = new HttpJsonMessenger(baseAddress);
        }

        public IEnumerable<Muscle> GetMuscles()
        {
            string url = UrlGenerator.GetMusclesUrl();
            string resultString = apiMessenger.Get(url);
            var result = apiMessenger.GetObjectFromString<IEnumerable<Muscle>>(resultString);
            return result;
        }

        public Muscle GetMuscle(int muscleId)
        {
            string url = UrlGenerator.GetMuscleUrl(muscleId);
            string resultString = apiMessenger.Get(url);
            var result = apiMessenger.GetObjectFromString<Muscle>(resultString);
            return result;
        }
        public IEnumerable<Movement> GetMovements()
        {
            string url = UrlGenerator.GetMovementsUrl();
            string resultString = apiMessenger.Get(url);
            var result = apiMessenger.GetObjectFromString<IEnumerable<Movement>>(resultString);
            return result;
        }
        public Movement GetMovement(int movementId)
        {
            string url = UrlGenerator.GetMovementUrl(movementId);
            string resultString = apiMessenger.Get(url);
            var result = apiMessenger.GetObjectFromString<Movement>(resultString);
            return result;
        }
        public int PostMovement(Movement movement)
        {
            return 0;
        }
        public Set GetSet(int setId)
        {
            return null;
        }
        public int PostSet(Set set)
        {
            return 0;
        }
        public Day GetDayName(int dayId)
        {
            return null;
        }
        public IEnumerable<Set> GetSetsForDay(int dayId)
        {
            string url = UrlGenerator.GetSetsForDayUrl(dayId);
            string resultString = apiMessenger.Get(url);
            var result = apiMessenger.GetObjectFromString<IEnumerable<Set>>(resultString);
            return result;
        }
        public int PostDay(Day day)
        {
            return 0;
        }
        public IEnumerable<Program> GetPrograms()
        {
            string url = UrlGenerator.GetProgramsUrl();
            string resultString = apiMessenger.Get(url);
            var result = apiMessenger.GetObjectFromString<IEnumerable<Program>>(resultString);
            return result;
        }
        public Program GetProgram(int programId)
        {
            string url = UrlGenerator.GetProgramUrl(programId);
            string resultString = apiMessenger.Get(url);
            var result = apiMessenger.GetObjectFromString<Program>(resultString);
            return result;
        }
        public IEnumerable<Day> GetProgramDays(int programId)
        {
            string url = UrlGenerator.GetProgramDaysUrl(programId);
            string resultString = apiMessenger.Get(url);
            var result = apiMessenger.GetObjectFromString<IEnumerable<Day>>(resultString);
            return result;
        }
        public int PostProgram(Program program)
        {
            return 0;
        }
    }
}
