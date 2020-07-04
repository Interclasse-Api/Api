namespace Api.Database
{
    public class Questão2Database
    {
         Models.apidbContext ctx = new Models.apidbContext();


        public Models.TbFilme InserirFilmeCompleto (Models.TbFilme filme)
        {
            ctx.TbFilme.Add(filme);
            ctx.SaveChanges();

            return filme;
        }
    }
}