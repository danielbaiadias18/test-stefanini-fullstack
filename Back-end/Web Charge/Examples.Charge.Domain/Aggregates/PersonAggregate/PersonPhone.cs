using System.ComponentModel.DataAnnotations;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhone
    {
        [Required(ErrorMessage = "BusinessEntityID é obrigatório")]
        public int BusinessEntityID { get; set; }

        [MaxLength(450)]
        [Required(ErrorMessage = "PhoneNumber é obrigatório")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "PhoneNumberTypeID é obrigatório")]
        public int PhoneNumberTypeID { get; set; }

        public Person Person { get; set; }

        public PhoneNumberType PhoneNumberType { get; set; }

    }
}
