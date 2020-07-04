using System.Collections.Generic;
using System.Linq;

namespace Api.Utils
{
    public class Questao2FilmeCompletoConverter
    {
        public Models.TbFilme ParaTbFilmeCompleto (Models.Response.Questao2FinalResponse req)
        {
            Models.TbFilme filme = new Models.TbFilme();

            filme.NmFilme = req.Filme.Nome;
            filme.DsGenero = req.Filme.Genero;
            filme.NrDuracao = req.Filme.Duracao;
            filme.VlAvaliacao = req.Filme.Avaliacao;
            filme.BtDisponivel = req.Filme.Disponivel;
            filme.DtLancamento = req.Filme.Lancamento;

            filme.TbDiretor = new List<Models.TbDiretor>()
            {
                new Models.TbDiretor() 
                {
                    NmDiretor = req.Diretor.Nome,
                    DtNascimento = req.Diretor.Nascimento 
                }
            }; 

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

        public Models.Response.Questao2FinalResponse ParaResponse (Models.TbFilme filme)
        {
            Models.Response.Questao2FinalResponse resp = new Models.Response.Questao2FinalResponse();

            resp.Filme = new Models.Response.Questao2FilmeResponse();
            resp.Filme.ID = filme.IdFilme;
            resp.Filme.Nome = filme.NmFilme;
            resp.Filme.Genero = filme.DsGenero;
            resp.Filme.Avaliacao = filme.VlAvaliacao;
            resp.Filme.Disponivel = filme.BtDisponivel;
            resp.Filme.Duracao = filme.NrDuracao;
            resp.Filme.Lancamento = filme.DtLancamento;

            if (filme.TbDiretor.Count > 0 )
            {
                resp.Diretor = new Models.Response.Questao2DiretorResponse()
                {
                    ID = filme.TbDiretor.FirstOrDefault().IdDiretor,
                    Nome = filme.TbDiretor.FirstOrDefault().NmDiretor,
                    Nascimento = filme.TbDiretor.FirstOrDefault().DtNascimento
                };
            };


            resp.Elenco = 
                filme.TbFilmeAtor.Select( x => new Models.Response.Questao2AtorResponse()
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