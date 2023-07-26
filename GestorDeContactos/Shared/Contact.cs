using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeContactos.Shared
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The first name field is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "The last name field is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "The phone field is required")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "The address field is required")]
        public string? Address { get; set; }
        public string? FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

    }
}
