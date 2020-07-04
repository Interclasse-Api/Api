using System.Linq;
using System.Collections.Generic;

 
namespace Api.Utils
{
    public class Questao6Conversor
    {
         public Models.Response.Questao6Response.Questao6FinalResponse ParaQuestao6Response(Models.TbAtor ator)
        {
            Models.Response.Questao6Response.Questao6FinalResponse resp = new Models.Response.Questao6Response.Questao6FinalResponse();
            resp.Ator = new Models.Response.Questao6Response.Questao6AtorResponse();
            resp.Ator.Nome = ator.NmAtor;
            resp.Ator.Altura = ator.VlAltura;
            resp.Ator.Nascimento = ator.DtNascimento;

            resp.Filmes = 
                ator.TbFilmeAtor.Select(x => new Models.Response.Questao6Response.Questao6FilmePersonagemJuntosResponse()
                {
                    Filme = new Models.Response.Questao6Response.Questao6FilmeResponse()
                    {
                        Nome = x.IdFilmeNavigation.NmFilme,
                        Genero = x.IdFilmeNavigation.DsGenero,
                        Avaliacao = x.IdFilmeNavigation.VlAvaliacao,
                        Disponivel = x.IdFilmeNavigation.BtDisponivel,
                        Duracao = x.IdFilmeNavigation.NrDuracao,
                        Lancamento = x.IdFilmeNavigation.DtLancamento
                    },
                    Personagem = new Models.Response.Questao6Response.Questao6PersonagemResponse()
                    {
                        Nome = x.NmPersonagem
                    }
                }).ToList();

            return resp;
        }

        public List<Models.Response.Questao6Response.Questao6FinalResponse> ParaQuestao6Response(List<Models.TbAtor> atores)
        {
            List<Models.Response.Questao6Response.Questao6FinalResponse> resp = new List<Models.Response.Questao6Response.Questao6FinalResponse>();
            foreach(Models.TbAtor ator in atores)
            {
                Models.Response.Questao6Response.Questao6FinalResponse r = this.ParaQuestao6Response(ator);
                resp.Add(r);
            }
            return resp;
        }
    }
}