using BusinessLayer.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StringResourcesManager : IStringResourcesService
    {
        IStringResourcesDal _stringResourcesDal;

        public StringResourcesManager(IStringResourcesDal stringResourcesDal)
        {
            _stringResourcesDal = stringResourcesDal;
        }

        public void Add(StringResources stringResources)
        {
           _stringResourcesDal.Add(stringResources);
        }

        public List<StringResources> GetAll()
        {
            var result = _stringResourcesDal.GetAll();
            if(result == null)
            {
                throw new Exception("Bilgi Bulunmamaktadır");
            }
            return result;
            
        }
    }
}
