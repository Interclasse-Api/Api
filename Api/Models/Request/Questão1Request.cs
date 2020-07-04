using System;
using System.Collections;
using System.Collections.Generic;

namespace Api.Models.Request
{
    public class Questão1Request
    {
        public string Filme { get; set; }
        public string Genero { get; set; }
        public decimal Avaliacao { get; set; }
        public bool Disponivel { get; set; }
        public int Duracao { get; set; }
        public DateTime Lancamento { get; set; }
    }
}