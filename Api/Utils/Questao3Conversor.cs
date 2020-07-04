namespace Api.Utils
{
    public class Questao3Conversor
    {
        public Models.TbDiretor ParaTabela(Models.Request.Questao3Request request)
        {
           Models.TbDiretor diretor = new Models.TbDiretor();
           diretor.NmDiretor = request.Diretor;

            return diretor;
        }
    }
}