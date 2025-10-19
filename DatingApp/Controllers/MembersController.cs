﻿using DatingApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {


        [HttpGet]
        public async Task< IActionResult> GetMembers()
        {
            var members = await context.Users.ToListAsync();

            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetMember(string id)
        {
            var member = await context.Users.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);



        }
    }
}
