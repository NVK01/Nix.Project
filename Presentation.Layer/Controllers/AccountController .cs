using AutoMapper;
using Business.Layer.DTO;
using Business.Layer.Interfaces;
using Data.Access.Layer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nix.Project.Models;
using Presentation.Layer.Models;

namespace Presentation.Layer.Controllers
{
    public class AccountController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        //private readonly UserManager<ApplicationUserVM> _userManager;
        //private readonly SignInManager<ApplicationUserVM> _signInManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IMapper mapper, ILogger<AccountController> logger, IWebHostEnvironment _webHostEnvironment, IUserService userService)
        {
            //_signInManager = signInManager;
            //_userManager = userManager;
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
            webHostEnvironment = _webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationVM model)
        {
            
             var userDto = new ApplicationUserDTO()
             {
                 Password = model.Password,
                 UserName = model.UserName,
                 Email = model.Email,
                 RememberMe = model.RememberMe,
             };

            var result = await _userService.AddUserAsync(userDto, model.RememberMe);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var identityError in result.Errors)
            {
                ModelState.AddModelError("", identityError.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("", "All fields have to be filled!");
            }

            if (!ModelState.IsValid) return View(model);

            var userDto = new ApplicationUserDTO() { Email = model.Email, UserName = model.Email,Password = model.Password, RememberMe = model.RememberMe };

            var result = await _userService.Login(userDto);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Incorrect data!");

            return View(model);
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AccountInfo()
        {
            var user = await _userService.GetUserInfoAsync(this.User.Identity.Name);

            var model = new ApplicationUserInfoVM()
            {
                Id = user.Id,
                UserName = user.UserName,
                IconURL = user.IconURL,
                About = user.About,
                Email = user.Email,
                Password = user.Password,
            };

            return View(model);

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AccountInfo(ApplicationUserInfoVM model)
        {
            var userDto = new ApplicationUserInfoDTO()
            {              
                Id = await _userService.GetUserIdAsync(this.User),
                UserName = model.UserName,
                About = model.About,
                Email = model.Email
            };
            var isSuccess = await _userService.UpdateProfileAsync(userDto);
            if (isSuccess)
                return RedirectToAction("AccountInfo", "Account", new { username = this.User.Identity.Name });

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AccountInfoImg(ApplicationUserInfoVM model )
        {
            string uniqueFileName = UploadedFile(model);
            var userDto = new ApplicationUserInfoDTO()
            {
                Id = await _userService.GetUserIdAsync(this.User),
                IconURL = uniqueFileName,
            };
            var isSuccess = await _userService.UpdateProfileIconAsync(userDto);
            if (isSuccess)
                return RedirectToAction("AccountInfo", "Account", new { username = this.User.Identity.Name });

            return View();
        }
 
        private string UploadedFile(ApplicationUserInfoVM model)
        {
            string? uniqueFileName = null;

            if (model.IconFile != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.IconFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.IconFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        [HttpPost]
        public async Task<IActionResult> AccountInfoPassword(ApplicationUserInfoVM model)
        {
            var userDto = new ApplicationUserInfoDTO()
            {
                Id = await _userService.GetUserIdAsync(this.User),
                Password = model.Password,

            };

            var isSuccess = await _userService.ChangePasswordAsync(userDto);

            if (isSuccess)
                return RedirectToAction("AccountInfo", "Account", new { username = this.User.Identity.Name
            });

            ModelState.AddModelError("", "Error with user updating.");

            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUserPaintings()
        {
            var list = await _userService.UserList(this.User.Identity.Name);

            return View(_mapper.Map<List<PaintingVM>>(list));
        }
    }
}
