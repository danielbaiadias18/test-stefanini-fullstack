using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<List<PersonPhone>> FindAllAsync();
        Task<PersonPhone> GetById(string phoneNumber, int phoneNumberTypeID);
        Task<PersonPhone> Post(PersonPhone personPhone);
        Task<PersonPhone> Put(string phoneNumber, int phoneNumberTypeID, PersonPhone personPhone);
        Task<int> Delete(string phoneNumber, int phoneNumberTypeID);
    }
}
