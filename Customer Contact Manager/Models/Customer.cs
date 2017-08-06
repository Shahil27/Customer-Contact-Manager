using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Customer_Contact_Manager.Models
{
    public class Customer
    {
        
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Range(-90, 90)]
        public decimal Latitude { get; set; }

        [Range(-180, 180)]
        public decimal Longitude { get; set; }

        public virtual ICollection<CustomerContact> CustomerContacts { get; set; }
    }
}
