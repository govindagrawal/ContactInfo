using ContactInfo.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ContactInfo.DataAccessLayer.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContact(int id);

        void AddContact(Contact contact);

        void EditContact(Contact contact);
        int ActivateDeactivateContact(int id);

        int DeleteContact(int id);
    }

    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _dbContext.Contacts.ToList();
        }

        public Contact GetContact(int id)
        {
            return _dbContext.Contacts.Find(id);
        }

        public void AddContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
        }

        public void EditContact(Contact contact)
        {
            _dbContext.Entry(contact).State = EntityState.Modified;
        }

        public int ActivateDeactivateContact(int id)
        {
            var contact = _dbContext.Contacts.Find(id);

            if (contact == null)
                return Constants.NotFound;

            contact.Status = (contact.Status == Constants.Active) ? Constants.Inactive : Constants.Active;

            _dbContext.Entry(contact).State = EntityState.Modified;

            return Constants.ContactStatusChanged;
        }

        public int DeleteContact(int id)
        {
            var contact = _dbContext.Contacts.Find(id);

            if (contact == null)
                return Constants.NotFound;

            _dbContext.Contacts.Remove(contact);

            return Constants.Deleted;
        }
    }
}