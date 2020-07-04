namespace Api.Utils
{
    public class Questão3Conversor
    {
        public Models.TbDiretor ParaTabela(Models.Request.Questão3Request request)
        {
           Models.TbDiretor diretor = new Models.TbDiretor();
           diretor.NmDiretor = request.Diretor;

            return diretor;
        }
    }
}