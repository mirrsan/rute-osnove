using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using frrstBildStudioProject.Models;

namespace TodoApi.Controllers
{
    /// <summary>
    /// aloha
    /// </summary>
    [Produces("application/json")]
    [Route("api/Todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }
        /// <summary>
        ///  getTodoItems 
        /// </summary>
        /// <remarks>Remarks place</remarks>
        /// <returns></returns>
        /// 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // get metod
        /// <summary>
        /// get item
        /// </summary>
        /// <param name="id">id obavezno</param>
        /// <returns>int</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if(todoItem == null)
            {
                return NotFound();
            }
            return todoItem;
        }

        // post metod
        /// <summary>
        /// Post  item
        /// </summary>
        /// <param name="todoItem">Obavezan unos todoItem-a</param>
        /// <returns></returns>
        [HttpPost("{todoItem}")]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        }

        // delete metod
        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="id">Obavezan id</param>
        /// <returns>todoItem</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }
        
       

    }
}