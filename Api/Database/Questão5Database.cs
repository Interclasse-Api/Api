using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Api.Database
{
    public class Questão5Database
    {
        Models.apidbContext ctx = new Models.apidbContext();
        public List<Models.TbFilme> ConsultarFilmeCompleto(string nome)
        {
            

            return ctx.TbFilme
                     .Include(x => x.TbDiretor)
                     .Include(x => x.TbFilmeAtor)
                     .ThenInclude(x => x.IdAtorNavigation)
                     .Where(x => x.NmFilme.Contains(nome))
                     .ToList();
        }

        public bool FilmeExiste (string nome)
        {
            return ctx.TbFilme.Any(x => x.NmFilme.Contains(nome));
        }
    }
}