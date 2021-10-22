using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.SendEmail
{
    public class ModelSend
    {
        [Required(ErrorMessage = "EmailDestinatario é um campo obrigatorio")]
        [EmailAddress(ErrorMessage = "Formato invalido")]
        public string EmailDestinatario { get; set; }

        [Required(ErrorMessage = "EmailRemetente é um campo obrigatorio")]
        [EmailAddress(ErrorMessage = "Formato invalido")]
        public string EmailRemetente { get; set; }

        public string ClientAssunto { get; set; }

        public string ClientName { get; set; }

        [Required(ErrorMessage = "EmailRemetente é um campo obrigatorio")]
        [EmailAddress(ErrorMessage = "Formato invalido")]
        public string ClientMail { get; set; }
        [StringLength(11)]
        public string ClientContato { get; set; }

        public string ClientMessage { get; set; }

    }
}
