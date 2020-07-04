using System;
using System.Collections.Generic;

 
namespace Api.Models.Response
{
    public class Questao6Response
    {
        public class Questao6AtorResponse
    {
        public string Nome { get; set; }
        public decimal Altura { get; set; }
        public DateTime Nascimento { get; set; }
    }

    public class Questao6FilmeResponse
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public decimal? Avaliacao { get; set; }
        public bool Disponivel { get; set; }
        public decimal? Duracao { get; set; }
        public DateTime Lancamento { get; set; }
    }

    public class Questao6PersonagemResponse
    {
        public string Nome { get; set; }
    }

    public class Questao6FilmePersonagemJuntosResponse
    {
        public Questao6FilmeResponse Filme { get; set; }
        public Questao6PersonagemResponse Personagem { get; set; }
    }

    public class Questao6FinalResponse
    {
        public Questao6AtorResponse Ator { get; set; }

        public List<Questao6FilmePersonagemJuntosResponse> Filmes { get; set; }

    }
    }
}