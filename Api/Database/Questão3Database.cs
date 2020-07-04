using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;


namespace Api.Database
{
    public class Questão3Database
    {
        Models.apidbContext ctx = new Models.apidbContext();
         public Models.TbDiretor ConsultarDiretorPorNome(string nome)
        {
            Models.TbDiretor diretor =
                ctx.TbDiretor.FirstOrDefault(x => x.NmDiretor == nome);

            return diretor;
        }
        public List<int> Invalidar(string diretor)
        {
            List<Models.TbFilme> filmes = ctx.TbFilme.Where(x => x.TbDiretor.Any(d => d.NmDiretor == diretor)).ToList();

            foreach (Models.TbFilme item in filmes)
            {
                item.BtDisponivel = false;
            }

            ctx.SaveChanges();

            List<int> ids = filmes.Select(x => x.IdFilme).ToList();

            return ids;

        }
    }
}