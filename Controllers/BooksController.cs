using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace fish_api.Controllers
{
    /// <summary>
    /// Endpoints associated to Book Resource
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private IRepository _repository;

        public BooksController(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="200">Returns array of books</response>
        [HttpGet]
        public IActionResult Get()
        {
            var result = new Result
            {
                Results = _repository.GetAll()
            };


            return Ok(result);
        }

        /// <summary>
        /// Gets a specific book.
        /// </summary>
        /// <param name="id"></param> 
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /books/{id}
        /// </remarks>
        /// <response code="404">If the item is not found</response>                 
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var book = _repository.GetById(id);
            if (book == null)
                return NotFound();

            var result = new Result
            {
                Results = book
            };


            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Book newBook)
        {
            if (_repository.Find(newBook) != null)
            {
                return StatusCode(409);
            };

            _repository.Add(newBook);

            return CreatedAtRoute("", new { id = newBook.Id }, newBook);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
