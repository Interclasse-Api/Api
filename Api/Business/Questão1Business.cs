using System;
using System.Collections.Generic;



namespace Api.Business
{
    public class Questão1Business
    {
        Database.Questão1Database db = new Database.Questão1Database();

        public List<Models.TbFilme> Inserir(List<Models.TbFilme> filme)
        {
            foreach(Models.TbFilme item in filme)
            {
                if (item.NmFilme == string.Empty)
                    throw new ArgumentException("Filme Obrigatório");
                if (item.DsGenero == string.Empty)
                    throw new ArgumentException("Genero Obrigatório");
                if (item.NrDuracao <= 0)
                    throw new ArgumentException("Duração Invalida");
            }
            return db.Inserir(filme);
        }   
    }
}