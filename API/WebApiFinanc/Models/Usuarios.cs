using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFinanc.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(80)]
        [Required(ErrorMessage = "Nome não pode ser nulo")]
        public string FirstName { get; set; }

        [StringLength(80)]
        [Required(ErrorMessage = "Sobrenome não pode ser nulo")]
        public string LastName { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Nome de usuário não pode ser nulo")]
        public string UserName { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Senha não pode ser nulo")]
        public string UserPass { get; set; }

        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Dado inserido não é um email!")]
        [Required(ErrorMessage = "Email não pode ser nulo")]
        public string Email { get; set; }

        // Coleção de débitos (relacionamento 1:N com Debito)
        public ICollection<Debito> Debitos { get; set; }
    }

}
