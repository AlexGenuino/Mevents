using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class Tickets
    {
        public Guid Id { get; set; }
        public Guid Hash { get; set; }
        public DateTime Datebuy { get; set; }
        public decimal PriceFinal { get; set; }
        public ICollection<UserEntity> Users { get; set; }
        public ICollection<Event> Events { get; set; }
        public TicketsTypes Type { get; set; }
    }
}