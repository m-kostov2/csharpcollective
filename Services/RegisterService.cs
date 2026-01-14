
using CSharpCollective.Models.DtoModels;
using DataBase.DataBaseProvider;
using DataBase.DataContext;
using DataBase.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class RegisterService 
    {

        private CollectiveContext _context;

        public RegisterService()
        {
            _context = new CollectiveContext();
        }
        

        public async Task<User> CommunicationService(UserDto Datarecieved)
        {

            User userRegistered = new User()
            {
                UserName = Datarecieved.UserName,
                Email = Datarecieved.Email,
                Password = Datarecieved.Password,
                

            };

            

            _context.Users.Add(userRegistered);
            await _context.SaveChangesAsync();

            return userRegistered;

        }
    }
}