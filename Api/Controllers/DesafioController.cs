using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DesafioController : ControllerBase
    {
        Utils.Questao1Conversor conv = new Utils.Questao1Conversor();
        Utils.Questao2FilmeCompletoConverter conv2 = new Utils.Questao2FilmeCompletoConverter();
        Utils.Questao3Conversor conv3 = new Utils.Questao3Conversor();
        Utils.Questao4Conversor conv4 = new Utils.Questao4Conversor();
        Utils.Questao5Conversor conv5 = new Utils.Questao5Conversor();
        Utils.Questao6Conversor conv6 = new Utils.Questao6Conversor();

        Business.Questao1Business busi = new Business.Questao1Business();
        Business.Questao2Business busi2 = new Business.Questao2Business();
        Business.Questao3Business busi3 = new Business.Questao3Business();
        Business.Questao4Business busi4 = new Business.Questao4Business();
        Business.Questao5Business busi5 = new Business.Questao5Business();
        Business.Questao6Business busi6 = new Business.Questao6Business();

        [HttpPost("muitosfilmes")]
        public ActionResult<List<Models.Response.Questao1Response>> Inserir(List<Models.Request.Questao1Request> req)
        {
            try
            {
               List<Models.TbFilme> filme = conv.ParaFilme(req);
               filme = busi.Inserir(filme);
               List<Models.Response.Questao1Response> resp = conv.ParaResponse(filme);
               return resp;
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }

        [HttpPost("filmeCompleto")]
        public ActionResult<Models.Response.Questao2FinalResponse> InserirFilmeCompleto (Models.Response.Questao2FinalResponse req)
        {
            try 
            {
                Models.TbFilme filme = conv2.ParaTbFilmeCompleto(req);
                busi2.InserirFilmeCompleto(filme);

                return conv2.ParaResponse(filme);

            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
               );
            }
        }

        [HttpPut("indisponibilizar")]
        public ActionResult<List<int>> Invalidar(Models.Request.Questao3Request req)
        {
            try
            {
                bool existe = busi3.ConsultarDiretorPorNome(req.Diretor);
                if(!existe)
                    return NotFound(null);

                List<int> resp = busi3.Invalidar(req.Diretor);

                return resp;
            }
            catch(SystemException ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400, ex.Message));
            }
        }

        [HttpDelete("personagens")]
        public ActionResult<Models.Response.Questao4Response.PersonagemResponse> DeletarPersonagens(Models.Request.Questao4Request.PersonagemRequest req)
        {
            try
            {
                bool existem = busi4.ValidarPersonagens(req.Filme, req.Personagens);
                if(!existem)
                    return NotFound(null);

                int filmeId = busi4.ConsultarFilme(req.Filme);
                List<int> personagensIds = busi4.ConsultarPersonagensIds(req.Personagens);
                personagensIds = busi4.RemoverPersonagens(filmeId, personagensIds);

                Models.Response.Questao4Response.PersonagemResponse resp = conv4.ParaPersonagemResponse(filmeId, personagensIds);
                return resp;

            }
            catch (System.Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }

        }

         [HttpGet("ConsultarFilme")]
        public ActionResult<List<Models.Response.Questao5Response.FilmeCompleto>> ConsultarFilmeCompleto(string nome)
        {
            try
            {
                List<Models.TbFilme> consulta = busi5.ConsultaCompletaBusiness(nome);

                return consulta.Select(x => conv5.ParaResponse(x)).ToList();
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
            
        }
        [HttpGet("consultarAtores")]
        public ActionResult<List<Models.Response.Questao6Response.Questao6FinalResponse>> ConsultarFilmeAtor(string nome)
        {
            try
            {
                List<Models.TbAtor> atores = busi6.ConsultarAtores(nome);
                if(atores.Count == 0)
                    return NotFound(null);

                List<Models.Response.Questao6Response.Questao6FinalResponse> resp = conv6.ParaQuestao6Response(atores);
                return resp;
            }
            catch (System.Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

    }
}