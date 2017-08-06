using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Customer_Contact_Manager.Models
{
    public class CustomerContact
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Contact Name")]
        public String Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public String Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int ContactNumber { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
