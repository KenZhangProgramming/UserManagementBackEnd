using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementBackEnd.Models
{
    public class Customer
    {   [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Province Province { get; set; }
        [ForeignKey("Province")]
        public int ProvinceId { get; set; }
        public int Zip { get; set; }
        public string Gender { get; set; }
        public int OrderCount { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
