using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.TP4.Entities;
using System.Net;
using Newtonsoft.Json;

namespace App.TP4.Data
{
    public class CharactersRickAndMortyQuery
    {
        private readonly RickAndMortyContext _context;

        public CharactersRickAndMortyQuery()
        {
            _context = new RickAndMortyContext();
        }

        public List<CharacterRickAndMortyDTO> GetCharactersRickAndMorty()
        {
            var data = _context.client.DownloadString(_context.url);
            var characters = JsonConvert.DeserializeObject<RickAndMortyModel>(data);
            var listCharacters = characters.results.Select(c => new CharacterRickAndMortyDTO
            {
                Name = c.name,
                Species = c.species,
                Gender = c.gender,
                UrlImage = c.image

            }).Take(10).ToList();

            return listCharacters;
        }
        
    }
}
