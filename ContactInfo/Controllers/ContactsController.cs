using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactInfo.DataAccessLayer;
using ContactInfo.DataAccessLayer.Repositories;
using ContactInfo.Models;

namespace ContactInfo.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: Contacts
        public ViewResult Index()
        {
            var contacts = _contactRepository.GetContacts();
            return View(contacts);
        }

        public ActionResult Details(int id)
        {
            var contact = _contactRepository.GetContact(id);

            if (contact == null)
                return HttpNotFound();

            return View(contact);
        }
    }
}