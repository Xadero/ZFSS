using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZfssUZ.Models.Users;
using ZfssUZData.Interfaces;

namespace ZfssUZ.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        public UserController(IUserService service)
        {
            userService = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var users = userService.GetAllUsers().ToList();

            var userList = users.Select(result => new UserModel
            {
                Username = result.UserName,
                Firstname = result.FirstName,
                LastName = result.LastName,
                EmailAddress = result.Email,
                PhoneNumber = result.PhoneNumber,
                Address = result.Address,
                PostCode = result.PostCode,
                City = result.City,
                UserGroup = userService.GetUserGroupById(result.UserGroupId).GroupName
            });

            var model = new UserListModel();
            model.UserList = userList;

            return View(model);
        }
    }
}