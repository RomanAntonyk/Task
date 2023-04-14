using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public int? AccountId { get; private set; }
        public Email Email { get; private set; }
        public  ContactState State { get; private set; } = ContactState.NotLinked;

        public Contact(string firstName, string lastName, Email email)
        {
            FirstName = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            LastName = !string.IsNullOrWhiteSpace(lastName) ? lastName : throw new ArgumentNullException(nameof(lastName));
            Email = email;
        }

        private Contact() { }

        internal void MarkAsLinked()
        {
            State = ContactState.Linked;
        }
        public bool IsLinked()
        {
            return State == ContactState.Linked;
        }

        public enum ContactState
        {
            NotLinked,
            Linked
        }
    }
}
