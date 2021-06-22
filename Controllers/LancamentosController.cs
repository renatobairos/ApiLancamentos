using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiLancamentos.Models;
using System.ComponentModel.DataAnnotations;
using ApiLancamentos.Business;

namespace ApiLancamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private readonly ILancamentoBusiness _lancamentoBusiness;

        public LancamentosController(ILancamentoBusiness lancamentoBusiness)
        {
            _lancamentoBusiness = lancamentoBusiness;
        }

        private IEnumerable<Lancamento> GetLancamentos()
        {
            return _lancamentoBusiness.GetAll();
        }

        [HttpGet("{periodoReferencia}")]
        public ActionResult<ConsultaLancamento> GetLancamento([RegularExpression(@"^([0-9]{4}-[0-9]{2})$", ErrorMessage = "Characters are not allowed. The correct format is yyyy-MM.")] string periodoReferencia)
        {

            ConsultaLancamento consultaLancamento = _lancamentoBusiness.GetConsultaLancamento(periodoReferencia);

            if (consultaLancamento == null)
            {
                return NotFound();
            } 
            
            return Ok(consultaLancamento);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Lancamento>> PostLancamento(IEnumerable<Lancamento> lancamentos)
        {
            _lancamentoBusiness.SaveLancamentos(lancamentos);

            return Created("", GetLancamentos());
        }
    }
}
