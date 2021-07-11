using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService personPhoneService, IMapper mapper)
        {
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }

        public async Task<PersonPhoneListResponse> FindAllAsync()
        {
            var result = await _personPhoneService.FindAllAsync();
            var response = new PersonPhoneListResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));
            return response;
        }
        public async Task<PersonPhoneResponse> GetById(string phoneNumber, int phoneNumberTypeID)
        {
            var result = await _personPhoneService.GetById(phoneNumber, phoneNumberTypeID);
            var response = new PersonPhoneResponse();
            response.PersonPhoneObject = new PersonPhoneDto();
            response.PersonPhoneObject = _mapper.Map<PersonPhoneDto>(result);
            return response;
        }

        public async Task<PersonPhoneResponse> Post(PersonPhone phonePerson)
        {
            var result = await _personPhoneService.Post(phonePerson);
            var response = new PersonPhoneResponse();
            response.PersonPhoneObject = new PersonPhoneDto();
            response.PersonPhoneObject = _mapper.Map<PersonPhoneDto>(result);
            return response;
        }
        public async Task<PersonPhoneResponse> Put(string phoneNumber, int phoneNumberTypeID, PersonPhone phonePerson)
        {
            var result = await _personPhoneService.Put(phoneNumber, phoneNumberTypeID,phonePerson);
            var response = new PersonPhoneResponse();
            response.PersonPhoneObject = new PersonPhoneDto();
            response.PersonPhoneObject = _mapper.Map<PersonPhoneDto>(result);
            return response;
        }
        public async Task<int> Delete(string phoneNumber, int phoneNumberTypeID)
        {
            return await _personPhoneService.Delete(phoneNumber, phoneNumberTypeID);
        }

    }
}
