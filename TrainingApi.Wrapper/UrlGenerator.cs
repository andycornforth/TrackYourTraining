using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApi.Wrapper
{
    public class UrlGenerator
    {
        public static string GetMusclesUrl()
        {
            return "api/Muslce";
        }

        public static string GetMuscleUrl(int muscleId)
        {
            return string.Format("api/Muscle/{0}", muscleId);
        }

        public static string GetMovementsUrl()
        {
            return "api/Movement";
        }

        public static string GetMovementUrl(int movementId)
        {
            return string.Format("api/Movement/{0}", movementId);
        }

        public static string GetSetUrl()
        {
            return "api/Set";
        }

        public static string GetSetUrl(int setId)
        {
            return string.Format("api/Set/{0}", setId);
        }

        public static string GetDayNameUrl(int dayId)
        {
            return string.Format("api/DayName/{0}", dayId);
        }

        public static string GetSetsForDayUrl(int dayId)
        {
            return string.Format("api/SetsForDay/{0}", dayId);
        }

        public static string GetAddDayUrl()
        {
            return "api/AddDay";
        }

        public static string GetProgramsUrl()
        {
            return "api/Programs";
        }

        public static string GetProgramUrl()
        {
            return "api/Program";
        }

        public static string GetProgramUrl(int programId)
        {
            return string.Format("api/Program/{0}", programId);
        }

        public static string GetProgramDaysUrl(int programId)
        {
            return string.Format("api/Days/{0}", programId);
        }
    }
}
