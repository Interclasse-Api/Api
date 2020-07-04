using System.Linq;
using System.Collections.Generic;

 
namespace Api.Business
{
    public class Questao4Business
    {
        Database.Questao4Database db = new Database.Questao4Database();   
        public bool ValidarPersonagens(string nomeFilme, List<string> personagens)
        {
            Models.TbFilme filme = db.ConsultarFilmePorNome(nomeFilme);
            if (filme == null)
                return false;

            bool todosExistem = personagens.All(
                x => filme.TbFilmeAtor.Any(
                    y => y.NmPersonagem == x));

            return todosExistem;
        }

        public List<int> RemoverPersonagens(int filmeId, List<int> personagens)
        {
            return db.RemoverPersonagens(filmeId, personagens);
        }

        public List<int> ConsultarPersonagensIds(List<string> personagens)
        {
            List<int> r = db.ConsultarIdPersonagem(personagens);
            return r;
        }
        public int ConsultarFilme(string nome)
        {
            int r = db.ConsultarFilmePorNome(nome).IdFilme;
            return r;
        }
    }
}