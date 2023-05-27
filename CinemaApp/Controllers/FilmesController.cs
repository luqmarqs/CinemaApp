using AutoMapper;
using CinemaApp.Data;
using CinemaApp.Data.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace CinemaApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private FilmesContext _context;
        private IMapper _mapper;

        public FilmesController(FilmesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery] int skip = 0,[FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            var filme = _context.Filmes
                .FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return Ok(filmeDto);
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDTO> patch)
        {
            var filme = _context.Filmes.FirstOrDefault(
                filme => filme.Id == id);
            if (filme == null) return NotFound();
            var filmeParaAtualizar = _mapper.Map<UpdateFilmeDTO>(filme);

            patch.ApplyTo(filmeParaAtualizar, ModelState);

            if (!TryValidateModel(filmeParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(filmeParaAtualizar, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(
                filme => filme.Id == id);
            if (filme == null) return NotFound();
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
