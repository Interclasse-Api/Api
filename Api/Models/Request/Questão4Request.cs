using System.Collections.Generic;


namespace Api.Models.Request
{
    public class Questão4Request
    {
        public class PersonagemRequest
        {
            public string Filme { get; set; }
            public List<string> Personagens { get; set; }

        }

    }
}