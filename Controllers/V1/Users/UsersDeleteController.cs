using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
using TechStoreAPI.DTOs.Request;

namespace TechStoreAPI.Controllers.V1.Users
{
    public partial class UsersController : ControllerBase
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepository.CheckExistence(id);
            if (user == false)
            {
                return NotFound();
            }

            await _userRepository.Delete(id);

            return NoContent();
        }
    }
}