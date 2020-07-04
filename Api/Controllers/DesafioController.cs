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
        Utils.Questão1Conversor conv = new Utils.Questão1Conversor();
        Utils.Questão2Conversor conv2 = new Utils.Questão2Conversor();
        Utils.Questão3Conversor conv3 = new Utils.Questão3Conversor();
        Utils.Questão4Conversor conv4 = new Utils.Questão4Conversor();
        Utils.Questão5Conversor conv5 = new Utils.Questão5Conversor();
        Utils.Questão6Conversor conv6 = new Utils.Questão6Conversor();

        Business.Questão1Business busi = new Business.Questão1Business();
        Business.Questão2Business busi2 = new Business.Questão2Business();
        Business.Questão3Business busi3 = new Business.Questão3Business();
        Business.Questão4Business busi4 = new Business.Questão4Business();
        Business.Questão5Business busi5 = new Business.Questão5Business();
        Business.Questão6Business busi6 = new Business.Questão6Business();

        [HttpPost("muitosfilmes")]
        public ActionResult<List<Models.Response.Questão1Response>> Inserir(List<Models.Request.Questão1Request> req)
        {
            try
            {
               List<Models.TbFilme> filme = conv.ParaFilme(req);
               filme = busi.Inserir(filme);
               List<Models.Response.Questão1Response> resp = conv.ParaResponse(filme);
               return resp;
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErroResponse(404, ex.Message)
                );
            }
        }
        [HttpPost("filmeCompleto")]

        public ActionResult<Models.Response.Questão2Response.Questao2Response> InserirFilmeCompleto (Models.Request.Questão2Request.Questao2Request req)
        {
            try 
            {
                Models.TbFilme filme = conv2.ParaTbFilmeCompleto(req);
                busi2.InserirFilmeCompleto(filme);

                return conv2.ParaResponse(filme);

            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErroResponse(404, ex.Message)
               );
            }
        }

        [HttpPut("indisponibilizar")]
        public ActionResult<List<int>> Invalidar(Models.Request.Questão3Request req)
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
        public ActionResult<Models.Response.Questão4Response.PersonagemResponse> DeletarPersonagens(Models.Request.Questão4Request.PersonagemRequest req)
        {
            try
            {
                bool existem = busi4.ValidarPersonagens(req.Filme, req.Personagens);
                if(!existem)
                    return NotFound(null);

                int filmeId = busi4.ConsultarFilme(req.Filme);
                List<int> personagensIds = busi4.ConsultarPersonagensIds(req.Personagens);
                personagensIds = busi4.RemoverPersonagens(filmeId, personagensIds);

                Models.Response.Questão4Response.PersonagemResponse resp = conv4.ParaPersonagemResponse(filmeId, personagensIds);
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
        public ActionResult<List<Models.Response.Questão5Response.FilmeCompleto>> ConsultarFilmeCompleto(string nome)
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
        public ActionResult<List<Models.Response.Questão6Response.Questao6Response>> ConsultarFilmeAtor(string nome)
        {
            try
            {
                List<Models.TbAtor> atores = busi6.ConsultarAtores(nome);
                if(atores.Count == 0)
                    return NotFound(null);

                List<Models.Response.Questão6Response.Questao6Response> resp = conv6.ParaQuestao6Response(atores);
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