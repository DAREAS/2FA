using _2FAService.Models;
using _2FAService.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace _2FAService.Controllers
{
    public class AccessControlController : ApiController
    {
        private readonly UserViewModel Users;

        public AccessControlController()
        {
            Users = UserViewModel.Instance;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Users.Users;
        }

        [HttpGet]
        public User GetUSer([FromUri] string userName, [FromUri] string password)
        {
            try {

                var currentUser = Users.GetUserByUserNameAndPassword(userName, password);

                return currentUser;
            }
            catch(Exception exception) {

                throw new Exception(exception.Message);
            }
        }
    }
}