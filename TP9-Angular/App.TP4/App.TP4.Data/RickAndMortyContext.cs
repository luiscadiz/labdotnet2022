using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace App.TP4.Data
{
    public class RickAndMortyContext
    {
        public string url;
        public WebClient client;

        public RickAndMortyContext()
        {
            this.url = "https://rickandmortyapi.com/api/character";
            this.client = new WebClient();
        }
    }
}
