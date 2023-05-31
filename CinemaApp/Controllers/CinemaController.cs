using AutoMapper;
using CinemaApp.Data;
using CinemaApp.Data.Dtos;
using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace CinemaApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private FilmesContext _context;
        private IMapper _mapper;

        public CinemaController(FilmesContext context, IMapper mapper)
        {
            _context= context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDTO cinemaDTO)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDTO);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IEnumerable RecuperaCinemas([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadCinemaDTO>>(_context.Cinemas.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if(cinema == null)
                return NotFound();
            return Ok(_mapper.Map<ReadCinemaDTO>(cinema));
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, UpdateCinemaDTO cinemaDTO)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if(cinema == null)
                return NotFound();
            _mapper.Map(cinemaDTO, cinema);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if(cinema == null)
                return NotFound();
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
