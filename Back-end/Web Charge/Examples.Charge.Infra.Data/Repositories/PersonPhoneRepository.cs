using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;
        protected readonly DbSet<PersonPhone> _dbSet;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context;
            _dbSet = context.Set<PersonPhone>();
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync(){
            return await Task.Run(() => _context.PersonPhone.Include(x => x.Person).Include(x => x.PhoneNumberType));
        }

        public virtual async Task<PersonPhone> GetById(string phoneNumber, int phoneNumberTypeID)
        {
            return await Task.Run(() => _context.PersonPhone.Include(x => x.Person).Include(x => x.PhoneNumberType).FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber && x.PhoneNumberTypeID == phoneNumberTypeID));
        }

        public virtual async Task<PersonPhone> Post(PersonPhone personPhone)
        {
            _dbSet.Add(personPhone);
            await SaveDb();
            return personPhone;
        }

        public virtual async Task<int> Delete(string phoneNumber, int phoneNumberTypeID)
        {
            PersonPhone oldPerson = await GetById(phoneNumber, phoneNumberTypeID);

            _dbSet.Remove(oldPerson);

            return await SaveDb();
        }

        public async Task<int> SaveDb()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
