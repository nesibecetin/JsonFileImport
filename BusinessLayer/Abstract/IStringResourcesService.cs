using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStringResourcesService 
    {
        void Add(StringResources stringResources);
        List<StringResources> GetAll();

    }
}
