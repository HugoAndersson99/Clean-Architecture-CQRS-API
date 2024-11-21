using Application.Commands.Authors.AddAuthor;
using Application.Commands.Authors.DeleteAuthor;
using Application.Commands.Authors.UpdateAuthor;
using Application.Commands.Books.AddBook;
using Application.Commands.Books.DeleteBook;
using Application.Commands.Books.UpdateBook;
using Application.Queries.Authors.GetAllAuthors;
using Application.Queries.Authors.GetAuthorById;
using Application.Queries.Books.GetAll;
using Application.Queries.Books.GetById;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        [Route("getAllAuthors")]
        public async Task<IActionResult> GetAllAuthorsFromDB()
        {
            // return Ok(await _mediator.Send(new GetAllAuthorsQuery()));
            var authors = await _mediator.Send(new GetAllAuthorsQuery());

            var authorsWithBooks = authors.Select(author => new
            {
                author.Id,
                author.Name,
                Books = author.Books // Lägg till böcker här
            });

            return Ok(authorsWithBooks);
        }

        // GET api/<AuthorController>/5
        [HttpGet]
        [Route("getAuthorById/{authorId}")]
        public async Task<IActionResult> GetAuthorById(int authorId)
        {
            // return Ok(await _mediator.Send(new GetAuthorByIdQuery(authorId)));
            var author = await _mediator.Send(new GetAuthorByIdQuery(authorId));

            // Skapa en anpassad struktur med böcker
            var authorWithBooks = new
            {
                author.Id,
                author.Name,
                Books = author.Books // Inkluderar böcker här
            };

            return Ok(authorWithBooks);
        }

        // POST api/<AuthorController>
        [HttpPost]
        [Route("AddNewAuthor")]
        public async void Post([FromBody] Author authorToAdd)
        {
            await _mediator.Send(new AddAuthorCommand(authorToAdd));
        }

        // PUT api/<AuthorController>/5
        [HttpPut]
        [Route("updateAuthor/{updatedAuthorId}")]
        public async Task<IActionResult> UpdateAuthor([FromBody] Author updatedAuthor, int updatedAuthorId)
        {
            return Ok(await _mediator.Send(new UpdateAuthorByIdCommand(updatedAuthor, updatedAuthorId)));
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async void DeleteAuthor(int id)
        {
            await _mediator.Send(new DeleteAuthorCommand(id));
        }
    }
}
