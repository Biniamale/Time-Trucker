using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        
       
    }
}
