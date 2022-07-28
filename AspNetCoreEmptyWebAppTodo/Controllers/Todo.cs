using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FirstWebApp.Data;
using FirstWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApp.Controllers
{
    [Route("api/todo")]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodo()
        {
            var data = await _context.Todo.ToListAsync();
            return data;
        }


        // PUT: api/todo/5
        [HttpPut("api/todo/{id}")]
        public async Task<IActionResult> PutTodo(int id, Todo todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }


            return NoContent();
        }

        // POST: api/todo
        [HttpPost("api/todo")]
        public async Task<ActionResult<Todo>> PostTodo(Todo todo)
        {
             _context.Todo.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodo", new { id = todo.Id }, todo);
        }

         // DELETE: api/todo/5
        [HttpDelete("api/todo/{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            _context.Todo.Remove(new Todo { Id = id });
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

}