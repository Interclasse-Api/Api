using System.Linq;

namespace Api.Database
{
    public class Questao2Database
    {
        Models.apidbContext ctx = new Models.apidbContext();


        public Models.TbFilme InserirFilmeCompleto (Models.TbFilme filme)
        {
            ctx.TbFilme.Add(filme);
            ctx.SaveChanges();

            return filme;
        }

        public bool FilmeExiste (string nome)
        {
            return ctx.TbFilme.ToList().Any(x => x.NmFilme == nome);
        }
    }
}