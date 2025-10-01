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

            [HttpGet]
            public IActionResult GetMembers() => Ok(_libraryService.GetMembers());

            [HttpGet("{id}")]
            public IActionResult GetMember(int id)
            {
                var member = _libraryService.GetMember(id);
                return member is null ? NotFound() : Ok(member);
            }

            [HttpPost]
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

            [HttpPut("{id}")]
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

            [HttpDelete("{id}")]
            public IActionResult DeleteMember(int id)
            {
                _libraryService.DeleteMember(id);
                return Ok("member Deleted");
            }
        }
    
}
