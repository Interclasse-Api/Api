using System.Collections.Generic;


namespace Api.Models.Response
{
    public class Questão4Response
    {
        public class PersonagemResponse
        {
            public int Filme { get; set; }
            public List<int> Personagens { get; set; }

        }   
    }
}