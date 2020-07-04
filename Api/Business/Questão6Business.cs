using System.Collections.Generic;


namespace Api.Business
{
    public class Questão6Business
    {
        Database.Questão6Database db = new Database.Questão6Database();
        public List<Models.TbAtor> ConsultarAtores(string nome)
        {
            return db.ConsultarAtores(nome);
        }
    }
}