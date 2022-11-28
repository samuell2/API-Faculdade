using Aula01.Domain;
using Aula01.Domain.Interfaces;
using Aula01.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Aula01.Data.Repository;

namespace Aula01.Controllers
{
    [Route("[controller]")]
	public class FreteController : Controller
	{
        public FreteRepository calculos;
		public IFreteRepository _freteRepository;
		public IMapper _mapper;


		public FreteController(IFreteRepository freteRepository, IMapper mapper, FreteRepository calculo)
		{
			_freteRepository = freteRepository;
			_mapper = mapper;
            calculos = calculo;
		}

		[HttpPost]
		public IActionResult Calculo(FreteViewModel frete)
		{
            if (!ModelState.IsValid) return BadRequest(ModelState);

			return Ok
            (
                new
                {
                     valor = _freteRepository.CalculoPeso(_mapper.Map<Frete>(frete)) + _freteRepository.TaxaEstado(_mapper.Map<Frete>(frete)) + _freteRepository.TaxaQuebravel(_mapper.Map<Frete>(frete)),
                     success = true
                }
            );
		}

    }
}
