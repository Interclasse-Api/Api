using System;
using System.Collections.Generic;
using System.Collections;

namespace Api.Models.Request
{
    public class Questao2AtorRequest
    {
        public string Ator { get; set; }
        public decimal Altura { get; set; }
        public DateTime Nascimento { get; set; }
        public string Personagem { get; set; }
    }

    public class Questao2DiretorRequest
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
    }

    public class Questao2FilmeRequest
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public decimal Avaliacao { get; set; }
        public bool Disponivel { get; set; }
        public int Duracao { get; set; }
        public DateTime Lancamento { get; set; }
    }

    public class Questao2FinalRequest 
    {
        public Questao2FilmeRequest Filme { get; set; }
        public Questao2DiretorRequest Diretor { get; set; }
        public List<Questao2AtorRequest> Elenco { get; set; }
    }

}