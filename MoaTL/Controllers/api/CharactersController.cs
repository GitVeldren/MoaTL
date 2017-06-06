using AutoMapper;
using MoaTL.Dtos;
using MoaTL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace MoaTL.Controllers.api
{
    public class CharactersController : ApiController
    {
        private ApplicationDbContext _context;

        public CharactersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<CharacterDto> GetCharacters()
        {
            return _context.Characters.ToList().Select(Mapper.Map<Character, CharacterDto>);
        }

        [HttpGet]
        public IHttpActionResult GetCharacter(int id)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);

            if (character == null)
                return NotFound();

            return Ok(Mapper.Map<Character, CharacterDto>(character));
        }

        [HttpPost]
        public IHttpActionResult CreateCharacter(CharacterDto characterDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var character = Mapper.Map<CharacterDto, Character>(characterDto);
            _context.Characters.Add(character);
            _context.SaveChanges();

            characterDto.Id = character.Id;
            return Created(new Uri(Request.RequestUri + "/" + character.Id), characterDto);
        }

        [HttpPut]
        public void UpdateCharacter(int id, CharacterDto characterDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var characterInDb = _context.Characters.SingleOrDefault(c => c.Id == id);

            if (characterInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(characterDto, characterInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCharacter(int id)
        {
            var characterInDb = _context.Characters.SingleOrDefault(c => c.Id == id);

            if (characterInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Characters.Remove(characterInDb);
            _context.SaveChanges();
        }
    }
}
