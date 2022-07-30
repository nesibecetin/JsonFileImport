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
    public class LanguageManager : ILanguageService
    {
        ILanguageDal _languageDal;
        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        public List<Language> GetAllLanguages()
        {
            var result = _languageDal.GetAll();
            if (result == null)
            {
                throw new Exception("Dil Bulunamadı");
            }
            return result;
        }

        public Language GetLanguage(int id)
        {
            var result = _languageDal.Get(x => x.Id == id);
            if (result == null)
            {
                throw new Exception("Dil Bulunamadı");
            }
            return result;
           
        }

        public Language GetLanguageByCulture(string culture)
        {
            var result = _languageDal.GetAll().FirstOrDefault(x =>
                x.Culture.Trim().ToLower() == culture.Trim().ToLower());
            if (result == null)
            {
                throw new Exception("Dil Bulunamadı");
            }
            return result;
        }

      
    }
}
