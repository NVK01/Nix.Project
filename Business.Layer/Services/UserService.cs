using AutoMapper;
using Business.Layer.DTO;
using Business.Layer.Interfaces;
using Data.Access.Layer.Entities;
using Data.Access.Layer.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        
        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<IdentityResult> AddUserAsync(ApplicationUserDTO userDto, bool rememberMe)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded) return result;

            await _signInManager.SignInAsync(user, rememberMe);           

            return result;
        }

        public async Task<Guid> GetUserIdAsync(ClaimsPrincipal userClaim) => (await _userManager.GetUserAsync(userClaim)).Id;

        /*await _userManager.FindByNameAsync(userDto.UserName) ??*/
        public async Task<SignInResult> Login(ApplicationUserDTO userDto)
        {
            var user = await _userManager.FindByNameAsync(userDto.UserName) ??  await _userManager.FindByEmailAsync(userDto.Email);

            if (user == null)
                return SignInResult.Failed;

            return await _signInManager.PasswordSignInAsync(user, userDto.Password, userDto.RememberMe, false);
        }

        //public Task SignOut()
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<ApplicationUserInfoDTO> GetUserInfoAsync(string username)
        {
            try
            {
                
                var applicationUserDTO = await _userManager.FindByNameAsync(username);
                
                return _mapper.Map<ApplicationUserInfoDTO>(applicationUserDTO); 
            }
            catch
            {
                return new ApplicationUserInfoDTO();
            }
        }

        public async Task<ApplicationUserInfoDTO> GetUserInfoAsync(ClaimsPrincipal userClaim) => _mapper.Map<ApplicationUserInfoDTO>(await _userManager.GetUserAsync(userClaim));
        public async Task<bool> UpdateProfileAsync(ApplicationUserInfoDTO userDto)
        {
            var us = userDto.Id.ToString();
            var user = await _userManager.FindByIdAsync(us);
            
            user.Id = userDto.Id;
            user.UserName = userDto.UserName;
            user.About = userDto.About;
            user.Email = userDto.Email;
            //user.IconURL = userDto.IconURL;

            await _userManager.UpdateAsync(user);

            return true;
        }
        public async Task<bool> UpdateProfileIconAsync(ApplicationUserInfoDTO userDto)
        {
            var us = userDto.Id.ToString();
            var user = await _userManager.FindByIdAsync(us);
            //var user = Guid.Parse(er);
            user.Id = userDto.Id;
            user.IconURL = userDto.IconURL;

            await _userManager.UpdateAsync(user);
            //await UserManager.ChangePasswordAsync(user, userDto.Password, userDto.Password);

            //await _userManager.RefreshSignInAsync(user);

            return true;
        }
        public async Task<bool> ChangePasswordAsync(ApplicationUserInfoDTO userDto)
        {
            var us = userDto.Id.ToString();
            var user = await _userManager.FindByIdAsync(us);

            user.PasswordHash = userDto.Password;


            await _userManager.RemovePasswordAsync(user);
            await _userManager.AddPasswordAsync(user, userDto.Password);
            return true;
        }
        //public Task<List<PaintingDTO>> GetAllByUserAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<PaintingDTO>> UserList(string username)
        {
            var id = (await _userManager.FindByNameAsync(username)).Id;

            var paintings = await _unitOfWork.Paintings.GetAllAsync();

            var ownpaint = paintings.Where(u => u.ApplicationUserId == id);

            return (List<PaintingDTO>)ownpaint;
           
        }

        
    }
}
