using System;
using System.Linq;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

 
namespace Api.Models.Response
{
    public class Questao1Response
    {
        public int Id { get; set; }
        public string Filme { get; set; }
        public string Genero { get; set; }
        public decimal? Avaliacao { get; set; }
        public bool Disponivel { get; set; }
        public int? Duracao { get; set; }
        public DateTime Lancamento { get; set; }
    }
}