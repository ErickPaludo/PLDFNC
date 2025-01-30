using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiFinanc.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        public Usuarios()
        {
            Debitos = new Collection<Debito>();
            Credito = new Collection<Credito>();
        }

        [Key]
        public int UserId { get; set; }

        [StringLength(80)]
        [Required(ErrorMessage = "Nome não pode ser nulo")]
        public string FirstName { get; set; }

        [StringLength(80)]
        [Required(ErrorMessage = "Sobrenome não pode ser nulo")]
        public string LastName { get; set; }

        [StringLength(15, MinimumLength = 3, ErrorMessage = "Usuário deve possuir entre 3 e 15 caracteres")]
        [Required(ErrorMessage = "Nome de usuário não pode ser nulo")]
        public string UserName { get; set; }

        [StringLength(15, MinimumLength = 3, ErrorMessage = "Senha deve possuir entre 3 e 15 caracteres")]
        [Required(ErrorMessage = "Senha não pode ser nulo")]
        public string UserPass { get; set; }

        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Dado inserido não é um email!")]
        [Required(ErrorMessage = "Email não pode ser nulo")]
        public string Email { get; set; }


        [JsonIgnore]
        public ICollection<Debito> Debitos { get; set; }
        [JsonIgnore]
        public ICollection<Credito> Credito { get; set; }
    }

}
