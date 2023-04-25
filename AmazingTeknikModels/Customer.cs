using System.ComponentModel.DataAnnotations;

namespace AmazingTeknikModels
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // One to many 
        public ICollection<Order> Order { get; set; }
    }
}