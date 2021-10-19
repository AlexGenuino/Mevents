using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{

    public class LoginDto
    {
        [Required(ErrorMessage = "Email é um campo obrigatorio")]
        [EmailAddress(ErrorMessage = "Formato invalido")]
        public string Email {get; set;}
        
        [Required(ErrorMessage = "Senha é um campo obrigatorio")]
        public string Password {get; set;}
    }
}