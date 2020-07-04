using System.Linq;


namespace Api.Utils
{
    public class Questão2Conversor
    {
         public Models.TbFilme ParaTbFilmeCompleto (Models.Request.Questão2Request.Questao2Request req)
        {
            Models.TbFilme filme = new Models.TbFilme();
            filme.NmFilme = req.Filme.Nome;
            filme.DsGenero = req.Filme.Genero;
            filme.NrDuracao = req.Filme.Duracao;
            filme.VlAvaliacao = req.Filme.Avaliacao;
            filme.BtDisponivel = req.Filme.Disponivel;
            filme.DtLancamento = req.Filme.Lancamento;

            filme.TbFilmeAtor = 
                req.Elenco.Select( x => new Models.TbFilmeAtor()
                {
                    NmPersonagem = x.Personagem,
                    IdAtorNavigation = new Models.TbAtor()
                    {
                        NmAtor = x.Ator,
                        VlAltura = x.Altura,
                        DtNascimento = x.Nascimento,

                    }
                }).ToList();

            return filme;
        }
        public Models.Response.Questão2Response.Questao2Response ParaResponse (Models.TbFilme filme)
        {
            Models.Response.Questão2Response.Questao2Response resp = new Models.Response.Questão2Response.Questao2Response();


            resp.Filme.ID = filme.IdFilme;
            resp.Filme.Nome = filme.NmFilme;
            resp.Filme.Genero = filme.DsGenero;
            resp.Filme.Avaliacao = filme.VlAvaliacao;
            resp.Filme.Disponivel = filme.BtDisponivel;
            resp.Filme.Duracao = filme.NrDuracao;
            resp.Filme.Lancamento = filme.DtLancamento;


            foreach(Models.TbDiretor item in filme.TbDiretor)
            {
                new Models.Response.Questão2Response.Questao2DiretorResponse()
                {
                    ID = item.IdDiretor,
                    Nome = item.NmDiretor,
                    Nascimento = item.DtNascimento
                };
            }


            resp.Elenco = 
                filme.TbFilmeAtor.Select( x => new Models.Response.Questão2Response.Questao2AtorResponse()
                {
                    ID = x.IdAtor,
                    Ator = x.IdAtorNavigation.NmAtor,
                    Altura = x.IdAtorNavigation.VlAltura,
                    Nascimento = x.IdAtorNavigation.DtNascimento,
                    Personagem = x.NmPersonagem
                }).ToList();


            return resp;
        }
    }
}