using System;
using System.Collections.Generic;
using System.Collections;

namespace Api.Models.Response
{
    public class Questao2AtorResponse
    {
        public int ID { get; set; }
        public string Ator { get; set; }
        public decimal Altura { get; set; }
        public DateTime Nascimento { get; set; }
        public string Personagem { get; set; }
    }

    public class Questao2DiretorResponse
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
    }

    public class Questao2FilmeResponse
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public decimal? Avaliacao { get; set; }
        public bool Disponivel { get; set; }
        public int? Duracao { get; set; }
        public DateTime Lancamento { get; set; }
    }

    public class Questao2FinalResponse 
    {
        public Questao2FilmeResponse Filme { get; set; }
        public Questao2DiretorResponse Diretor { get; set; }
        public List<Questao2AtorResponse> Elenco { get; set; }
    }
}