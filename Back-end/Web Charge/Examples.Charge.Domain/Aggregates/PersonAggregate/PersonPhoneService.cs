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
        public async Task<PersonPhone> FindAllAsync(int Id, string PhoneNumber, int PhoneNumberTypeID)
        {
            return (await _personPhoneRepository.FindAllAsync())
                .FirstOrDefault(x => x.BusinessEntityID == Id && x.PhoneNumber == PhoneNumber && x.PhoneNumberTypeID == PhoneNumberTypeID);
        }
    }
}
