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
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDTO updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var checkUser = await _userRepository.CheckExistence(id);
            if (checkUser == false)
            {
                return NotFound();
            }

            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password = PasswordHasher.HashPassword(updatedUser.Password);
            user.Role = updatedUser.Role;


            await _userRepository.Update(user);
            return NoContent();
        }
    }


}