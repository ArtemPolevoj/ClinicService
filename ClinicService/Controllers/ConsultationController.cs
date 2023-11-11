using ClinicService.Models.Requests;
using ClinicService.Models;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private IConsultationRepository _consultationRepository;
        public ConsultationController(IConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }
		[HttpPost("create")]
		public IActionResult Create([FromBody] CreateConsultationRequest createRequest)
		{
			Consultation con = new Consultation();
			con.ConsultationId = createRequest.ConsultationId;
			con.PetId = createRequest.PetId;
			con.ClientId = createRequest.ClientId;
			con.ConsultationDate = createRequest.ConsultationDate;
			con.Description = createRequest.Description;
			return Ok(_consultationRepository.Create(con));
		}

		[HttpPut("edit")]
		public IActionResult Update([FromBody] UpdateConsultationReques updateRequest)
		{
			Consultation con = new Consultation();
			con.ConsultationId = updateRequest.ConsultationId;
			con.PetId = updateRequest.PetId;
			con.ConsultationDate = updateRequest.ConsultationDate;
			con.Description = updateRequest.Description;
			return Ok(_consultationRepository.Update(con));
		}


		[HttpDelete("delete")]
		public IActionResult Delete([FromQuery] int ConsultationId)
		{
			int res = _consultationRepository.Delete(ConsultationId);
			return Ok(res);
		}

		[HttpGet("get-all")]
		public IActionResult GetAll()
		{
			return Ok(_consultationRepository.GetAll());
		}


		[HttpGet("get/{ConsultationId}")]
		public IActionResult GetById([FromRoute] int ConsultationId)
		{
			return Ok(_consultationRepository.GetById(ConsultationId));
		}

	}
}
