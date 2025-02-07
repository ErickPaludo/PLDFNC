using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLDFinanc.ModelObjects
{
    public class Usuario
    {
        public int UserId { get; set; }
        public bool Active { get; set; }
        public int Status { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        [StringLength(15, MinimumLength = 3, ErrorMessage = "Senha deve possuir entre 3 e 15 caracteres")]
        [Required(ErrorMessage = "Senha não pode ser nulo")]
        public string UserPass { get; set; }

        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Dado inserido não é um email!")]
        [Required(ErrorMessage = "Email não pode ser nulo")]
        public string Email { get; set; }

    }
}
