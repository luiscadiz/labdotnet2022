using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.TP4.Data;
using App.TP4.Entities;

namespace App.TP4.Logic
{
    public class RickAndMortyLogic
    {
        
        public List<CharacterRickAndMortyDTO> GetCharacters()
        {
            try
            {
                var query = new CharactersRickAndMortyQuery();
                return query.GetCharactersRickAndMorty();

            }catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
