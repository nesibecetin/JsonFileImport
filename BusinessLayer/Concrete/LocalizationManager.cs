using Business.Abstract;
using BusinessLayer.Abstract;
using BusinessLayer.Caching;
using BusinessLayer.Caching.InMemory;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LocalizationManager : ILocalizationService
    {
        IStringResourcesService _stringResourcesService;
        ICacheManager _memoryCache;
        IAuthenticationService _authenticationService;
      
        public LocalizationManager(IStringResourcesService stringResourcesService,
            IAuthenticationService authenticationService, ICacheManager memoryCache)
        {
            _memoryCache = memoryCache;
            _authenticationService = authenticationService;
            _stringResourcesService = stringResourcesService;
          
        }

        public List<StringResources> GetStringResource(string resourceKey, int languageId)
        {
            const string key = "stringresources";
            var result = _stringResourcesService.GetAll().Where(x=>x.Name== resourceKey && x.LanguageId == languageId);
            if (result == null)
            {
                throw new Exception("Kaynak Bulunamadı");
            }
            _memoryCache.Add(key, result, 60);
            return result.ToList();
        }

        public List<StringResources> Localize(string resourceKey , Users users)
        {
            const string key = "stringresources";
            var currentCulture = _authenticationService.GetUserCulture(users);
           
            var stringResource = this.GetStringResource(resourceKey, currentCulture.Id);
            if (currentCulture != null)
            {
                if (stringResource != null)
                {
                    if (_memoryCache.IsAdd(key))
                        _memoryCache.Get(key);
                    else
                        _memoryCache.Add(key, stringResource, 60);
                    
                    return stringResource;
                }
                else
                    throw new Exception("yönlendirme yapılamadı");
                
            }           

            return stringResource;
        }
    }
}
