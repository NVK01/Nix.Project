using Business.Layer.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> AddUserAsync(ApplicationUserDTO userDto, bool rememberMe);
        public Task<SignInResult> Login(ApplicationUserDTO userDto);
        //public Task SignOut();        
        Task<Guid> GetUserIdAsync(ClaimsPrincipal userClaim);
        public Task<ApplicationUserInfoDTO> GetUserInfoAsync(string username);
        public Task<ApplicationUserInfoDTO> GetUserInfoAsync(ClaimsPrincipal userClaim);
        public Task<bool> UpdateProfileAsync(ApplicationUserInfoDTO userDto);
        public Task<bool> UpdateProfileIconAsync(ApplicationUserInfoDTO userDto);
        public Task<bool> ChangePasswordAsync(ApplicationUserInfoDTO userDto);
        Task<List<PaintingDTO>> UserList(string username);
        //Task<List<PaintingDTO>> GetAllByUserAsync(Guid id);
    }
}
