using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechStore.Helpers;
using TechStore.Models;
using TechStoreAPI.DTOs.Request;

namespace TechStoreAPI.Controllers.V1.Users
{
    public partial class UsersController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<User>> Create(UserDTO inputUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = new User(

            inputUser.Username,
            inputUser.Email,
            inputUser.Password = PasswordHasher.HashPassword(inputUser.Password),
            inputUser.Role
            );

            await _userRepository.Add(newUser);

            return Ok(newUser);
        }
    }
}