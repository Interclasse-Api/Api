using System;
using System.Collections.Generic;


namespace Api.Business
{
    public class Questao3Business
    {
        Database.Questao3Database db = new Database.Questao3Database();
        public bool ConsultarDiretorPorNome(string nome)
        {
            Models.TbDiretor diretor = db.ConsultarDiretorPorNome(nome);
            if (diretor == null)
                return false;
            else 
                return true;
        }

        public List<int> Invalidar(string diretor)
        {
            if(diretor == string.Empty)
                throw new ArgumentException("Nome Obrigatório.");

            return db.Invalidar(diretor);
        }

    }
}