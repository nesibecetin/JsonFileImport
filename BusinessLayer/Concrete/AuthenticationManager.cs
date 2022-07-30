using Business.Abstract;
using BusinessLayer.Abstract;
using BusinessLayer.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Authentication
{
    public class AuthenticationManager : IAuthenticationService
    {

        public IConfiguration _configuration;
        IUserService _userService;
        ILanguageService _languageService;
        public AuthenticationManager(IConfiguration configuration, IUserService userService, 
            ILanguageService languageService)
        {
            _languageService = languageService;
            _configuration = configuration;
            _userService = userService;
        }
        

        public Language GetUserCulture(Users users)
        {
            var result = this.Login(users).LanguageId;
            if(result == null)
            {
                throw new Exception("Bulunamadı");
            }

            return _languageService.GetLanguage(result);
           
        }

        public Users Login(Users user)
        {
            LoginUserValidator validator = new LoginUserValidator();
            ValidationResult result1 = validator.Validate(user);
            var result = _userService.GetByMail(user.Email);
            if (result != null && result1.IsValid)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateToken();
                result.Token = JsonConvert.SerializeObject(token);               
             
                _userService.Update(result);
              

            }
            else
            {
                throw new Exception("Bilgiler yanlış");
            }
            return result;
        }

        public Users Register(Users user)
        {
            RegisterUserValidator validator = new RegisterUserValidator();
            ValidationResult result1 = validator.Validate(user);
            ;
            if ( result1.IsValid)
            {
                 _userService.Add(user);
            }
            else
            {
                throw new Exception("kullanıcı zaten var");
            }
            return user;
        }

      
    }
}
