using System;
using System.Collections.Generic;


namespace Api.Models.Response
{
    public class Questão5Response
    {
        public class Filme    
        {
            public string Nome { get; set; }
            public string Genero { get; set; }
            public decimal? Avaliacao { get; set; }
            public bool Disponivel { get; set; }
            public int? Duracao { get; set; }
            public DateTime Lancamento { get; set; }
        }

        public class Diretor
        {
            public string nome { get; set; } 
            public DateTime nascimento { get; set; } 
        }

        public class Elenco
        {
            public string ator { get; set; } 
            public decimal altura { get; set; } 
            public DateTime nascimento { get; set; } 
            public string personagem { get; set; } 
        }

        public class FilmeCompleto
        {
            public Filme Filme { get; set; } 
            public Diretor diretor { get; set; } 
            public List<Elenco> elenco { get; set; } 
        }

        public class Erro
        {
            public int codigo { get; set; }
            public string msn { get; set; }
            public Erro(int codigo, string msn)
            {
                this.codigo = codigo;
                this.msn = msn;
            }
        }
    }
}