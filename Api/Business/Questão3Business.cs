using System;
using System.Collections.Generic;


namespace Api.Business
{
    public class Questão3Business
    {
        Database.Questão3Database ctx = new Database.Questão3Database();
        public bool ConsultarDiretorPorNome(string nome)
        {
            Models.TbDiretor diretor = ctx.ConsultarDiretorPorNome(nome);
            if (diretor == null)
                return false;
            else 
                return true;
        }

        public List<int> Invalidar(string diretor)
        {
            if(diretor == string.Empty)
                throw new ArgumentException("Nome Obrigatório.");

            return ctx.Invalidar(diretor);
        }

    }
}