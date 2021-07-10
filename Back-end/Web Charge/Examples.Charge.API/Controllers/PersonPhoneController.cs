using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;
using Examples.Charge.Infra.Data.Context;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

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
        public async Task<ActionResult<PersonPhoneListResponse>> Get() => Response(await _facade.FindAllAsync());


        [HttpGet("{Id}/{PhoneNumber}/{PhoneNumberTypeID}")]
        public async Task<ActionResult<PersonPhoneResponse>> Get(int Id, string PhoneNumber, int PhoneNumberTypeID)
        {
            return Response(await _facade.FindAllAsync(Id, PhoneNumber, PhoneNumberTypeID));
        }
    }
}
