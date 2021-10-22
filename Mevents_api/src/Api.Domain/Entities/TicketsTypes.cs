using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class TicketsTypes : BaseEntity
    {
        public string Description { get; set; }
        public int DiscontPorcentage { get; set; }
    }
}
