using DBModels;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DayBusiness
    {
        DayRepository dayRepoitory = new DayRepository();
        DaySetRepository daySetRepository = new DaySetRepository();
        SetRepository setRepository = new SetRepository();

        public Day GetDayName(int dayId)
        {
            return dayRepoitory.GetDay(dayId);
        }

        public List<Set> GetSetsForDay(int dayId)
        {
            var daySets = daySetRepository.GetSetIdsForDay(dayId);
            var sets = new List<Set>();
            foreach (var daySet in daySets)
            {
                sets.Add(setRepository.GetSet(daySet.SetId));
            }
            return sets;
        }

        public int CreateNewDay(Day day)
        {
            return dayRepoitory.CreateNewDay(day);
        }
    }
}
