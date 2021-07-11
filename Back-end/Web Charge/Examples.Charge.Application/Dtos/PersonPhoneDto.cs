using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.Dtos
{
    public class PersonPhoneDto
    {
        public int BusinessEntityID { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }
        public Person Person { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
    }
}
