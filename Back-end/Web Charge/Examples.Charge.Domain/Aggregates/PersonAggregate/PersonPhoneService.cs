using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();
        public async Task<PersonPhone> GetById(string phoneNumber, int phoneNumberTypeID)
        {
            return (await _personPhoneRepository.GetById(phoneNumber, phoneNumberTypeID));
        }
        public async Task<PersonPhone> Post(PersonPhone personPhone)
        {
            return await _personPhoneRepository.Post(personPhone);
        }
        public async Task<PersonPhone> Put(string phoneNumber, int phoneNumberTypeID, PersonPhone personPhone)
        {
            await _personPhoneRepository.Delete(phoneNumber, phoneNumberTypeID);
            await _personPhoneRepository.Post(personPhone);

            return personPhone;
        }
        public async Task<int> Delete(string phoneNumber, int phoneNumberTypeID)
        {
            return await _personPhoneRepository.Delete(phoneNumber, phoneNumberTypeID);
        }
    }       
}
