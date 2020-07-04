using System;
using System.Linq;
using System.Collections.Generic;


namespace Api.Business
{
    public class Questão2Business
    {
        Database.Questão2Database db = new Database.Questão2Database();


        public Models.TbFilme InserirFilmeCompleto (Models.TbFilme filme)
        {
            if (string.IsNullOrEmpty(filme.NmFilme))
                throw new ArgumentNullException("Nome do filme é obrigatório");
            if (string.IsNullOrEmpty(filme.DsGenero))
                throw new ArgumentNullException("Genero do filme é obrigatório.");
            if (filme.VlAvaliacao <= 0)
                throw new ArgumentNullException("Avaliação do filme inválida.");
            if (filme.NrDuracao <= 0 || filme.NrDuracao > 400)
                throw new ArgumentNullException("Duração do filme inválida.");
            if (filme.DtLancamento == DateTime.MinValue)
                throw new ArgumentNullException("Data do filme inválida.");

            filme.TbDiretor.ToList().ForEach(diretor => 
            {
                if(string.IsNullOrEmpty(diretor.NmDiretor))
                    throw new ArgumentNullException("Duração do filme inválida.");

                if(diretor.DtNascimento == DateTime.MinValue)
                    throw new ArgumentNullException("Data do diretor inválida.");
            });
filme.TbFilmeAtor.ToList().ForEach (persona =>
            {
                if(string.IsNullOrEmpty(persona.IdAtorNavigation.NmAtor))
                    throw new ArgumentNullException("Nome do personagem é obrigatório.");
                if (persona.IdAtorNavigation.VlAltura <= 0)
                    throw new ArgumentNullException("Altura do personagem inválida.");
                if(persona.IdAtorNavigation.DtNascimento == DateTime.MinValue)
                    throw new ArgumentNullException("Data do personagem inválida.");
                if(string.IsNullOrEmpty(persona.NmPersonagem))
                    throw new ArgumentNullException("Nome do personagem é obrigatório.");
            });


            return db.InserirFilmeCompleto(filme);
        }
    }
}