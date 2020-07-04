using System.Collections.Generic;

 
namespace Api.Utils
{
    public class Questao4Conversor
    {
        public Models.Response.Questao4Response.PersonagemResponse ParaPersonagemResponse(int filmeId, List<int> personagensId)
        {
            Models.Response.Questao4Response.PersonagemResponse resp = new Models.Response.Questao4Response.PersonagemResponse();
            resp.Filme = filmeId;
            resp.Personagens = personagensId;
            return resp;
        }
    }
}