using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notebook.Data;
using Notebook.Models;

namespace Notebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly DataContext _context;

        public NotesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var notes = await _context.Notes.ToListAsync();
            return Ok(notes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return Ok(note);
        }
    }
}
