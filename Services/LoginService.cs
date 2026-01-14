

using CSharpCollective.Models.DtoModels;
using DataBase.DataContext;
using DataBase.Models;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Services
{
    public class LoginService 
    {

        private CollectiveContext _context;

        public LoginService()
        {
            _context = new CollectiveContext();
        }

        public async Task<User> CommunicationService(UserDto Datarecieved) 
        {


            

            bool userExists = _context.Users.Any(u => u.UserName == Datarecieved.UserName);



            User userInfo = new User();
            if (userExists == true)
            {
                var role = _context.Users.Where(u => u.UserName == Datarecieved.UserName).Select(u => u.Role).ToString();

                if (role == "Admin")
                {
                    userInfo = _context.Users.Where(u => u.UserName == Datarecieved.UserName).Select(u => new User
                    {
                        UserName = u.UserName,
                        Email = u.Email,
                        Role = u.Role,
                        Posts = u.Posts.ToArray()

                    }).Single();



                }
                else if (role == "User")
                {
                    userInfo = _context.Users.Where(u => u.UserName == Datarecieved.UserName).Select(u => new User
                    {
                        UserName = u.UserName,
                        Email = u.Email,
                        Role = u.Role

                    }).Single();

                }

            }
            else if (userExists == false)
            { 
            
            return null;
            }

                return await Task.FromResult(userInfo);

        }

        }
    }
