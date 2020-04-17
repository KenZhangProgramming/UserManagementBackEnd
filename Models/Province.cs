using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UserManagementBackEnd.Models
{
    public class Province
    {
        [Key]
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
