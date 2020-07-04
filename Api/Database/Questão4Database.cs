using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Api.Database
{
    public class Questão4Database
    {
        Models.apidbContext ctx = new Models.apidbContext();

        public int ConsultarIdFilme(string nomeFilme)
        {
            Models.TbFilme filme = ctx.TbFilme.FirstOrDefault(x => x.NmFilme == nomeFilme);
            int id = filme.IdFilme;
            return id;
        }

        public List<int> ConsultarIdPersonagem(List<string> personagens)
        {
            List<int> personagensIds = new List<int>();
            foreach(string personagem in personagens)
            {
                Models.TbFilmeAtor filmeAtor = ctx.TbFilmeAtor.FirstOrDefault(x => x.NmPersonagem == personagem);
                if (filmeAtor != null)
                {
                    personagensIds.Add(filmeAtor.IdFilmeAtor);
                }
            }

            return personagensIds;
        }

        public List<int> RemoverPersonagens(int filmeId, List<int> personagensId)
        {
            List<Models.TbFilmeAtor> filmeAtores = 
                ctx.TbFilmeAtor.Where(x => x.IdFilme == filmeId).ToList();

            foreach (int personagem in personagensId)
            {
                Models.TbFilmeAtor filmeAtor = filmeAtores.FirstOrDefault(x => x.IdFilmeAtor == personagem);
                if (filmeAtor != null)
                {
                    ctx.TbFilmeAtor.Remove(filmeAtor);
                }
            }

            ctx.SaveChanges();
            return personagensId;
        }

        public Models.TbFilme ConsultarFilmePorNome(string nome)
        {
            Models.TbFilme filme = ctx.TbFilme.Include(x => x.TbFilmeAtor)
                                              .FirstOrDefault(x => x.NmFilme == nome);

            return filme;
        }
    }
}