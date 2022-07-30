using Business.Abstract;
using BusinessLayer.Abstract;
using BusinessLayer.Caching;
using DataAccess.Abstract;
using Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class JsonFileManager : IJsonFileService
    {
        IJsonFileDal _jsonFileDal;
        IStringResourcesService _stringResourceService;
        ICacheManager _cacheManager;

        public JsonFileManager(IJsonFileDal jsonFileDal, IStringResourcesService stringResourceService, ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
            _stringResourceService = stringResourceService;
            _jsonFileDal = jsonFileDal;
        }

        public void Add(JsonFile jsonPath)
        {
            
            try
            {
                const string key = "stringresources";
                var myJsonString = File.ReadAllText(jsonPath.Path);

                List<JsonTr> Objects = null;
                Objects = JsonConvert.DeserializeObject<List<JsonTr>>(myJsonString);

                List<JsonIt> Object = null;       
                Object = JsonConvert.DeserializeObject<List<JsonIt>>(myJsonString);

                if (jsonPath.LanguageId == (int)LanguageEnum.Tr)
                {
                    foreach (var objects in Objects)
                    {
                        StringResources strings = new StringResources
                        {
                            Category = objects.dc_Kategori,
                            Name="Turkish.Language.Events",
                            Date = objects.dc_Zaman,
                            Event = objects.dc_Olay,
                            EventId = objects.ID,
                            LanguageId = (int)LanguageEnum.Tr
                        };                       
                        _stringResourceService.Add(strings);
                        
                    }
                    _cacheManager.RemoveByPattern(key);
                }
               
                else if(jsonPath.LanguageId == (int)LanguageEnum.It)
                {
                    foreach (var objects in Object)
                    {
                        
                        StringResources strings = new StringResources
                        {
                            Category = objects.dc_Categoria,
                            Name = "Italian.Language.Events",
                            Date = objects.dc_Orario,
                            Event = objects.dc_Evento,
                            EventId = objects.ID,
                            LanguageId = (int)LanguageEnum.It
                        };
                        _stringResourceService.Add(strings);
                        
                    }
                    _cacheManager.RemoveByPattern(key);
                }            
            }
            catch 
            {
                throw new Exception("Hata oluştu");
            }
            _jsonFileDal.Add(jsonPath);
        }
    }
}
