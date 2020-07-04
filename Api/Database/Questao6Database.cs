using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

 
namespace Api.Database
{
    public class Questao6Database
    {
        Models.apidbContext ctx = new Models.apidbContext();
        public List<Models.TbAtor> ConsultarAtores(string nome)
        {
            return ctx.TbAtor
                     .Include(x => x.TbFilmeAtor)
                     .ThenInclude(x => x.IdFilmeNavigation)
                     .Where(x => x.NmAtor.Contains(nome))
                     .ToList();
        }
    }
}