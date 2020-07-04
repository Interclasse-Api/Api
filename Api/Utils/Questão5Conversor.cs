using System.Linq;


namespace Api.Utils
{
    public class Questão5Conversor
    {
        public Models.Response.Questão5Response.FilmeCompleto ParaResponse (Models.TbFilme filme)
        {
            Models.Response.Questão5Response.FilmeCompleto resp = new Models.Response.Questão5Response.FilmeCompleto();

            resp.Filme = new Models.Response.Questão5Response.Filme();

            resp.Filme.Nome = filme.NmFilme;
            resp.Filme.Genero = filme.DsGenero;
            resp.Filme.Avaliacao = filme.VlAvaliacao;
            resp.Filme.Disponivel = filme.BtDisponivel;
            resp.Filme.Duracao = filme.NrDuracao;
            resp.Filme.Lancamento = filme.DtLancamento;

            if (filme.TbDiretor.Count > 0 )
            {
                resp.diretor = new Models.Response.Questão5Response.Diretor()
                {
                    nome = filme.TbDiretor.FirstOrDefault().NmDiretor,
                    nascimento = filme.TbDiretor.FirstOrDefault().DtNascimento
                };
            };


            resp.elenco = 
            filme.TbFilmeAtor.Select( x => new Models.Response.Questão5Response.Elenco()
            {
                ator = x.IdAtorNavigation.NmAtor,
                altura = x.IdAtorNavigation.VlAltura,
                nascimento = x.IdAtorNavigation.DtNascimento,
                personagem = x.NmPersonagem
            }).ToList();


            return resp;
        }
    }
}