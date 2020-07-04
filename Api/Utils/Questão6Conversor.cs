using System.Linq;
using System.Collections.Generic;


namespace Api.Utils
{
    public class Questão6Conversor
    {
         public Models.Response.Questão6Response.Questao6Response ParaQuestao6Response(Models.TbAtor ator)
        {
            Models.Response.Questão6Response.Questao6Response resp = new Models.Response.Questão6Response.Questao6Response();
            resp.Ator = new Models.Response.Questão6Response.Questao6AtorResponse();
            resp.Ator.Nome = ator.NmAtor;
            resp.Ator.Altura = ator.VlAltura;
            resp.Ator.Nascimento = ator.DtNascimento;

            resp.Filmes = 
                ator.TbFilmeAtor.Select(x => new Models.Response.Questão6Response.Questao6FilmePersonagemJuntosResponse()
                {
                    Filme = new Models.Response.Questão6Response.Questao6FilmeResponse()
                    {
                        Nome = x.IdFilmeNavigation.NmFilme,
                        Genero = x.IdFilmeNavigation.DsGenero,
                        Avaliacao = x.IdFilmeNavigation.VlAvaliacao,
                        Disponivel = x.IdFilmeNavigation.BtDisponivel,
                        Duracao = x.IdFilmeNavigation.NrDuracao,
                        Lancamento = x.IdFilmeNavigation.DtLancamento
                    },
                    Personagem = new Models.Response.Questão6Response.Questao6PersonagemResponse()
                    {
                        Nome = x.NmPersonagem
                    }
                }).ToList();

            return resp;
        }

        public List<Models.Response.Questão6Response.Questao6Response> ParaQuestao6Response(List<Models.TbAtor> atores)
        {
            List<Models.Response.Questão6Response.Questao6Response> resp = new List<Models.Response.Questão6Response.Questao6Response>();
            foreach(Models.TbAtor ator in atores)
            {
                Models.Response.Questão6Response.Questao6Response r = this.ParaQuestao6Response(ator);
                resp.Add(r);
            }
            return resp;
        }
    }
}