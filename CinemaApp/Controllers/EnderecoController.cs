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
    public class EnderecoController : ControllerBase
    {
        private readonly FilmesContext _context;
        private readonly IMapper _mapper;

        public EnderecoController(FilmesContext filmesContext, IMapper mapper)
        {
            _context = filmesContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CriaEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDTO);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable RecuperaEnderecos([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadEnderecoDTO>>(_context.Enderecos.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);
            if(endereco == null)
                return NotFound();
            return Ok(_mapper.Map<ReadEnderecoDTO>(endereco));

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDTO)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
            if(endereco == null)
                return NotFound();
            _mapper.Map(enderecoDTO, endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveEndereco(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null)
                return NotFound();
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
