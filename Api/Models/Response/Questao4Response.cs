using System.Collections.Generic;

 
namespace Api.Models.Response
{
    public class Questao4Response
    {
        public class PersonagemResponse
        {
            public int Filme { get; set; }
            public List<int> Personagens { get; set; }

        }   
    }
}