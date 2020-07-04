using System.Collections.Generic;


namespace Api.Utils
{
    public class Questão4Conversor
    {
        public Models.Response.Questão4Response.PersonagemResponse ParaPersonagemResponse(int filmeId, List<int> personagensId)
        {
            Models.Response.Questão4Response.PersonagemResponse resp = new Models.Response.Questão4Response.PersonagemResponse();
            resp.Filme = filmeId;
            resp.Personagens = personagensId;
            return resp;
        }
    }
}