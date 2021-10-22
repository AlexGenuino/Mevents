using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class Event : BaseEntity
    {
        public string name { get; set; }
        public double price { get; set; }
        public string Adress { get; set; }
        public DateTime Date { get; set; }
        public string Organizer { get; set; }
        public int Available_Tickets { get; set; }
        public string Description { get; set; }
        public ICollection<Admin> Admin { get; set; }
        public ICollection<Tickets> Tickets { get; set; }

    }
}