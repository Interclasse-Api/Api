using System;
using System.Collections.Generic;


namespace Api.Business
{
    public class Questão5Business
    {
        Database.Questão5Database db = new Database.Questão5Database();
        public List<Models.TbFilme> ConsultaCompletaBusiness (string nome)
        {
            if(String.IsNullOrEmpty(nome))
                throw new ArgumentException("campo nome do Filme é obrigatório para realizar a consulta.");

            if(!db.FilmeExiste(nome))
                throw new ArgumentException("Filme não encotrado no sistema.");

            return db.ConsultarFilmeCompleto(nome);
        }
    }
}