using System;
using System.Linq;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;



namespace Api.Utils
{
    public class Questão1Conversor
    {
        public List<Models.TbFilme> ParaFilme(List<Models.Request.Questão1Request> req)
        {
            List<Models.TbFilme> filmes = new List<Models.TbFilme>();

            foreach(Models.Request.Questão1Request item in req)
            {
                Models.TbFilme filme = new Models.TbFilme();
                filme.NmFilme = item.Filme;
                filme.DsGenero = item.Genero;
                filme.NrDuracao = item.Duracao;
                filme.VlAvaliacao = item.Avaliacao;
                filme.DtLancamento = item.Lancamento;
                filme.BtDisponivel = item.Disponivel;

                filmes.Add(filme);
            }
            return filmes;
        } 
    
        public List<Models.Response.Questão1Response> ParaResponse(List<Models.TbFilme> filme)
        {
            List<Models.Response.Questão1Response> response = new List<Models.Response.Questão1Response>();


            foreach(Models.TbFilme item in filme)
            {
                Models.Response.Questão1Response resp = new Models.Response.Questão1Response();
                resp.Id = item.IdFilme;
                resp.Filme = item.NmFilme;
                resp.Genero = item.DsGenero;
                resp.Duracao = item.NrDuracao;
                resp.Avaliacao = item.VlAvaliacao;
                resp.Lancamento = item.DtLancamento;
                resp.Disponivel = item.BtDisponivel;

                response.Add(resp);
            }

            return response;
     
        }
    }
}