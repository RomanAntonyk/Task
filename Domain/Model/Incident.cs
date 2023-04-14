using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Incident 
    {
        public Guid Name { get; private set; }
        public int AccountId { get; private set; }
        public string Description { get; private set; }

        public Incident(Guid name, string description)
        {
            Name = name; 
            Description = !string.IsNullOrEmpty(description) ? description : throw new ArgumentNullException(nameof(description));
        }
        private Incident() { }
    }
}
