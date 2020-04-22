﻿using ContactInfo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Unity;

namespace ContactInfo.DataAccessLayer.Repositories
{
    public interface IContactRepository : IDisposable
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContact(int id);

        void AddContact(Contact contact);

        void EditContact(Contact contact);
        int ActivateDeactivateContact(int id);

        int DeleteContact(int id);

        void Complete();
    }

    public class ContactRepository : IContactRepository
    {
        [Dependency]
        public ApplicationDbContext DbContext { get; set; }

        private bool _disposed = false;

        public IEnumerable<Contact> GetContacts()
        {
            return DbContext.Contacts.ToList();
        }

        public Contact GetContact(int id)
        {
            return DbContext.Contacts.Find(id);
        }

        public void AddContact(Contact contact)
        {
            DbContext.Contacts.Add(contact);
        }

        public void EditContact(Contact contact)
        {
            DbContext.Entry(contact).State = EntityState.Modified;
        }

        public int ActivateDeactivateContact(int id)
        {
            var contact = DbContext.Contacts.Find(id);

            if (contact == null)
                return Constants.NotFound;

            contact.Status = (contact.Status == Constants.Active) ? Constants.Inactive : Constants.Active;

            DbContext.Entry(contact).State = EntityState.Modified;

            return Constants.ContactStatusChanged;
        }

        public int DeleteContact(int id)
        {
            var contact = DbContext.Contacts.Find(id);

            if (contact == null)
                return Constants.NotFound;

            DbContext.Contacts.Remove(contact);

            return Constants.Deleted;
        }

        public void Complete()
        {
            DbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    DbContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}