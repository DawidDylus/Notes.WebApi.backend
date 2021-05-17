using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notes.Core;
using Notes.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notes.WebApi.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ILogger<NotesController> _logger;
        private readonly INotesServices _notesServices;

        public NotesController(ILogger<NotesController> logger, INotesServices notesServices)
        {
            _logger = logger;
            _notesServices = notesServices;
        }

        // GET: api/<NotesController>
        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_notesServices.GetNotes());
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}", Name ="GetNote")]
        public IActionResult GetNote(int id)
        {
            return Ok(_notesServices.GetNote(id));
        }
        
        // POST api/<NotesController>
        [HttpPost]
        public IActionResult CreateNote(Note note)
        {
            var newNote = _notesServices.CreateNote(note);

            return CreatedAtRoute("GetNote", new { newNote.Id }, newNote);
        }
        
        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public IActionResult EditNote(int id, [FromBody] Note note)
        {
            _notesServices.EditNote(id, note);
            return Ok();
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            _notesServices.DeleteNote(id);
            return Ok();
        }
    }
}
