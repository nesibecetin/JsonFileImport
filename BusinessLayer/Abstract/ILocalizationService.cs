using Entities.Concrete;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ILocalizationService
    {
        List<StringResources> GetStringResource(string resourceKey, int languageId);

        public List<StringResources> Localize(string resourceKey, Users users);



    }
}
