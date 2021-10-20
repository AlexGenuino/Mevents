using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class Admin : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}