using Domain.Exceptions;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Account
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private List<Contact> contacts = new List<Contact>();
        private List<Incident> incidents = new List<Incident>();
        public IReadOnlyList<Contact> Contacts => contacts.AsReadOnly();
        public IReadOnlyList<Incident> Incidents => incidents.AsReadOnly();
        public Account(string accountName, Contact contact)
        {
            if(contact.IsLinked())
                throw new DomainException("Contact is already linked");
            Name = accountName;
            contact.MarkAsLinked();
            contacts.Add(contact);

        }

        private Account() { }

        public bool IsContactBelongsToAccount(Contact contact)
        {
            return contacts.Any(c => c.Id == contact.Id);
        }
        public void LinkContact(Contact contact)
        {
            if (contact.IsLinked())
                throw new DomainException("Contact is already linked");
            contact.MarkAsLinked();
            contacts.Add(contact);
        }

        public void AddIncident(Incident incident)
        {
            incidents.Add(incident);
        }
    }
}
