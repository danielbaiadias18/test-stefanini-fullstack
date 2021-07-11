using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Cors;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private IPersonPhoneFacade _facade;

        public PersonPhoneController(IPersonPhoneFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonPhoneListResponse>> Get()
        {
            return Response(await _facade.FindAllAsync());
        }

        [HttpGet("{PhoneNumber}/{PhoneNumberTypeID}")]
        public async Task<ActionResult<PersonPhoneResponse>> Get(string phoneNumber, int phoneNumberTypeID)
        {
            return Response(await _facade.GetById(phoneNumber, phoneNumberTypeID));
        }

        [HttpPost]
        public async Task<ActionResult<PersonPhone>> Post([FromBody] PersonPhone request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, errors = ModelState });
            }
            else if(_facade.GetById(request.PhoneNumber, request.PhoneNumberTypeID).IsCompletedSuccessfully)
            {
                return BadRequest(new { success = false, errors = "Esse registro já foi cadastrado!" });
            }

            return Response(await _facade.Post(request));
        }

        [HttpPost("{PhoneNumber}/{PhoneNumberTypeID}")]
        public async Task<ActionResult<PersonPhone>> Put(string phoneNumber, int phoneNumberTypeID, [FromBody] PersonPhone request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, errors = ModelState});
            }

            return Response(await _facade.Put(phoneNumber, phoneNumberTypeID, request));
        }

        [HttpDelete("{PhoneNumber}/{PhoneNumberTypeID}")]
        public async Task<ActionResult> Delete(string phoneNumber, int phoneNumberTypeID)
        {
            try
            {
                if (await _facade.Delete(phoneNumber, phoneNumberTypeID) > 0)
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possível excluir o registro");
            }

            return BadRequest();
        }
    }
}
