using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response
{
    public class UserResponse : BaseResponse
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public string Phone { get; set; }

        public ICollection<Tickets> Tickets { get; set; }

        public UserResponse(string message, bool success, string name, string email, string cpf, string phone, ICollection<Tickets> tickets) : base(message, success)
        {
            Name = name;
            Email = email;
            CPF = cpf;
            Phone = phone;
            Tickets = tickets;
        }

        public UserResponse(string message) : base(message, false)
        { }


    }
}

