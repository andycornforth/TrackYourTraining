using DBModels;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SetBusiness
    {
        SetRepository setRepository = new SetRepository();

        public Set GetSet(int id)
        {
            return setRepository.GetSet(id);
        }

        public int CreateNewSet(Set set)
        {
            return setRepository.CreateNewSet(set);
        }
    }
}
