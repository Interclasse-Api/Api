using System;
using System.Collections.Generic;

 
namespace Api.Business
{
    public class Questao5Business
    {
        Database.Questao5Database db = new Database.Questao5Database();
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