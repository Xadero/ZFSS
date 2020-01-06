using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZfssUZ.Models.Users;
using ZfssUZData.Interfaces;
using ZfssUZData.Models.Users;

namespace ZfssUZ.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        private UserManager<ApplicationUser> _userManager;
        public UserController(IUserService service, UserManager<ApplicationUser> userManager)
        {
            userService = service;
            _userManager = userManager;
        }

        public static string idUser = string.Empty;

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
                UserGroup = userService.GetUserGroupById(result.UserGroupId).GroupName,
                UserGroupId = result.UserGroupId
            });

            var model = new UserListModel();
            model.UserList = userList;

            return View(model);
        }

        public ActionResult Register()
        {
            var model = new RegisterModel()
            {
                CategoryList = new SelectList(userService.GetUserGroups(), "Id", "GroupName")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            model.CategoryList = new SelectList(userService.GetUserGroups(), "Id", "GroupName");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.EmailAddress,
                    FirstName = model.Firstname,
                    LastName = model.LastName,
                    City = model.City,
                    Address = model.Address,
                    DateOfBirth = model.DateOfBirth,
                    Password = model.Password,
                    PostCode = model.PostCode,
                    UserGroupId = model.UserGroupId,
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit (string userId)
        {
            idUser = userId;
            var user = userService.GetUserById(userId);
            var model = new UserModel
            {
                Username = user.UserName,
                Id = user.Id,
                Firstname = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.Email,
                City = user.City,
                Address = user.Address,
                PostCode = user.PostCode,
                PhoneNumber = user.PhoneNumber,
                UserGroup = userService.GetUserGroupById(user.UserGroupId).GroupName,
                UserGroupId = user.UserGroupId,
                CategoryList = new SelectList(userService.GetUserGroups(), "Id", "GroupName")
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserModel model)
        {
            model.Id = idUser;
            model.CategoryList = new SelectList(userService.GetUserGroups(), "Id", "GroupName");
            if (ModelState.IsValid)
            {
                var userToUpdate = new ApplicationUser
                {
                    FirstName = model.Firstname,
                    LastName = model.LastName,
                    Email = model.EmailAddress,
                    PhoneNumber = model.PhoneNumber,
                    Id = model.Id,
                    Address = model.Address,
                    City = model.Address,
                    PostCode = model.PostCode,
                    UserName = model.Username,
                    UserGroupId = model.UserGroupId
                };

                userService.UpdateUserData(userToUpdate);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
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