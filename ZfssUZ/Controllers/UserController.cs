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
                Id = result.Id,
                IsLocked = result.LockoutEnd != null ? true : false,
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

        public ActionResult Edit (string userId)
        {
            var user = userService.GetUserById(userId);
            var model = new UserModel
            {
                Firstname = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.Email,
                City = user.City,
                Address = user.Address,
                PostCode = user.PostCode,
                PhoneNumber = user.PhoneNumber,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateUserData(UserModel model)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UnlockUser (string userId)
        {
            userService.UnlockUser(userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult LockUser(string userId)
        {
            userService.LockUser(userId);
            return RedirectToAction("Index");
        }

        public ActionResult Show(string userId)
        {
            var user = userService.GetUserById(userId);
            var model = new UserModel
            {
                Username = user.UserName,
                Firstname = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.Email,
                City = user.City,
                Address = user.Address,
                PostCode = user.PostCode,
                PhoneNumber = user.PhoneNumber,
                UserGroup = userService.GetUserGroupById(user.UserGroupId).GroupName,
                IsLocked = user.LockoutEnd != null ? true : false,
            };

            return PartialView("ShowUser", model);
        }

        [HttpPost]
        public ActionResult DeleteUser(string userId)
        {
            try
            {
                userService.DeleteUser(userId);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}