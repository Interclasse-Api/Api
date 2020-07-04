using System;
using System.Linq;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;



namespace Api.Database
{
    public class Questao1Database
    {
         Models.apidbContext ctx = new Models.apidbContext();

        public List<Models.TbFilme> Inserir(List<Models.TbFilme> filme)
        {
            ctx.TbFilme.AddRange(filme);
            ctx.SaveChanges();
            return filme;
        }    
    }
}