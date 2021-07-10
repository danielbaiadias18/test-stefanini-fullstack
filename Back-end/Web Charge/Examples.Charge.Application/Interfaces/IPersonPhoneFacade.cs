using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<PersonPhoneListResponse> FindAllAsync();
        Task<PersonPhoneResponse> GetById(string phoneNumber, int phoneNumberTypeID);
        Task<PersonPhoneResponse> Post(PersonPhone phonePerson);
        Task<PersonPhoneResponse> Put(string phoneNumber, int phoneNumberTypeID, PersonPhone personPhone);
        Task<int> Delete(string phoneNumber, int phoneNumberTypeID);
    }
}