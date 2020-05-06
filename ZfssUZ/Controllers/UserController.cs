using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZfssUZ.Models.Users;
using ZfssUZData.Interfaces;
using ZfssUZData.Models.Users;
using Microsoft.Extensions.Localization;
using AutoMapper;

namespace ZfssUZ.Controllers
{
    public class UserController : Controller
    {
        public static string idUser = string.Empty;
        private readonly IMapper mapper;
        private IUserService userService;
        private IDictionaryService dictionaryService;
        private IBenefitService benefitService;
        private UserManager<ApplicationUser> userManager;
        private readonly IStringLocalizer<UserController> localizer;
        public UserController(IUserService userService, UserManager<ApplicationUser> userManager, IStringLocalizer<UserController> localizer, IDictionaryService dictionaryService, IMapper mapper, IBenefitService benefitService)
        {
            this.userService = userService;
            this.dictionaryService = dictionaryService;
            this.userManager = userManager;
            this.localizer = localizer;
            this.mapper = mapper;
            this.benefitService = benefitService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = userService.GetAllUsers().ToList();
            var userList = users.Select(result => new UserModel
            {
                Id = result.Id,
                Username = result.UserName,
                Firstname = result.FirstName,
                LastName = result.LastName,
                IsLocked = result.LockoutEnd.HasValue
            });

            var model = new UserListModel()
            {
                UserList = userList
            };

            return View(model);
        }

        public IActionResult Register()
        {
            var model = new RegisterModel()
            {
                UserGroupList = new SelectList(userService.GetUserGroups(), "Id", "GroupName"),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            model.UserGroupList = new SelectList(userService.GetUserGroups(), "Id", "GroupName");

            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.EmailAddress,
                FirstName = model.Firstname,
                LastName = model.LastName,
                City = model.City,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth.Value,
                Password = model.Password,
                PostCode = model.PostCode,
                UserGroupId = model.UserGroup.Id,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return RedirectToAction("Index");

            foreach (var error in result.Errors)
            {
                if (error.Code == "DuplicateUserName")
                    ModelState.AddModelError(string.Empty, string.Format(localizer["DuplicateUsername"], user.UserName));

                if (error.Code == "DuplicateEmail")
                    ModelState.AddModelError(string.Empty, string.Format(localizer["DuplicateEmail"], user.Email));
                if (result.Errors.Any())
                    return View(model);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit (string userId)
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
                DateOfBirth = user.DateOfBirth,
                City = user.City,
                Address = user.Address,
                PostCode = user.PostCode,
                PhoneNumber = user.PhoneNumber,
                UserGroup = mapper.Map<UserGroupModel>(dictionaryService.Get<UserGroup>(user.UserGroupId)),
                UserGroupList = new SelectList(userService.GetUserGroups(), "Id", "GroupName"),
                IsLocked = user.LockoutEnd.HasValue
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserModel model)
        {
            model.Id = idUser;
            model.UserGroupList = new SelectList(userService.GetUserGroups(), "Id", "GroupName");
            if (!ModelState.IsValid)
                return View(model);

            var userToUpdate = new ApplicationUser
            {
                FirstName = model.Firstname,
                LastName = model.LastName,
                Email = model.EmailAddress,
                PhoneNumber = model.PhoneNumber,
                Id = model.Id,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
                City = model.City,
                PostCode = model.PostCode,
                UserName = model.Username,
                UserGroupId = model.UserGroup.Id
            };

            if (model.IsLocked)
                userService.LockUser(model.Id);
            else
                userService.UnlockUser(model.Id);

            userService.UpdateUserData(userToUpdate);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UnlockUser (string userId)
        {
            userService.UnlockUser(userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult LockUser(string userId)
        {
            userService.LockUser(userId);
            return RedirectToAction("Index");
        }

        public IActionResult Show(string userId)
        {
            var user = userService.GetUserById(userId);
            var model = new UserModel
            {
                Username = user.UserName,
                Firstname = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                EmailAddress = user.Email,
                City = user.City,
                Address = user.Address,
                PostCode = user.PostCode,
                PhoneNumber = user.PhoneNumber,
                UserGroup = mapper.Map<UserGroupModel>(dictionaryService.Get<UserGroup>(user.UserGroupId)),
                IsLocked = user.LockoutEnd != null
            };

            return PartialView("ShowUser", model);
        }

        [HttpPost]
        public IActionResult DeleteUser(string userId)
        {
            try
            {
                benefitService.DeleteUserBenefits(userId);
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