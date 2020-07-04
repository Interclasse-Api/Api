using System.Collections.Generic;

 
namespace Api.Business
{
    public class Questao6Business
    {
        Database.Questao6Database db = new Database.Questao6Database();
        public List<Models.TbAtor> ConsultarAtores(string nome)
        {
            return db.ConsultarAtores(nome);
        }
    }
}