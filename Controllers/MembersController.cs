using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class MembersController : Controller
    {
        private readonly ILibraryService _libraryService;

            public MembersController(ILibraryService libraryService)
            {
                _libraryService = libraryService;
            }

            [HttpGet("GetAllMembers")]
            public IActionResult GetMembers() => Ok(_libraryService.GetMembers());

            [HttpGet("GetMember/{id}")]
            public IActionResult GetMember(int id)
            {
                var member = _libraryService.GetMember(id);
                return member is null ? NotFound() : Ok(member);
            }

            [HttpPost("AddMember")]
            public IActionResult AddMember([FromBody] MemberDto memberDto)
            {
                var member = new Member
                {
                    Name = memberDto.Name,
                    Email = memberDto.Email
                };
                _libraryService.AddMember(member);
                return Ok(member);
            }

            [HttpPut("UpdateMember/{id}")]
            public IActionResult Updatemember(int id, [FromBody] MemberDto memberDto)
            {
                var updated = new Member
                {
                    Name = memberDto.Name,
                    Email = memberDto.Email
                };
            _libraryService.UpdateMember(id, updated);
                return Ok("member Updated");
            }

            [HttpDelete("DeleteMember/{id}")]
            public IActionResult DeleteMember(int id)
            {
                _libraryService.DeleteMember(id);
                return Ok("member Deleted");
            }
        }
    
}
